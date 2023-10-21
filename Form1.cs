using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        // dictionary where key = 'combo_box_item_text' and value = 'corresponding_ip_address'
        Dictionary<string, string> ipstr_ip = new Dictionary<string, string>();

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

        public static void SendUdpPayload(string hostIp, int port, string payload)
        {
            try
            {
                using (UdpClient udpClient = new UdpClient())
                {
                    IPAddress ipAddress = IPAddress.Parse(hostIp);
                    IPEndPoint endPoint = new IPEndPoint(ipAddress, port);

                    byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);
                    udpClient.Send(payloadBytes, payloadBytes.Length, endPoint);
                    Console.WriteLine("UDP payload sent successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending UDP payload: {ex.Message}");
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

            // load scenes from json
            // 

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
            if (comboBox1.SelectedItem != null)
            {
                string brightnessLevel = trackBar1.Value.ToString();
                string hostIp = ipstr_ip[comboBox1.SelectedItem.ToString()];
                string payload = $"{{\"method\":\"setPilot\",\"params\":{{\"state\":true,\"dimming\":{brightnessLevel}}}}}";

                if (hostIp != null)
                {
                    SendUdpPayload(hostIp, 38899, payload);
                }
            }
            else
            {
                ErrorLabelShowFor("No Bulb Selected", 1000);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string kelvins = (Int32.Parse(trackBar2.Value.ToString()) * 100).ToString();
                string hostIp = ipstr_ip[comboBox1.SelectedItem.ToString()];
                string payload = $"{{\"method\":\"setPilot\",\"params\":{{\"state\":true,\"temp\":{kelvins}}}}}";

                if (hostIp != null)
                {
                    SendUdpPayload(hostIp, 38899, payload);
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
                    SendUdpPayload(hostIp, 38899, payload);
                }
            }
            else
            {
                ErrorLabelShowFor("No Bulb Selected", 1000);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PeformScan();
            SuccessLabelShowFor("Done", 1000);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string hostIp = ipstr_ip[comboBox1.SelectedItem.ToString()];
                string payload = $"{{\"method\":\"setPilot\",\"params\":{{\"state\":false}}}}";

                if (hostIp != null)
                {
                    SendUdpPayload(hostIp, 38899, payload);
                }
            }
            else
            {
                ErrorLabelShowFor("No Bulb Selected", 1000);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string hostIp = ipstr_ip[comboBox1.SelectedItem.ToString()];
                string payload = $"{{\"method\":\"setPilot\",\"params\":{{\"state\":true}}}}";

                if (hostIp != null)
                {
                    SendUdpPayload(hostIp, 38899, payload);
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
    }
}