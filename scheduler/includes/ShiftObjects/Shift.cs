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
    /// a structure containing information common to all types of shifts
    /// </summary>
    [Serializable()]
    public class Shift : ISerializable
    {
        // public fields
        private string       _shiftName;  // name of shift - this must match closely with the list of job types
        private string       _day;        // day of week this shift is on
        private string       _startTime;  // start time for this shift in military format, as a string, with no ':'
        private string       _endTime;    // end time for this shift in military format, as a string, with no ':'
        private DateTime     _date;
        private uint         _shiftNumber;
        private string      _when;

        #region serialization functions

        public Shift(SerializationInfo info, StreamingContext ctxt)
        {
            this._shiftName     = (string)info.GetValue("shiftName", typeof(string));
            this._day           = (string)info.GetValue("day", typeof(string));
            this._startTime     = (string)info.GetValue("startTime", typeof(string));
            this._endTime       = (string)info.GetValue("endTime", typeof(string));
            this._date          = (DateTime)info.GetValue("date", typeof(DateTime));
            this._shiftNumber   = 0;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("shiftName", this._shiftName);
            info.AddValue("day", this._day);
            info.AddValue("startTime", this._startTime);
            info.AddValue("endTime", this._endTime);
            info.AddValue("date", this._date);
        }

        #endregion
        
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="shiftName">name of the shift.</param>
        /// <param name="day">day of the shift</param>
        /// <param name="startTime">start time for this shift in military format, as a string, with no ':'</param>
        /// <param name="endTime">end time for this shift in military format, as a string, with no ':'</param>
        public Shift(string shiftName, string day, string startTime, string endTime, uint shiftNumber, DateTime date)
        {
            this._shiftName = shiftName.ToLower();
            this._day = day.ToLower();
            this._startTime = startTime.ToLower();
            this._endTime = endTime.ToLower();
            this._shiftNumber = shiftNumber;
            this._date = date;
        }

        public Shift()
        {
            this._shiftName = "";
            this._day = "";
            this._startTime = "";
            this._endTime = "";
            this._shiftNumber = uint.MaxValue;
            this._date = new DateTime();
        }

        #region get set functions


        /// <summary>
        /// Name of Shift.
        /// </summary>
        public uint ShiftNumber
        {
            get { return this._shiftNumber; }
            set { this._shiftNumber = value; }
        }

        /// <summary>
        /// Name of Shift.
        /// </summary>
        public string Name
        {
            get { return _shiftName; }
            set { _shiftName = value; }
        }

        /// <summary>
        /// Type of shift.
        /// </summary>
        public string Type
        {
            get 
            {
                return Utilities.TrimTrailingNumbers(_shiftName.Split(' ')[0]).ToLower(); 
            }
        }

        /// <summary>
        /// Day shift is on.
        /// </summary>
        public string Day
        {
            get { return _day; }
            set { _day = value; }
        }

        /// <summary>
        /// When is this shift, morning, noon, afternoon, night
        /// </summary>
        /// <returns></returns>
        public string When()
        {
            // calculate when
            if (int.Parse(this._startTime) < 1200)
            {
                this._when = "mo";
            }
            else if (int.Parse(this._startTime) >= 1200 && int.Parse(this._startTime) < 1500)
            {
                this._when = "no";
            }
            else if (int.Parse(this._startTime) >= 1500 && int.Parse(this._startTime) < 1800)
            {
                this._when = "af";
            }
            else if (int.Parse(this._startTime) >= 1800)
            {
                this._when = "ni";
            }

            return this._when;
        }

        /// <summary>
        /// Start time of shift.
        /// </summary>
        public string Start
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        /// <summary>
        /// End time of shift.
        /// </summary>
        public string End
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        /// <summary>
        /// Start time of shift in time object.
        /// </summary>
        public DateTime StartTime
        {
            get { return TimeUtilities.ConvertToDateTime(this._startTime); }
        }

        /// <summary>
        /// End time of shift in time object
        /// </summary>
        public DateTime EndTime
        {
            get { return TimeUtilities.ConvertToDateTime(this._endTime); }
        }

        public DateTime Date
        {
            get { return this._date; }
        }

        /// <summary>
        /// Length of shift
        /// </summary>
        public TimeSpan Length
        {
            get { return TimeUtilities.CalculateLengthOfShift(this._startTime, this._endTime); }
        }

        #endregion

        public override string ToString()
        {
            return ("" + System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(this.Type) + " " + this.Day + " from " + this.Start + " to " + this.End + ".");
        }

        public bool Equals(Shift obj)
        {
            if (this.ShiftNumber == obj.ShiftNumber)
            {
                return true;
            }

            return false;
        }
    }
}
