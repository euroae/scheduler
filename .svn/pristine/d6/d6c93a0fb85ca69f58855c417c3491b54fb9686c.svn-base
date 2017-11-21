using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scheduler.Utilities;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ShiftObjects
{
    /// <summary>
    /// An object containing information regarding a slot of time that needs to be filled for a schedule.
    /// </summary>
    [Serializable()]
    public class ScheduleSlot : ISerializable
    {
        // public fields
        static uint             _count = 0;
        private int             _peopleNeeded;       // number of employes required for this shift slot
        private int             _peopleWorking;      // number of employees actually working
        private List<string>    _unassigned;         // the list of people who can work this but not assigned to it yet - stores their username in string
        private List<string>    _assigned;           // the list of people who are working this - stores their username

        // private fields
        public Shift           _shiftInfo;          // Basic information regarding this shift slot

        #region serialization functions

        public ScheduleSlot(SerializationInfo info, StreamingContext ctxt)
        {
            this._peopleNeeded  = (int)info.GetValue("peopleNeeded", typeof(int));
            this._peopleWorking = (int)info.GetValue("peopleWorking", typeof(int));

            this._unassigned    = (List<string>)info.GetValue("unassigned", typeof(List<string>));
            this._assigned      = (List<string>)info.GetValue("assigned", typeof(List<string>));

            this._shiftInfo     = (Shift)info.GetValue("shiftInfo", typeof(Shift));
            this._shiftInfo.ShiftNumber = _count;
            _count++;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("peopleNeeded", this._peopleNeeded);
            info.AddValue("peopleWorking", this._peopleWorking);
            info.AddValue("unassigned", this._unassigned);
            info.AddValue("assigned", this._assigned);
            info.AddValue("shiftInfo", this._shiftInfo);
        }

        #endregion

        #region get set functions

        /// <summary>
        /// Name of Shift.
        /// </summary>
        public int EmployeeNeededCount
        {
            get { return this._peopleNeeded; }
            set { this._peopleNeeded = value; }
        }

        /// <summary>
        /// Day shift is on.
        /// </summary>
        public int EmployeeWorkingCount
        {
            get { return this._peopleWorking; }
            set { this._peopleWorking = value; }
        }

        /// <summary>
        /// List of people who can work this shift.
        /// </summary>
        public List<string> Unassigned
        {
            get { return this._unassigned; }
            // set disabled to avoid exceptions.
            //set { this._unassigned = value; }
        }

        /// <summary>
        /// List of people who are working this shift.
        /// </summary>
        public List<string> Assigned
        {
            get { return this._assigned; }
            // set disabled to avoid exceptions.
            //set { this._assigned = value; }
        }

        /// <summary>
        /// Name of Shift.
        /// </summary>
        public string Name
        {
            get { return this._shiftInfo.Name; }
            set { this._shiftInfo.Name = value; }
        }

        /// <summary>
        /// Type of shift.
        /// </summary>
        public string Type
        {
            get
            {
                return this._shiftInfo.Type;
            }
        }

        /// <summary>
        /// Day shift is on.
        /// </summary>
        public string Day
        {
            get { return this._shiftInfo.Day; }
            set { this._shiftInfo.Day = value; }
        }

        /// <summary>
        /// Start time of shift.
        /// </summary>
        public string Start
        {
            get { return this._shiftInfo.Start; }
            set { this._shiftInfo.Start = value; }
        }

        /// <summary>
        /// End time of shift.
        /// </summary>
        public string End
        {
            get { return this._shiftInfo.End; }
            set { this._shiftInfo.End = value; }
        }

        /// <summary>
        /// Length of shift
        /// </summary>
        public TimeSpan Length
        {
            get { return this._shiftInfo.Length; }
        }

        public DateTime Date
        {
            get { return this._shiftInfo.Date; }
        }

        #endregion

        #region constructors functions used to construct class and add data

        ~ScheduleSlot()
        {
            if (_count > 0)
            {
                _count--;
            }
        }

        /// <summary>
        /// Default Constructor. Initializes everything with 0.
        /// Doesn't bother with creating struct - remainds null.
        /// </summary>
        public ScheduleSlot()
        {
            Load(0, new List<string>(), new List<string>());
        }

        /// <summary>
        /// Loads scheduleslot by copying an old one
        /// </summary>
        /// <param name="copyThis">Existing object to copy</param>
        public ScheduleSlot(ScheduleSlot copyThis)
        {
            Load(copyThis._peopleNeeded, copyThis.Unassigned, copyThis.Assigned);
            LoadStruct(copyThis.Name, copyThis.Day, copyThis.Start, copyThis.End, copyThis.Date);
        }

        /// <summary>
        /// Constructor. Provided with data for most fields. Collections initialized as empty.
        /// </summary>
        //// <param name="shiftName">Name of shift.</param>
        /// <param name="day">day of the week this shift is on.</param>
        /// <param name="startTime">start time for this shift in military format, as a string, with no ':'</param>
        /// <param name="endTime">end time for this shift in military format, as a string, with no ':'</param>
        /// <param name="employeesRequired">Number of employees who can work this slot</param>
        public ScheduleSlot(string shiftName, string day, string startTime, string endTime, int peopleNeeded, DateTime date)
        {
            Load(peopleNeeded, new List<string>(), new List<string>());
            LoadStruct(shiftName, day, startTime, endTime, date);
        }

        /// <summary>
        /// Constructor. Provided with data for all fields
        /// </summary>
        //// <param name="shiftName">Name of shift.</param>
        /// <param name="day">day of the week this shift is on.</param>
        /// <param name="startTime">start time for this shift in military format, as a string, with no ':'</param>
        /// <param name="endTime">end time for this shift in military format, as a string, with no ':'</param>
        /// <param name="employeesRequired">Number of employees who can work this slot</param>
        /// <param name="canWorkEmployees">Who can work this shift</param>
        /// <param name="areWorkingEmployees">Who is working this shift</param>
        public ScheduleSlot(string shiftName, string day, string startTime, string endTime, int peopleNeeded, DateTime date, List<string> canWorkThis, List<string> assignedToWorkThis) 
        {
            Load(peopleNeeded, canWorkThis, assignedToWorkThis);
            LoadStruct(shiftName, day, startTime, endTime, date);
        }

        /// <summary>
        /// Used to initialize
        /// </summary>
        /// <param name="employeesRequired">Number of employees who can work this slot</param>
        /// <param name="canWorkEmployees">Who can work this shift</param>
        /// <param name="areWorkingEmployees">Who is working this shift</param>
        private void Load(int peopleNeeded, List<string> canWorkThis, List<string> assignedToWorkThis)
        {
            // assign values
            this._peopleNeeded       = peopleNeeded;
            this._peopleWorking      = 0;
            this._unassigned         = canWorkThis;
            this._assigned           = assignedToWorkThis;
        }

        /// <summary>
        /// Generates the shift struct containing the basic information about this shift.
        /// Used a seperate function to improve readability
        /// </summary>
        /// <param name="shiftName">Name of shift.</param>
        /// <param name="day">day of the week this shift is on.</param>
        /// <param name="startTime">start time for this shift in military format, as a string, with no ':'</param>
        /// <param name="endTime">end time for this shift in military format, as a string, with no ':'</param>
        public void LoadStruct(string shiftName, string day, string startTime, string endTime, DateTime date)
        {
            _shiftInfo = new Shift(shiftName, day, startTime, endTime, _count, date);
            _count++;
        }
        #endregion

        #region Assignment Function used to facilitate assigning of shifts

        /// <summary>
        /// Assigns employee to this shift.
        /// </summary>
        /// <param name="employeeUsername">Username of the employee to assign to this shift</param>
        public void AssignToThisShift(string username)
        {
            // check if this person is even in the list
            if (_unassigned.Contains(username))
            {
                // assign this person
                this.AssignEmployee(username, 1);
            }
            else
            {
                // throw exception if not
                throw new Exception(username + " not in unassigned list.");
            }
        }

        /// <summary>
        /// Assigns employee to this shift.
        /// </summary>
        /// <param name="employeeIndex">Position of employee in unassigned list</param>
        /// <returns>The username of this employee</returns>
        public string AssignToThisShift(int employeeIndex)
        {
            // holds the username to output
            string username = "";

            // check if valid index value
            if (_unassigned.Count > employeeIndex)
            {
                // get this person' username
                username = _unassigned[employeeIndex];
                // assign this person
                this.AssignEmployee(username, 1);
            }
            else
            {
                // throw exception if not
                throw new Exception(employeeIndex + " is not a valid index.");
            }

            // return username
            return username;
        }

        /// <summary>
        /// Unassigns employee to this shift.
        /// </summary>
        /// <param name="employeeUsername">Username of the employee to assign to this shift</param>
        public void UnassignToThisShift(string username)
        {
            // check if this person is even in the list
            if (_assigned.Contains(username))
            {
                // assign this person
                this.AssignEmployee(username, 0);
            }
            else
            {
                // throw exception if not
                throw new Exception(username + " not in unassigned list.");
            }
        }

        /// <summary>
        /// Unassigns employee to this shift.
        /// </summary>
        /// <param name="employeeIndex">Position of employee in unassigned list</param>
        /// <returns>The username of this employee</returns>
        public string UnassignToThisShift(int employeeIndex)
        {
            // holds the username to output
            string username = "";

            // check if valid index value
            if (_assigned.Count > employeeIndex)
            {
                // get this person' username
                username = _assigned[employeeIndex];
                // assign this person
                this.AssignEmployee(username, 0);
            }
            else
            {
                // throw exception if not
                throw new Exception(employeeIndex + " is not a valid index.");
            }

            // return username
            return username;
        }

        /// <summary>
        /// Assigns or unassigns the username to this shift. Private function.
        /// Assumes calling function has check to ensure employee is value.
        /// </summary>
        /// <remarks>
        /// Provides a single point for modifying all assign functions.
        /// </remarks>
        /// <param name="username">username of employee</param>
        /// <param name="assign">Int value to tell this function whether to assign the employee or unassign them. 1 for assign. 0 for unassign.</param>
        private void AssignEmployee(string username, int assign)
        {
            // assignment
            if (assign == 1)
            {
                // assign this person
                this._assigned.Add(username);
                // remove them form the list
                bool result = this._unassigned.Remove(username);
                // increment count
                this._peopleWorking++;
            }
            // unassignment
            else if (assign == 0)
            {
                // unassign this person
                this._unassigned.Add(username);
                // remove them form the list
                this._assigned.Remove(username);
                // decrement count
                this._peopleWorking--;
            }
        }
        #endregion

        #region Accessors_And_Information Contains all the functions use to access fields and get information

        /// <summary>
        /// Returns a string of this object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";
            output = "" + this._shiftInfo.ShiftNumber + " " + this._shiftInfo.Day + " " + this._shiftInfo.Name + " ";

            // appends up to 32 white spaces - purpose is so that each shift will have the same clickable area in the list.
            int fillout = 32 - output.Length;
            for (int x = 0; x < fillout; x++)
            {
                output += " ";
            }

            return output;
        }

        /// <summary>
        /// Returns the underlining shift of this schedule slot.
        /// </summary>
        /// <returns>The shift.</returns>
        public Shift ReturnShift()
        {
            return this._shiftInfo;
        }

        /// <summary>
        /// who is working this shift in string format
        /// </summary>
        /// <returns></returns>
        public string WhosWorking()
        {
            // sort it first
            //this._assigned = this._assigned

            string output = "";
            foreach (string person in _assigned)
            {
                output += person + " ";
            }
            return output.Trim();
        }
        #endregion

        #region mutators Functions that change the internal data that doesn't fall under one of the other regions

        /// <summary>
        /// Clears Lists.
        /// </summary>
        public void ClearLists()
        {
            this._unassigned.Clear();
            this._assigned.Clear();
        }

        /// <summary>
        /// Adds a name to list of people who can work this shift.
        /// Removes them from list of employees currently working if they are on there.
        /// </summary>
        /// <param name="username">username of employee.</param>
        public void AddToAbleToWork(string username)
        {
            if (this._unassigned.Contains(username))
            {
                throw new Exception("Username " + username + " already in list.");
            }

            this._unassigned.Add(username);

            // remove employee and decrement count of people working if removed
            if (this._assigned.Remove(username)) { this._peopleWorking--; }
        }

        /// <summary>
        /// Adds a name to list of people who are work this shift.
        /// Removes them from list of employees available to work if they are on there.
        /// </summary>
        /// <param name="username">username of employee.</param>
        public void AddToWorking(string username)
        {
            this._assigned.Add(username);
            this._peopleWorking++;          // increment count of people working

            this._unassigned.Remove(username);
        }

        public List<ScheduleSlot> SplitIntoGroupsOf(int count)
        {
            // output
            List<ScheduleSlot> output = new List<ScheduleSlot>();

            // figure out how many times we need to loop
            int loopTimes = (this.Assigned.Count > this.EmployeeNeededCount) ? this.Assigned.Count : this.EmployeeNeededCount;

            for (int x = 0; x < loopTimes; )
            {
                // create new object
                ScheduleSlot splitOne = new ScheduleSlot(this.Name, this.Day, this.Start, this.End, 0, this.Date);
                
                // check how if we need to add names
                if (x < this._assigned.Count)
                {
                    splitOne._assigned.Add(this._assigned[x]);
                }
                splitOne._peopleNeeded++;
                //increment
                x++;

                // check if count is too high
                if (x >= loopTimes)
                {
                    output.Add(splitOne);
                    break;
                }

                // check again and add if needed
                if (x < this._assigned.Count)
                {
                    splitOne._assigned.Add(this._assigned[x]);
                }
                splitOne._peopleNeeded++;

                x++;

                // add to output
                output.Add(splitOne);
            }

            return output;
        }

        /// <summary>
        /// Unassigns everyone from this shift
        /// </summary>
        public void UnassignAll()
        {
            // get list of names
            List<string> temp = new List<string>(this.Assigned);

            // for each person assigned to this shift
            foreach (string person in temp)
            {
                // unassign them
                this.UnassignToThisShift(person);
            }
        }

        public void RESET()
        {
            _count = 0;
        }

        #endregion
    }
}
