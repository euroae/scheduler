using System;
using System.Collections;
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
    /// Datastructure that contains a group of shifts.
    /// This structure keeps the shifts ordered by the day they occur on and by time from earliest to latest.
    /// Also provides a set of functions to work on the data.
    /// </summary>
    [Serializable()]
    public class GroupOfShifts : ISerializable
    {
        // public fields
        public Dictionary<string, List<Shift>> _shifts;          // Basic information regarding this shift slot
       
        // private fields
        private int _count;

        #region serialization functions

        public GroupOfShifts(SerializationInfo info, StreamingContext ctxt)
        {
            this._shifts = (Dictionary<string, List<Shift>>)info.GetValue("shifts", typeof(Dictionary<string, List<Shift>>));
            this._count = (int)info.GetValue("count", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("shifts", this._shifts);
            info.AddValue("count", this._count);
        }

        #endregion

        #region constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GroupOfShifts()
        {
            this.InitializeDS();
        }

        /// <summary>
        /// Initializes datastructure
        /// </summary>
        private void InitializeDS()
        {
            // initialize the DS
            this._shifts = new Dictionary<string, List<Shift>>();
            // populate with keys and empty Lists
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                // initialize the list
                List<Shift> temp = new List<Shift>();
                // add everything into the DS
                this._shifts.Add(TimeUtilities.daysOfWeek[x], temp);
            }
        }

        #endregion

        #region mutators

        /// <summary>
        /// goes through the entire list of shifts and clears them out
        /// </summary>
        public void Clear()
        {
            // for each day of the week
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                // clear it
                _shifts[TimeUtilities.daysOfWeek[x]].Clear();
            }
        }

        /// <summary>
        /// adds new shift in ordered form.
        /// </summary>
        /// <param name="shift">new shift.</param>
        public void AddInOrder(Shift shift)
        {
            // case 1 - no other shifts added for this day yet, just add it
            if (this._shifts[shift.Day].Count == 0)
            {
                this._shifts[shift.Day].Add(shift);
                this._count++;
                return;
            }


            // case 2 - shifts already exist
            int insertAt = -1;
            // go through each element until we find the position to insert at
            foreach (Shift existing in this._shifts[shift.Day])
            {
                // check if new shift is earlier than existing
                if (TimeUtilities.IsEarlier(shift, existing))
                {
                    insertAt = this._shifts[shift.Day].IndexOf(existing);
                    break;
                }
            }

            // check if we found place to insert at
            if (insertAt == -1)
            {
                // insert at end, all exisiting shifts are earlier than this one
                this._shifts[shift.Day].Add(shift);
                this._count++;
            }
            else
            {
                // found somewhere to insert at and insert there.
                this._shifts[shift.Day].Insert(insertAt, shift);
                this._count++;
            }
        }

        /// <summary>
        /// Add a new shift to end of list.
        /// </summary>
        /// <param name="shift">new shift.</param>
        public void Add(Shift shift)
        {
            this._shifts[shift.Day].Add(shift);
        }

        /// <summary>
        /// removes a specified shift from dictionary.
        /// </summary>
        /// <param name="target"></param>
        public void Remove(Shift target)
        {
            this._shifts[target.Day].Remove(target);
        }

        #endregion

        #region accessors_information contains functions used to access datastructure and get information

        /// <summary>
        /// Returns a list of all the shifts for day.
        /// </summary>
        /// <param name="day">Day we want shifts from</param>
        /// <returns>List containing all the shifts for that day.</returns>
        public List<Shift> ReturnShiftsForDay(string day)
        {
            return this._shifts[day];
        }


        /// <summary>
        /// Returns count of shifts in this object
        /// </summary>
        public int Count
        {
            get
            {
                return this._count;
            }
        }

        /// <summary>
        /// Merges all the lists in the dictionary into a single list and returns it
        /// </summary>
        /// <returns></returns>
        public List<Shift> ToList()
        {
            // output
            List<Shift> output = new List<Shift>();

            // for each day of the week
            foreach (List<Shift> listOfShifts in this._shifts.Values)
            {
                // append the list to the output
                output.AddRange(listOfShifts);
            }

            // return it
            return output;
        }

        /// <summary>
        /// Returns a list of shifts within this object.
        /// </summary>
        /// <returns>List of shifts.</returns>
        public override string ToString()
        {
            string output = "";

            List<string> daysOfWeek = TimeUtilities.daysOfWeek;

            output += "---------------------------------------------------" + System.Environment.NewLine;

            // per day
            for (int x = 0; x < daysOfWeek.Count; x++)
            {
                output += daysOfWeek[x] + System.Environment.NewLine;
                // per shift
                foreach (Shift shift in this._shifts[daysOfWeek[x]])
                {
                    output += shift.Name + " from " + shift.Start + " until " + shift.End + "." + System.Environment.NewLine;
                }
                output += "---------------------------------------------------" + System.Environment.NewLine;
            }
            return output;
        }

        #endregion

        #region search functions

        /// <summary>
        /// Checks if we contain this shift.
        /// </summary>
        /// <param name="day">day of the shift.</param>
        /// <param name="name">name of the shift.</param>
        /// <returns></returns>
        public bool Contains(string day, string name)
        {
            foreach (Shift shift in this._shifts[day])
            {
                if (shift.Name.ToLower() == name.ToLower())
                    return true;
            }

            return false;
        }

        /// <summary>
        /// check we contain this shift.
        /// </summary>
        /// <param name="target">Shift to find.</param>
        /// <returns></returns>
        public bool Contains(Shift target)
        {
            return this.Contains(target.Day, target.Name);
        }

        #endregion
    }
}
