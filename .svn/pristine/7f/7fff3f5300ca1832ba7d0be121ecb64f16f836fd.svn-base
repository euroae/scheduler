using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scheduler.Utilities;

namespace scheduler.includes.DataObjects
{
    /// <summary>
    /// Shift class used to denote shift slots on a schedule
    /// shiftName: name of shift/type of shift
    /// startTime: Time this shift starts at
    /// endTime: time this shift ends at
    /// </summary>
    class ShiftOld
    {
        // Name of this shift
        public string shiftName;

        public string day;
	
        // Start time for this shift
        public string startHour;
	
        // End time for this shift
        public string endHour;

        // length of shift
        public System.TimeSpan lengthShift;

        /// <summary>
        /// Constructor that takes supplied data.
        /// </summary>
        /// <param name="_shiftName">name for this shift</param>
        /// <param name="_startHour">start time</param>
        /// <param name="_endHour">end time</param>
        public ShiftOld(string _shiftName, string _startHour, string _endHour, string _day)
        {
            shiftName  = _shiftName;
            startHour  = _startHour;
            endHour    = _endHour;
            day        = _day;
            CalculateShiftLength();
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ShiftOld()
        {
            shiftName   = "Not Set";
            startHour   = "0000";
            endHour     = "0000";
            CalculateShiftLength();
        }

        private void CalculateShiftLength()
        {
            lengthShift = TimeUtilities.CalculateLengthOfShift(this.startHour, this.endHour);
        }

        /// <summary>
        ///  overridden ToString class. Format internal data into a string for your reading pleasure
        /// </summary>
        /// <returns>The eye pleasing string</returns>
        public override string ToString()
        {
            string output = "";

            output += this.shiftName + " from " + this.startHour + " Till " + this.endHour;

            return output;
        }
    }
}
