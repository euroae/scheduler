using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SchedulingObjects;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace scheduler.Utilities
{
    /// <summary>
    /// Utility class for performing file reading/writing
    /// </summary>
    public static class FileIO
    {
        #region reads functions used to read from file

        /// <summary>
        /// Read from a file at location
        /// </summary>
        /// <param name="fileLocation">location of file.</param>
        /// <returns>contents of file.</returns>
        public static string ReadFromFile(string fileLocation)
        {
            // check if file exists
            if (File.Exists(fileLocation))
            {
                // open, read and return the data if it does.
                return File.ReadAllText(fileLocation);
            }
            else
            {
                // else throw an exception
                throw new FileNotFoundException("File not found at " + fileLocation);
            }
        }

        /// <summary>
        /// Saves scheduler object to file
        /// </summary>
        /// <param name="filename">location to save</param>
        /// <param name="objectToSerialize">object to save</param>
        public static void SaveSchedulerObject(string filename, Schedule objectToSerialize)
        {
            try
            {
                Stream stream = File.Open(filename, FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, objectToSerialize);
                stream.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error while trying to write text to file. Error message: " + ex.Message + "." + System.Environment.NewLine
                    + "You can probably safely ignore this message but nothing has been saved to file.");
            }
        }

        /// <summary>
        /// Loads scheduler obecjt from file
        /// </summary>
        /// <param name="filename">location of save</param>
        /// <returns>Schedule object</returns>
        public static Schedule LoadSchedulerObject(string filename)
        {
            Schedule objectToSerialize = new Schedule();
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (Schedule)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }

        #endregion

        #region writes functions that write to file

        /// <summary>
        /// Writes to file overwriting everything.
        /// </summary>
        /// <param name="fileLocation">location of file</param>
        /// <param name="output">data in string format to write to file.</param>
        public static void WriteToFile(string fileLocation, string output)
        {
            // check if file exists
            try
            {
                File.WriteAllText(fileLocation, output);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error while trying to write text to file. Error message: " + ex.Message);
            }

        }

        /// <summary>
        /// Writes to file appending it to the end.
        /// </summary>
        /// <param name="fileLocation">location of file</param>
        /// <param name="output">data in string format to write to file.</param>
        public static void AppendToFile(string fileLocation, string output)
        {
            try
            {
                File.AppendAllText(fileLocation, output);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error while trying to append text to file. Error message: " + ex.Message);
            }
        }

        #endregion
    }
}
