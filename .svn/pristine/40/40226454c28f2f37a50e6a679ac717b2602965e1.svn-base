using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scheduler.Utilities;

namespace scheduler.includes.DataObjects
{
    /// <summary>
    /// Employee object. Contains all the information related to an employee.
    /// </summary>
    class EmployeeOld
    {
        // employee name and username
        public string                               _username;
        public string                               _name;
        // number of hours working
        public System.TimeSpan                      _assignedHours;
        // list of shifts this person can work
        public string                               _validJobs;
        // list of availabilities
        // Format is <string, list<Shift>> - first one is day of week, second one is list of shifts
        public Dictionary<string, List<ShiftOld>>      _availabilities;
        // list of shifts assigned to this person
        // Format is <string, list<Shift>> - first one is day of week, second one is list of shifts
        public Dictionary<string, List<ShiftOld>>      _shiftsWorking;

        public EmployeeOld()
        {
        }

        public EmployeeOld(string username, string name, string[] availabilities, string validShifts)
        {
            Load(username, name, availabilities, validShifts);
        }

        private void Load(string username, string name, string[] availabilities, string validShifts)
        {
            initializeDS();

            // assign values
            _username = username;
            _name = name;
            this._validJobs = validShifts;

            // assign default values
            _assignedHours = new TimeSpan(0);

            LoadAvailability(availabilities);
        }

        private void initializeDS()
        {
            // initialize the DS
            _availabilities = new Dictionary<string, List<ShiftOld>>();
            _shiftsWorking = new Dictionary<string, List<ShiftOld>>();

            // populate with keys and empty Lists
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                // initialize the list
                List<ShiftOld> temp = new List<ShiftOld>();
                List<ShiftOld> temp2 = new List<ShiftOld>();

                // add everything into the DS
                _availabilities.Add(TimeUtilities.daysOfWeek[x], temp);
                _shiftsWorking.Add(TimeUtilities.daysOfWeek[x], temp2);
            }
        }

        private void LoadAvailability(string[] raw)
        {
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                // get this "days" availability
                string temp = raw[x];

                // split it into each of it's blocks
                string[] preProcess = temp.Split(' ');

                // for each block
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

        // add availability to this person
        public void AddAvailabilitySlot(string day, string availability)
        {
            // create a new shift object
            ShiftOld newAvailability = new ShiftOld();
            newAvailability.shiftName = "Availble";

            // add the start and end time
            newAvailability.startHour = availability.Split('-')[0];
            newAvailability.endHour = availability.Split('-')[1];

            // add to data structure
            _availabilities[day].Add(newAvailability);
        }

        /// <summary>
        ///  overridden ToString class. Format internal data into a string for your reading pleasure
        /// </summary>
        /// <returns>The eye pleasing string</returns>
        public override string ToString()
        {
            string output = "";

            // output
            output += "Employee " + this._name + " with username, " + this._username + ", is allowed to work " + this._validJobs + " jobs and has the following availability:";
            output += Environment.NewLine;
            output += "================================================================";

            // populate with keys and empty Lists
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                output += Environment.NewLine;
                output += "For " + TimeUtilities.daysOfWeek[x] + ":";
                output += Environment.NewLine;
                foreach (ShiftOld element in _availabilities[TimeUtilities.daysOfWeek[x]])
                {
                    output += element.ToString();
                }
            }

            output += Environment.NewLine;
            output += "================================================================";

            return output;
        }

        public void AssignShift(ShiftOld newShift)
        {

        }

        /// <summary>
        /// Check if person can work this shift - ie does it overlap with an existing shift.
        /// does not check if they have the correct tags
        /// </summary>
        /// <param name="newShift"></param>
        /// <returns></returns>
        public bool CanWorkThis(ShiftSlotOld newShift)
        {
            foreach (ShiftOld item in _shiftsWorking[newShift.day])
            {
                if ((int.Parse(newShift.startHour) >= int.Parse(item.startHour))
                   &&
                   (int.Parse(newShift.endHour) <= int.Parse(item.endHour)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
