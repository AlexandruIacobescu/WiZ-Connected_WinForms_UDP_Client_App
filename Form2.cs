using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        static List<string> GetScenarioJsonFiles()
        {
            // Get the current working directory
            string cwd = Directory.GetCurrentDirectory();

            // Search for files starting with "scenario" and ending with ".json"
            var matchingFiles = Directory.GetFiles(cwd, "scenario*.json", SearchOption.TopDirectoryOnly);

            // Extract only the relative file names
            var relativePaths = new List<string>();
            foreach (var file in matchingFiles)
            {
                relativePaths.Add(Path.GetFileName(file));
            }

            return relativePaths;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<string> scenarios = GetScenarioJsonFiles();
            foreach (string scenario in scenarios)
            {
                listBox1.Items.Add(scenario);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jsonString = File.ReadAllText(listBox1.SelectedItem.ToString());
            jsonString = jsonString.Replace("\t", "  ");
            richTextBox1.Text = jsonString;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                bool ok = SetScenarioFromJsonFile(listBox1.SelectedItem.ToString());
                if (!ok)
                {
                    ErrorLabelShowFor("Failed to load scenario. Check log.", 2000, Color.Red);
                }
                else
                {
                    ErrorLabelShowFor("Scenario loaded successfully", 2000, Color.Green);
                }
            }
            else
            {
                ErrorLabelShowFor("Please select a scenario to load", 2000, Color.Red);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<string> scenarios = GetScenarioJsonFiles();
            foreach (string scenario in scenarios)
            {
                listBox1.Items.Add(scenario);
            }
        }

        async private void ErrorLabelShowFor(string msg, int delay, Color color)
        {
            msgLabel.ForeColor = color;
            msgLabel.Text = msg;
            msgLabel.Visible = true;
            await Task.Delay(delay);
            msgLabel.Visible = false;
        }

        public bool SetScenarioFromJsonFile(string filePath)
        {
            if (!File.Exists(filePath))            
                throw new FileNotFoundException("File not found", filePath);            
            string json = File.ReadAllText(filePath);
            dynamic scenario = JsonConvert.DeserializeObject(json);
            ValidateScenarioJson(scenario);

            int temp = 0, dimming = 0, sceneId = 0;
            int[] rgbcw = new int[5];
            try
            {                
                foreach (var bulb in scenario.appliesTo)
                {
                    string ip = bulb.ip;
                    if (bulb.dimming != null)
                    {
                        dimming = bulb.dimming;                        
                        Functions.SetBrightness(ip, 38899, dimming);
                    }
                    else
                    {
                        throw new Exception("Invalid scenario format");
                    }
                    if (bulb.temp != null)
                    {
                        temp = bulb.temp;
                        Functions.SetTemperature(ip, 38899, temp);
                    }
                    else if (bulb.rgbcw != null)
                    {
                        rgbcw[0] = bulb.rgbcw[0];
                        rgbcw[1] = bulb.rgbcw[1];
                        rgbcw[2] = bulb.rgbcw[2];
                        rgbcw[3] = bulb.rgbcw[3];
                        rgbcw[4] = bulb.rgbcw[4];
                        Functions.SetRGBCW(ip, 38899, rgbcw[0], rgbcw[1], rgbcw[2], rgbcw[3], rgbcw[4]);
                    }
                    else if (bulb.sceneId != null)
                    {
                        sceneId = bulb.sceneId;
                        Functions.SetScene(ip, 38899, sceneId);
                    }
                    else
                    {
                        throw new Exception("Invalid scenario format");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                File.WriteAllText("error.log", ex.Message);
                return false;
            }
        }

        static bool ValidateScenarioJson(dynamic jsonObject)
        {
            // 1. Check if 'appliesTo' exists and is an array
            if (jsonObject.appliesTo == null || !(jsonObject.appliesTo is IEnumerable<dynamic>))
            {
                return false;
            }

            foreach (var item in jsonObject.appliesTo)
            {
                // 2. Check if 'ip' exists and is a string
                if (item.ip == null || !(item.ip is string))
                {
                    return false;
                }

                // 3. Check if 'dimming' exists and is an integer
                if (item.dimming == null || !(item.dimming is int))
                {
                    return false;
                }

                // 4. Check for mutually exclusive fields: 'temp' (int), 'rgbcw' (list of 5 ints), or 'sceneid' (int)
                bool hasTemp = item.temp != null && item.temp is int;
                bool hasRgbcw = item.rgbcw != null && item.rgbcw is IEnumerable<dynamic> && ValidateRgbcw(item.rgbcw);
                bool hasSceneid = item.sceneid != null && item.sceneid is int;

                // Ensure only one of these fields is present
                if (!(hasTemp ^ hasRgbcw ^ hasSceneid)) // XOR ensures exactly one is true
                {
                    return false;
                }
            }

            // All checks passed
            return true;
        }

        static bool ValidateRgbcw(dynamic rgbcw)
        {
            // Ensure rgbcw is a list of exactly 5 integers
            var list = (IEnumerable<dynamic>)rgbcw;
            int count = 0;
            foreach (var value in list)
            {
                if (!(value is int))
                {
                    return false;
                }
                count++;
            }
            return count == 5;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
