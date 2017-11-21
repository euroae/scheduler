using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.includes.DataObjects
{
    class RosterOld
    {
        public  Dictionary<string, EmployeeOld>    teamRoster;
        private int                             totalEmployees;

        /// Public Classes
        public RosterOld()
        {
            initializeDS();
            totalEmployees = 0;
        }

        public RosterOld(string input)
        {
            initializeDS();
            totalEmployees = 0;
            
            this.LoadEmployees(input);
        }

        public void LoadEmployees(string input)
        {
            // split input into each line - one line equals one employee's info
            string[] raw = input.Split('\n');

            // for each line
            foreach (string element in raw)
            {   // do
                if (element == "") { continue; } // skip this element if it is an empty line

                // split input
                string[] processing = element.Split('$');
                totalEmployees++;

                // create new employee object
                EmployeeOld temp = new EmployeeOld(
                    processing[1],  // username 
                    processing[0],  // nickname
                    new string[] { processing[2], processing[3], processing[4], processing[5], processing[6], processing[7], processing[8], }, // availbility array
                    processing[9]); // type of shifts this person can work

                // add to roster
                teamRoster.Add(processing[1], temp);
            }
        }

        /// <summary>
        ///  overridden ToString class. Format internal data into a string for your reading pleasure
        /// </summary>
        /// <returns>The eye pleasing string</returns>
        public override string ToString()
        {
            string output = "There are " + this.totalEmployees + " employees:";
            output += Environment.NewLine;
            output += "================================================================";
            output += Environment.NewLine;

            foreach (EmployeeOld element in teamRoster.Values)
            {
                output += element.ToString();
                output += Environment.NewLine;
            }

            return output;
        }

        /// Private classes
        private void initializeDS()
        {
            teamRoster = new Dictionary<string, EmployeeOld>();
        }
    }
}