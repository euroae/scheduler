using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using scheduler.Utilities;
using ShiftObjects;

namespace scheduler.includes.DataObjects
{
    class ShiftSkeletonOld
    {
        public Dictionary<string, List<ShiftSlotOld>>      shiftSlots;
        public int                                      maxHours;
        public int                                      minHours;

        // information about this skeleton
        public string                                   author;
        public string                                   startDay;
        public string                                   endDay;
        public string                                   payDay;
        public int                                      scheduleID;

        public int                                      totalShiftsAvailabile;
        public int                                      totalShiftsFilled;

        /// <summary>
        /// default constructor
        /// </summary>
        public ShiftSkeletonOld()
        {
            Load();
        }

        /// <summary>
        /// Constructor with arguements
        /// </summary>
        /// <param name="fileLocation">Location of skeleton shift file</param>
        public ShiftSkeletonOld(string input)
        {
            Load();
            LoadSkeleton(input);
        }

        /// <summary>
        /// Loads schedule skeleton from text file
        /// </summary>
        /// <param name="fileLocation">Location of the file</param>
        /// <returns>Raw shift skeleton data</returns>
        private string LoadSkeletonRaw(string fileLocation)
        {
            try
            {
                return FileIO.ReadFromFile(fileLocation);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return "";
            }
        }

        /// <summary>
        /// Use to initialize the datastructure and set values to initial values
        /// </summary>
        private void Load()
        {
            // initialize the DS
            shiftSlots = new Dictionary<string, List<ShiftSlotOld>>();
            // populate with keys and empty Lists
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                // initialize the list
                List<ShiftSlotOld> temp = new List<ShiftSlotOld>();
                // add everything into the DS
                shiftSlots.Add(TimeUtilities.daysOfWeek[x], temp);
            }

            // default shifts available and filled
            totalShiftsAvailabile = 0;
            totalShiftsFilled = 0;

            // default minimum and maximum
            maxHours = 15;
            minHours = 3;
        }

        public void LoadSkeleton(string fileLocation, bool whoCares)
        {
            this.LoadSkeleton(this.LoadSkeletonRaw(fileLocation));
        }

        /// <summary>
        /// Used to actually load the data into memory
        /// </summary>
        public void LoadSkeleton(string input)
        {
            // Variables required to process input
            // a copy of the array of lists of days
            List<string> daysOfWeek = TimeUtilities.daysOfWeek;
            // holds semi-processed data
            List<string> splitRawData = new List<string>();

            // raw input
            string rawData = input;
            
            // if there was an error loading the data or file is empty
            if (rawData == "")
            {
                return;
            }


            // remove all the extra whitespaces
            rawData = rawData.Trim();
            // temporary hold the raw data split by newline character
            string[] temp = rawData.Split('\n');
            

            // loop through split string and extract the useful information omitting not useful data
            for (int x = 0; x < temp.Length; x++)
            {
                // check if this commented out and skip this iteration if it is
                if (temp[x] == "" || temp[x][0] == '#' ||  temp[x] == System.Environment.NewLine || temp[x] == "\r") continue;

                splitRawData.Add(temp[x].Trim());
            }

            // extract the main useful data
            author = splitRawData[1];
            startDay = splitRawData[2];
            endDay = splitRawData[3];
            scheduleID = Int32.Parse(splitRawData[4]);
            payDay = splitRawData[5];

            // now extract the remaining data

            // start at this position
            int rawDataLoop = 8;
            // loop once per day of the week
            for (int x = 0; x < daysOfWeek.Count; x++)
            {
                // get the list for the current day
                List<ShiftSlotOld> loadInProgress = shiftSlots[daysOfWeek[x]];

                // while the current line isn't a closing day for this day of the week ie "</monday>"
                while (!splitRawData[rawDataLoop].Contains("/" + daysOfWeek[x]))
                {
                    // used to ignore opening tags i.e. "<monday>"
                    if (!splitRawData[rawDataLoop].Contains(daysOfWeek[x]))
                    {
                        // create a new shift slot object and populate with the approperiate data
                        ShiftSlotOld newSlot = new ShiftSlotOld();
                        
                        // split line by ','
                        temp = splitRawData[rawDataLoop].Split(',');
                        
                        // only process if there are 4 or more items post-split
                        if (!(temp.Length < 4))
                        {
                            // populate data
                            newSlot.shiftName = temp[0].Trim();
                            newSlot.day = daysOfWeek[x];
                            if (Int32.Parse(temp[1]) < 1000) { newSlot.startHour = "0" + temp[1].Trim(); } else { newSlot.startHour = temp[1].Trim(); }

                            if (Int32.Parse(temp[2]) < 1000) { newSlot.endHour = "0" + temp[2].Trim(); } else { newSlot.endHour = temp[2].Trim(); }
                            newSlot._employeesRequired = Int32.Parse(temp[3].Trim());

                            // add to list
                            loadInProgress.Add(newSlot);

                            // increment count of shifts
                            totalShiftsAvailabile += newSlot._employeesRequired;
                        }
                    }
                    // increment loop value
                    rawDataLoop++;
                }
            }

            rawData = null;
        }

        public override string ToString()
        {
            string output = "";

            List<string> daysOfWeek = TimeUtilities.daysOfWeek;

            // main info
            output += "Schedule for " + this.startDay + " until " + this.endDay + ". Created by " + this.author + System.Environment.NewLine + "There are a total of " + this.totalShiftsAvailabile + " for this schedule." + System.Environment.NewLine;
            output += "---------------------------------------------------" + System.Environment.NewLine;

            // per day
            for (int x = 0; x < daysOfWeek.Count; x++)
            {
                output += "Displaying shifts for " + daysOfWeek[x] + System.Environment.NewLine;
                // per shift
                foreach (ShiftSlotOld shift in shiftSlots[daysOfWeek[x]])
                {
                    output += shift.shiftName + " from " + shift.startHour + " until " + shift.endHour + " and we need up to " + shift._employeesRequired + " employees can work this shift." + System.Environment.NewLine;
                }
                output += "---------------------------------------------------" + System.Environment.NewLine;
            }
            return output;
        }

        public List<ShiftSlotOld> MergeDictionaryToList()
        {
            List<ShiftSlotOld> output = new List<ShiftSlotOld>();

            foreach (List<ShiftSlotOld> listOfShifts in shiftSlots.Values)
            {
                output.AddRange(listOfShifts);
            }

            return output;
        }

        public ShiftSlotOld FindThisShiftSlot(string day, string name)
        {
            foreach (ShiftSlotOld shift in this.shiftSlots[day])
            {
                if (shift.shiftName == name)
                    return shift;
            }

            return null;
        }

        #region assignment_unassignment_of_shifts

        public TimeSpan AssignShift(string shiftName, string employee)
        {

            return new TimeSpan(0);
        }

        #endregion
    }
}
