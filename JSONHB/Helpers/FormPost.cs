using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Collections.Specialized;

namespace JSONHB
{
    class FormPost
    {
        public static string SendData(string sendURI, string formMessage)
        {
            string MACCheck = "";
            string IPAddress = "";
            string sendResponse = "";
            string roundTrip = "";
            try
            {
                using (WebClient client = new WebClient())
                {
                    DateTime t1 = Convert.ToDateTime(System.DateTime.Now);
                    byte[] response =
                    client.UploadValues(sendURI, new NameValueCollection()
                    {
                    { "msg", formMessage },
                    });

                    DateTime t2 = Convert.ToDateTime(System.DateTime.Now);
                    TimeSpan ts = t2.Subtract(t1);
                    roundTrip = ts.TotalMilliseconds.ToString();

                    string result = System.Text.Encoding.UTF8.GetString(response);

                    //parse the return string
                    MACCheck = getBetween(result, "", "IPAddress");
                    MACCheck = MACCheck.Replace("\"", "");
                    IPAddress = getBetween(result, "IPAddress:", "|");
                    bool contains = sendURI.Contains("debug");
                    if (contains)
                        sendResponse = result;
                    else
                        sendResponse = "Response: \n" + MACCheck + "\nClient IP: " + IPAddress + "\nRound trip: " + roundTrip + " ms";

                }
                return sendResponse;
            }

            catch (Exception e)
            {
                sendResponse = e.Message;
                return sendResponse;
            }
        }

        private static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
    }
}