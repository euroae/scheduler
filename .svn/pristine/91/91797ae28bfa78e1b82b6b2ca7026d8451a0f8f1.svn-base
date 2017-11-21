using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftObjects;

namespace scheduler.Utilities
{
    public static class TimeUtilities
    {
        #region fields  list of static fields

        public const int DAYS_IN_WEEK = 7;

        public static List<string> daysOfWeek = new List<string> { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };

        /// <summary>
        /// List of possible hours in military time
        /// </summary>
        public static List<string> hoursMilitary = new List<string>()
        {
	        "0000",
	        "0030",
	        "0100",
	        "0130",
	        "0200",
	        "0230",
	        "0300",
	        "0330",
	        "0400",
	        "0430",
	        "0500",
	        "0530",
	        "0600",
	        "0630",
	        "0700",
	        "0730",                                                                                             
	        "0800",                                                                                             
	        "0830",                                                                                             
	        "0900",                                                                                             
	        "0930",                                                                                             
	        "1000",                                                                                            
	        "1030",                                                                                            
	        "1100",                                                                                            
	        "1130",                                                                                            
	        "1200",                                                                                            
	        "1230",                                                                                            
	        "1300",                                                                                            
	        "1330",                                                                                            
	        "1400",                                                                                            
	        "1430",                                                                                            
	        "1500",                                                                                            
	        "1530",                                                                                            
	        "1600",                                                                                            
	        "1630",                                                                                            
	        "1700",                                                                                            
	        "1730",                                                                                            
	        "1800",                                                                                            
	        "1830",                                                                                            
	        "1900",                                                                                            
	        "1930",                                                                                            
	        "2000",                                                                                            
	        "2030",                                                                                            
	        "2100",                                                                                            
	        "2130",                                                                                            
	        "2200",                                                                                            
	        "2230",
	        "2300",
	        "2330"
        };

        /// <summary>
        /// List of possible hours in Non-Military time
        /// </summary>
        public static List<string> hoursNotMilitary = new List<string>()
        {
            "12:00 A.M.",
	        "12:30 A.M.",
	        "01:00 A.M.",
	        "01:30 A.M.",
	        "02:00 A.M.",
	        "02:30 A.M.",
	        "03:00 A.M.",
	        "03:30 A.M.",
	        "04:00 A.M.",
	        "04:30 A.M.",
	        "05:00 A.M.",
	        "05:30 A.M.",
	        "06:00 A.M.",
	        "06:30 A.M.",
	        "07:00 A.M.",
	        "07:30 A.M.",
	        "08:00 A.M.",
	        "08:30 A.M.",
	        "09:00 A.M.",
	        "09:30 A.M.",
	        "10:00 A.M.",
	        "10:30 A.M.",
	        "11:00 A.M.",
	        "11:30 A.M.",
	        "12:00 P.M.",
	        "12:30 P.M.",
	        "01:00 P.M.",
	        "01:30 P.M.",
	        "02:00 P.M.",
	        "02:30 P.M.",
	        "03:00 P.M.",
	        "03:30 P.M.",
	        "04:00 P.M.",
	        "04:30 P.M.",
	        "05:00 P.M.",
	        "05:30 P.M.",
	        "06:00 P.M.",
	        "06:30 P.M.",
	        "07:00 P.M.",
	        "07:30 P.M.",
	        "08:00 P.M.",
	        "08:30 P.M.",
	        "09:00 P.M.",
	        "09:30 P.M.",
	        "10:00 P.M.",
	        "10:30 P.M.",
	        "11:00 P.M.",
            "11:30 P.M."
        };

        /// <summary>
        /// a mapping of string values representing hours to integers values used for a variety of calculations
        /// for example, determining which hours appear first
        /// </summary>
        public static Dictionary<string, int> hoursMap = new Dictionary<string, int>()
        {
            { "0000", 0},
            { "0030", 1},                                                                                                                                                                                                                                           
            { "0100", 2},                                                                                                                                                                                                                                           
            { "0130", 3},                                                                                                                                                                                                                                           
            { "0200", 4},                                                                                                                                                                                                                                           
            { "0230", 5},                                                                                                                                                                                                                                           
            { "0300", 6},                                                                                                                                                                                                                                           
            { "0330", 7},                                                                                                                                                                                                                                           
            { "0400", 8},                                                                                                                                                                                                                                           
            { "0430", 9},                                                                                                                                                                                                                                           
            { "0500", 10},                                                                                                                                                                                                                                          
            { "0530", 11},                                                                                                                                                                                                                                          
            { "0600", 12},                                                                                                                                                                                                                                          
            { "0630", 13},                                                                                                                                                                                                                                          
            { "0700", 14},                                                                                                                                                                                                                                          
            { "0730", 15},                                                                                                                                                                                                                                          
            { "0800", 16},                                                                                                                                                                                                                                          
            { "0830", 17},                                                                                                                                                                                                                                          
            { "0900", 18},                                                                                                                                                                                                                                          
            { "0930", 19},                                                                                                                                                                                                                                          
            { "1000", 20},                                                                                                                                                                                                                                          
            { "1030", 21},                                                                                                                                                                                                                                          
            { "1100", 22},                                                                                                                                                                                                                                          
            { "1130", 23},                                                                                                                                                                                                                                          
            { "1200", 24},                                                                                                                                                                                                                                          
            { "1230", 25},                                                                                                                                                                                                                                          
            { "1300", 26},                                                                                                                                                                                                                                          
            { "1330", 27},                                                                                                                                                                                                                                          
            { "1400", 28},                                                                                                                                                                                                                                          
            { "1430", 29},                                                                                                                                                                                                                                          
            { "1500", 30},                                                                                                                                                                                                                                          
            { "1530", 31},                                                                                                                                                                                                                                          
            { "1600", 32},                                                                                                                                                                                                                                          
            { "1630", 33},                                                                                                                                                                                                                                          
            { "1700", 34},                                                                                                                                                                                                                                          
            { "1730", 35},                                                                                                                                                                                                                                          
            { "1800", 36},                                                                                                                                                                                                                                          
            { "1830", 37},                                                                                                                                                                                                                                          
            { "1900", 38},                                                                                                                                                                                                                                          
            { "1930", 39},                                                                                                                                                                                                                                          
            { "2000", 40},                                                                                                                                                                                                                                          
            { "2030", 41},                                                                                                                                                                                                                                          
            { "2100", 42},                                                                                                                                                                                                                                          
            { "2130", 43},                                                                                                                                                                                                                                          
            { "2200", 44},                                                                                                                                                                                                                                          
            { "2230", 45},                                                                                                                                                                                                                                          
            { "2300", 46},                                                                                                                                                                                                                                          
            { "2330", 47} 
        };

        public static Dictionary<string, string> intToString = new Dictionary<string, string>()
        {
            { "000", "0000"},
            { "030", "0030"},                                                                                                                                                                                                                                           
            { "100", "0100"},                                                                                                                                                                                                                                           
            { "130", "0130"},                                                                                                                                                                                                                                           
            { "200", "0200"},                                                                                                                                                                                                                                           
            { "230", "0230"},                                                                                                                                                                                                                                           
            { "300", "0300"},                                                                                                                                                                                                                                           
            { "330", "0330"},                                                                                                                                                                                                                                           
            { "400", "0400"},                                                                                                                                                                                                                                           
            { "430", "0430"},                                                                                                                                                                                                                                           
            { "500", "0500"},                                                                                                                                                                                                                                          
            { "530", "0530"},                                                                                                                                                                                                                                          
            { "600", "0600"},                                                                                                                                                                                                                                          
            { "630", "0630"},                                                                                                                                                                                                                                          
            { "700", "0700"},                                                                                                                                                                                                                                          
            { "730", "0730"},                                                                                                                                                                                                                                          
            { "800", "0800"},                                                                                                                                                                                                                                          
            { "830", "0830"},                                                                                                                                                                                                                                          
            { "900", "0900"},                                                                                                                                                                                                                                          
            { "930", "0930"} 
        };

        #endregion

        /// <summary>
        /// Static function that determines if the first supplied time is earlier than second time
        /// </summary>
        /// <param name="time1">Time value supplied as a string and that matches to one of the values in the map</param>
        /// <param name="time2">Time value supplied as a string and that matches to one of the values in the map</param>
        /// <returns>True if time1 is earlier than time2, false otherwise</returns>
        public static bool IsEarlierThan(string time1, string time2)
        {
            // ensure both values are mapped int array and display an error message if not
            if (!hoursMap.ContainsKey(time1) || !hoursMap.ContainsKey(time2))
            {
                DisplayError(time1 + " " + time2 + " were supplied to IsEarlierThan. One or both of the values are not mapped on the dictionary. Remainding Calculations may not be correct.");
                return false;
            }

            if (hoursMap[time1] < hoursMap[time2])
                return true;

            return false;
        }

        /// <summary>
        /// Converts a supplied time to Military
        /// </summary>
        /// <param name="time">Time in non-military format to convert. Must be a value that exists in the lists.</param>
        /// <returns>The corresponding time</returns>
        public static string ConvertToMilitary(string time)
        {
            // check if value time
            if (!hoursNotMilitary.Contains(time))
            {
                DisplayError(time + " was supplied to ConvertToMilitary. One or both of the values are not mapped on the dictionary. Remainding Calculations may not be correct.");
            }

            // return corresponding time in military
            return hoursMilitary[hoursNotMilitary.IndexOf(time)];
        }

        /// <summary>
        /// Converts a supplied time to non-military format
        /// </summary>
        /// <param name="time">Time in military format to convert. Must be a value that exists in the lists.</param>
        /// <returns>The corresponding time</returns>
        public static string ConvertToNonmilitary(string time)
        {
            // check if value time
            if (!hoursMilitary.Contains(time))
            {
                DisplayError(time + " was supplied to ConvertToNonmilitary. One or both of the values are not mapped on the dictionary. Remainding Calculations may not be correct.");
            }

            // return corresponding time in military
            return hoursNotMilitary[hoursMilitary.IndexOf(time)];
        }

        /// <summary>
        /// Calculate the length between 2 times from string format
        /// </summary>
        /// <param name="startTime">Start time in string, military time and no commas format</param>
        /// <param name="Endtime">End time in string, military time and no commas format</param>
        /// <returns>timespan element containing the length of the shift</returns>
        public static System.TimeSpan CalculateLengthOfShift(string startTime, string Endtime)
        {
            int hours = int.Parse(startTime.Substring(0, 2));
            int minutes = int.Parse(startTime.Substring(2, 2));
            System.DateTime start = new System.DateTime(2, 2, 2, hours, minutes, 0);

            hours = int.Parse(Endtime.Substring(0, 2));
            minutes = int.Parse(Endtime.Substring(2, 2));
            System.DateTime end = new System.DateTime(2, 2, 2, hours, minutes, 0);

            return end - start;
        }

        /// <summary>
        /// Takes a time value in string and converts it to a datetime value
        /// </summary>
        /// <param name="time">Time in string, military time and no commas format</param>
        /// <returns>DateTime value of supplied time</returns>
        public static System.DateTime ConvertToDateTime(string time)
        {
            int hours = int.Parse(time.Substring(0, 2));
            int minutes = int.Parse(time.Substring(2, 2));
            return new System.DateTime(2, 2, 2, hours, minutes, 0);
        }

        /// <summary>
        /// Used to display a dialog box with information about an exception being generated than throws a new exception
        /// </summary>
        /// <param name="error">Error message containing additional information to display in addition to generic message</param>
        public static void DisplayError(string error)
        {
            System.Windows.Forms.MessageBox.Show("Error in TimeUtilities.cs. Error Message: " + error);
            throw new Exception();
        }

        /// <summary>
        /// Check if first shift is before second shift. Compares only start times of shift. Scheduleslot version
        /// </summary>
        /// <param name="first">The first shift.</param>
        /// <param name="second">The second shift.</param>
        /// <returns>True if first shift is before second shift, else false.</returns>
        public static bool IsEarlier(ScheduleSlot first, ScheduleSlot second)
        {
            return IsEarlier(first._shiftInfo, second._shiftInfo);
        }

        /// <summary>
        /// Check if first shift is before second shift. Compares only start times of shift.
        /// </summary>
        /// <param name="first">The first shift.</param>
        /// <param name="second">The second shift.</param>
        /// <returns>True if first shift is before second shift, else false.</returns>
        public static bool IsEarlier(Shift first, Shift second)
        {
            if (int.Parse(first.Start) <= int.Parse(second.Start))
            {
                return true;
            }
            return false;
        }
    }
}
