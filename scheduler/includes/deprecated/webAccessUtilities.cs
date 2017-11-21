using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace scheduler.includes
{
    class webAccessUtilities
    {
        // variables required to access york webpages
        private CookieContainer cookieJar;
        private HttpWebRequest request;
        private HttpWebResponse response;

        public webAccessUtilities()
        {
            // initialize variables
            cookieJar = new CookieContainer();
        }

        private void CreateWebRequestAndGetResponseFor(String webpage)
        {
            try
            {
                // create response with correct client information to trick york site
                request = (HttpWebRequest)HttpWebRequest.Create(webpage);
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.CookieContainer = cookieJar;
                request.KeepAlive = true;
                request.Timeout = 5000;

                // get response and put the cookie in the cookie jar
                response = (HttpWebResponse)request.GetResponse();
                cookieJar.Add(response.Cookies);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ConnectToYork(String username, String password)
        {
            // connect
            // first access a random yorku page to get the log in page
            CreateWebRequestAndGetResponseFor("http://www.yorku.ca/schedule/sched2/config/shiftskeleton.txt");

            // now send a log in connection string to log in
            CreateWebRequestAndGetResponseFor("https://passportyork.yorku.ca/ppylogin/ppylogin?mli=" + username + "&password=" + password + "&dologin=Login");
        }

        public String GetDataFor(String webpage, String username, String password)
        {
            String output = "";

            // open connection
            ConnectToYork(username, password);

            // load webpage
            CreateWebRequestAndGetResponseFor(webpage);

            // read from webpage response
            StreamReader reader = new StreamReader(response.GetResponseStream());
            reader = new StreamReader(response.GetResponseStream());
            output = reader.ReadToEnd();

            return output;
        }
    }
}
