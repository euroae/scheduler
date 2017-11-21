using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using scheduler.includes;
using scheduler.includes.DataObjects;
using scheduler.Utilities;
using ShiftObjects;
using SchedulingObjects;
using EmployeeObjects;

namespace scheduler
{
    public partial class Form1 : Form
    {
        // Database connection 
        DBConnect dbConnect;

        ShiftSkeletonOld testObject;
        //SchedulingOld schedule;

        Schedule schedule;

        public Form1()
        {
            InitializeComponent();
            testObject = new ShiftSkeletonOld();
            testObject.LoadSkeleton("shiftskeleton.txt", true);
            txOutput.Text = testObject.ToString();

            // initialize

            // the following set of lines of code is used to set up the listview objects in the GUI so that it displays the list vertically instead of horizontally
            // by default it will display the list similar to how the "list" view in windows explorer does

            // ensure that we can still scroll
            lstShifts.Scrollable = true;
            // change view type
            lstShifts.View = View.Details;
            // create a new header with no title so it doesn't appea to end user
            ColumnHeader header = new ColumnHeader();
            header.Text = "Shifts to fill.";
            header.Name = "col1";
            // attach the header
            lstShifts.Columns.Add(header);
            // resizes column size automatically so we can see all the text
            lstShifts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // ensure that we can still scroll
            lstAvailPreview.Scrollable = true;
            // change view type
            lstAvailPreview.View = View.Details;
            // create a new header with no title so it doesn't appea to end user
            ColumnHeader header2 = new ColumnHeader();
            header2.Text = "** Availability For \"The Van\" **";
            header2.Name = "col1";
            header2.TextAlign = HorizontalAlignment.Center;
            // attach the header
            lstAvailPreview.Columns.Add(header2);
            // resizes column size automatically so we can see all the text
            lstAvailPreview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // ensure that we can still scroll
            lstEmployees.Scrollable = true;
            // change view type
            lstEmployees.View = View.LargeIcon;
            // create a new header with no title so it doesn't appea to end user
            /*ColumnHeader header3 = new ColumnHeader();
            header3.Text = "** All Employees And Hours Working **";
            header3.Name = "col1";
            header3.Width = 200;
            header3.TextAlign = HorizontalAlignment.Center;
            // attach the header
            lstEmployees.Columns.Add(header3);*/
            // resizes column size automatically so we can see all the text
            lstEmployees.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // ensure that we can still scroll
            lstConflicts.Scrollable = true;
            // change view type
            lstConflicts.View = View.Details;
            // create a new header with no title so it doesn't appea to end user
            ColumnHeader header4 = new ColumnHeader();
            header4.Text = "";
            header4.Name = "col1";
            header4.TextAlign = HorizontalAlignment.Center;
            // attach the header
            lstConflicts.Columns.Add(header4);
            // resizes column size automatically so we can see all the text
            lstConflicts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // ensure that we can still scroll
            this.lstAssigned.Scrollable = true;
            // change view type
            lstAssigned.View = View.Details;
            // create a new header with no title so it doesn't appea to end user
            ColumnHeader header5 = new ColumnHeader();
            header5.Text = "";
            header5.Name = "col1";
            header5.TextAlign = HorizontalAlignment.Center;
            // attach the header
            lstAssigned.Columns.Add(header5);
            // resizes column size automatically so we can see all the text
            lstAssigned.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // ensure that we can still scroll
            this.lstUnassigned.Scrollable = true;
            // change view type
            lstUnassigned.View = View.Details;
            // create a new header with no title so it doesn't appea to end user
            ColumnHeader header6 = new ColumnHeader();
            header6.Text = "";
            header6.Name = "col1";
            header6.TextAlign = HorizontalAlignment.Center;
            // attach the header
            lstUnassigned.Columns.Add(header6);
            // resizes column size automatically so we can see all the text
            lstUnassigned.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // add context menus to richtextboxes
            LoadContextMenus();
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            //webAccessUtilities temp = new webAccessUtilities();

            //txOutput.Text = temp.RunCommand("SELECT * FROM public_info", ";");
                //temp.DownloadFile("sched", "temppa55", "publish.yorku.ca/MyWebSite/sched2/config/shiftskeleton.txt", "shiftskeleton.txt");
            //temp.TestCommand();
            //temp.GetDataFor("http://www.yorku.ca/schedule/sched2/config/shiftskeleton.txt", txUsername.Text, txPassword.Text);

            /*testRoster = new Roster();
            testRoster.LoadEmployees(rtbAvail.Text);*/

            /*schedule = new SchedulingOld(this.rtbAvail.Text, this.rtbSkeleton.Text);

            schedule.MatchShifts();

            txOutput.Text = schedule.PrintMatchedShifts();*/

            //Schedule testing = new Schedule(this.rtbSkeleton.Text);

            DisplayPreview();
        }

        /// <summary>
        /// Closes application when someone goes to file -> exit
        /// </summary>
        private void fileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Test connection and load.
        /// </summary>
        private void btTestConnection_EnterPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // call function if enter was pressed
                btTestConnection_Click(sender, e);
            }
        }

        /// <summary>
        /// Test connection and load. Gets configuration data from mysql database and populates the fields
        /// </summary>
        private void btTestConnection_Click(object sender, EventArgs e)
        {
            try // Attempt this section of code
            {
                // initialize the db object
                dbConnect = new DBConnect(txDBHostName.Text, txDBName.Text, txDBPass.Text, txDBName.Text);

                // create the query string
                string query = "SELECT * FROM schedulerconfig";

                // run command and get output
                string[] fromDB = dbConnect.RunCommand(query, ";").Split('\n');

                // loop through each line from the database and populate the respective field with the data.
                foreach (string temp in fromDB)
                {
                    // split the config data from database into it's seperate 
                    string[] temp2 = temp.ToLower().Split(';');
                    // switch statement, runs a specific set of instructions depending on which line this is from config database
                    switch (temp2[0])
                    {
                        case "skeleton":
                            txSkeletonLoc.Text = temp2[1];
                            break;
                        case "availability":
                            txAvailLoc.Text = temp2[1];
                            break;
                        case "incomplete":
                            txSaveLoc.Text = temp2[1];
                            break;
                        case "minhours":
                            txMinHours.Text = temp2[1];
                            break;
                        case "maxhours":
                            txMaxHours.Text = temp2[1];
                            break;
                        case "sweet":
                            txSweet.Text = temp2[1];
                            break;
                        case "highp":
                            this.txHigh.Text = temp2[1];
                            break;
                        case "mediump":
                            this.txMedium.Text = temp2[1];
                            break;
                        case "lowp":
                            this.txLow.Text = temp2[1];
                            break;
                        case "highpv":
                            this.txHighV.Text = temp2[1];
                            break;
                        case "mediumpv":
                            this.txMediumV.Text = temp2[1];
                            break;
                        case "lowpv":
                            this.txLowV.Text = temp2[1];
                            break;
                        case "hourmod":
                            this.txHourMod.Text = temp2[1];
                            break;
                        case "priority":
                            this.txPriority.Text = temp2[1];
                            break;
                        case "availmod":
                            this.txAvailMod.Text = temp2[1];
                            break;
                        default:
                            break;
                    }
                }

                // ensures the DB connect is open and changes status label color
                if (dbConnect.IsReady()) { 
                    msDBStatus.BackColor = System.Drawing.Color.Lime; 
                    // enable buttons
                    btUpdateFileLoc.Enabled = true;
                    btDownloadFresh.Enabled = true;
                }

                // load and display the text files
                rtbSkeleton.Text = FileIO.ReadFromFile(txSkeletonLoc.Text);
                rtbAvail.Text = FileIO.ReadFromFile(txAvailLoc.Text);

                // if blank out isnt checked, load previous information
                if (!cbBlankIt.Checked)
                {
                    // load it
                    this.schedule = new Schedule();
                    this.schedule = FileIO.LoadSchedulerObject(this.txSaveLoc.Text);

                    // update displays
                    // bind the list of shift slots to listbox
                    this.ReloadShiftsToList();
                    this.UpdateEmployeeHoursView();
                    this.UpdateHoursAvailabilityDisplay();
                    this.lbEmployeeCount.Text = this.schedule._employees.Count + " Employees.";
                    this.UpdateConflicts();
                }
            }
            catch (Exception ex)
            {
                msDBStatus.BackColor = System.Drawing.Color.Red;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Opens file dialog box for availability file location.
        /// </summary>
        private void btAvailLoc_Click(object sender, EventArgs e)
        {
            // set it to current location from DB
            ofdAvail.FileName = txAvailLoc.Text;
            ofdAvail.InitialDirectory = System.IO.Path.GetDirectoryName(txAvailLoc.Text);

            // open the dialog box
            ofdAvail.ShowDialog();

            // put the new one
            txAvailLoc.Text = ofdAvail.FileName;
        }

        /// <summary>
        /// Opens file dialog box for shift skeleton file location.
        /// </summary>
        private void btSkeletonLoc_Click(object sender, EventArgs e)
        {
            // set it to current location from DB
            ofdSkeleton.FileName = txSkeletonLoc.Text;
            ofdSkeleton.InitialDirectory = System.IO.Path.GetDirectoryName(txSkeletonLoc.Text);

            // open the dialog box
            ofdSkeleton.ShowDialog();

            // put the new one
            txSkeletonLoc.Text = ofdSkeleton.FileName;
        }

        /// <summary>
        /// Opens file dialog box for save file location.
        /// </summary>
        private void btSaveLoc_Click(object sender, EventArgs e)
        {
            // set it to current location from DB
            ofdSave.FileName = txSaveLoc.Text;
            ofdSave.InitialDirectory = System.IO.Path.GetDirectoryName(txSaveLoc.Text);

            // open the dialog box
            ofdSave.ShowDialog();

            // put the new one
            txSaveLoc.Text = ofdSave.FileName;
        }

        /// <summary>
        /// Updates/saves the file locations on the mysql database
        /// </summary>
        private void btUpdateFileLoc_Click(object sender, EventArgs e)
        {
            try
            {
                // create the query string
                string query = "UPDATE schedulerconfig SET information =\"" + txSkeletonLoc.Text.Replace("\\", "/") + "\" WHERE name='skeleton'";
                dbConnect.RunCommand(query, ";");

                query = "UPDATE schedulerconfig SET information =\"" + txAvailLoc.Text.Replace("\\", "/") + "\" WHERE name='availability'";
                dbConnect.RunCommand(query, ";");

                query = "UPDATE schedulerconfig SET information =\"" + txSaveLoc.Text.Replace("\\", "/") + "\" WHERE name='incomplete'";
                dbConnect.RunCommand(query, ";");

                int ignoreMe;
                double doubleIgnore;
                // create the query string
                if (!int.TryParse(txMinHours.Text, out ignoreMe)) { throw new Exception("Not a number in minimum hours field."); }
                query = "UPDATE schedulerconfig SET information =\"" + txMinHours.Text + "\" WHERE name='minhours'";
                dbConnect.RunCommand(query, ";");

                if (!int.TryParse(txMaxHours.Text, out ignoreMe)) { throw new Exception("Not a number in minimum hours field."); }
                query = "UPDATE schedulerconfig SET information =\"" + txMaxHours.Text + "\" WHERE name='maxhours'";
                dbConnect.RunCommand(query, ";");

                if (!int.TryParse(txSweet.Text, out ignoreMe)) { throw new Exception("Not a number in sweet hours field."); }
                query = "UPDATE schedulerconfig SET information =\"" + txSweet.Text + "\" WHERE name='sweet'";
                dbConnect.RunCommand(query, ";");

                query = "UPDATE schedulerconfig SET information =\"" + this.txHigh.Text + "\" WHERE name='highp'";
                dbConnect.RunCommand(query, ";");

                query = "UPDATE schedulerconfig SET information =\"" + this.txMedium.Text + "\" WHERE name='mediump'";
                dbConnect.RunCommand(query, ";");

                query = "UPDATE schedulerconfig SET information =\"" + this.txLow.Text + "\" WHERE name='lowp'";
                dbConnect.RunCommand(query, ";");

                if (!int.TryParse(txHighV.Text, out ignoreMe)) { throw new Exception("Not a number in high priority field."); }
                query = "UPDATE schedulerconfig SET information =\"" + this.txHighV.Text + "\" WHERE name='highpv'";
                dbConnect.RunCommand(query, ";");

                if (!int.TryParse(txMediumV.Text, out ignoreMe)) { throw new Exception("Not a number in medium priority field."); }
                query = "UPDATE schedulerconfig SET information =\"" + this.txMediumV.Text + "\" WHERE name='mediumpv'";
                dbConnect.RunCommand(query, ";");

                if (!int.TryParse(txLowV.Text, out ignoreMe)) { throw new Exception("Not a number in low priority field."); }
                query = "UPDATE schedulerconfig SET information =\"" + this.txLowV.Text + "\" WHERE name='lowpv'";
                dbConnect.RunCommand(query, ";");

                if (!double.TryParse(txHourMod.Text, out doubleIgnore)) { throw new Exception("Not a number in Hour Modifier field."); }
                query = "UPDATE schedulerconfig SET information =\"" + this.txHourMod.Text + "\" WHERE name='hourmod'";
                dbConnect.RunCommand(query, ";");

                if (!double.TryParse(txAvailMod.Text, out doubleIgnore)) { throw new Exception("Not a number in Avail Modifier field."); }
                query = "UPDATE schedulerconfig SET information =\"" + this.txAvailMod.Text + "\" WHERE name='availmod'";
                dbConnect.RunCommand(query, ";");

                query = "UPDATE schedulerconfig SET information =\"" + this.txPriority.Text + "\" WHERE name='priority'";
                dbConnect.RunCommand(query, ";");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Downloads fresh availability from the mysql data formatted in the required format.
        /// </summary>
        private void btDownloadFresh_Click(object sender, EventArgs e)
        {
            // display box ensuring this is what user wants to do.
            DialogResult dialogResult = MessageBox.Show("Downloading fresh availability will clear the current availability saved, are you sure you want to do this?", "Notice", MessageBoxButtons.YesNo);
            
            // if they do
            if (dialogResult == DialogResult.Yes)
            {
                // first get the availability info
                // create query
                string query = "SELECT `index`, `username`, `nick_name`, `position_title`, `can_work` FROM admin_table;";
                // get data, split by each employee
                string[] availability = dbConnect.RunCommand(query, "$").Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);

                // next get information about each person and reformat output
                // holds output
                string output = "";
                // loop through once per person
                for (int x = 0; x < availability.Length; x++)
                {
                    // split the string into individual sections
                    string[] temp = availability[x].Split('$');

                    // check if they're enabled and staff, skips this person if they aren't
                    if (temp.Length <= 1 || temp[3].ToLower() != "staff") { continue; }

                    // create the query string to get information about this person
                    query = "SELECT * FROM public_info WHERE username='" + temp[1] +"';";

                    // extract the data
                    string[] temp2 = dbConnect.RunCommand(query, "$").Split('$');

                    // format output and go to next person
                    output += temp[2] + "$" + temp[1] + "$" + temp2[2] + "$" + temp2[3] + "$" + temp2[4] + "$" + temp2[5] + "$" + temp2[6] + "$" + temp2[7] + "$" + temp2[8] + "$" + temp[4];
                    output += System.Environment.NewLine;
                }

                // display final data
                rtbAvail.Text = output;
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        /// <summary>
        /// Saves availability to text file.
        /// </summary>
        private void btAvailSave_Click(object sender, EventArgs e)
        {
            try
            {
                // throw exception is nothing in file location field
                if (txAvailLoc.Text == "") { throw new Exception("empty file location field"); }
                FileIO.WriteToFile(txAvailLoc.Text, rtbAvail.Text);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error saving file. " + ex.Message);
            }
            finally
            {
                // reload everyone's availability
                this.schedule.ReloadEmployees(rtbAvail.Text);

                this.schedule.RefreshMatchedShifts();

                // update the lists and views
                this.UpdateAssignedUnassigned(new ScheduleSlot());  // updates list of assigned and unassigned employees
                this.UpdateEmployeeHoursView();         // updates the list of employees with their hours
                this.UpdateConflicts();                 // updates the list of conflicts
                this.UpdateHoursAvailabilityDisplay();  // updates the labels with information regarding total hours/shifts available/allocated
            }
        }

        /// <summary>
        /// Updates general settings on mysql database
        /// </summary>
        private void btUpdateGenSets_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Saves the shift skeleton to file.
        /// </summary>
        private void btSkeletonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // throw exception is nothing in file location field
                if (txSkeletonLoc.Text == "") { throw new Exception("empty file location field"); }
                FileIO.WriteToFile(txSkeletonLoc.Text, rtbSkeleton.Text);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error saving file. " + ex.Message);
            }
        }

        /// <summary>
        /// Clears the availablility text box.
        /// </summary>
        private void btAvailClear_Click(object sender, EventArgs e)
        {
            rtbAvail.Clear();
        }

        /// <summary>
        /// Clears the shift skeleton text box.
        /// </summary>
        private void btSkeletonClear_Click(object sender, EventArgs e)
        {
            rtbSkeleton.Clear();
        }

        /// <summary>
        /// reloads shift skeleton from file.
        /// </summary>
        private void btSkeletonReload_Click(object sender, EventArgs e)
        {
            try
            {
                // throw exception is nothing in file location field
                if (txSkeletonLoc.Text == "") { throw new Exception("empty file location field"); }
                FileIO.ReadFromFile(txSkeletonLoc.Text);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error reading file. " + ex.Message);
            }
        }

        /// <summary>
        /// reloads availability from file
        /// </summary>
        private void btAvailReload_Click(object sender, EventArgs e)
        {
            try
            {
                // throw exception is nothing in file location field
                if (txAvailLoc.Text == "") { throw new Exception("empty file location field"); }
                FileIO.ReadFromFile(txAvailLoc.Text);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error reading file. " + ex.Message);
            }
        }

        /// <summary>
        /// Loads information when selected shift is changed
        /// </summary>
        private void lstShifts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 0 is an invalid index - does nothing
            if (lstShifts.SelectedIndices.Count == 0) { return; }

            // get the selected scheduleslot object from the shift skeleton
            ScheduleSlot target = this.schedule._skeleton.ToList()[lstShifts.SelectedIndices[0]];

            // update lists and labels
            this.UpdateAssignedUnassigned(target);

            lbCurrent.Text = "Currently Working on " + target.Name;
        }

        /// <summary>
        /// testing function - not required in final
        /// </summary>
        private void btTest2_Click(object sender, EventArgs e)
        {
            if (schedule != null)
            {
                schedule = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            // create the object
            schedule = new Schedule(this.rtbAvail.Text, this.rtbSkeleton.Text);

            // match availability to shifts
            schedule.MatchShifts();

            // print the results
            txOutput.Text = schedule.ToStringMatchedShifts();

            // bind the list of shift slots to listbox
            this.ReloadShiftsToList();
            UpdateEmployeeHoursView();
            UpdateHoursAvailabilityDisplay();
        }

        #region Display_Update
        //          =================================================================
        // region of code containing functions that update GUI elements

        /// <summary>
        /// Updates the hours/shift information display
        /// </summary>
        private void UpdateHoursAvailabilityDisplay()
        {
            string output = "Total Hours: " + this.schedule.TotalHours.TotalHours;
            output += System.Environment.NewLine + "Allocated: " + this.schedule.HoursFilled.TotalHours;

            this.lbHoursInfo.Text = output;

            output = "Total Shifts: " + this.schedule.ShiftsAvailable;
            output += System.Environment.NewLine + "Allocated: " + this.schedule.ShiftsFilled;

            this.lbShiftInfo.Text = output;
        }

        /// <summary>
        /// color codes the list of employees to give an idea of whether they have too few or too many hours
        /// </summary>
        private void UpdateHoursColors()
        {
            // list of all employees
            List<Employee> process = schedule._employees.ToList();
            // sort the list
            process.Sort((x, y) => string.Compare(x.Nickname, y.Nickname));

            // minimum hours
            TimeSpan min = new TimeSpan(int.Parse(this.txMinHours.Text), 0, 0);
            TimeSpan max = new TimeSpan(int.Parse(this.txMaxHours.Text), 0, 0);
            TimeSpan sweet = new TimeSpan(int.Parse(this.txSweet.Text), 0, 0);

            int maxColor = 150;

            for (int x = 0; x < process.Count; x++)
            {
                // get the employee in question
                Employee temp = process[x];

                // make text white
                this.lstEmployees.Items[x].ForeColor = Color.White;

                // changes the color of the employee in the list depending on how many hours they are working
                if (temp.Length == sweet)
                {
                    // at sweet spot, make green
                    this.lstEmployees.Items[x].BackColor = Color.FromArgb(0, maxColor, 0);
                }
                else if (temp.Length >= max)
                {
                    // above max, make red
                    this.lstEmployees.Items[x].BackColor = Color.FromArgb(255, 0, 0);
                }
                else if (temp.Length <= min)
                {
                    // below min, make blue
                    this.lstEmployees.Items[x].BackColor = Color.FromArgb(0, 0, maxColor);
                }
                else if (temp.Length < sweet)
                {
                    // less than sweet spot, modify color as necessary
                    double ratio = maxColor * ((temp.Length.TotalHours - min.TotalHours) / (sweet.TotalHours - min.TotalHours));
                    this.lstEmployees.Items[x].BackColor = Color.FromArgb(0, (int)ratio, (maxColor - (int)ratio));
                }
                else
                {
                    // greater than sweet spot, modify color as necessary
                    double ratio = maxColor * ((temp.Length.TotalHours - sweet.TotalHours) / (max.TotalHours - sweet.TotalHours));
                    this.lstEmployees.Items[x].BackColor = Color.FromArgb((int)ratio, (int)(maxColor - (int)ratio), 0);
                }

                // Working less than or more than min/max
                /*if (temp.Length < min)
                {
                    this.lstEmployees.Items[x].BackColor = Color.Orange;
                }
                else if (temp.Length == sweet)
                {
                    lstEmployees.Items[x].BackColor = Color.Green;
                }
                else if (temp.Length > max)
                {
                    this.lstEmployees.Items[x].BackColor = Color.Red;
                }
                // within the sweet zone but not exact
                else
                {
                    lstEmployees.Items[x].BackColor = Color.GreenYellow;
                }*/
            }
        }

        /// <summary>
        /// Updates the data in the list of assigned and unassigned employees
        /// </summary>
        private void UpdateAssignedUnassigned(ScheduleSlot target)
        {
            // get the currently selected indices in order to place back afterwards
            // check if list if empty, if it is then set value to -1 otherwise used the currently selected index
            int indexAssigned = (this.lstAssigned.Items.Count == 0 || this.lstAssigned.SelectedIndices.Count <= 0) ? -1 : this.lstAssigned.SelectedIndices[0];
            int indexUnassigned = (this.lstUnassigned.Items.Count == 0 || this.lstUnassigned.SelectedIndices.Count <= 0) ? -1 : this.lstUnassigned.SelectedIndices[0];

            // clear the lists
            this.lstUnassigned.Items.Clear();
            this.lstAssigned.Items.Clear();

            // get the source data
            List<string> assigned = target.Assigned;
            List<string> unassigned = target.Unassigned;

            // add the assigned
            foreach (string employUser in assigned)
            {
                Employee temp = this.schedule._employees.ReturnEmployee(employUser);

                lstAssigned.Items.Add(temp.Username + " " + temp.Length.TotalHours);
            }
            // add the unassigned
            foreach (string employUser in unassigned)
            {
                Employee temp = this.schedule._employees.ReturnEmployee(employUser);

                lstUnassigned.Items.Add(temp.Username + " " + temp.Length.TotalHours);
            }

            // update the info label
            this.ShiftSlotInfoLabelUpdate(target.EmployeeNeededCount, target.EmployeeWorkingCount);

            // update colors of shifts
            UpdateColorOfShifts();

            // Set selected indices based on previous
            this.UpdateSelectedItems(indexAssigned, indexUnassigned);
        }

        /// <summary>
        /// Updates the info label that displays how many employees a shift slot asks for verus how many are actually working
        /// </summary>
        /// <param name="employeeNeededCount">Number of people needed</param>
        /// <param name="employeeWorkingCount">Number of people actually working this shift</param>
        private void ShiftSlotInfoLabelUpdate(int employeeNeededCount, int employeeWorkingCount)
        {
            // update the info label
            lbInfo.Text = "Skeleton suggests " + employeeNeededCount + " employees " + Environment.NewLine + "for this shift.";

            // update label color depending on how many people working verses number of people requested
            if (employeeNeededCount > employeeWorkingCount)
                // not enough epople working
            {
                lbInfo.BackColor = Color.Orange;
            }
                // if the exact number of people are working
            else if (employeeNeededCount == employeeWorkingCount)
            {
                lbInfo.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                // too many people
                lbInfo.BackColor = System.Drawing.Color.Red;
            }
        }

        /// <summary>
        /// Updates the colors of the shifts on the list
        /// </summary>
        private void UpdateColorOfShifts()
        {
            List<ScheduleSlot> process = schedule._skeleton.ToList();

            for (int x = 0; x < process.Count; x++)
            {
                ScheduleSlot temp = process[x];

                // changes the color of the shift in the list depending on how many people are working verses number of people required

                // no one assigned
                if (temp.EmployeeWorkingCount == 0)
                {
                    lstShifts.Items[x].BackColor = Color.FromArgb(224, 224, 224);
                }
                // if there are more employees than required
                else if (temp.EmployeeNeededCount < temp.EmployeeWorkingCount)
                {
                    lstShifts.Items[x].BackColor = Color.Red;
                }
                    // if there are the exact number of employees working
                else if (temp.EmployeeNeededCount == temp.EmployeeWorkingCount)
                {
                    lstShifts.Items[x].BackColor = Color.Green;
                }
                    // if there aren't enough employees working
                else if (temp.EmployeeNeededCount > temp.EmployeeWorkingCount)
                {
                    lstShifts.Items[x].BackColor = Color.Orange;
                }
            }
        }

        /// <summary>
        /// Reloads the list of shifts in the scheduling listview
        /// </summary>
        private void ReloadShiftsToList()
        {
            // clear the list
            lstShifts.Items.Clear();

            // add each item to the list
            foreach (ScheduleSlot item in schedule._skeleton.ToList())
            {
                lstShifts.Items.Add(item.ToString());
            }

            UpdateColorOfShifts();
        }

        /// <summary>
        /// Updates availability preview page with this persons
        /// </summary>
        private void UpdateAvailabilityPreview(Employee target)
        {
            // used to check if any items are even in this list
            int bool = true;

            // clear the listview first
            this.lstAvailPreview.Items.Clear();

            // enter in header for availability
            this.lstAvailPreview.Columns[0].Text = "** Availability For " + target.Nickname + " **";

            // go throught their availability and list them
            foreach (Shift item in target.Availabilities.ToList())
            {
                lstAvailPreview.Items.Add(item.ToString().Trim());
                // incrementing count each time
                count++;
            }

            // add in a blank space
            lstAvailPreview.Items.Add("");
            
            // add in the shifts worked header
            lstAvailPreview.Items.Add("** Shifts worked by " + target.Nickname + " **");

            // go through each shift this person is working and add to the list
            foreach (Shift item in target.Working.ToList())
            {
                lstAvailPreview.Items.Add(item.ShiftNumber + " " + item.ToString().Trim());
                // incrementing count each time
                count++;
            }

            // if this isnt someone with no availability and no shifts assigned to them
            if (count > 0)
            {
                // set the column header width to be as width as the longest item in the list
                lstAvailPreview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            else
            {
                // otherwise set it the width of the header
                lstAvailPreview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }  // for most cases, this will set the column width to the minimum required to display all text without truncating it.
        }

        /// <summary>
        /// Lists all the employees and the number of hours working in a preview list view
        /// </summary>
        private void UpdateEmployeeHoursView()
        {
            // clear the list view first
            this.lstEmployees.Items.Clear();

            // get the list of employees
            List<Employee> sorted = this.schedule._employees.ToList();
            // sort the list alphabetical
            sorted.Sort((x, y) => string.Compare(x.Nickname, y.Nickname));

            // add each item to the list
            foreach (Employee item in sorted)
            {
                lstEmployees.Items.Add(item.ToString());
            }

            UpdateHoursColors();
        }

        /// <summary>
        /// Updates the list of employees who have issues with their current scheduling
        /// </summary>
        private void UpdateConflicts()
        {
            // clear it first
            this.lstConflicts.Items.Clear();

            string[] input = this.schedule._conflicts.ToString(this.schedule._employees).Split('\n');

            foreach (string item in input)
            {
                this.lstConflicts.Items.Add(item);
            }

            lstConflicts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            // loop once per item in the conflict dictionary
            /*for (int x = 0; x < this.schedule._conflicts.Keys.Count; x++)
            {
                // check if conflict list is empty
                if (this.schedule._conflicts.ElementAt(x).Value.Count <= 0)
                {
                    // skip this person
                    continue;
                }

                // generate output
                string output = "";

                output += this.schedule._conflicts.ElementAt(x).Key;
                output += " has issues with: " + System.Environment.NewLine;

                this.lstConflicts.Items.Add(output);

                // for each conflicting shift
                foreach (Shift shift in this.schedule._conflicts.ElementAt(x).Value)
                {
                    this.lstConflicts.Items.Add(shift.ShiftNumber + " " + shift.ToString());
                }
                this.lstConflicts.Items.Add(" ");
            }*/
        }

        #endregion // =================================================================

        #region Context_Menu_Functionality
        //          =================================================================
        //          functions used to create context menu (right click menu with edit controls) for objects that lack such
        //          functionality natively


        private void AddContextMenu(RichTextBox rtb)
        {
            if (rtb.ContextMenuStrip == null)
            {
                ContextMenuStrip cms = new ContextMenuStrip { ShowImageMargin = false };
                ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Cut");
                tsmiCut.Click += (sender, e) => rtb.Cut();
                cms.Items.Add(tsmiCut);
                ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Copy");
                tsmiCopy.Click += (sender, e) => rtb.Copy();
                cms.Items.Add(tsmiCopy);
                ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Paste");
                tsmiPaste.Click += (sender, e) => rtb.Paste();
                cms.Items.Add(tsmiPaste);
                rtb.ContextMenuStrip = cms;
            }
        }

        private void LoadContextMenus()
        {
            AddContextMenu(rtbAvail);
            AddContextMenu(rtbSkeleton);
        }

        #endregion // =================================================================

        /// <summary>
        /// When selected unassigned employee is changed - updates availability preview window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstUnassigned_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUnassigned.SelectedItems.Count <= 0)
            {
                return;
            }

            // get selected employee
            Employee target = schedule._employees.ReturnEmployee(this.lstUnassigned.SelectedItems[0].Text.Split(' ')[0]);

            //update display
            UpdateAvailabilityPreview(target);
        }

        private void lstAssigned_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstAssigned.SelectedItems.Count <= 0)
            {
                return;
            }

            // get selected employee
            Employee target = schedule._employees.ReturnEmployee(this.lstAssigned.SelectedItems[0].Text.Split(' ')[0]);

            //update display
            UpdateAvailabilityPreview(target);
        }

        /// <summary>
        /// Used to display the schedule preview.
        /// </summary>
        private void DisplayPreview()
        {
            // generate file

            //using System.IO;  
            String appdir = Path.GetDirectoryName(Application.ExecutablePath);
            String myfile = Path.Combine(appdir, "test.html");

            this.GeneratePreview(myfile);

            this.wbPreview.Url = new Uri("file:///" + myfile);
        }

        /// <summary>
        /// Generates the actual preview page and saves it as an html file
        /// </summary>
        /// <param name="location">location to save preview page</param>
        private void GeneratePreview(string location)
        {
            // holds html output, prefilled with header of html code
            string output = "<html><head><title>Schedule Preview</title></head><body><table border='1'>";

            // Check how many columns we need by checking which days actually have shifts
            int columnsNeeded = 0;
            for (int x = 0; x < TimeUtilities.daysOfWeek.Count; x++)
            {
                if (this.schedule._skeleton.ReturnShiftsForDay(TimeUtilities.daysOfWeek[x]).Count > 0)
                {
                    // increment count because this day has more than 0 shift slots
                    columnsNeeded++;
                }
            }

            // morning first
            output += this.GenerateSegmentPreview(columnsNeeded, 0, 1200, "Morning");

            // Noon next
            output += this.GenerateSegmentPreview(columnsNeeded, 1200, 1500, "Noon");

            // afternoon next
            output += this.GenerateSegmentPreview(columnsNeeded, 1500, 1800, "Afternoon");

            // night last
            output += this.GenerateSegmentPreview(columnsNeeded, 1800, 2400, "Night");
           
            // close the remainder
            output += "</table></body></html>";

            Utilities.FileIO.WriteToFile(location, output);
        }

        private string GenerateDateHeading(int columnsNeeded)
        {
            string output = "";
            
            // used for getting days of the week
            DateTime scheduleDays = new DateTime(int.Parse(this.schedule.Start.Split('-')[0]), int.Parse(this.schedule.Start.Split('-')[1]), int.Parse(this.schedule.Start.Split('-')[2]));

            // generate date heading first
            output += "<tr>";
            for (int x = 0; x < columnsNeeded; x++)
            {
                output += "<td style='text-align:Center;color:white;background-color:#CC3300;'>" + scheduleDays.ToLongDateString() + "</td>";
                scheduleDays = scheduleDays.AddDays(1);
            }
            output += "</tr>";

            return output;
        }

        private string GenerateSegmentPreview(int columnsNeeded, int after, int before, string header)
        {
            // output
            string output = "";

            // holds the index position for each individual day
            List<int> positions = new List<int>();
            // determines whether to keep looping or stop
            bool keepGoing = true;

            // next morning header
            output += "<tr><td colspan='" + columnsNeeded + "' style='text-align:Center;color:white;background-color:#CC3300;'>" + header + "</td></tr>";
            output += this.GenerateDateHeading(columnsNeeded);

            // zero out the list of positions
            for (int x = 0; x < columnsNeeded; x++)
            {
                // generate variables needed to add shifts to preview
                positions.Add(0);
            }

            List<List<ScheduleSlot>> morningShifts = this.schedule._skeleton.ReturnShiftsBetween(after, before);

            // counts how many times we looped
            int looped = 0;
            // print out the morning shifts
            while (keepGoing)
            {
                // new row
                if ((looped % 2) == 0)
                {
                    output += "<tr style='background-color:#E7E4E2;'>";
                }
                else
                {
                    output += "<tr>";
                }
                looped++;

                keepGoing = false; // initially set to false - if any day of the week adds a shift, switch to true. otherwise it stays false if there is nothing left to add

                // loop once per day
                for (int x = 0; x < columnsNeeded; x++)
                {
                    // if the current position is equal to or greater than elements in this list
                    if (positions[x] >= morningShifts[x].Count)
                    {
                        // output an empty cell and skip interation
                        output += "<td></td>";
                        continue;
                    }
                    // keep going other wise
                    keepGoing = true;

                    // get a shift for this day
                    ScheduleSlot temp = morningShifts[x][positions[x]];

                    //increment position
                    positions[x]++;

                    // check how many times to loop through - total people working can be higher than employees needed
                    int loopTimes = (temp.Assigned.Count > temp.EmployeeNeededCount) ? temp.Assigned.Count : temp.EmployeeNeededCount;

                    // loop once per groups of 2
                    for (int y = 0; y < loopTimes; y += 2)
                    {
                        //output += "<td>
                    }

                    // generate the output
                    output += "<td width='200'>";
                    // loop through once for each employee working
                    for (int y = 0; y < temp.Assigned.Count; y++)
                    {
                        output += "<span>" + this.schedule._employees.ReturnEmployee(temp.Assigned[y]).Nickname + " </span>";
                    }

                    // now check if there are fewer employees working here than requested
                    if (temp.EmployeeNeededCount > temp.Assigned.Count)
                    {
                        // output a plain Available lable for each one
                        for (int y = 0; y < (temp.EmployeeNeededCount - temp.Assigned.Count); y++)
                        {
                            output += "<span style=\"background-color:#FFFF00\">Available </span>";
                        }
                    }

                    // output the rest of this shift's information
                    output += "<br>" + TimeUtilities.ConvertToDateTime(temp.Start).ToShortTimeString() + "-" + TimeUtilities.ConvertToDateTime(temp.End).ToShortTimeString();
                    output += "<br>" + temp.Name.ToUpper();
                    output += "</td>";
                }

                // close the row
                output += "</tr>";
            }

            return output;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            FileIO.SaveSchedulerObject(this.txSaveLoc.Text, this.schedule);
        }

        private void Config_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayPreview();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            // skip if selected index is invalid
            if (this.lstEmployees.SelectedIndices.Count <= 0)
            { return; }

            // get selected employee

            // get the list of employees
            List<Employee> temp = schedule._employees.ToList();
            // sort it
            temp.Sort((x, y) => string.Compare(x.Nickname, y.Nickname));
            // get the selected employee
            Employee target = temp[this.lstEmployees.SelectedIndices[0]];

            //update display
            UpdateAvailabilityPreview(target);
        }

        private void btDebug_Click(object sender, EventArgs e)
        {
            Employee temp = schedule._employees.ReturnEmployee("elikpk");

            temp.Length += new TimeSpan(0, 30, 0);

            UpdateEmployeeHoursView();
        }


        #region assignment/unassignment

        /// <summary>
        /// Assigns employee to shift when enter is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssignToShift(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // call assignment function
                this.AssignToShift(lstShifts.SelectedIndices[0], lstUnassigned.SelectedItems[0].Text.Split(' ')[0]);

                FileIO.SaveSchedulerObject(this.txSaveLoc.Text, this.schedule);
            }
        }

        /// <summary>
        /// Unassigns employee to shift when enter is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnassignToShift(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // call unassignment function
                this.UnassignEmployee(lstShifts.SelectedIndices[0], lstAssigned.SelectedItems[0].Text.Split(' ')[0]);

                FileIO.SaveSchedulerObject(this.txSaveLoc.Text, this.schedule);
            }
        }

        /// <summary>
        /// Assigns employee to shift when assignment button is pressed or item is double clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AssignToShift(object sender, EventArgs e)
        {
            // call assignment function
            this.AssignToShift(lstShifts.SelectedIndices[0], lstUnassigned.SelectedItems[0].Text.Split(' ')[0]);

            FileIO.SaveSchedulerObject(this.txSaveLoc.Text, this.schedule);
        }

        /// <summary>
        /// Unassigns employee to shift when unassignment button is pressed or item is double clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UnassignToShift(object sender, EventArgs e)
        {
            // call unassignment function
            this.UnassignEmployee(lstShifts.SelectedIndices[0], lstAssigned.SelectedItems[0].Text.Split(' ')[0]);

            FileIO.SaveSchedulerObject(this.txSaveLoc.Text, this.schedule);
        }

        /// <summary>
        /// Assigned selected employee to shift. No guarantee employee will be assigned shift if they have conflicts.
        /// </summary>
        /// <param name="shiftIndex">index of shift we are talking about.</param>
        /// <param name="username">username of employee to assign to shift.</param>
        private void AssignToShift(int shiftIndex, string username)
        {
            // try to assign the employee
            schedule.AssignEmployee(shiftIndex, username);

            // Currently selected ScheduleSlot - used in the next line to update employees information
            ScheduleSlot target = this.schedule._skeleton.ToList()[lstShifts.SelectedIndices[0]];

            // update the lists and views
            this.UpdateAssignedUnassigned(target);  // updates list of assigned and unassigned employees
            this.UpdateEmployeeHoursView();         // updates the list of employees with their hours
            this.UpdateConflicts();                 // updates the list of conflicts
            this.UpdateHoursAvailabilityDisplay();  // updates the labels with information regarding total hours/shifts available/allocated
        }

        /// <summary>
        /// Unassigned selected employee to shift.
        /// </summary>
        /// <param name="shiftIndex">index of shift we are talking about.</param>
        /// <param name="username">username of employee to assign to shift.</param>
        private void UnassignEmployee(int shiftIndex, string username)
        {
            // unassign employee to a shift
            schedule.UnassignEmployee(shiftIndex, username);

            ScheduleSlot target = this.schedule._skeleton.ToList()[lstShifts.SelectedIndices[0]];

            // update the lists
            this.UpdateAssignedUnassigned(target);  // updates list of assigned and unassigned employees
            this.UpdateEmployeeHoursView();         // updates the list of employees with their hours
            this.UpdateConflicts();                 // updates the list of conflicts
            this.UpdateHoursAvailabilityDisplay();  // updates the labels with information regarding total hours/shifts available/allocated
        }

        /// <summary>
        /// Auto Assigns employees to shift when double clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoAssign(object sender, EventArgs e)
        {
            // get shift
            ScheduleSlot target = this.schedule._skeleton.ToList()[lstShifts.SelectedIndices[0]];

            // run the auto assign algorithm
            this.schedule.AutoAssignShift(target, double.Parse(this.txHourMod.Text), this.txLow.Text, this.txMedium.Text, this.txHigh.Text, double.Parse(this.txLowV.Text), double.Parse(this.txMediumV.Text), double.Parse(this.txHighV.Text), double.Parse(this.txAvailMod.Text));

            // update the lists and views
            this.UpdateAssignedUnassigned(target);  // updates list of assigned and unassigned employees
            this.UpdateEmployeeHoursView();         // updates the list of employees with their hours
            this.UpdateConflicts();                 // updates the list of conflicts
            this.UpdateHoursAvailabilityDisplay();  // updates the labels with information regarding total hours/shifts available/allocated

            FileIO.SaveSchedulerObject(this.txSaveLoc.Text, this.schedule);
        }

        #endregion

        /// <summary>
        /// Updates selected indices on lstAssigned and lstUnassigned.
        /// </summary>
        /// <param name="indexAssigned">Previous selected index for lstAssigned</param>
        /// <param name="indexUnassigned">Previous selected index for lstUnassigned</param>
        private void UpdateSelectedItems(int indexAssigned, int indexUnassigned)
        {
            // if the previous index is greater than the actual count of items, make the index (max value - 1) -> ie, select the last item on the list
            if (indexAssigned >= this.lstAssigned.Items.Count)
            {
                indexAssigned = this.lstAssigned.Items.Count - 1;
            }
            if (indexUnassigned >= this.lstUnassigned.Items.Count)
            {
                indexUnassigned = this.lstUnassigned.Items.Count - 1;
            }

            // set the index only as long as the index value is valid - ie, there is actually items on the list
            if (indexAssigned >= 0)
            {
                this.lstAssigned.Items[indexAssigned].Selected = true;
            }
            if (indexUnassigned >= 0)
            {
                this.lstUnassigned.Items[indexUnassigned].Selected = true;
            }
        }

        private void btAutoAll_Click(object sender, EventArgs e)
        {
            // get the priority
            string[] priorities = txPriority.Text.Split('$');

            // go through type of priorities one by one
            for (int x = 0; x < priorities.Length; x++)
            {
                // go through all shifts
                foreach (ScheduleSlot slot in this.schedule._skeleton.ToList())
                {
                    // if this shift is one of the type we wish to fill in now
                    if (slot.Type.Contains(priorities[x]))
                    {
                        // autoassign it!
                        this.schedule.AutoAssignShift(slot, double.Parse(this.txHourMod.Text), this.txLow.Text, this.txMedium.Text, this.txHigh.Text, double.Parse(this.txLowV.Text), double.Parse(this.txMediumV.Text), double.Parse(this.txHighV.Text), double.Parse(this.txAvailMod.Text));
                    }
                }
            }

            // update the lists and views
            UpdateColorOfShifts();
            this.UpdateEmployeeHoursView();         // updates the list of employees with their hours
            this.UpdateConflicts();                 // updates the list of conflicts
            this.UpdateHoursAvailabilityDisplay();  // updates the labels with information regarding total hours/shifts available/allocated

            FileIO.SaveSchedulerObject(this.txSaveLoc.Text, this.schedule);
        }

        private void lstAssigned_SelectedIndexChanged(object sender, MouseEventArgs e)
        {
            lstAssigned_SelectedIndexChanged(sender, new EventArgs());
        }

        private void lstUnassigned_SelectedIndexChanged(object sender, MouseEventArgs e)
        {
            lstUnassigned_SelectedIndexChanged(sender, new EventArgs());
        }
    }
}
