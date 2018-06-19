using JSONHB.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSONHB.Forms
{
    public partial class JSONView : Form
    {
        private string uri;

        public JSONView(string jsonAPI)
        {
            uri = jsonAPI;
            InitializeComponent();
        }

        private void JSONView_Load(object sender, EventArgs e)
        {
            string heartBeatURI = uri;
            string json = UtilitiesJSON.BuildJSON().ToString();
            string jsonFormatted = JValue.Parse(json).ToString(Formatting.Indented);
            //textBox1.Text = jsonFormatted;
            txtJSON.Text = jsonFormatted;

        }
    }
}
