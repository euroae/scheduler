using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scheduler.Utilities;

namespace scheduler.includes.DataObjects
{
    class SchedulingOld
    {
        // ============================ Private Memebers ==========================
        public ShiftSkeletonOld schedule;
        public RosterOld employees;

        // ============================ Public Members ============================

        /// <summary>
        /// Default constructor
        /// </summary>
        public SchedulingOld()
        {
            schedule = new ShiftSkeletonOld();
            employees = new RosterOld();
        }

        /// <summary>
        /// Constructor with arguements
        /// </summary>
        /// <param name="availabilityData">Availability Data</param>
        /// <param name="skeletonData">Shift Skeleton Data</param>
        public SchedulingOld(string availabilityData, string skeletonData)
        {
            this.Load(availabilityData, skeletonData);
        }

        // ============================ Public Methods ============================

        public override string ToString()
        {
            string output = "";

            output += schedule.ToString();
            output += "================================================================";
            output += employees.ToString();

            return output;
        }

        public string PrintMatchedShifts()
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
                foreach (ShiftSlotOld shiftElement in schedule.shiftSlots[TimeUtilities.daysOfWeek[x]])
                {

                    output += Environment.NewLine;
                    output += "For shift \"" + shiftElement.shiftName + "\" From " + shiftElement.startHour + " until " + shiftElement.endHour + ". The following employees can work this:";
                    output += Environment.NewLine;
                    //output += Environment.NewLine;

                    foreach (string name in shiftElement._unassigned)
                    {
                        output += name;
                        output += Environment.NewLine;
                    }
                }
            }

            return output;
        }


        /// <summary>
        /// matches up employee availabilities to shifts
        /// </summary>
        public void MatchShifts()
        {
            // for each day of the week
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                // for each shift for this day
                foreach (ShiftSlotOld shiftElement in schedule.shiftSlots[TimeUtilities.daysOfWeek[x]])
                {
                    // for each employee
                    foreach (EmployeeOld employElement in employees.teamRoster.Values)
                    {
                        // if this employee can work this type of shift
                        if (employElement._validJobs.Contains(shiftElement.shiftName.Split(' ')[0]))
                        {
                            // for each of this employees availability slot for this day
                            foreach (ShiftOld availElement in employElement._availabilities[TimeUtilities.daysOfWeek[x]])
                            {
                                // check if this person's available allows for this shift
                                if ((int.Parse(shiftElement.startHour) >= int.Parse(availElement.startHour)) 
                                    && 
                                    (int.Parse(shiftElement.endHour) <= int.Parse(availElement.endHour)))
                                {
                                    // add this 
                                    shiftElement._unassigned.Add(employElement._username);
                                }
                            }
                        }
                    }
                }
            }
        }

        public ShiftSlotOld FindThisShiftSlot(string day, string name)
        {
            return schedule.FindThisShiftSlot(day, name);
        }

        /// <summary>
        /// Assigns employee to this job
        /// </summary>
        /// <param name="index">Index of employee to add</param>
        public void AssignEmployee(int shift, int employeeIndex, string name)
        {

            // assign shift and get employee
            

            //Employee assignee = employees.teamRoster[employee];

            //shift.AssignEmployee(employeeIndex);

            
        }

        /// <summary>
        /// Unassigns Employee from this job
        /// </summary>
        /// <param name="index">Index of employee to unassign</param>
        public void UnassignEmployee(ShiftSlotOld shift, int employeeIndex)
        {

        }

        // ============================ Private Methods ============================
        
        /// <summary>
        /// Initializes and loads the data for this schedule
        /// </summary>
        /// <param name="availabilityData">Availability data for each employee along with employee information (name, username, shift they can work)</param>
        /// <param name="skeletonData">Skeleton shift data - the layout of the schedule with all the shifts that need to be filled by employees</param>
        private void Load(string availabilityData, string skeletonData)
        {
            // load data
            schedule = new ShiftSkeletonOld(skeletonData);
            employees = new RosterOld(availabilityData);
        }
    }
}
