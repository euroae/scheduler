﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataObjects;
using EmployeeObjects;
using ShiftObjects;
using scheduler.Utilities;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Priority_Queue;
using System.Globalization;

namespace SchedulingObjects
{
    [Serializable()]
    public class Schedule : ISerializable
    {


        public GroupOfSlots _skeleton;
        public Roster       _employees;
        private const int   TIMEOUT = 10;

        // information about this skeleton
        private string      _author;
        private string      _startDay;
        private string      _endDay;
        private string      _payDay;
        private int         _scheduleID;

        private int         _totalShiftsAvailable;
        private int         _totalShiftsFilled;

        public Conflicts    _conflicts;

        #region get/set

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string Start
        {
            get { return _startDay; }
            set { _startDay = value; }
        }

        public string End
        {
            get { return _endDay; }
            set { _endDay = value; }
        }

        public string PayDay
        {
            get { return _payDay; }
            set { _payDay = value; }
        }

        public int ScheduleID
        {
            get { return _scheduleID; }
            set { _scheduleID = value; }
        }

        public int ShiftsAvailable
        {
            get { return _totalShiftsAvailable; }
            set { _totalShiftsAvailable = value; }
        }

        public int ShiftsFilled
        {
            get { return _totalShiftsFilled; }
            set { _totalShiftsFilled = value; }
        }

        public TimeSpan TotalHours
        {
            get { return this._skeleton.TotalHoursAvailable(); }
        }

        public TimeSpan HoursFilled
        {
            get { return this._skeleton.TotalHoursAllocated(); }
        }

        #endregion

        #region contructors and loading functions

        /// <summary>
        /// default constructor
        /// </summary>
        public Schedule()
        {
            this.Load();
        }

        /// <summary>
        /// Constructor with arguements
        /// </summary>
        /// <param name="fileLocation">Location of skeleton shift file</param>
        public Schedule(string input)
        {
            this.Load();
            this.LoadSkeleton(input);
        }

        /// <summary>
        /// Constructor with arguements
        /// </summary>
        /// <param name="avail">Availabilities</param>
        /// <param name="skele">Skeleton</param>
        public Schedule(string avail, string skele)
        {
            this.Load();
            this.LoadSkeleton(skele);
            this.LoadEmployees(avail);
        }

        /// <summary>
        /// Use to initialize the datastructure and set values to initial values
        /// </summary>
        private void Load()
        {
            // initialize the datastructure
            this._skeleton = new GroupOfSlots();
            this._employees = new Roster();

            this._conflicts = new Conflicts();

            // default shifts available and filled
            this._totalShiftsAvailable = 0;
            this._totalShiftsFilled     = 0;
        }

        /// <summary>
        /// Loads employees and their availability.
        /// </summary>
        /// <param name="input">String containing all of the employee information.</param>
        /// <param name="whoCares">an extra parameter needed for overloading</param>
        public void LoadEmployees(string input, bool whoCares)
        {
            this.LoadEmployees(FileIO.ReadFromFile(input));
        }

        /// <summary>
        /// Loads employees and their availability.
        /// </summary>
        /// <param name="input">String containing all of the employee information.</param>
        public void LoadEmployees(string input)
        {
            this._employees.LoadEmployees(input);
            // match availabilities to shifts
            this.MatchShifts();
        }

        /// <summary>
        /// Overloaded. Use to load directly from file
        /// </summary>
        /// <param name="fileLocation">Location of file</param>
        /// <param name="whoCares">an extra parameter needed for overloading</param>
        public void LoadSkeleton(string fileLocation, bool whoCares)
        {
            this.LoadSkeleton(FileIO.ReadFromFile(fileLocation));
        }

        /// <summary>
        /// Overloaded. Used to actually load the data into memory.
        /// </summary>
        /// <param name="input">input data containing the schedule skeleton information.</param>
        public void LoadSkeleton(string input)
        {
            // Variables required to process input
            // a copy of the array of lists of days
            List<string> daysOfWeek = TimeUtilities.daysOfWeek;
            // holds semi-processed data
            List<string> splitRawData = new List<string>();

            // raw input            
            // remove all the extra whitespaces
            string rawData = input.Trim();

            // if there was an error loading the data or file is empty
            if (rawData == "")
            {
                return;
            }

            // temporary hold the raw data split by newline character
            string[] temp = rawData.Split('\n');


            // loop through split string and extract the useful information omitting not useful data
            for (int x = 0; x < temp.Length; x++)
            {
                // check if this commented out and skip this iteration if it is
                if (temp[x] == "" || temp[x][0] == '#' || temp[x] == System.Environment.NewLine || temp[x] == "\r") continue;

                splitRawData.Add(temp[x].Trim());
            }

            // extract the main useful data
            this._author        = splitRawData[1];
            this._startDay      = splitRawData[2];
            this._endDay        = splitRawData[3];
            this._scheduleID    = Int32.Parse(splitRawData[4]);
            this._payDay        = splitRawData[5];

            // now extract the remaining data

            // start at this position
            int rawDataLoop = 8;
            // loop once per day of the week
            for (int x = 0; x < daysOfWeek.Count; x++)
            {
                // while the current line isn't a closing day for this day of the week ie "</monday>"
                while (!splitRawData[rawDataLoop].Contains("/" + daysOfWeek[x]))
                {
                    // used to ignore opening tags i.e. "<monday>"
                    if (!splitRawData[rawDataLoop].Contains(daysOfWeek[x]))
                    {
                        // create a new shift slot object and populate with the approperiate data
                        ScheduleSlot newSlot = new ScheduleSlot();

                        // split line by ','
                        temp = splitRawData[rawDataLoop].Split(',');

                        // only process if there are 4 or more items post-split
                        if (!(temp.Length < 4))
                        {
                            // calculate time to submit
                            string start, end;
                            if (Int32.Parse(temp[1]) < 1000) { start = "0" + temp[1].Trim(); } else { start = temp[1].Trim(); }
                            if (Int32.Parse(temp[2]) < 1000) { end = "0" + temp[2].Trim(); } else { end = temp[2].Trim(); }

                            // calculate the date of this shift
                            DateTime date = new DateTime(int.Parse(_startDay.Split('-')[0]), int.Parse(_startDay.Split('-')[1]), int.Parse(_startDay.Split('-')[2]));
                            date = date.AddDays(x);

                            // populate shift info data
                            newSlot.LoadStruct(
                                temp[0].Trim(), daysOfWeek[x], start, end, date);
                            // old code
                            //newSlot._shiftInfo.Name = temp[0].Trim();
                            //newSlot._shiftInfo.Day = daysOfWeek[x];
                            
                            // number of people working
                            newSlot.EmployeeNeededCount = Int32.Parse(temp[3].Trim());

                            // add to list
                            this._skeleton.Add(newSlot);

                            // increment count of shifts
                            this._totalShiftsAvailable += newSlot.EmployeeNeededCount;
                        }
                    }
                    // increment loop value
                    rawDataLoop++;
                }
            }
        }

        #endregion

        #region Accessors_And_Information Contains all the functions use to access fields and get information

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";

            List<string> daysOfWeek = TimeUtilities.daysOfWeek;

            // main info
            output += "Schedule for " + this._startDay + " until " + this._endDay + ". Created by " + this._author + System.Environment.NewLine + "There are a total of " + this._totalShiftsAvailable + " for this schedule." + System.Environment.NewLine;
            output += "---------------------------------------------------" + System.Environment.NewLine;

            // per day
            this._skeleton.ToString();

            return output;
        }

        /// <summary>
        /// Creates a string containing information about all shifts and who is able to work each shift.
        /// </summary>
        /// <returns>String containing information about all shifts and who is able to work each shift.</returns>
        public string ToStringMatchedShifts()
        {
            string output = "";

            // for each day of the week
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                // Print todays
                output += Environment.NewLine;
                output += "=========================================";
                output += Environment.NewLine;
                output += TimeUtilities.daysOfWeek[x];
                output += Environment.NewLine;
                output += "=========================================";
                output += Environment.NewLine;

                // for each shift for this day
                foreach (ScheduleSlot slot in this._skeleton._shifts[TimeUtilities.daysOfWeek[x]])
                {

                    output += Environment.NewLine;
                    output += "For shift \"" + slot.Name + "\" From " + slot.Start + " until " + slot.End + ". The following employees can work this:";
                    output += Environment.NewLine;
                    //output += Environment.NewLine;

                    foreach (string name in slot.Unassigned)
                    {
                        output += name;
                        output += Environment.NewLine;
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// returns a count of how many shifts left to fill.
        /// </summary>
        /// <returns>count of shifts left to fill.</returns>
        public int RemaindingShiftsAvailable()
        {
            return this._totalShiftsAvailable - this._totalShiftsFilled;
        }

        #endregion

        #region scheduling related functions

        /// <summary>
        /// matches up employee availabilities to shifts
        /// </summary>
        public void MatchShifts()
        {
            // for each day of the week
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                // for each shift for this day
                foreach (ScheduleSlot slot in this._skeleton._shifts[TimeUtilities.daysOfWeek[x]])
                {
                    // Clear the assigned and unassigned lists to avoid duplications and people being left on schedules they are no longer able to work
                    slot.ClearLists();

                    // for each employee
                    foreach (Employee employee in this._employees._members.Values)
                    {
                        // if this employee can work this type of shift
                        if (employee.CanWork(slot._shiftInfo))
                        {
                            // add this username to list of those who are able to work
                            slot.AddToAbleToWork(employee.Username);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// matches up employee availabilities to shifts
        /// </summary>
        public void RefreshMatchedShifts()
        {
            // for each day of the week
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                // for each shift for this day
                foreach (ScheduleSlot slot in this._skeleton._shifts[TimeUtilities.daysOfWeek[x]])
                {
                    // clear the unassigned list
                    slot.Unassigned.Clear();

                    // for each employee
                    foreach (Employee employee in this._employees._members.Values)
                    {
                        // if this employee can work this type of shift
                        if (employee.CanWork(slot._shiftInfo))
                        {
                            // make sure they aren't already on this shifts lists
                            if (!slot.Assigned.Contains(employee.Username))
                            {
                                // add this username to list of those who are able to work
                                slot.AddToAbleToWork(employee.Username);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Attempts to assigns employee to this shift.
        /// </summary>
        /// <param name="shiftIndex">Index of shift in question.</param>
        /// <param name="username">username of employee in question</param>
        public bool AssignEmployee(int shiftIndex, string username)
        {
            // do nothing if username is null
            if (username == null)
                return false;

            // get the objects
            ScheduleSlot targetSlot = this._skeleton.AtIndex(shiftIndex);
            Employee targetEmployee = this._employees.ReturnEmployee(username);

            // call main assignment function
           return this.AssignEmployee(targetSlot, targetEmployee);
        }

        /// <summary>
        /// Attempts to assigns employee to this shift.
        /// Only allows assignment if employee is allowed to work said shift.
        /// </summary>
        /// <param name="shift">ScheduleSlot object of shift in question.</param>
        /// <param name="Employee">Employee object of employee.</param>
        public bool AssignEmployee(ScheduleSlot shift, Employee employee)
        {
            //　tries to assign shift
            if (employee.AssignShift(shift._shiftInfo))
            {
                // adding shift was successful on employee end, update schedule slot
                shift.AssignToThisShift(employee.Username);

                // increment filled count
                this._totalShiftsFilled++;

                // update conflict list
                ConflictChecker(shift._shiftInfo, employee, true);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Unassigns all employees from a targeted schedule slot.
        /// </summary>
        /// <param name="target">The schedule slot to clear out</param>
        public void UnassignAll(ScheduleSlot target)
        {
            // get a list of all the usernames of employees assigned to this shift
            List<string> targets = new List<string>(target.Assigned);

            // for each one
            foreach (string employee in targets)
            {
                // get the employee and unassign them
                this.UnassignEmployee(target, this._employees.ReturnEmployee(employee));
            }
        }

        /// <summary>
        /// Unassigns all employees from a targeted schedule slot.
        /// </summary>
        /// <param name="target">The schedule slot to clear out</param>
        public void UnassignAllShifts()
        {
            // go through all shifts and unassign everyone
            foreach (ScheduleSlot shift in this._skeleton.ToList())
            {
                this.UnassignAll(shift);
            }
        }

        /// <summary>
        /// Attempts to unassigns employee to this shift.
        /// </summary>
        /// <param name="shiftIndex">Index of shift in question.</param>
        /// <param name="username">username of employee in question</param>
        public void UnassignEmployee(int shiftIndex, string username)
        {
            // do nothing if username is null
            if (username == null)
                return;

            // get the objects
            ScheduleSlot targetSlot = this._skeleton.AtIndex(shiftIndex);
            Employee targetEmployee = this._employees.ReturnEmployee(username);

            // call main unassignment function
            this.UnassignEmployee(targetSlot, targetEmployee);
        }

        /// <summary>
        /// Attempts to unassigns employee to this shift.
        /// Only allows assignment if employee is allowed to work said shift.
        /// </summary>
        /// <param name="shift">ScheduleSlot object of shift in question.</param>
        /// <param name="Employee">Employee object of employee.</param>
        public void UnassignEmployee(ScheduleSlot shift, Employee employee)
        {
            //　tries to unassign shift
            if (employee.UnassignShift(shift._shiftInfo))
            {
                // unassigning shift was successful on employee end, update schedule slot
                shift.UnassignToThisShift(employee.Username);

                // decrement filled count
                this._totalShiftsFilled--;

                // update conflict list
                ConflictChecker(shift._shiftInfo, employee, false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTarget"></param>
        /// <param name="eTarget"></param>
        /// <param name="mode">Used to check whether we are adding or removing a shift. True = adding shift to employee, False means we are removing shift</param>
        public void ConflictChecker(Shift sTarget, Employee eTarget, bool mode)
        {
            if (mode)
            {
                // check for and get conflict
                List<Conflict> newOnes = eTarget.ReturnConflicts(sTarget);

                // if object is not null
                if (newOnes.Count > 0)
                {
                    this._conflicts.AddConflicts(eTarget.Username, newOnes);
                }

                // if it creates a double shift
                /*if (eTarget.CreatesDoubleShift(sTarget) || eTarget.ConsecutiveOpenClose(sTarget))
                {
                    // check if employee exists yet
                    this.ExistsInConflict(eTarget.Username);

                    // add new shift to them
                    this._conflicts[eTarget.Username].Add(sTarget);
                }*/
            }
            else
            {
                // remove it
                try
                {
                    this._conflicts.RemoveConflict(eTarget.Username, sTarget);
                    //this._conflicts[eTarget.Username].Remove(sTarget);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Checks if an employee is already on the conflict menu and if not, adds them.
        /// </summary>
        /// <param name="username"></param>
        /*private void ExistsInConflict(string username)
        {
            if (this._conflicts.Keys.Contains(username))
            {
                return;
            }
            else
            {
                // else create a new list and add it to conflicts
                List<Shift> newOne = new List<Shift>();

                this._conflicts.Add(username, newOne);

                return;
            }
        }*/

        #endregion

        #region mutators

        /// <summary>
        /// Reloads employees from input.
        /// </summary>
        /// <param name="input">Employee information. The availability file essentially.</param>
        public void ReloadEmployees(string input)
        {
            // sends input to reload function and gets a dictionary which contains the usernames of employees who had shifts removed and a list of shifts they've been removed from who had shifts removed
            Dictionary<string, List<Shift>> removes = this._employees.Reload(input);

            // go through and remove selected employees

            // foreach username
            foreach (string username in removes.Keys)
            {
                // foreach shift they were removed from
                foreach (Shift shift in removes[username])
                {
                    // get the shift in question
                    ScheduleSlot temp = this._skeleton.Return(shift.Day, shift.Name);

                    // remove them from this shift
                    temp.UnassignToThisShift(username);

                    // decrement count
                    this._totalShiftsFilled--;
                }
            }
        }

        #endregion

        #region scheduling problem

        /// <summary>
        /// Auto assigned employees to a supplied shift
        /// </summary>
        /// <param name="shift">shift to schedule</param>
        /// <param name="hourMod">Modifier for hours.</param>
        /// <param name="lowP">List of low priority shifts</param>
        /// <param name="mediumP">List of medium priority shifts</param>
        /// <param name="highP">List of hight priority shifts</param>
        /// <param name="lowPV">Modifier for low priority shifts</param>
        /// <param name="mediumPV">Modifier for medium priority shifts</param>
        /// <param name="highPV">Modifier for high priority shifts</param>
        /// <param name="availMod">Modifier for availability</param>
        /// <param name="preferMod">Modifier for preference</param>
        /// <param name="exceptions">Exceptions for max hours</param>
        public void AutoAssignShift(ScheduleSlot shift, double maxHours, double hourMod, string lowP, string mediumP, string highP, double lowPV, double mediumPV, double highPV, double availMod, double preferMod, Dictionary<string, double> exceptions)
        {
            // unassign everyone
            this.UnassignAll(shift);

            double newMax = maxHours;

            // create a priority queue
            HeapPriorityQueue<StringNode> workQueue = new HeapPriorityQueue<StringNode>(shift.Unassigned.Count + 2);

            // go through and enqueue everyone with their score
            foreach (string person in shift.Unassigned)
            {

                if (exceptions.Keys.Contains(person))
                {
                    newMax = exceptions[person];
                }
                else
                {
                    newMax = maxHours;
                }

                // get this employee
                Employee target = this._employees.ReturnEmployee(person);

                // check if this person can even work this shift or if it will create a double shift
                if (!target.CanWork(shift._shiftInfo) || 
                    (target.CreatesDoubleShift(shift._shiftInfo)))
                {
                    // skip to the next person!
                    continue;
                }

                // check if they will get too many hours
                {
                    TimeSpan total = target.Length + shift.Length;
                    if (total.TotalHours > newMax)
                    {
                        // skip them
                        continue;
                    }
                }

                // create node for p queue
                StringNode newOne = new StringNode(person);

                // calculate their score
                double score = 10000;

                // modify score based on availability and shifts remaining
                score += (double)this.CalculateAvailabilityScoreFor(target, shift.Day) * availMod;

                // assign score for hours
                score += (target.Length.TotalHours) * hourMod;

                // if this shift will give them a night/morning conflict
                if (target.ReturnConsecutiveOpenCloseShifts(shift._shiftInfo) != null)
                {
                    score += 20000;
                }

                // if this is a high priority shift - ignore flags
                if (highP.Contains(shift.Type))
                {
                    // do nothing
                }

                // medium priority shift - employees who have flag for high priority shifts will have their score reduced
                // people with low priorty  tags only will have their score increased
                else if (mediumP.Contains(shift.Type))
                {
                    if (target.ContainsTheseFlags(highP))
                    {
                        // decrese priority
                        score += highPV;
                    }
                    else if (target.ContainsTheseFlags(mediumP))
                    {
                        // nothing
                    }
                    else if (target.ContainsTheseFlags(lowP))
                    {
                        // increase priority
                        score -= highPV;
                    }
                }
                else if (lowP.Contains(shift.Type))
                {
                    if (target.ContainsTheseFlags(highP))
                    {
                        // decrese priority
                        score += highPV;
                    }
                    else if (target.ContainsTheseFlags(mediumP))
                    {
                        score += mediumPV;
                    }
                    else if (target.ContainsTheseFlags(lowP))
                    {
                        // do nothing
                    }
                }

                // calcualate a preference weight
                if (((target.preference & (int)Math.Pow(2, 0)) != 0) && shift._shiftInfo.When() == "mo")
                {
                    // decrese priority
                    score += preferMod;
                }
                else if (((target.preference & (int)Math.Pow(2, 1)) != 0) && shift._shiftInfo.When() == "no")
                {
                    // decrese priority
                    score += preferMod;
                }
                else if (((target.preference & (int)Math.Pow(2, 2)) != 0) && shift._shiftInfo.When() == "af")
                {
                    // decrese priority
                    score += preferMod;
                }
                else if (((target.preference & (int)Math.Pow(2, 3)) != 0) && shift._shiftInfo.When() == "ni")
                {
                    // decrese priority
                    score += preferMod;
                }

                // enqueue them
                workQueue.Enqueue(newOne, score);
            }

            // queue is empty, no one was added -> get out of here
            if (workQueue.Count == 0)
            {
                return;
            }

            // used to get a list of employees. 
            // This list will contain either the minimum number of employees required or all employees with the same priority value
            int loop = 0;
            double lastPriority = workQueue.First.Priority;
            List<string> choices = new List<string>();

            // gets either the minimum number of employees required or all employees with the same priority
            while ((workQueue.Count > 0) && (loop < shift.EmployeeNeededCount || lastPriority == workQueue.First.Priority))
            {
                if (workQueue.Count > 0 && loop < shift.EmployeeNeededCount)
                {
                    lastPriority = workQueue.First.Priority;
                }

                string assignThisOne = workQueue.Dequeue().Text;
                // dequeue person was null, skip them
                if (assignThisOne == null)
                {
                    continue;
                }

                // add to list
                choices.Add(assignThisOne);

                
                loop++;
            }

            // Summon RNGesus
            Random r = new Random();

            // loop once per employee required
            for (int x = 0; x < shift.EmployeeNeededCount; x++)
            {
                // not enough choices left, break the loop
                if (choices.Count <= 0)
                {
                    break;
                }

                // get a random number between 0 and the number of people in the choices list
                int index = r.Next(0, choices.Count);

                // assign them
                this.AssignEmployee(shift, this._employees.ReturnEmployee(choices[index]));

                // remove that person
                choices.Remove(choices[index]);
            }



            /* original code
            // actually assign people
            for (int x = 0; x < shift.EmployeeNeededCount; x++)
            {
                if (workQueue.Count <= 0)
                {
                    break;
                }
                string assignThisOne = workQueue.Dequeue().Text;
                if (assignThisOne == null)
                {
                    x--;
                    continue;
                }

                this.AssignEmployee(shift, this._employees.ReturnEmployee(assignThisOne));
            }
             * */
        }


        public double CalculateAvailabilityScoreFor(Employee target, string day)
        {
            // get from where we should start
            int startLoop = TimeUtilities.daysOfWeek.IndexOf(day) + 1;
            double output = 0;

            // go through each remaining days of the week
            for (int x = startLoop; x < TimeUtilities.DAYS_IN_WEEK; x++)
            {
                foreach (ScheduleSlot shiftSlot in this._skeleton._shifts[TimeUtilities.daysOfWeek[x]])
                {
                    if (target.CanWork(shiftSlot.ReturnShift()))
                    {
                        output += 1.0 * (Math.Pow(2, (double)x));
                    }
                }
            }


            return output;
        }

        #endregion

        #region serialization functions

        /// <summary>
        /// Load previously save data
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public Schedule(SerializationInfo info, StreamingContext ctxt)
        {
            this._skeleton      = (GroupOfSlots)info.GetValue("skeleton", typeof(GroupOfSlots));
            this._employees     = (Roster)      info.GetValue("employees", typeof(Roster));
            this._author        = (string)      info.GetValue("author", typeof(string));
            this._startDay      = (string)      info.GetValue("startDay", typeof(string));
            this._endDay        = (string)      info.GetValue("endDay", typeof(string));
            this._payDay        = (string)      info.GetValue("payDay", typeof(string));
            this._scheduleID    = (int)         info.GetValue("scheduleID", typeof(int));

            this._totalShiftsAvailable  = (int)info.GetValue("totalShiftsAvailable", typeof(int));
            this._totalShiftsFilled     = (int)info.GetValue("totlaShiftsFilled", typeof(int));

            this._conflicts             = (Conflicts)info.GetValue("conflicts", typeof(Conflicts));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("skeleton", this._skeleton);
            info.AddValue("employees", this._employees);
            info.AddValue("author", this._author);
            info.AddValue("startDay", this._startDay);
            info.AddValue("endDay", this._endDay);
            info.AddValue("payDay", this._payDay);
            info.AddValue("scheduleID", this._scheduleID);
            info.AddValue("totalShiftsAvailable", this._totalShiftsAvailable);
            info.AddValue("totlaShiftsFilled", this._totalShiftsFilled);
            info.AddValue("conflicts", this._conflicts);
        }

        #endregion

        #region finalization

        /// <summary>
        /// Uploads the schedule to the database
        /// </summary>
        /// <param name="db_conn">database connection object</param>
        /// <param name="pbBar">progress bar</param>
        public void SubmitSchedule(DBConnect db_conn, System.Windows.Forms.ToolStripProgressBar pbBar)
        {
            // upload database info
            string query = "INSERT INTO route (schedule_ID, payment_due, is_paid, posted_by, posted_on, starting_date, ending_date)" +
                " VALUES ('"
                + this.ScheduleID + "', '"
                + this.PayDay + "', '0', '"
                + this.Author + "', '"
                + DateTime.Today.ToString("yyyy-MM-dd") + "', '"
                + this.Start + "', '"
                + this._endDay + "');";

            // used to count if timed out
            int timeout = 0;
            // keeps trying until command either runs successfully or connection times out
            while (!db_conn.RunCommand(query))
            {
                timeout++;
                if (timeout > TIMEOUT)
                {
                    System.Windows.Forms.MessageBox.Show("Connecting to database timed out while trying to run the following mysql statement: " + query);
                    return;
                }
            }

            pbBar.Maximum = 1 + this._employees.ToList().Count + this._skeleton.ToList().Count;

            pbBar.PerformStep();

            // second part
            bool result = this.UploadEmployeeTables(db_conn, pbBar);

            // final part
            result = result && this.UploadMainTable(db_conn, pbBar);

            if (result)
            {
                System.Threading.Thread.Sleep(600);
                System.Windows.Forms.MessageBox.Show("Uploaded Schedule successfully.");
            }

            return;
        }

        /// <summary>
        /// uploads shift data to each employee's table
        /// </summary>
        /// <param name="db_conn">database connection object</param>
        /// <param name="pbBar">progress bar</param>
        /// <returns>true if successful, false otherwise</returns>
        private bool UploadEmployeeTables(DBConnect db_conn, System.Windows.Forms.ToolStripProgressBar pbBar)
        {
            // format for time display
            string format = "HH:mm:ss";

            // go through each employee
            foreach (Employee employee in this._employees.ToList())
            {
                // go through each shift this person is working
                foreach (Shift shift in employee._shiftsWorking.ToList())
                {
                    // upload this info
                    string query = "INSERT INTO " + employee.Username + " (date, schedule_ID, shift_ID, type, start, end, length, is_paid) "
                        + "VALUES ("
                        + "'" + shift.Date.ToString("yyyy-MM-dd") + "', "
                        + "'" + this.ScheduleID     + "', "
                        + "'" + shift.ShiftNumber   + "', "
                        + "'" + shift.Name.ToUpper() + "', "
                        + "'" + shift.StartTime.ToString(format)    + "', "
                        + "'" + shift.EndTime.ToString(format)      + "', "
                        + "'" + shift.Length.TotalHours             + "', "
                        + "'0');";

                    int timeout = 0;
                    // keeps trying until command either runs successfully or connection times out
                    while (!db_conn.RunCommand(query))
                    {
                        timeout++;
                        if (timeout > TIMEOUT)
                        {
                            System.Windows.Forms.MessageBox.Show("Connecting to database timed out while trying to run the following mysql statement: " + query); ;
                            return false;
                        }
                    }
                }

                // update progress bar
                pbBar.PerformStep();
            }

            return true;
        }

        /// <summary>
        /// Uploads the main schedule table to the database
        /// </summary>
        /// <param name="db_conn">database connection object</param>
        /// <param name="pbBar">progress bar</param>
        /// <returns>true if successful, false otherwise</returns>
        private bool UploadMainTable(DBConnect db_conn, System.Windows.Forms.ToolStripProgressBar pbBar)
        {
            string format = "HH:mm:ss";

            // create the main table first
            string query = "CREATE TABLE `s" + this.ScheduleID + "` ("
	                    + "`index` SMALLINT(5) UNSIGNED NOT NULL DEFAULT '0', "
	                    + "`date` DATE NOT NULL DEFAULT '0000-00-00', "
	                    + "`day` ENUM('Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday') NOT NULL DEFAULT 'Monday', "
	                    + "`when` ENUM('mo','no','af','ni') NOT NULL DEFAULT 'mo', "
	                    + "`type` VARCHAR(15) NOT NULL DEFAULT '', "
	                    + "`start` TIME NOT NULL DEFAULT '00:00:00', "
	                    + "`end` TIME NOT NULL DEFAULT '00:00:00', "
	                    + "`length` FLOAT UNSIGNED NOT NULL DEFAULT '0', "
	                    + "`staffs` VARCHAR(255) NOT NULL DEFAULT '', "
	                    + "`wage` FLOAT UNSIGNED NOT NULL DEFAULT '0', "
	                    + "PRIMARY KEY (`index`)) "
                        + "COLLATE='latin1_swedish_ci' "
                        + "ENGINE=MyISAM"
                        + ";";
            // create it
            // used to count if timed out
            int timeout = 0;
            // keeps trying until command either runs successfully or connection times out
            while (!db_conn.RunCommand(query))
            {
                timeout++;
                if (timeout > TIMEOUT)
                {
                    System.Windows.Forms.MessageBox.Show("Connecting to database timed out while trying to run the following mysql statement: " + query); ;
                    return false;
                }
            }

            // for each shift in this schedule
            foreach (ScheduleSlot slot in this._skeleton.ToList())
            {
                // generate insert query
                query = "INSERT INTO `s" + this.ScheduleID + "` (`index`, date, day, `when`, `type`, `start`, `end`, length, staffs, wage)  "
                        + "VALUES ("
                        + "'" + slot._shiftInfo.ShiftNumber         + "', "
                        + "'" + slot.Date.ToString("yyyy-MM-dd")    + "', "
                        + "'" + new CultureInfo("en-US").TextInfo.ToTitleCase(slot.Day) + "', "
                        + "'" + slot._shiftInfo.When()                + "', "
                        + "'" + slot.Name.ToUpper() + "', "
                        + "'" + slot._shiftInfo.StartTime.ToString(format) + "', "
                        + "'" + slot._shiftInfo.EndTime.ToString(format) + "', "
                        + "'" + slot.Length.TotalHours              + "', "
                        + "'" + this.PeopleWorkingThis(slot) + "', "
                        + "'0');";

                // update progress bar
                pbBar.PerformStep();

                timeout = 0;
                // keeps trying until command either runs successfully or connection times out
                while (!db_conn.RunCommand(query))
                {
                    timeout++;
                    if (timeout > TIMEOUT)
                    {
                        System.Windows.Forms.MessageBox.Show("Connecting to database timed out while trying to run the following mysql statement: " + query); ;
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// outputs a string of the names of everyone working this shift order by alphabetical order.
        /// </summary>
        /// <param name="shift">Shift to process</param>
        /// <returns>string of names of people working this shift</returns>
        public string PeopleWorkingThis(ScheduleSlot shift)
        {
            string output = "";
            // get a list of all assigned employees ordered in alpha order
            List<string> assigned = shift.Assigned.OrderBy(q => q).ToList();
            //foreach person
            foreach (string person in shift.Assigned)
            {
                // append name to output
                output += this._employees.ReturnEmployee(person).Nickname + " ";
            }

            int availableSlots = shift.EmployeeNeededCount - shift.EmployeeWorkingCount;
            // add **AV** for each empty slot
            for (int x = 0; x < availableSlots; x++)
            {
                output += "**AV** ";
            }

            return output;
        }

        /// <summary>
        /// Uploads the schedule to the database
        /// </summary>
        /// <param name="db_conn">database connection object</param>
        /// <param name="pbBar">progress bar</param>
        public void SubmitScheduleNewSite(DBConnect db_conn, System.Windows.Forms.ToolStripProgressBar pbBar)
        {
            // upload database info
            string query = "INSERT INTO schedule_master_list (sched_id, payment_due, is_paid, posted_by, posted_on, starting_date, ending_date)" +
                " VALUES ('"
                + this.ScheduleID + "', '"
                + this.PayDay + "', '0', '"
                + this.Author + "', '"
                + DateTime.Today.ToString("yyyy-MM-dd") + "', '"
                + this.Start + "', '"
                + this._endDay + "');";

            // used to count if timed out
            int timeout = 0;
            // keeps trying until command either runs successfully or connection times out
            while (!db_conn.RunCommand(query))
            {
                timeout++;
                if (timeout > TIMEOUT)
                {
                    System.Windows.Forms.MessageBox.Show("Connecting to database timed out while trying to run the following mysql statement: " + query);
                    return;
                }
            }

            pbBar.Maximum = 1 + this._employees.ToList().Count + this._skeleton.ToList().Count;

            pbBar.PerformStep();

            // final part
            bool result = this.UploadShiftsNewSite(db_conn, pbBar);
            result = result && this.UploadAssignmentsNewSite(db_conn, pbBar);

            if (result)
            {
                System.Threading.Thread.Sleep(600);
                System.Windows.Forms.MessageBox.Show("Uploaded Schedule successfully.");
            }

            return;
        }

        /// <summary>
        /// Uploads the main schedule table to the database
        /// </summary>
        /// <param name="db_conn">database connection object</param>
        /// <param name="pbBar">progress bar</param>
        /// <returns>true if successful, false otherwise</returns>
        private bool UploadShiftsNewSite(DBConnect db_conn, System.Windows.Forms.ToolStripProgressBar pbBar)
        {
            string format = "HH:mm:ss";
            int timeout;
            string query;

            // for each shift in this schedule
            foreach (ScheduleSlot slot in this._skeleton.ToList())
            {
                // generate insert query
                query = "INSERT INTO `shifts_list` (`shift_id`, sched_id, `date`, `day`, `when`, `type`, `start`, `end`, length)  "
                        + "VALUES ("
                        + "'" + slot._shiftInfo.ShiftNumber + "', "
                        + "'" + this.ScheduleID + "', "
                        + "'" + slot.Date.ToString("yyyy-MM-dd") + "', "
                        + "'" + new CultureInfo("en-US").TextInfo.ToTitleCase(slot.Day) + "', "
                        + "'" + slot._shiftInfo.When() + "', "
                        + "'" + slot.Name.ToUpper() + "', "
                        + "'" + slot._shiftInfo.StartTime.ToString(format) + "', "
                        + "'" + slot._shiftInfo.EndTime.ToString(format) + "', "
                        + "'" + slot.Length.TotalHours + "');";

                // update progress bar
                pbBar.PerformStep();

                timeout = 0;
                // keeps trying until command either runs successfully or connection times out
                while (!db_conn.RunCommand(query))
                {
                    timeout++;
                    if (timeout > TIMEOUT)
                    {
                        System.Windows.Forms.MessageBox.Show("Connecting to database timed out while trying to run the following mysql statement: " + query); ;
                        return false;
                    }
                }
            }

            return true;
        }

        private bool UploadAssignmentsNewSite(DBConnect db_conn, System.Windows.Forms.ToolStripProgressBar pbBar)
        {
            int timeout;
            string query;

            // for each shift in this schedule
            foreach (ScheduleSlot slot in this._skeleton.ToList())
            {

                foreach (string employee in slot.Assigned)
                {
                    // generate insert query
                    query = "INSERT INTO `shift_assignments` (`shift_id`, sched_id, username)  "
                            + "VALUES ("
                            + "'" + slot._shiftInfo.ShiftNumber + "', "
                            + "'" + this.ScheduleID + "', "
                            + "'" + employee + "');";

                    // update progress bar
                    pbBar.PerformStep();

                    timeout = 0;
                    // keeps trying until command either runs successfully or connection times out
                    while (!db_conn.RunCommand(query))
                    {
                        timeout++;
                        if (timeout > TIMEOUT)
                        {
                            System.Windows.Forms.MessageBox.Show("Connecting to database timed out while trying to run the following mysql statement: " + query); ;
                            return false;
                        }
                    }
                }

                if (slot.EmployeeWorkingCount < slot.EmployeeNeededCount)
                {
                    for (int x = 0; x < slot.EmployeeNeededCount - slot.EmployeeWorkingCount; x++)
                    {
                        query = "INSERT INTO `shift_assignments` (`shift_id`, sched_id, username, details)  "
                            + "VALUES ("
                            + "'" + slot._shiftInfo.ShiftNumber + "', "
                            + "'" + this.ScheduleID + "', "
                            + "'**AV**', "
                            + "'" + "Available" + x.ToString() + "');";

                        // update progress bar
                        pbBar.PerformStep();

                        timeout = 0;
                        // keeps trying until command either runs successfully or connection times out
                        while (!db_conn.RunCommand(query))
                        {
                            timeout++;
                            if (timeout > TIMEOUT)
                            {
                                System.Windows.Forms.MessageBox.Show("Connecting to database timed out while trying to run the following mysql statement: " + query); ;
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
        #endregion
    }
}
