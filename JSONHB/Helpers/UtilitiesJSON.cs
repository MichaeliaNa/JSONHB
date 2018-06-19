using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JSONHB.Helpers
{
    class UtilitiesJSON
    {
        public static string JSONPost(JObject JSONRequest, Boolean responseCode, string APISvc, string MAC)
        {

            byte[] byteArray = Encoding.UTF8.GetBytes(JSONRequest.ToString());
            string returnContent = "";

            // Post the data to the right place.
            Uri target = new Uri(APISvc);
            WebRequest request = System.Net.WebRequest.Create(target);

            request.Method = "POST";
            request.Headers.Add("DS-FLYTE-HMAC", "hash=" + MAC);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            try
            {
                using (var dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    //Do what needs to be done with the response.
                    if (responseCode)
                        returnContent = response.StatusCode.ToString();
                    else
                        returnContent = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    //MessageBox.Show(content);
                }
            }
            catch (Exception ex)
            {
                returnContent = ex.Message;
            }
            return returnContent;

        }
        public static JObject BuildJSON()
        {
            //reference 
            //https://stackoverflow.com/questions/5978904/how-to-build-object-hierarchy-for-serialization-with-json-net
            var json = new JObject(
                                new JProperty("UAVSerial", Heartbeat.UAVSerial),
                                new JProperty("SecretKey", Heartbeat.SecretKey),
                                new JProperty("Count", Heartbeat.Count),
                                new JProperty("FlightID", Heartbeat.FlightID),
                                new JProperty("Status", Heartbeat.Status),
                                new JProperty("RSSI", Heartbeat.RSSI),
                                new JProperty("SightLine", 4),
                                new JProperty("Docked", 1),
                                new JProperty("GPSLocation",
                                        new JObject(
                                            new JProperty("Latitude", Heartbeat.Latitude),
                                            new JProperty("Longitude", Heartbeat.Longitude)
                                        )
                                ),
                                new JProperty("Altitude",
                                        new JObject(
                                            new JProperty("AboveSL", Heartbeat.Alt_ASL),
                                            new JProperty("AboveGL", Heartbeat.Alt_AGL)
                                        )
                                ),
                                new JProperty("Attitude",
                                        new JObject(
                                            new JProperty("Yaw", Heartbeat.Yaw),
                                            new JProperty("Pitch", Heartbeat.Pitch),
                                            new JProperty("Roll", Heartbeat.Roll),
                                            new JProperty("Bearing", Heartbeat.Bearing),
                                            new JProperty("Speed", Heartbeat.Speed)
                                        )
                                ),
                                new JProperty("Batteries",
                                        new JArray(
                                                new JObject(
                                                    new JProperty("Type", "Avionics"),
                                                    new JProperty("APReading", 14.5),
                                                    new JProperty("Batteries",
                                                    new JArray(
                                                        new JObject(
                                                            new JProperty("Battery", 1),
                                                            new JProperty("Cells", 11.1, 14.0, 14.0, 14.0)
                                                        ),
                                                        new JObject(
                                                            new JProperty("Battery", 2),
                                                            new JProperty("Cells", 22.2, 12.1, 12.1, 12.1)
                                                        )
                                                    )
                                                    )
                                                ),
                                                new JObject(
                                                    new JProperty("Type", "Servo"),
                                                    new JProperty("APReading", 24.5),
                                                    new JProperty("Batteries",
                                                        new JArray(
                                                            new JObject(
                                                                new JProperty("Battery", 1),
                                                                    new JProperty("Cells", 11.1, 25, 0.0, 25.0, 25.0, 25.0)
                                                            ),
                                                            new JObject(
                                                                new JProperty("Battery", 2),
                                                                    new JProperty("Cells", 22.2, 12.3, 23.1, 24.3, 19.2, 23.4)
                                                            ),
                                                            new JObject(
                                                                new JProperty("Battery", 3),
                                                                    new JProperty("Cells", 33.3, 12.3, 23.1, 24.3, 19.2, 23.4)
                                                            ),
                                                            new JObject(
                                                                new JProperty("Battery", 4),
                                                                    new JProperty("Cells", 44.4, 11.1, 11.1, 11.1, 11.1, 11.1)
                                                            )

                                                        )
                                                    )
                                                ) //
                                        )
                                ),
                                new JProperty("TemperatureSensors",
                                        new JArray(
                                                new JObject(
                                                    new JProperty("Sensor", 1),
                                                    new JProperty("Temperature", 19.3)
                                                ),
                                                new JObject(
                                                    new JProperty("Sensor", 2),
                                                    new JProperty("Temperature", 21.4)
                                                ),
                                                new JObject(
                                                    new JProperty("Sensor", 3),
                                                    new JProperty("Temperature", 45.2)
                                                ),
                                                new JObject(
                                                    new JProperty("Sensor", 4),
                                                    new JProperty("Temperature", -9.1)
                                                ),
                                                new JObject(
                                                    new JProperty("Sensor", 5),
                                                    new JProperty("Temperature", 0.1)
                                                )
                                        )
                                ),      //
                                new JProperty("CurrentSensors",
                                        new JArray(
                                                new JObject(
                                                    new JProperty("Sensor", 1),
                                                    new JProperty("Current", 89.3)
                                                ),
                                                new JObject(
                                                    new JProperty("Sensor", 2),
                                                    new JProperty("Current", 87.2)
                                                )
                                        )
                                )//
                        );
            //var jsonString = json.ToString();
            return json;
        }

        public static int CountLinesInFile(string FileName)
        {
            var count = 0;
            try
            {
                count = File.ReadLines(FileName).Count();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return count;
        }

    }
}
