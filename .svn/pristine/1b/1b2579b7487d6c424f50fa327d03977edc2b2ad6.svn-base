using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftObjects;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using EmployeeObjects;

namespace DataObjects
{
    [Serializable()]
    public class Conflicts : ISerializable
    {
        public Dictionary<string, List<Conflict>> _conflicts;

        #region constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public Conflicts()
        {
            Load();
        }

        /// <summary>
        /// Loads and initializes everything
        /// </summary>
        /// <param name="username">Username</param>
        public void Load()
        {
            _conflicts = new Dictionary<string, List<Conflict>>();
        }

        
        #endregion

        #region serialization functions

        public Conflicts(SerializationInfo info, StreamingContext ctxt)
        {
            this._conflicts = (Dictionary<string, List<Conflict>>)info.GetValue("conflicts", typeof(Dictionary<string, List<Conflict>>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("conflicts", this._conflicts);
        }

        #endregion

        /// <summary>
        /// Tries to add a new conflict
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newOne"></param>
        public void AddConflict(string username, Conflict newOne)
        {
            // check if this person already exists
            if (_conflicts.Keys.Contains(username))
            {
                // if it does

                // check if this conflict doesn't already exist
                if (!_conflicts[username].Contains(newOne))
                {
                    // add it because it doesn't
                    _conflicts[username].Add(newOne);
                }
            }
            else
            {
                // this username doesn't exist
                // create new user and entry
                List<Conflict> newTemp = new List<Conflict>();
                // add them in
                _conflicts.Add(username, newTemp);

                // add the conflict
                _conflicts[username].Add(newOne);
            }
        }

        /// <summary>
        /// Tries to add a new conflict
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newOne"></param>
        public void AddConflicts(string username, List<Conflict> newOne)
        {
            // check if this person already exists
            if (_conflicts.Keys.Contains(username))
            {
                // if it does

                // go through each conglict
                foreach (Conflict element in newOne)
                {
                    // check if this conflict doesn't already exist
                    if (!_conflicts[username].Contains(element))
                    {
                        // and add it if it doesnt
                        _conflicts[username].Add(element);
                    }
                }
            }
            else
            {
                // this username doesn't exist
                // create new user and entry
                List<Conflict> newTemp = new List<Conflict>();
                // add them in
                _conflicts.Add(username, newTemp);

                // add the conflict(s)
                foreach (Conflict element in newOne)
                {
                    _conflicts[username].Add(element);
                }
            }
        }

        /// <summary>
        /// Finds and removes a conflict based on shift
        /// </summary>
        /// <param name="username">employee to check</param>
        /// <param name="remove">Shift to find in conflicts</param>
        public void RemoveConflict(string username, Shift remove)
        {
            // maximum number of times to loop
            int maxLoop = this._conflicts[username].Count;

            // search through all conflicts for this user
            for (int x = 0; x < maxLoop; x++)
            {
                // get target conflict
                Conflict target = this._conflicts[username][x];

                // if this conflict contains this shift
                if (target.Contains(remove))
                {
                    // remove it
                    this.RemoveConflict(username, target);

                    // modify loop values
                    maxLoop--;
                    x--;
                }
            }
        }

        public void RemoveConflict(string username, Conflict remove)
        {
            this._conflicts[username].Remove(remove);
        }

        public string ToString(Roster employees, bool ds, bool openClose)
        {
            // output for this object
            string output = "";

            // for each employee in the conflict list
            foreach (string employee in _conflicts.Keys)
            {
                // check if this employee actually has conflicts
                if (_conflicts[employee].Count <= 0)
                {
                    // skip this one
                    continue;
                }

                // other wise format the output
                output += "Employee " + employees.ReturnEmployee(employee).Nickname + " has the following shift conflicts: ";
                output += Environment.NewLine;

                // for each conflict they have
                foreach (Conflict target in _conflicts[employee])
                {
                    if (ds && target._conflictType.ToLower().Contains("double"))
                    {
                        output += target.ToString();
                        output += Environment.NewLine;
                    }
                    if (openClose && target._conflictType.ToLower().Contains("open"))
                    {
                        output += target.ToString();
                        output += Environment.NewLine;
                    }
                }

                output += Environment.NewLine;
            }
            return output;
        }
    }
}
