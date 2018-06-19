using JSONHB.Forms;
using JSONHB.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Configuration;

namespace JSONHB
{

    public partial class frmMain : Form
    {
        OpenFileDialog openFile = new OpenFileDialog();
        String RouteFile = "";
        int sleepTime = 3200;
        Boolean TCPThread = false;
        //this stuff is so the thread can access the controls on the form in a threadsafe way
        delegate void SetTextCallback(string text);
        string heartbeatURL = "";
        byte[] bEncryptionKey = new byte[32];
        byte[] bSessionID = new byte[4];

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string[] heartbeatURLs = new string[7];

            this.Text = "H e a r t b e a t    P l a y e r  -  U D P   V e r s i o n    " + Application.ProductVersion;
            trackBar1.Value = 1500;
            chkPause.Enabled = false;
            txtUAV_SN.Text = Properties.Settings.Default.UAVSerialNumberJson;
            txtSecretKey.Text = Properties.Settings.Default.UAVSecretKeyJson;
            heartbeatURLs[0] = Properties.Settings.Default.FlyteDev;
            heartbeatURLs[1] = Properties.Settings.Default.FlyeUAT;
            heartbeatURLs[2] = Properties.Settings.Default.FlyteProd;
            heartbeatURLs[3] = Properties.Settings.Default.Azure;
            heartbeatURLs[4] = Properties.Settings.Default.UDPEndpoint;
            heartbeatURLs[5] = Properties.Settings.Default.IRIS;
            heartbeatURLs[6] = Properties.Settings.Default.Local;

            BindingSource comboSource = new BindingSource();
            comboSource.DataSource = heartbeatURLs;
            cmbHeartbeatURL.DataSource = comboSource.DataSource;
            propertyGrid1.SelectedObject = Properties.Settings.Default;

            //get last setting
            cmbHeartbeatURL.SelectedIndex = Properties.Settings.Default.HeartbeatURIJson;
            heartbeatURL = cmbHeartbeatURL.Text;

            //get the encryption key & InitVector
            string encryptionKey = Properties.Settings.Default.EncryptionKey;
            string SessionID = Properties.Settings.Default.SessionID;

            bEncryptionKey = Utilities.StringToByteArray(encryptionKey, 16);
            bSessionID = Utilities.StringToByteArray(SessionID, 16);
            
            //this is where user settings are stored
            //var path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
            //MessageBox.Show(path);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["UAVSerialNumberJson"] = txtUAV_SN.Text;
            Properties.Settings.Default["UAVSecretKeyJson"] = txtSecretKey.Text;
            Properties.Settings.Default["HeartbeatURIJson"] = cmbHeartbeatURL.SelectedIndex;
            Properties.Settings.Default.Save(); // Saves settings in application configuration file
            MessageBox.Show("Changes saved", "Properties", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float simSpeed = 0.0f;
            float trackValue = (float)trackBar1.Value;
            float UAVSpeedInKm = 216f;
            simSpeed = 3200f / trackValue;
            SetSimulationSpeedText(simSpeed.ToString("0.0"));
            //SetUAVSpeedText((UAVSpeedInKm * simSpeed).ToString("0"));
            //SetUAVSpeedText(trackValue.ToString("0.0"));
        }

        private void btnFileOpen1_Click(object sender, EventArgs e)
        {
            openFile.Filter = "GPS Route Files | *.csv";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                RouteFile = openFile.FileName;
                txtFileName.Text = RouteFile;
                string[] path = RouteFile.Split('\\');
                //MessageBox.Show("len: " + path[path.Length-1]);

                //set form name to file name
                //this.Text = path[path.Length - 1];

                //System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                // MessageBox.Show(sr.ReadToEnd());
                //sr.Close();
            }


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            RouteFile = txtFileName.Text;

            if (File.Exists(RouteFile))
            {
                Thread thread = new Thread(() => ProcessHeartbeatData(RouteFile));
                thread.IsBackground = true; //this prevents the thread from continuing when the applicaition ends

                if (btnStart.Text == "Start")
                {
                    TCPThread = true;
                    btnStart.Text = "Stop";
                    txtMsgText.Text = "";
                    txtResponse.Text = "";
                    chkPause.Enabled = true;
                    grpParams.Enabled = false;
                }
                else
                {
                    TCPThread = false;
                    btnStart.Text = "Start";
                    chkPause.Enabled = false;
                    chkPause.Checked = false;
                    grpParams.Enabled = true;
                }
                thread.Start();
            }
            else
            {
                MessageBox.Show("No route file was selected", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void ProcessHeartbeatData(string RouteFileName)
        {
            int totLines = UtilitiesJSON.CountLinesInFile(RouteFileName);
            //Utilities.setHeartbeatDefaults(txtUAV_SN.Text);
            processRouteFile();
        }
        private void processRouteFile()
        {
            string msg = "";
            string RouteLine = "";
            //string heartBeatURI = txtHeartbeatURI.Text;
            //string heartBeatURI = cmbHeartbeatURL.Text;
            int counter = 0;
            try
            {
                var reader = new StreamReader(File.OpenRead(RouteFile));
                //"Lat,Lon,Avionics Bat,Alt(ASL),Alt(AGL),RSSI,Speed,Bearing,Yaw,Pitch,Roll,Servo,Status";
                while (!reader.EndOfStream && TCPThread)
                {
                    //sleepTime = (int)numSleepTime.Value;
                    sleepTime = GetValue();
                    if (chkPause.Checked != true)
                    {
                        //reader.ReadLine();
                        string line = reader.ReadLine();
                        var values = line.Split(',');           //array to hold values from each line in the file
                        Heartbeat.Latitude = Convert.ToDouble(values[0]);
                        Heartbeat.Longitude = Convert.ToDouble(values[1]);
                        Heartbeat.Bat1 = Convert.ToDouble(values[2]);
                        Heartbeat.Alt_ASL = Convert.ToDouble(values[3]);
                        Heartbeat.Alt_AGL = Convert.ToDouble(values[4]);
                        Heartbeat.RSSI = Convert.ToInt16(values[5]);
                        Heartbeat.Speed = Convert.ToDouble(values[6]);
                        Heartbeat.Bearing = Convert.ToDouble(values[7]);
                        Heartbeat.Yaw = Convert.ToDouble(values[8]);
                        Heartbeat.Pitch = Convert.ToDouble(values[9]);
                        Heartbeat.Roll = Convert.ToDouble(values[10]);
                        Heartbeat.Bat2 = Convert.ToDouble(values[11]);
                        //Heartbeat.Status = Convert.ToByte(values[12], 16);
                        Heartbeat.Status = Convert.ToInt16(values[12]);
                        Heartbeat.UAVSerial = txtUAV_SN.Text;
                        Heartbeat.SecretKey = txtSecretKey.Text;
                        Heartbeat.Count = counter;
                        Heartbeat.Sensor1 = 21.4;
                        Heartbeat.Sensor2 = -19.2;
                        Heartbeat.Sensor3 = 6.2;
                        Heartbeat.Sensor4 = 12.3;
                        Heartbeat.Sensor5 = 48.2;

                        JObject JSONPostData = UtilitiesJSON.BuildJSON();

                        if (radTCP.Checked)
                        {
                            SetResponseText(UtilitiesJSON.JSONPost(JSONPostData, false, heartbeatURL, null));
                        }
                        else
                        {
                            ////// Test UDP code using zLib ///////////
                            byte[] bIV = Utilities.generateInitVector();  //generate a random initialization vector
                            string JSONString = JsonConvert.SerializeObject(JSONPostData);
                            byte[] bJSON = Encoding.ASCII.GetBytes(JSONString);
                            byte[] zLibEncoded = Utilities.Zip(JSONString);
                            byte[] encrypted = Utilities.Encrypt(zLibEncoded, bEncryptionKey, bIV);
                            //prefix the encrypted code with the IV
                            byte[] encWithIV = AppendTwoByteArrays(bIV, encrypted);
                            //prefix encWithIV code with the session ID
                            byte[] encWithIVandSessionID = AppendTwoByteArrays(bSessionID, encWithIV);
                            Utilities.SendUDPData(encWithIVandSessionID, heartbeatURL, 11000);
                            //byte[] decrypted = Utilities.Decrypt(encrypted, bEncryptionKey, bInitVector);
                            //string JSON = Encoding.ASCII.GetString(decrypted);
                            //SetResponseText(JSON);
                            /////////////////

                            //////  Test UDP code using GZip ///////////
                            //byte[] bIV = Utilities.generateInitVector();  //generate a random initialization vector
                            //string JSONString = JsonConvert.SerializeObject(JSONPostData);
                            //byte[] bJSON = Encoding.ASCII.GetBytes(JSONString);
                            //byte[] gzipEncoded = Utilities.Zip(JSONString);
                            //byte[] encrypted = Utilities.Encrypt(gzipEncoded, bEncryptionKey, bIV);
                            ////prefix the encrypted code with the IV
                            //byte[] encWithIV = AppendTwoByteArrays(bIV, encrypted);
                            ////prefix encWithIV code with the session ID
                            //byte[] encWithIVandSessionID = AppendTwoByteArrays(bSessionID, encWithIV);
                            //Utilities.SendUDPData(encWithIVandSessionID, heartbeatURL, 11000);
                            //byte[] decrypted = Utilities.Decrypt(encrypted, bEncryptionKey, bInitVector);
                            //string JSON = Encoding.ASCII.GetString(decrypted);
                            //SetResponseText(JSON);
                            /////////////////
                        }

                        RouteLine = values[0] + ", " + values[1] + ", " + values[2] + ", " + values[3] + ", " + values[4] + ", " + values[4] + ", " + values[5] + ", " + values[6] + ", " + values[7] + ", " + values[8] + ", " + values[9];
                        if (txtMsgText.Text.Length < 1)
                            SetMsgText(RouteLine);
                        else
                            SetMsgText(txtMsgText.Text + Environment.NewLine + RouteLine);
                        //MessageBox.Show(values[0] + "," + values[1] + "," + values[2] + "," + values[3]);
                        counter++;
                    }

                    Thread.Sleep(sleepTime);
                }                SetButtonText("Start");
                SetGrpBoxState(true);
            }
            catch (Exception ex)
            {
                SetMsgText(ex.Message);
            }

        }

        // from https://blogs.msdn.microsoft.com/tfang/2012/07/04/c-two-easy-tricks-to-play-with-byte-array-using-buffer-blockcopy/
        private static byte[] AppendTwoByteArrays(byte[] arrayA, byte[] arrayB)
        {
            byte[] outputBytes = new byte[arrayA.Length + arrayB.Length];
            Buffer.BlockCopy(arrayA, 0, outputBytes, 0, arrayA.Length);
            Buffer.BlockCopy(arrayB, 0, outputBytes, arrayA.Length, arrayB.Length);
            return outputBytes;
        }
        private void SetResponseText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            if (this.btnStart.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetResponseText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtResponse.Text = text;
            }
        }
        private void SetMsgText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            if (this.btnStart.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetMsgText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtMsgText.Text = text;
            }
        }
        private void SetButtonText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            if (this.btnStart.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetButtonText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.btnStart.Text = text;
            }
        }


        private int GetValue()
        {
            int sliderValue;
            if (trackBar1.InvokeRequired)
            {
                GetSliderValueCallback cb = new GetSliderValueCallback(GetValue);
                return (int)trackBar1.Invoke(cb);
            }
            else
            {
                return (int)trackBar1.Value;
            }
        }
        delegate int GetSliderValueCallback();

        private void btnWebForm_Click(object sender, EventArgs e)
        {
            string heartBeatURI = "http://heartbeatjsvc2.azurewebsites.net";
            JSONView frm = new JSONView(heartBeatURI);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.ShowDialog();

        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            test();
        }

        private void test()
        {
        }
        private void SetSimulationSpeedText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            if (this.btnStart.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetSimulationSpeedText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.grpTrackbar.Text = "Simulation Speed: (" + text + " X)";
            }
        }

        private void btnIrisURL_Click(object sender, EventArgs e)
        {
                MessageBox.Show("IRIS: http://173.244.122.69:8090/Heartbeat \n 2. FlyteUAT http://FlyteUAT.dronedeliverycanada.com/controllerboard/heartbeat");

            //txtIRISURL.Visible = true;
            ////MessageBox.Show("http://173.244.122.69:8090/Heartbeat", "IRIS URL");
        }

        private void txtIRISURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbHeartbeatURL_SelectedIndexChanged(object sender, EventArgs e)
        {
            heartbeatURL = cmbHeartbeatURL.Text;
        }

        // This delegate enables asynchronous calls for setting  
        // the text property on a TextBox control.  
        delegate void BooleanArgReturningVoidDelegate(Boolean trueOrfalse);

        // If the calling thread is the same as the thread that created  
        // the TextBox control, the Text property is set directly.   

        private void SetGrpBoxState(Boolean trueOrfalse)
        {
            // InvokeRequired required compares the thread ID of the  
            // calling thread to the thread ID of the creating thread.  
            // If these threads are different, it returns true.  
            if (this.grpParams.InvokeRequired)
            {
                BooleanArgReturningVoidDelegate d = new BooleanArgReturningVoidDelegate(SetGrpBoxState);
                this.Invoke(d, new object[] { trueOrfalse });
            }
            else
            {
                this.grpParams.Enabled = trueOrfalse;
            }
        }

        private void btnPropertiesSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            txtUAV_SN.Text = Properties.Settings.Default.UAVSerialNumberJson;
            txtSecretKey.Text = Properties.Settings.Default.UAVSecretKeyJson;
        }
    }
}
