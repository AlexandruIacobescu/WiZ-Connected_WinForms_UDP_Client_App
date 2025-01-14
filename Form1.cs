using System.Net.Sockets;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        // dictionary where key = 'combo_box_item_text' and value = 'corresponding_ip_address'
        Dictionary<string, string> ipstr_ip = new Dictionary<string, string>();

        Dictionary<string, int> scene_id = new Dictionary<string, int>();

        private Dictionary<string, bool> cachedSettings = new Dictionary<string, bool>();

        private Dictionary<string, List<string>> groups = new();


        static List<string> ScanNetwork(int port)
        {
            var s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            s.Connect("8.8.8.8", 80);
            var ip = s.LocalEndPoint.ToString().Split(".")[0..3];
            s.Close();
            var payload = "{\"method\":\"registration\",\"params\":{\"register\":true}}";
            var activeHosts = new List<string>();

            var tasks = new List<Task>();
            for (int i = 1; i < 255; i++) // Adjust the range as needed
            {
                var host = $"{ip[0]}.{ip[1]}.{ip[2]}.{i}";
                tasks.Add(Task.Run(() =>
                {
                    var result = ScanHost(host, port, payload);
                    if (result != null)
                    {
                        activeHosts.Add(result);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
            return activeHosts;
        }

        static string ScanHost(string host, int port, string payload, int timeout = 800)
        {
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.ReceiveTimeout = timeout;

            try
            {
                var data = Encoding.UTF8.GetBytes(payload);
                udpSocket.SendTo(data, new IPEndPoint(IPAddress.Parse(host), port));
                var buffer = new byte[1024];
                EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                udpSocket.ReceiveFrom(buffer, ref remoteEP);
                return host;
            }
            catch (SocketException e) when (e.SocketErrorCode == SocketError.TimedOut)
            {
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                udpSocket.Close();
            }
        }

        async private void PeformScan()
        {
            int portToScan = 38899; // Change this to the desired port
            var activeHosts = ScanNetwork(portToScan);
            foreach (string host in activeHosts)
            {
                if (!ipstr_ip.ContainsValue(host))
                {
                    string alias = "";
                    string ip = host;
                    string name = $"[{alias}] [{ip}]";
                    comboBox1.Items.Add(name);
                    SuccessLabelShowFor("Bulb Added to List", 1000);
                    ipstr_ip.Add(name, ip);

                }
                else
                {
                    ErrorLabelShowFor("Bulb name already added", 1000);
                }
            }
        }        

        async private void SuccessLabelShowFor(string msg, int delay)
        {
            label9.ForeColor = Color.Green;
            label9.Text = msg;
            label9.Visible = true;
            await Task.Delay(delay);
            label9.Visible = false;
        }

        async private void ErrorLabelShowFor(string msg, int delay)
        {
            label9.ForeColor = Color.Red;
            label9.Text = msg;
            label9.Visible = true;
            await Task.Delay(delay);
            label9.Visible = false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            brgLabel.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            tempLabel.Text = (trackBar2.Value * 100).ToString() + " K";
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            redLabel.Text = trackBar3.Value.ToString();
            pictureBox1.BackColor = Color.FromArgb(trackBar3.Value, trackBar4.Value, trackBar5.Value);
            label11.Text = RGBToHex(trackBar3.Value, trackBar4.Value, trackBar5.Value);
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            greenLabel.Text = trackBar4.Value.ToString();
            pictureBox1.BackColor = Color.FromArgb(trackBar3.Value, trackBar4.Value, trackBar5.Value);
            label11.Text = RGBToHex(trackBar3.Value, trackBar4.Value, trackBar5.Value);
        }

        private void trackBar5_ValueChanged(object sender, EventArgs e)
        {
            blueLabel.Text = trackBar5.Value.ToString();
            pictureBox1.BackColor = Color.FromArgb(trackBar3.Value, trackBar4.Value, trackBar5.Value);
            label11.Text = RGBToHex(trackBar3.Value, trackBar4.Value, trackBar5.Value);
        }

        private void trackBar6_ValueChanged(object sender, EventArgs e)
        {
            whiteLabel.Text = trackBar6.Value.ToString();
        }

        private void trackBar7_ValueChanged(object sender, EventArgs e)
        {
            label13.Text = trackBar7.Value.ToString();
        }

        public static string RGBToHex(int red, int green, int blue)
        {
            Color color = Color.FromArgb(red, green, blue);
            return ColorToHex(color);
        }

        public static string ColorToHex(Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            brgLabel.Text = trackBar1.Value.ToString();
            tempLabel.Text = (trackBar2.Value * 100).ToString() + " K";
            redLabel.Text = trackBar4.Value.ToString();
            greenLabel.Text = trackBar5.Value.ToString();
            blueLabel.Text = trackBar3.Value.ToString();
            whiteLabel.Text = trackBar6.Value.ToString();
            label13.Text = trackBar7.Value.ToString();
            comboBox3.Items.Add("(None)");
            comboBox3.Items.Add("(All)");
            File.WriteAllText("error.log", string.Empty);

            // load scenes from json
            string scenes_json = File.ReadAllText("scenes.json");
            Dictionary<string, int> scenes = JsonConvert.DeserializeObject<Dictionary<string, int>>(scenes_json);

            foreach (var scene in scenes)
            {
                comboBox2.Items.Add(scene.Key);
            }
            scene_id = scenes;

            // load bulb grous from json         
            try
            {
                string groups_json = File.ReadAllText("groups.json");
                groups = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(groups_json);
                foreach (var group in groups)
                {
                    comboBox3.Items.Add(group.Key);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
                File.AppendAllText("error.log", ex.Message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                File.AppendAllText("error.log", ex.Message + Environment.NewLine);
            }

            // Load bulbs from json
            try
            {
                string bulbs_json = File.ReadAllText("bulbs.json");
                Dictionary<string, string> bulbs = JsonConvert.DeserializeObject<Dictionary<string, string>>(bulbs_json);

                foreach (var bulb in bulbs)
                {
                    comboBox1.Items.Add($"[{bulb.Value}] [{bulb.Key}]");
                    if (!ipstr_ip.ContainsValue(bulb.Key))
                        ipstr_ip.Add($"[{bulb.Value}] [{bulb.Key}]", bulb.Key);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
                File.AppendAllText("error.log", ex.Message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                File.AppendAllText("error.log", ex.Message + Environment.NewLine);
            }

            // Load cached settings
            try
            {
                string cacheJson = File.ReadAllText("cache.json");
                cachedSettings = JsonConvert.DeserializeObject<Dictionary<string, bool>>(cacheJson);
                if (cachedSettings.ContainsKey("checkBox1.Checked"))
                {
                    checkBox1.Checked = cachedSettings["checkBox1.Checked"];
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
                File.AppendAllText("error.log", ex.Message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                File.AppendAllText("error.log", ex.Message + Environment.NewLine);
            }

            // Initizlize Preview
            pictureBox1.BackColor = Color.FromArgb(trackBar3.Value, trackBar4.Value, trackBar5.Value);
            label11.Text = RGBToHex(trackBar3.Value, trackBar4.Value, trackBar5.Value);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ipstr_ip.ContainsValue(textBox1.Text) && !ipstr_ip.ContainsKey(textBox2.Text))
            {
                string alias = textBox2.Text;
                string ip = textBox1.Text;
                string name = $"[{alias}] [{ip}]";
                comboBox1.Items.Add(name);
                SuccessLabelShowFor("Bulb Added to List", 1000);
                ipstr_ip.Add(name, ip);

            }
            else
            {
                ErrorLabelShowFor("Bulb name already added", 1000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != 0 && comboBox3.SelectedItem != null)
            {
                foreach (var line in richTextBox1.Lines)
                {
                    if (line != "")
                    {
                        string ip = ipstr_ip[line];
                        Functions.SetBrightness(ip, 38899, trackBar1.Value);
                    }
                }

            }
            else if (comboBox1.SelectedItem != null)
            {
                string brightnessLevel = trackBar1.Value.ToString();
                string hostIp = ipstr_ip[comboBox1.SelectedItem.ToString()];
                string payload = $"{{\"method\":\"setPilot\",\"params\":{{\"state\":true,\"dimming\":{brightnessLevel}}}}}";

                if (hostIp != null)
                {
                    Functions.SendUdpPayload(hostIp, 38899, payload);
                }
            }
            else
            {
                ErrorLabelShowFor("No Bulb Selected", 1000);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kelvins = Int32.Parse(trackBar2.Value.ToString()) * 100;
            if (comboBox3.SelectedIndex != 0 && comboBox3.SelectedItem != null)
            {
                foreach (var line in richTextBox1.Lines)
                {
                    if (line != "")
                    {
                        string ip = ipstr_ip[line];
                        Functions.SetTemperature(ip, 38899, kelvins);
                    }
                }

            }
            else if (comboBox1.SelectedItem != null)
            {
                string hostIp = ipstr_ip[comboBox1.SelectedItem.ToString()];

                if (hostIp != null)
                {
                    Functions.SetTemperature(hostIp, 38899, kelvins);
                }
            }
            else
            {
                ErrorLabelShowFor("No Bulb Selected", 1000);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string r = trackBar3.Value.ToString();
                string g = trackBar4.Value.ToString();
                string b = trackBar5.Value.ToString();
                string w = trackBar6.Value.ToString();
                string payload = $"{{\"method\":\"setPilot\",\"params\":{{\"state\":true,\"r\":{r},\"g\":{g},\"b\":{b},\"w\":{w}}}}}";
                string hostIp = ipstr_ip[comboBox1.SelectedItem.ToString()];

                if (hostIp != null)
                {
                    Functions.SendUdpPayload(hostIp, 38899, payload);
                }
            }
            else
            {
                ErrorLabelShowFor("No Bulb Selected", 1000);
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            PeformScan();
            SuccessLabelShowFor("Done", 1000);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != 0 && comboBox3.SelectedItem != null)
            {
                foreach (var line in richTextBox1.Lines)
                {
                    if (line != "")
                    {
                        string ip = ipstr_ip[line];
                        Functions.TurnOffLight(ip, 38899);
                    }
                }

            }
            else if (comboBox1.SelectedItem != null)
            {
                string hostIp = ipstr_ip[comboBox1.SelectedItem.ToString()];
                if (hostIp != null)
                {
                    Functions.TurnOffLight(hostIp, 38899);
                }
            }
            else
            {
                ErrorLabelShowFor("No Bulb Selected", 1000);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != 0 && comboBox3.SelectedItem != null)
            {
                foreach (var line in richTextBox1.Lines)
                {
                    if (line != "")
                    {
                        string ip = ipstr_ip[line];
                        Functions.TurnOnLight(ip, 38899);
                    }
                }

            }
            else if (comboBox1.SelectedItem != null)
            {
                string hostIp = ipstr_ip[comboBox1.SelectedItem.ToString()];
                if (hostIp != null)
                {
                    Functions.TurnOnLight(hostIp, 38899);
                }
            }
            else
            {
                ErrorLabelShowFor("No Bulb Selected", 1000);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to Rremove:\n{comboBox1.Text}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ipstr_ip.Remove(comboBox1.SelectedItem.ToString());
                    comboBox1.Items.Remove(comboBox1.SelectedItem);
                }
            }
            else
            {
                ErrorLabelShowFor("No Bulb Selected", 1000);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && comboBox1.SelectedItem != null)
            {
                string hostIp = ipstr_ip[comboBox1.SelectedItem.ToString()];
                string scene = comboBox2.SelectedItem.ToString();
                int scene_id_int = scene_id[scene];
                string payload1 = $"{{\"method\":\"setPilot\",\"params\":{{\"state\":true,\"sceneid\":{scene_id_int}}}}}";
                string payload2 = $"{{\"method\":\"setPilot\",\"params\":{{\"speed\":{trackBar7.Value}}}}}";

                if (hostIp != null)
                {
                    Functions.SendUdpPayload(hostIp, 38899, payload1);
                    Functions.SendUdpPayload(hostIp, 38899, payload2);
                }
            }
            else
            {
                ErrorLabelShowFor("No Bulb Selected", 1000);
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                int brightnessLevel = trackBar1.Value;
                if (comboBox3.SelectedIndex != 0 && comboBox3.SelectedItem != null)
                {
                    foreach (var line in richTextBox1.Lines)
                    {
                        if (line != "")
                        {
                            string ip = ipstr_ip[line];
                            Functions.SetBrightness(ip, 38899, brightnessLevel);
                        }
                    }

                }
                else if (comboBox1.SelectedItem != null)
                {
                    string hostIp = ipstr_ip[comboBox1.SelectedItem.ToString()];
                    if (hostIp != null)
                    {
                        Functions.SetBrightness(hostIp, 38899, brightnessLevel);
                    }
                }
                else
                {
                    ErrorLabelShowFor("No Bulb Selected", 1000);
                }
            }
        }



        private async void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            string cacheJson = File.ReadAllText("cache.json");
            try
            {
                cachedSettings["checkBox1.Checked"] = checkBox1.Checked;
            }
            catch (KeyNotFoundException)
            {
                cachedSettings.Add("checkBox1.Checked", checkBox1.Checked);
            }
            finally
            {
                File.WriteAllText("cache.json", JsonConvert.SerializeObject(cachedSettings, Formatting.Indented));
            }
        }

        private async void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string ip = ipstr_ip[comboBox1.SelectedItem.ToString()];
                string response = await Functions.GetState(ip, 38899);
                if (response != string.Empty)
                {
                    richTextBox2.Text = response;
                }
                else
                {
                    richTextBox2.Text = "(No response received.)";
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            //comboBox1.SelectedIndex = 0;
            if (comboBox3.SelectedIndex == 0)
            {
                richTextBox1.Text = "";
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                foreach (var item in ipstr_ip)
                {
                    richTextBox1.Text += item.Key + "\n";
                }
            }
            else
            {
                string group = comboBox3.SelectedItem.ToString();
                List<string> bulbs = groups[group];
                foreach (var bulb in bulbs)
                {
                    foreach (var item in ipstr_ip)
                    {
                        if (bulb == item.Value)
                        {
                            richTextBox1.Text += item.Key + "\n";
                        }
                    }
                }
            }
        }
    }
}