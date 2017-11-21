using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scheduler.Utilities;
using ShiftObjects;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmployeeObjects
{
    [Serializable()]
    public class Roster : ISerializable
    {
        public  Dictionary<string, Employee>        _members;
        private int                                 _count;

        #region serialization functions

        public Roster(SerializationInfo info, StreamingContext ctxt)
        {
            this._members = (Dictionary<string, Employee>)info.GetValue("members", typeof(Dictionary<string, Employee>));
            this._count = (int)info.GetValue("count", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("members", this._members);
            info.AddValue("count", this._count);
        }

        #endregion

        #region constructors/loader functions

        /// <summary>
        /// default constructor
        /// </summary>
        public Roster()
        {
            initializeDS();
            _count = 0;
        }

        /// <summary>
        /// Constructor with input.
        /// </summary>
        /// <param name="input">Input employee information.</param>
        public Roster(string input)
        {
            initializeDS();
            _count = 0;
            
            this.LoadEmployees(input);
        }

        /// <summary>
        /// Load employees information from input.
        /// </summary>
        /// <param name="input">Input containing all employee information and their availability.</param>
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

                // Add new employee
                this.Add(
                    processing[1],  // username 
                    processing[0],  // nickname
                    new string[] { processing[2], processing[3], processing[4], processing[5], processing[6], processing[7], processing[8], }, // availbility array
                    processing[9], // type of shifts this person can work
                    int.Parse(processing[10]));// shift preference
            }
        }

        /// <summary>
        /// Initializes data structure
        /// </summary>
        private void initializeDS()
        {
            _members = new Dictionary<string, Employee>();
        }

        #endregion

        #region get/set

        /// <summary>
        /// Get set for count.
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        #endregion

        #region accessors

        /// <summary>
        /// Returns a list of employees.
        /// </summary>
        /// <returns>List of employees.</returns>
        public List<Employee> ToList()
        {
            // output
            List<Employee> output = new List<Employee>();

            // for each day of the week
            foreach (Employee employee in this._members.Values)
            {
                // append the list to the output
                output.Add(employee);
            }

            // return it
            return output;
        }

        /// <summary>
        ///  overridden ToString class. Format internal data into a string for your reading pleasure
        /// </summary>
        /// <returns>The eye pleasing string</returns>
        public override string ToString()
        {
            string output = "There are " + this.Count + " employees:";
            output += Environment.NewLine;
            output += "================================================================";
            output += Environment.NewLine;

            foreach (Employee element in this._members.Values)
            {
                output += element.ToString();
                output += Environment.NewLine;
            }

            return output;
        }

        /// <summary>
        /// returns employee at index.
        /// </summary>
        /// <param name="index">index.</param>
        /// <returns>Employee or null</returns>
        public Employee AtIndex(int index)
        {
            return this.ToList()[index];
        }

        /// <summary>
        /// Returns employee with specified username.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <returns>Employee or null.</returns>
        public Employee ReturnEmployee(string username)
        {
            return this._members[username];
        }

        #endregion

        #region mutator

        /// <summary>
        /// adds a new employee to roster.
        /// </summary>
        /// <param name="newEmployee">New employee to add.</param>
        public void Add(Employee newEmployee)
        {
            this._members.Add(newEmployee.Username, newEmployee);
            this.Count++;
        }

        /// <summary>
        /// over loaded add function. Adds a new employee to roster.
        /// </summary>
        /// <param name="username">Employee username</param>
        /// <param name="nickname">Employee nickname</param>
        /// <param name="availability">Employee availability</param>
        /// <param name="validShifts">Employee validshifts</param>
        public void Add(string username, string nickname, string[] availability, string validShifts, int preference)
        {
            // creates a new employee object and passes it to exisiting add function.
            this.Add(new Employee(username, nickname, availability, validShifts, preference));
        }

        /// <summary>
        /// Reloads everyones availability and can work tags
        /// </summary>
        /// <param name="input">input data</param>
        /// <returns>true if something changed</returns>
        public Dictionary<string, List<Shift>> Reload(string input)
        {
            Dictionary<string, List<Shift>> output = new Dictionary<string, List<Shift>>();
            // split input into each line - one line equals one employee's info
            string[] raw = input.Split('\n');

            // for each line
            foreach (string element in raw)
            {   // do
                if (element == "") { continue; } // skip this element if it is an empty line

                // split input
                string[] processing = element.Split('$');

                // does this employee already exist?
                if (!this._members.Keys.Contains(processing[1]))
                {
                    // Add new employee
                    this.Add(
                        processing[1],  // username 
                        processing[0],  // nickname
                        new string[] { processing[2], processing[3], processing[4], processing[5], processing[6], processing[7], processing[8], }, // availbility array
                        processing[9], // type of shifts this person can work
                        int.Parse(processing[10]));// shift preference
                }
                else
                {
                    // reload existing employee
                    output.Add(processing[1], this._members[processing[1]].Reload(
                        new string[] { processing[2], processing[3], processing[4], processing[5], processing[6], processing[7], processing[8], },
                        processing[9]));
                }
            }

            return output;
        }

        #endregion
    }
}
