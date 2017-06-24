using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Globalization;
using mesic.Properties;

namespace mesic
{
    public partial class Form1 : Form
    {
        string serverAddress;
        int landingID;
        LandingState lastState;

        bool autoland;
        int maxSpeed;

        public Form1()
        {
            InitializeComponent();

            landingID = -1; // landing is not running right now
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // start landing automatically if called from command line
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 3)
            {
                autoland = true;
                maxSpeed = int.Parse(args[2]);

                textBoxAddress.Text = args[1];
                serverAddress = args[1];
                lastState = makeRequest(serverAddress + "/start");
                landingID = lastState.id;

                disableControls();
            }
        }

        // handles making requests to the server w/ parsing response into LandingState struct defined at the bottom
        private LandingState makeRequest(string address)
        {
            string text = string.Empty;

            // do HTTP request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + address);
            request.AutomaticDecompression = DecompressionMethods.GZip; // to be sure

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd(); // get the response
            }

            LandingState result = new LandingState();

            string[] linesArray = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            if(linesArray[0] == "Zdar!")
            {
                result.state = LandingState.SUCCESS;
                return result;
            }

            if (linesArray[0] == "Krach!")
            {
                result.state = LandingState.FAILURE;
                return result;
            }

            // parsing response into struct
            result.state = LandingState.LANDING;
            result.id = int.Parse(linesArray[0]);

            result.moduleX = float.Parse(linesArray[1].Split(new char[] { ' ' })[0], CultureInfo.InvariantCulture);
            result.moduleY = float.Parse(linesArray[1].Split(new char[] { ' ' })[1], CultureInfo.InvariantCulture);

            result.velocityX = float.Parse(linesArray[2].Split(new char[] { ' ' })[0], CultureInfo.InvariantCulture);
            result.velocityY = float.Parse(linesArray[2].Split(new char[] { ' ' })[1], CultureInfo.InvariantCulture);

            result.fuel = float.Parse(linesArray[3], CultureInfo.InvariantCulture);

            result.landingL = float.Parse(linesArray[4].Split(new char[] { ' ' })[0], CultureInfo.InvariantCulture);
            result.landingR = float.Parse(linesArray[4].Split(new char[] { ' ' })[1], CultureInfo.InvariantCulture);

            return result;
        }

        // occurs when manual landing button is clicked
        private void buttonStart_Click(object sender, EventArgs e)
        {
            autoland = false;

            serverAddress = textBoxAddress.Text;
            lastState = makeRequest(serverAddress + "/start");
            landingID = lastState.id;

            disableControls();
        }

        // occurs when autolanding button is clicked
        private void buttonStartAuto_Click(object sender, EventArgs e)
        {
            autoland = true;

            serverAddress = textBoxAddress.Text;
            lastState = makeRequest(serverAddress + "/start");
            landingID = lastState.id;

            disableControls();
        }

        // calculates autolanding moves and sends the requests
        private void calculateAutoLand(LandingState state)
        {
            bool thrustUp = false;
            bool thrustLeft = false;
            bool thrustRight = false;

            // vertical
            if ((state.velocityY < -4 && state.moduleY < 40) ||
                (state.velocityY < -8 && state.moduleY < 100) ||
                (state.velocityY < -12 && state.moduleY < 150) ||
                (state.velocityY < -15 && state.moduleY < 160))
            {
                thrustUp = true;
            }

            // to fit the board
            if((state.moduleX - 20 < state.landingL))
            {
                thrustRight = true;
            }

            if((state.moduleX + 20 > state.landingR))
            {
                thrustLeft = true;
            }

            // horizontal overspeed
            if((state.velocityX > 5))
            {
                thrustRight = false;
                thrustLeft = true;
            }

            if((state.velocityX < -5))
            {
                thrustRight = true;
                thrustLeft = false;
            }

            // create and send the request
            string url = serverAddress + "/stav?id=" + landingID;
            if (thrustUp) url += "&nahoru=1"; else url += "&nahoru=0";
            if (thrustLeft) url += "&doleva=1"; else url += "&doleva=0";
            if (thrustRight) url += "&doprava=1"; else url += "&doprava=0";
            makeRequest(url);
        }

        // periodic call, fetches actual data and triggers autolanding function
        private void updaterTimer_Tick(object sender, EventArgs e)
        {
            if(landingID != -1)
            {
                LandingState state = makeRequest(serverAddress + "/stav?id=" + landingID);
                if (autoland) calculateAutoLand(state); // autoland calculations

                showState(state);

                switch (state.state)
                {
                    case LandingState.SUCCESS:
                        landingID = -1;
                        //MessageBox.Show("Přistání bylo úspěšné!", "Stav přistání", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        enableControls();
                        break;

                    case LandingState.FAILURE:
                        landingID = -1;
                        //MessageBox.Show("Přistání se nezdařilo.", "Stav přistání", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        enableControls();
                        break;

                    case LandingState.LANDING:
                        showData(state);
                        drawScheme(state);

                        lastState = state;
                        break;
                }
            }
        }

        // output the data into information labels
        private void showData(LandingState state)
        {
            labelID.Text = "ID: " + state.id.ToString();

            labelX.Text = "X: " + Math.Round(state.moduleX, 1).ToString();
            labelY.Text = "Y: " + Math.Round(state.moduleY, 1).ToString();

            if (state.velocityX > -5 && state.velocityX < 5) labelVX.ForeColor = Color.Green;
            if (state.velocityX < -5 || state.velocityX > 5) labelVX.ForeColor = Color.Red;
            labelVX.Text = "vX: " + Math.Round(state.velocityX, 1).ToString();

            if (state.velocityY > -5) labelVY.ForeColor = Color.Green;
            if (state.velocityY < -5) labelVY.ForeColor = Color.Red;
            labelVY.Text = "vY: " + Math.Round(state.velocityY, 1).ToString();

            if (state.fuel < 5) labelFuel.ForeColor = Color.Red;
            if (state.fuel > 5 && state.fuel < 10) labelFuel.ForeColor = Color.Orange;
            if (state.fuel > 10) labelFuel.ForeColor = Color.Green;
            labelFuel.Text = "P: " + Math.Round(state.fuel, 1).ToString();

            labelLandingL.Text = "L: " + Math.Round(state.landingL, 1).ToString();
            labelLandingR.Text = "R: " + Math.Round(state.landingR, 1).ToString();
        }

        // show colored state info
        private void showState(LandingState state)
        {
            switch (state.state)
            {
                case LandingState.LANDING:
                    labelState.Text = "Přistání probíhá...";
                    labelState.ForeColor = Color.Orange;
                    break;
                case LandingState.SUCCESS:
                    labelState.Text = "Přistání bylo úspěšné!";
                    labelState.ForeColor = Color.Green;
                    break;
                case LandingState.FAILURE:
                    labelState.Text = "Přistání se nezdařilo.";
                    labelState.ForeColor = Color.Red;
                    break;
            }
            labelState.Visible = true;
        }

        // draw the picture of the situation
        private void drawScheme(LandingState state)
        {
            Bitmap bmp = new Bitmap(2000, 2000);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
            }
            scheme.Image = bmp;

            using (Graphics g = Graphics.FromImage(scheme.Image))
            {
                g.DrawLine(new Pen(Color.Black, 20), state.landingL * 10, 2000, state.landingR * 10, 2000);

                object o = Resources.ResourceManager.GetObject("lunarModule");
                Image lunarModule = (Image)o;
                g.DrawImage(lunarModule, 10 * state.moduleX, 2000 - 10 * state.moduleY - 70);
            }
        }

        // disabling/enabling buttons
        private void disableControls()
        {
            buttonStart.Enabled = false;
            buttonStartAuto.Enabled = false;
            textBoxAddress.Enabled = false;
        }

        private void enableControls()
        {
            buttonStart.Enabled = true;
            buttonStartAuto.Enabled = true;
            textBoxAddress.Enabled = true;
            textBoxAddress.Focus();
        }

        // handling keyboard manual movement
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                landingID = -1;
                enableControls();
            }

            if (landingID == -1 || autoland) return;
            switch (e.KeyCode) // sending requests by the detected keys
            {
                case Keys.Up:
                    makeRequest(serverAddress + "/stav?id=" + landingID + "&nahoru=1");
                    break;
                case Keys.Left:
                    makeRequest(serverAddress + "/stav?id=" + landingID + "&doleva=1");
                    break;
                case Keys.Right:
                    makeRequest(serverAddress + "/stav?id=" + landingID + "&doprava=1");
                    break;
            }
        }

        // DTTO like higher
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (landingID == -1 || autoland) return;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    makeRequest(serverAddress + "/stav?id=" + landingID + "&nahoru=0");
                    break;
                case Keys.Left:
                    makeRequest(serverAddress + "/stav?id=" + landingID + "&doleva=0");
                    break;
                case Keys.Right:
                    makeRequest(serverAddress + "/stav?id=" + landingID + "&doprava=0");
                    break;
            }
        }
    }

    // server data struct
    struct LandingState
    {
        public const int LANDING = 1;
        public const int SUCCESS = 2;
        public const int FAILURE = 3;

        public int state;

        public int id;

        public float moduleX, moduleY, velocityX, velocityY, fuel, landingL, landingR;

        public override string ToString() // debugging purposes
        {
            return "ID " + id + " (state " + state + ")\nX: " + moduleX + ", Y: " + moduleY + "\nvX: " + velocityX + ", vY: " + velocityY + "\nfuel: " + fuel + "\nlandingL: " + landingL + ", landingR: " + landingR;
        }
    }
}
