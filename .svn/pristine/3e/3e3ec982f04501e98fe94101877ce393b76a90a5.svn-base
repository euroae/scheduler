using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftObjects;
using DataObjects;
using scheduler.Utilities;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmployeeObjects
{
    /// <summary>
    /// Class containing information about an employee and functions required to work on that data.
    /// </summary>
    [Serializable()]
    public class Employee : ISerializable
    {
        // public fields
        private string              _username;      // employee username
        private string              _name;          // employee name
        private TimeSpan            _assignedHours; // how many hours this person is already working
        private string              _canWork;       // string contain the jobs this person can work
        private int                 _preference;    // shift preference            
        public GroupOfShifts        _availabilities;// employees availability - Format is <string, list<Shift>> - first one is day of week, second one is list of shifts
        public GroupOfShifts        _shiftsWorking; // shift this person is actually working - Format is <string, list<Shift>> - first one is day of week, second one is list of shifts

        #region serialization functions

        public Employee(SerializationInfo info, StreamingContext ctxt)
        {
            this._username = (string)info.GetValue("username", typeof(string));
            this._name = (string)info.GetValue("name", typeof(string));
            this._canWork = (string)info.GetValue("canWork", typeof(string));

            this._assignedHours = (TimeSpan)info.GetValue("assignedHours", typeof(TimeSpan));

            this._availabilities = (GroupOfShifts)info.GetValue("availabilities", typeof(GroupOfShifts));
            this._shiftsWorking = (GroupOfShifts)info.GetValue("shiftsWorking", typeof(GroupOfShifts));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("username", this._username);
            info.AddValue("name", this._name);
            info.AddValue("canWork", this._canWork);

            info.AddValue("assignedHours", this._assignedHours);

            info.AddValue("availabilities", this._availabilities);
            info.AddValue("shiftsWorking", this._shiftsWorking);
        }

        #endregion

        #region get/set

        /// <summary>
        /// Get set for count.
        /// </summary>
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// Get set for count.
        /// </summary>
        public string Nickname
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Get set for count.
        /// </summary>
        public TimeSpan Length
        {
            get { return _assignedHours; }
            set { _assignedHours = value; }
        }

        /// <summary>
        /// Get set for count.
        /// </summary>
        public string ValidShifts
        {
            get { return _canWork; }
            set { _canWork = value; }
        }

        /// <summary>
        /// Get set for preference.
        /// </summary>
        public int preference
        {
            get { return _preference; }
            set { _preference = value; }
        }

        /// <summary>
        /// Get set for count.
        /// </summary>
        public GroupOfShifts Working
        {
            get { return _shiftsWorking; }
            set { _shiftsWorking = value; }
        }

        /// <summary>
        /// Get set for count.
        /// </summary>
        public GroupOfShifts Availabilities
        {
            get { return _availabilities; }
            set { _availabilities = value; }
        }

        #endregion

        #region constructors functions used to construct class and add data

        /// <summary>
        /// Default Constructor. Starts everything off with empty.
        /// </summary>
        public Employee()
        {
            this.Load("", "", "", 0);
        }

        /// <summary>
        /// Constructor with provided data.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="name"></param>
        /// <param name="availabilities"></param>
        /// <param name="validShifts"></param>
        public Employee(string username, string name, string[] availabilities, string canWork, int preference)
        {
            this.Load(username, name, canWork, preference);
            this.LoadAvailability(availabilities);
        }

        /// <summary>
        /// Common function to load main fields.
        /// </summary>
        /// <param name="username">username of Employee</param>
        /// <param name="name">Name of employee</param>
        /// <param name="canWork">Shift this person can work.</param>
        private void Load(string username, string name, string canWork, int preference)
        {
            // initialize the datastructures
            this.InitializeDS();

            // assign values
            this._username = username;
            this._name = name;
            this._canWork = canWork.ToLower();

            // assign defaults
            this._assignedHours = new TimeSpan(0);

            this._preference = preference;
        }

        /// <summary>
        /// Initializes datastructures to empty.
        /// </summary>
        private void InitializeDS()
        {
            // initialize the DS
            _availabilities = new GroupOfShifts();
            _shiftsWorking  = new GroupOfShifts();
        }

        /// <summary>
        /// Loads availability for this employee.
        /// </summary>
        /// <param name="raw">
        /// raw input of availability. Format is array of strings, each element in array represents a day.
        /// Each day's availability is formatted as a string, time is in military time, no ':' and each block of availability is seperate by a space.
        /// no spaces between a time and the '-'.
        /// Example: "0800-1400 1630-2200"
        /// </param>
        private void LoadAvailability(string[] raw)
        {
            // for each day of the week
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                // get the availability for this day
                string temp = raw[x];

                // split it into each of it's blocks
                string[] preProcess = temp.Split(' ');

                // for each block of time
                foreach (string element in preProcess)
                {
                    // add to availability slot if not empty
                    if (element != "")
                    {
                        AddAvailabilitySlot(TimeUtilities.daysOfWeek[x], element);
                    }
                }
            }
        }

        #endregion

        #region Accessor Function that return information without modifying internal data

        public Conflict ConflictCheck(Shift newShift)
        {
            // output
            Conflict output = new Conflict();

            // Check for and get double shift
            Shift conflicter = this.ReturnDoubleShift(newShift);

            // if there is a double shift
            if (conflicter != null)
            {
                // create output
                output._conflict1 = newShift;
                output._conflict2 = conflicter;
                output._conflictType = "Double Shift";

                // return it
                return output;
            }
            // check if they have an evening shift followed by night shift
            else
            {
                conflicter = ReturnConsecutiveOpenCloseShift(newShift);

                if (conflicter != null)
                {
                    // create output
                    output._conflict1 = newShift;
                    output._conflict2 = conflicter;
                    output._conflictType = "Close/Open Shift";

                    // return it
                    return output;
                }
            }

            // otherwise, return null
            return null;
        }

        public List<Conflict> ReturnConflicts(Shift newShift)
        {
            // output
            List<Conflict> output = new List<Conflict>();

            // Check for and get double shift
            List<Shift> conflicters = this.ReturnDoubleShifts(newShift);

            // add them to output if they exist
            foreach (Shift element in conflicters)
            {
                Conflict temp = new Conflict();
                // create output
                temp._conflict1 = newShift;
                temp._conflict2 = element;
                temp._conflictType = "Double Shift";

                output.Add(temp);
            }

            Shift temp2 = ReturnConsecutiveOpenCloseShift(newShift);

            if (temp2 != null)
            {
                Conflict temp = new Conflict();
                // create output
                temp._conflict1 = newShift;
                temp._conflict2 = temp2;
                temp._conflictType = "Close/Open Shift";

                // append to output
                output.Add(temp);
            }

            // otherwise, return null
            return output;
        }

        /// <summary>
        /// Check if this shift creates a double shift for this employee.
        /// </summary>
        /// <param name="newShift">shift to check</param>
        /// <returns>true if it is doubled</returns>
        public bool CreatesDoubleShift(Shift newShift)
        {
            // for each shift in this day
            foreach (Shift shift in this._shiftsWorking._shifts[newShift.Day])
            {
                // if ends touch
                if ((shift.End == newShift.Start) || (shift.Start == newShift.End))
                {
                    // return true
                    return true;
                }
            }

            // returns false otherwise
            return false;
        }

        /// <summary>
        /// Check if this shift creates a double shift for this employee.
        /// </summary>
        /// <param name="newShift">shift to check</param>
        /// <returns>The double shift if it exists</returns>
        public Shift ReturnDoubleShift(Shift newShift)
        {
            // for each shift in this day
            foreach (Shift shift in this._shiftsWorking._shifts[newShift.Day])
            {
                // if ends touch
                if ((shift.End == newShift.Start) || (shift.Start == newShift.End))
                {
                    // return true
                    return shift;
                }
            }

            return null;
        }

        /// <summary>
        /// Check if this shift creates a double shift for this employee.
        /// </summary>
        /// <param name="newShift">shift to check</param>
        /// <returns>A list of all double shifts if they exists</returns>
        public List<Shift> ReturnDoubleShifts(Shift newShift)
        {
            List<Shift> output = new List<Shift>();

            // for each shift in this day
            foreach (Shift shift in this._shiftsWorking._shifts[newShift.Day])
            {
                // if ends touch
                if ((shift.End == newShift.Start) || (shift.Start == newShift.End))
                {
                    // append to output
                    output.Add(shift);
                }
            }

            return output;
        }

        /// <summary>
        /// Check if this new shift occurs the next morning after a night shift or night before a morning shift
        /// </summary>
        /// <param name="newShift">The new shift</param>
        /// <returns>true if it is consecutive overnight, false otherwise</returns>
        public bool ConsecutiveOpenClose(Shift newShift)
        {
            bool checkYesterday = false;

            // check if this is even a morning or night shift
            if (!(newShift.StartTime <= TimeUtilities.ConvertToDateTime("0900") || newShift.EndTime >= TimeUtilities.ConvertToDateTime("2100")))
            {
                // not an opening or closing shift - return false
                return false;
            }

            // holds the target start and ened times
            DateTime targetStart = newShift.StartTime;
            DateTime targetEnd = newShift.EndTime;

            // get the index of this shifts day
            int index = TimeUtilities.daysOfWeek.IndexOf(newShift.Day);
            int target = 0;
            // get the target index of the day we wish to check
            if (newShift.StartTime <= TimeUtilities.ConvertToDateTime("0900"))
            {   // this shift is an opening shift
                // we will need to check previous day
                checkYesterday = true;

                // increment target times by 1 day
                targetStart = targetStart.AddDays(1);
                targetEnd = targetEnd.AddDays(1);


                // check if current index is monday
                if (index == 0)
                {
                    // set target to sunday
                    target = TimeUtilities.daysOfWeek.Count - 1;
                }
                else
                {
                    // otherwise subtract 1
                    target = index - 1;
                }
            }
            else if (newShift.EndTime >= TimeUtilities.ConvertToDateTime("2100"))
            {// this shift is an opening shift
                // we will check next day's shift
                checkYesterday = false;

                // increment target times by 1 day
                targetStart.AddDays(-1);
                targetEnd.AddDays(-1);


                // check if current index is sunday
                if (index == TimeUtilities.daysOfWeek.Count - 1)
                {
                    // set target to monday
                    target = 0;
                }
                else
                {
                    // otherwise add 1
                    target = index + 1;
                }
            }
            else
            {
                throw new Exception("WTF?! How'd you get here?!?");
            }

            // do the actual checking
            foreach (Shift shift in this._shiftsWorking._shifts[TimeUtilities.daysOfWeek[target]])
            {
                // if we're checking yesterday
                if (checkYesterday)
                {
                    TimeSpan difference = (targetStart - shift.EndTime);
                    // get time difference and see if it is at least or less than expected amount
                    if (difference <= new TimeSpan(11, 30, 0))
                    {
                        // these are consecutive shifts, return true
                        return true;
                    }
                }
                else
                {   // we are checking tomorrow
                    // get time difference and see if it is at least or less than expected amount
                    if ( (targetEnd - shift.StartTime) <= new TimeSpan(11, 30, 0))
                    {
                        // these are consecutive shifts, return true
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check if this new shift occurs the next morning after a night shift or night before a morning shift
        /// </summary>
        /// <param name="newShift">The new shift</param>
        /// <returns>true if it is consecutive overnight, false otherwise</returns>
        public Shift ReturnConsecutiveOpenCloseShift(Shift newShift)
        {
            bool checkYesterday = false;

            // check if this is even a morning or night shift
            if (!(newShift.StartTime <= TimeUtilities.ConvertToDateTime("0900") || newShift.EndTime >= TimeUtilities.ConvertToDateTime("2100")))
            {
                // not an opening or closing shift - return false
                return null;
            }

            // holds the target start and ened times
            DateTime targetStart = newShift.StartTime;
            DateTime targetEnd = newShift.EndTime;

            // get the index of this shifts day
            int index = TimeUtilities.daysOfWeek.IndexOf(newShift.Day);
            int target = 0;
            // get the target index of the day we wish to check
            if (newShift.StartTime <= TimeUtilities.ConvertToDateTime("0900"))
            {   // this shift is an opening shift
                // we will need to check previous day
                checkYesterday = true;

                // increment target times by 1 day
                targetStart = targetStart.AddDays(1);
                targetEnd = targetEnd.AddDays(1);


                // check if current index is monday
                if (index == 0)
                {
                    // set target to sunday
                    target = TimeUtilities.daysOfWeek.Count - 1;
                }
                else
                {
                    // otherwise subtract 1
                    target = index - 1;
                }
            }
            else if (newShift.EndTime >= TimeUtilities.ConvertToDateTime("2100"))
            {// this shift is an opening shift
                // we will check next day's shift
                checkYesterday = false;

                // increment target times by 1 day
                targetStart = targetStart.AddDays(-1);
                targetEnd = targetEnd.AddDays(-1);


                // check if current index is sunday
                if (index == TimeUtilities.daysOfWeek.Count - 1)
                {
                    // set target to monday
                    target = 0;
                }
                else
                {
                    // otherwise add 1
                    target = index + 1;
                }
            }
            else
            {
                // should be impossible to reach this point due to first if statement at top of method
                throw new Exception("WTF?! How'd you get here?!?");
            }

            // do the actual checking
            foreach (Shift shift in this._shiftsWorking._shifts[TimeUtilities.daysOfWeek[target]])
            {
                // if we're checking yesterday
                if (checkYesterday)
                {
                    TimeSpan difference = (targetStart - shift.EndTime);
                    // get time difference and see if it is at least or less than expected amount
                    if (difference <= new TimeSpan(11, 30, 0))
                    {
                        // these are consecutive shifts, return true
                        return shift;
                    }
                }
                else
                {   // we are checking tomorrow
                    // get time difference and see if it is at least or less than expected amount
                    TimeSpan difference = (shift.StartTime - targetEnd);
                    if (difference <= new TimeSpan(11, 30, 0))
                    {
                        // these are consecutive shifts, return true
                        return shift;
                    }
                }
            }

            // never found a conflicting shift
            return null;
        }

        /// <summary>
        /// Check if this new shift occurs the next morning after a night shift or night before a morning shift
        /// </summary>
        /// <param name="newShift">The new shift</param>
        /// <returns>true if it is consecutive overnight, false otherwise</returns>
        public Shift ReturnConsecutiveOpenCloseShifts(Shift newShift)
        {
            bool checkYesterday = false;

            // check if this is even a morning or night shift
            if (!(newShift.StartTime <= TimeUtilities.ConvertToDateTime("0900") || newShift.EndTime >= TimeUtilities.ConvertToDateTime("2100")))
            {
                // not an opening or closing shift - return false
                return null;
            }

            // holds the target start and ened times
            DateTime targetStart = newShift.StartTime;
            DateTime targetEnd = newShift.EndTime;

            // get the index of this shifts day
            int index = TimeUtilities.daysOfWeek.IndexOf(newShift.Day);
            int target = 0;
            // get the target index of the day we wish to check
            if (newShift.StartTime <= TimeUtilities.ConvertToDateTime("0900"))
            {   // this shift is an opening shift
                // we will need to check previous day
                checkYesterday = true;

                // increment target times by 1 day
                targetStart = targetStart.AddDays(1);
                targetEnd = targetEnd.AddDays(1);


                // check if current index is monday
                if (index == 0)
                {
                    // set target to sunday
                    target = TimeUtilities.daysOfWeek.Count - 1;
                }
                else
                {
                    // otherwise subtract 1
                    target = index - 1;
                }
            }
            else if (newShift.EndTime >= TimeUtilities.ConvertToDateTime("2100"))
            {// this shift is an opening shift
                // we will check next day's shift
                checkYesterday = false;

                // increment target times by 1 day
                targetStart.AddDays(-1);
                targetEnd.AddDays(-1);


                // check if current index is sunday
                if (index == TimeUtilities.daysOfWeek.Count - 1)
                {
                    // set target to monday
                    target = 0;
                }
                else
                {
                    // otherwise add 1
                    target = index + 1;
                }
            }
            else
            {
                // should be impossible to reach this point due to first if statement at top of method
                throw new Exception("WTF?! How'd you get here?!?");
            }

            // do the actual checking
            foreach (Shift shift in this._shiftsWorking._shifts[TimeUtilities.daysOfWeek[target]])
            {
                // if we're checking yesterday
                if (checkYesterday)
                {
                    TimeSpan difference = (targetStart - shift.EndTime);
                    // get time difference and see if it is at least or less than expected amount
                    if (difference <= new TimeSpan(11, 30, 0))
                    {
                        // these are consecutive shifts, return true
                        return shift;
                    }
                }
                else
                {   // we are checking tomorrow
                    // get time difference and see if it is at least or less than expected amount
                    if ((targetEnd - shift.StartTime) <= new TimeSpan(11, 30, 0))
                    {
                        // these are consecutive shifts, return true
                        return shift;
                    }
                }
            }

            // never found a conflicting shift
            return null;
        }

        /// <summary>
        /// Returns true or false depending on whether this employee can work this shift.
        /// </summary>
        /// <param name="newShift">The new shift to check.</param>
        /// <returns>true if this employee is flagged as able to work this shift, has availability during this time and is not already assigned during this time. False otherwise.</returns>
        public bool CanWork(Shift newShift)
        {
            // output
            bool case2 = false;

            // Case1 - needs to check if they have premissions to work this shift
            if (!this._canWork.Contains(newShift.Type))
            {
                // cant work this type of shift
                return false;
            }
            
            // Case2 - next check if they are availability for that time frame
            foreach (Shift avail in this._availabilities.ReturnShiftsForDay(newShift.Day))
            {
                // if start time is available
                if ((int.Parse(newShift.Start) >= int.Parse(avail.Start))
                   &&
                   // end time is available
                   (int.Parse(newShift.End) <= int.Parse(avail.End)))
                {
                    // set case2 to true and break out of the foreach loop - dont waste time checking the rest
                    case2 = true;
                    break;
                }
            }

            // case3 - check if they are already working during that time
            foreach (Shift working in this._shiftsWorking.ReturnShiftsForDay(newShift.Day))
            {
                // if start time is available
                if ((int.Parse(newShift.Start) < int.Parse(working.End))
                   &&
                    // end time is available
                   (int.Parse(newShift.End) > int.Parse(working.Start)))
                {
                    // return false - employee is already working during this time frame
                    return false;
                }
            }

            // returns results - returns true only if all cases return true
            return case2;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";

            // main part of the output
            if (this.Nickname.Length > 8)
            {
                output = this.Nickname.Substring(0, 8) + System.Environment.NewLine;
            }
            else
            {
                output = this.Nickname + System.Environment.NewLine;
            }

            // append up to 8 white spaces for formatting purposes in GUI
            int loopTimes = (8 - this._assignedHours.TotalHours.ToString().Length);
            output += this._assignedHours.TotalHours.ToString();

            for (int x = 0; x < loopTimes; x++)
            {
                output += " ";
            }

            return output;
        }

        #endregion

        #region mutators Functions that change the internal data that doesn't fall under one of the other regions

        /// <summary>
        /// Loads availability for this employee.
        /// </summary>
        /// <param name="raw">
        /// raw input of availability. Format is array of strings, each element in array represents a day.
        /// Each day's availability is formatted as a string, time is in military time, no ':' and each block of availability is seperate by a space.
        /// no spaces between a time and the '-'.
        /// Example: "0800-1400 1630-2200"
        /// </param>
        /// <returns>Returns true if a shift was removed due to the new availability</returns>
        public List<Shift> Reload(string[] raw, string canWork)
        {
            // set the new canwork
            this._canWork = canWork.ToLower();

            // clear the current availability
            this._availabilities.Clear();

            // load the availability
            this.LoadAvailability(raw);

            // check discrepencies
            return RecheckAll();
        }

        /// <summary>
        /// Checks all currently/previously assigned shifts and see if they can still work them.
        /// </summary>
        /// <returns>true if we removed a shift from the list</returns>
        public List<Shift> RecheckAll()
        {
            List<Shift> output = new List<Shift>();

            // check every single shift
            foreach (Shift shiftElement in this._shiftsWorking.ToList())
            {
                this.UnassignShift(shiftElement);
                // if we cant work this shift
                if (this.CanWork(shiftElement))
                {
                    // remove it
                    this.AssignShift(shiftElement);
                }
                else
                {
                    output.Add(shiftElement);
                }
            }

            // return true if we removed shift(s)
            return output;
        }

        /// <summary>
        /// Adds a block of time to this person's availability
        /// </summary>
        /// <param name="day"></param>
        /// <param name="availability"></param>
        public void AddAvailabilitySlot(string day, string availability)
        {
            // create a new shift object
            Shift newAvailability = new Shift();
            newAvailability.Name    = "";
            newAvailability.Day     = day;

            // add the start and end time
            newAvailability.Start   = availability.Split('-')[0];
            newAvailability.End     = availability.Split('-')[1];

            // add to data structure
            this._availabilities.Add(newAvailability);
        }

        /// <summary>
        /// Assign to this shift.
        /// </summary>
        /// <param name="newShift">Shift to add.</param>
        /// <returns>true if successful, false otherwise.</returns>
        public bool AssignShift(Shift newShift)
        {
            // checks if employee is able to work this shift
            if (this.CanWork(newShift))
            {
                // add to shifts working list
                this._shiftsWorking.Add(newShift);
                // increment working hours count
                _assignedHours += newShift.Length;

                // return true - successful
                return true;
            }

            // if the code reaches this point, adding new shift failed.
            return false;
        }

        /// <summary>
        /// Unassign from this shift.
        /// </summary>
        /// <param name="oldShift">Shift to remove.</param>
        /// <returns>true if successful, false otherwise.</returns>
        public bool UnassignShift(Shift oldShift)
        {
            // checks if employee is working this shift
            if (this._shiftsWorking.Contains(oldShift))
            {
                // remove shift from working list
                this._shiftsWorking.Remove(oldShift);
                // decrement working hours count
                _assignedHours -= oldShift.Length;

                // return true - successful
                return true;
            }

            // if the code reaches this point, adding new shift failed.
            return false;
        }

        public bool ContainsTheseFlags(string flags)
        {
            // split the flags up
            string[] inFlags = flags.Split('-');
            string[] hasFlags = this._canWork.Split('-');

            // trim those nasty strings down (☞ﾟヮﾟ)☞
            for (int x = 0; x < inFlags.Length; x++)
            {
                inFlags[x] = inFlags[x].Trim();
            }
            for (int x = 0; x < hasFlags.Length; x++)
            {
                hasFlags[x] = hasFlags[x].Trim();
            }

            bool output = false;

            foreach (string item in inFlags)
            {
                if (hasFlags.Contains(item))
                {
                    output = true;
                }
            }

            return output;
        }

        #endregion
    }
}
