using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using MySql.Data.MySqlClient;

namespace scheduler.Utilities
{
    /// <summary>
    /// Class for connection to database and performing operations on it
    /// </summary>
    public class DBConnect
    {
        // database connection information
        private string              _dbhost;
        private string              _dbuser;
        private string              _dbpass;
        private string              _dbname;

        // mysql connection object and connection string
        private MySqlConnection     conn;
        private String              myConnectionString;

        #region constructors

        /// <summary>
        /// Constructor. creates connection string.
        /// </summary>
        /// <param name="host">Database host.</param>
        /// <param name="user">Database username.</param>
        /// <param name="pass">Database password.</param>
        /// <param name="name">Database name.</param>
        public DBConnect(string host, string user, string pass, string name)
        {
            this.AddConnectionString(host, user, pass, name);
        }

        /// <summary>
        /// default destructor
        /// </summary>
        ~DBConnect()
        {
            // close connection when object is killed
            CloseConnection();
        }

        /// <summary>
        /// Adds the information required to open a database contection and creates a connection string.
        /// </summary>
        /// <param name="host">Database host.</param>
        /// <param name="user">Database username.</param>
        /// <param name="pass">Database password.</param>
        /// <param name="name">Database name.</param>
        public void AddConnectionString(string host, string user, string pass, string name)
        {
            _dbhost = host;
            _dbuser = user;
            _dbpass = pass;
            _dbname = name;

            // set the connection string
            myConnectionString = "server=" + _dbhost + ";uid=" + _dbuser + ";pwd=" + _dbpass + ";database=" + _dbname + ";";
        }

        #endregion

        #region connection_Functions functions used to open/close connection and check connection

        /// <summary>
        /// connects to DB and opens connection
        /// </summary>
        private void ConnectToDB()
        {
            try
            {
                // connect to mysql server with credentials supplied at the top
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to connect to database. Error Message: " + ex.Message);
            }
        }

        /// <summary>
        /// closes database connection if open
        /// </summary>
        private void CloseConnection()
        {
            // try to close connection
            try
            {
                if (IsOpen())
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // error was encountered
                throw new Exception("Error while trying to close connection to database. Error Message: " + ex.Message);
            }
        }

        /// <summary>
        /// open connection to database if it is closed
        /// </summary>
        private void OpenConnection()
        {
            // try to open connection
            try
            {
                if (!IsOpen())
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                // error was encountered
                throw new Exception("Error while trying to open connection to database. Error Message: " + ex.Message);
            }
        }

        /// <summary>
        /// checks if connection is open and returns true or false based on that
        /// </summary>
        /// <returns>True if connection is open, otherwise false</returns>
        public bool IsOpen()
        {
            if ((conn != null) && (conn.State == System.Data.ConnectionState.Open)) { return true; } else { return false; }
        }

        /// <summary>
        /// returns true if connection string has been inputted.
        /// </summary>
        /// <returns></returns>
        public bool IsReady()
        {
            conn.Open();
            if ((conn != null) && (conn.State == System.Data.ConnectionState.Open)) { return true; } else { return false; }
        }

        #endregion

        #region database_functions various functions used to perform operations on the database.

        /// <summary>
        /// Runs a sql query
        /// </summary>
        /// <param name="queryString">Command to be run on mysql</param>
        /// <param name="delimiter">Used to delimit the columns of the output from a select query</param>
        /// <returns></returns>
        public string RunCommand(string queryString, string delimiter)
        {
            // output string
            string output = "";

            int debug = 0;
            string lastSuccessful = "";
            try
            {
                // check if conn has been created, and create it if not
                if (conn == null)
                {
                    ConnectToDB();
                }
                // open connection
                OpenConnection();

                // run the query
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, conn);


                // create streamreader to read the data from output
                MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();

                // read the file - columns are delimited by the selected delimiter
                while (dr.Read())
                {
                    debug++;
                    lastSuccessful = "";
                    for (int x = 0; x < dr.FieldCount; x++)
                    {
                        lastSuccessful += dr[x].ToString() + delimiter;
                        output += dr[x].ToString();
                        output += delimiter;
                    }
                    output += System.Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                // error was encountered
                throw new Exception("Error while trying to run query. Error Message: \"" + ex.Message + "\" at row " + debug + " with: " + lastSuccessful);
            }
            finally
            {
                // close connection
                CloseConnection();
            }
            return output;
        }

        /// <summary>
        /// Runs a sql query
        /// </summary>
        /// <param name="queryString">Command to be run on mysql</param>
        /// <param name="delimiter">Used to delimit the columns of the output from a select query</param>
        /// <returns></returns>
        public bool RunCommand(string queryString)
        {
            // output
            bool output = true;

            string lastSuccessful = "";
            try
            {
                // check if conn has been created, and create it if not
                if (conn == null)
                {
                    ConnectToDB();
                }
                // open connection
                OpenConnection();

                // run the query
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, conn);


                // create streamreader to read the data from output
                MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("unable to connect to any"))
                {
                    output = false;
                }
                else
                {
                    throw new Exception("Error while trying to run query. Error Message: \"" + ex.Message + "\" with: " + lastSuccessful);
                }
            }
            finally
            {
                // close connection
                CloseConnection();
            }
            return output;
        }

        #endregion
    }
}
