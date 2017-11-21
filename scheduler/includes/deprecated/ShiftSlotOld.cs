using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.includes.DataObjects
{
    /// <summary>
    /// Extended version of the shift class used to denote shift slots on a schedule
    /// In addition to the original fields of:
    /// shiftName: name of shift/type of shift
    /// startTime: Time this shift starts at
    /// endTime: time this shift ends at
    /// We add:
    /// employeesRequired - number of employees required for this shift
    /// canWorkEmployees - list of employees who are able to work this shift
    /// areWorkingEmployees - list of employees actyally
    /// </summary>
    class ShiftSlotOld : ShiftOld
    {
        // number of employees who can be assigned to this shift
        public int              _employeesRequired;
        public int              _areWorking;

        // List of employees who are able to work this shift
        public List<string>     _unassigned;
        // List of employees who are actually working this shift
        public List<string>     _assigned;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ShiftSlotOld() : base()
        {
            Load(0, new List<string>(), new List<string>());
        }

        /// <summary>
        /// Constructor with starting data
        /// </summary>
        /// <param name="_shiftName">name for this shift</param>
        /// <param name="_startHour">start time</param>
        /// <param name="_endHour">end time</param>
        /// <param name="employeesRequired">Number of employees who can work this slot</param>
        /// <param name="canWorkEmployees">Who can work this shift</param>
        /// <param name="areWorkingEmployees">Who is working this shift</param>
        public ShiftSlotOld(string _shiftName, string _startHour, string _endHour, string _day, int employeesRequired, List<string> canWorkEmployees, List<string> areWorkingEmployees) 
            : base(_shiftName, _startHour, _endHour, _day)
        {
            Load(employeesRequired, canWorkEmployees, areWorkingEmployees);
        }

        /// <summary>
        /// Constructor with starting data
        /// </summary>
        /// <param name="_shiftName">name for this shift</param>
        /// <param name="_startHour">start time</param>
        /// <param name="_endHour">end time</param>
        /// <param name="employeesRequired">Number of employees who can work this slot</param>
        /// <param name="employeesRequired"></param>
        public ShiftSlotOld(string _shiftName, string _startHour, string _day, string _endHour, int employeesRequired)
            : base(_shiftName, _startHour, _endHour, _day)
        {
            Load(employeesRequired, new List<string>(), new List<string>());
        }

        /// <summary>
        /// Used to initialize
        /// </summary>
        /// <param name="employeesRequired">Number of employees who can work this slot</param>
        /// <param name="canWorkEmployees">Who can work this shift</param>
        /// <param name="areWorkingEmployees">Who is working this shift</param>
        private void Load(int employeesRequired, List<string> canWorkEmployees, List<string> areWorkingEmployees)
        {
            _employeesRequired = employeesRequired;
            _unassigned = canWorkEmployees;
            _assigned = areWorkingEmployees;
            _areWorking = 0;
        }

        /// <summary>
        /// Returns a string of this object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";

            output = day + " " + shiftName;
            
            return output;
        }

        /// <summary>
        /// Assigns employee to this job
        /// </summary>
        /// <param name="index">Index of employee to add</param>
        public string AssignEmployee(int index)
        {
            // add employee to the list
            string output = _unassigned[index];

            _assigned.Add(_unassigned[index]);

            // remove from other list
            _unassigned.RemoveAt(index);

            // increment count
            _areWorking++;

            return output;
        }

        /// <summary>
        /// Unassigns Employee from this job
        /// </summary>
        /// <param name="index">Index of employee to unassign</param>
        public string UnassignEmployee(int index)
        {
            string output = _assigned[index];

            // add employee to the list
            _unassigned.Add(_assigned[index]);

            // remove from other list
            _assigned.RemoveAt(index);

            // increment count
            _areWorking--;

            return output;
        }
    }
}
