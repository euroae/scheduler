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
    [Serializable()]
    public class GroupOfSlots : ISerializable
    {
        // public fields
        // Dictionary holding schedule slots. Key is a string and should be the days of the week -> therefore there should be a total 7 of List's containing schedule slots
        public Dictionary<string, List<ScheduleSlot>> _shifts;
       
        // private fields
        private int _count;

        #region serialization functions

        public GroupOfSlots(SerializationInfo info, StreamingContext ctxt)
        {
            this._shifts = (Dictionary<string, List<ScheduleSlot>>)info.GetValue("shifts", typeof(Dictionary<string, List<ScheduleSlot>>));
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
        public GroupOfSlots()
        {
            this.InitializeDS();
        }

        /// <summary>
        /// Initializes datastructure
        /// </summary>
        private void InitializeDS()
        {
            // initialize the DS
            this._shifts = new Dictionary<string, List<ScheduleSlot>>();
            // populate with keys and empty Lists
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                // initialize the list
                List<ScheduleSlot> temp = new List<ScheduleSlot>();
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
            for (int x = 0; x <= TimeUtilities.daysOfWeek.Count; x++)
            {
                // clear it
                _shifts[TimeUtilities.daysOfWeek[x]].Clear();
            }
        }

        /// <summary>
        /// adds new shift in ordered form.
        /// </summary>
        /// <param name="shift">new shift.</param>
        public void AddInOrder(ScheduleSlot shift)
        {
            // case 1 - no other shifts added for this day yet, just add it
            if (this._shifts[shift._shiftInfo.Day].Count == 0)
            {
                this._shifts[shift._shiftInfo.Day].Add(shift);
                this._count++;
                return;
            }


            // case 2 - shifts already exist
            int insertAt = -1;
            // go through each element until we find the position to insert at
            foreach (ScheduleSlot existing in this._shifts[shift._shiftInfo.Day])
            {
                // check if new shift is earlier than existing
                if (TimeUtilities.IsEarlier(shift, existing))
                {
                    insertAt = this._shifts[shift._shiftInfo.Day].IndexOf(existing);
                    break;
                }
            }

            // check if we found place to insert at
            if (insertAt == -1)
            {
                // insert at end, all exisiting shifts are earlier than this one
                this._shifts[shift._shiftInfo.Day].Add(shift);
                this._count++;
            }
            else
            {
                // found somewhere to insert at and insert there.
                this._shifts[shift._shiftInfo.Day].Insert(insertAt, shift);
                this._count++;
            }
        }

        /// <summary>
        /// Add a new shift to end of list.
        /// </summary>
        /// <param name="shift">new shift.</param>
        public void Add(ScheduleSlot shift)
        {
            this._shifts[shift._shiftInfo.Day].Add(shift);
        }

        /// <summary>
        /// removes a specified shift from dictionary.
        /// </summary>
        /// <param name="target"></param>
        public void Remove(ScheduleSlot target)
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
        public List<ScheduleSlot> ReturnShiftsForDay(string day)
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
        public List<ScheduleSlot> ToList()
        {
            // output
            List<ScheduleSlot> output = new List<ScheduleSlot>();

            // for each day of the week
            foreach (List<ScheduleSlot> listOfShifts in this._shifts.Values)
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
                foreach (ScheduleSlot shift in this._shifts[daysOfWeek[x]])
                {
                    output += shift._shiftInfo.Name + " from " + shift._shiftInfo.Start + " until " + shift._shiftInfo.End;
                    output += ". This shift requires " + shift.EmployeeNeededCount + " and has " + shift.EmployeeWorkingCount + " people working." + System.Environment.NewLine;
                }
                output += "---------------------------------------------------" + System.Environment.NewLine;
            }
            return output;
        }

        /// <summary>
        /// gets shift at index.
        /// </summary>
        /// <param name="index">Index of shift we want.</param>
        /// <returns>The shift or null.</returns>
        public ScheduleSlot AtIndex(int index)
        {
            return this.ToList()[index];
        }

        /// <summary>
        /// Calculates the number of hours available to distribute
        /// </summary>
        /// <returns>A timespan count of total hours</returns>
        public TimeSpan TotalHoursAvailable()
        {
            TimeSpan output = new TimeSpan();

            foreach (ScheduleSlot shift in this.ToList())
            {
                output += new TimeSpan(shift.Length.Ticks * shift.EmployeeNeededCount);
            }

            return output;
        }

        /// <summary>
        /// Calculates the number of hours available allocated
        /// </summary>
        /// <returns>A timespan count of total hours</returns>
        public TimeSpan TotalHoursAllocated()
        {
            TimeSpan output = new TimeSpan();

            foreach (ScheduleSlot shift in this.ToList())
            {
                output += new TimeSpan(shift.Length.Ticks * shift.EmployeeWorkingCount);
            }

            return output;
        }

        /// <summary>
        /// Returns a list of shifts that have start times before the supplied time and occur on the supplied day. after is less than before
        /// </summary>
        /// <param name="after">start time is after this time</param>
        /// <param name="before">We should only return shifts that occur before this time</param>
        /// <param name="day">Return shifts that occur on this day</param>
        /// <returns>list of schedule slots that conform to the selected rules</returns>
        public List<ScheduleSlot> ReturnShiftsBetweenForDay(int after, int before, string day)
        {
            // output
            List<ScheduleSlot> output = new List<ScheduleSlot>();

            // go through all schedule slots for the selected day
            foreach (ScheduleSlot element in this._shifts[day])
            {
                // if this shifts start time is before the supplied value, add it to the output
                if (int.Parse(element.Start) < before && int.Parse(element.Start) >= after)
                {
                    output.Add(element);
                }
            }

            return output;
        }

        /// <summary>
        /// Return shifts between these time points. after is less than before
        /// </summary>
        /// <param name="after">start time is after this time</param>
        /// <param name="before">start time is before this time</param>
        /// <returns>list of shifts</returns>
        public List<List<ScheduleSlot>> ReturnShiftsBetween(int after, int before)
        {
            // output
            List<List<ScheduleSlot>> output = new List<List<ScheduleSlot>>();

            // loop once per day of the week
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                // get all shifts that conform to rule for this day
                output.Add(this.ReturnShiftsBetweenForDay(after, before, TimeUtilities.daysOfWeek[x]));
            }

            return output;
        }

        #endregion

        #region search functions

        /// <summary>
        /// Checks if we contain this shift adn returns it.
        /// </summary>
        /// <param name="day">day of the shift.</param>
        /// <param name="name">name of the shift.</param>
        /// <returns>The shift in question otherwise null</returns>
        public ScheduleSlot Return(string day, string name)
        {
            foreach (ScheduleSlot shift in this._shifts[day])
            {
                if (shift._shiftInfo.Name == name.ToLower())
                    return shift;
            }

            return null;
        }

        /// <summary>
        /// Checks if we contain this shift.
        /// </summary>
        /// <param name="day">day of the shift.</param>
        /// <param name="name">name of the shift.</param>
        /// <returns></returns>
        public bool Contains(string day, string name)
        {
            foreach (ScheduleSlot shift in this._shifts[day])
            {
                if (shift._shiftInfo.Name == name.ToLower())
                    return true;
            }

            return false;
        }

        /// <summary>
        /// check we contain this shift.
        /// </summary>
        /// <param name="target">Shift to find.</param>
        /// <returns></returns>
        public bool Contains(ScheduleSlot target)
        {
            return this.Contains(target._shiftInfo.Day, target._shiftInfo.Name);
        }

        #endregion
    }
}
