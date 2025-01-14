using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WinFormsApp4
{
    internal class Functions
    {
        public static async Task<string> GetState(string hostIp, int port)
        {
            string payload = JsonConvert.SerializeObject(new
            {
                method = "getPilot",
                @params = new { }
            });

            using (UdpClient client = new UdpClient())
            {
                client.Client.ReceiveTimeout = 1000; // Set timeout to 1 second

                try
                {
                    byte[] sendData = Encoding.UTF8.GetBytes(payload);
                    IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Parse(hostIp), port);

                    // Send the payload asynchronously
                    await client.SendAsync(sendData, sendData.Length, serverEndpoint);

                    // Receive the response asynchronously
                    var receiveTask = client.ReceiveAsync();
                    if (await Task.WhenAny(receiveTask, Task.Delay(1000)) == receiveTask)
                    {
                        UdpReceiveResult receiveResult = await receiveTask;
                        byte[] receiveData = receiveResult.Buffer;

                        // Convert response to string
                        string response = Encoding.UTF8.GetString(receiveData);

                        // Format JSON with indentation for display
                        var parsedJson = JsonConvert.DeserializeObject(response);
                        string formattedJson = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);

                        return formattedJson;
                    }
                    else
                    {
                        File.AppendAllText("error.log", $"Error: Timeout: No response received within 1 second for host: [{hostIp}]\n");
                    }
                }
                catch (SocketException ex)
                {
                    File.AppendAllText("error.log", $"Error: {ex.Message}\n");
                }
                return string.Empty;
            }
        }

        public static void TurnOnLights(List<string> ips, int port)
        {

        }

        public static void TurnOnLight(string ip, int port)
        {
            string payload = "{\"method\":\"setPilot\",\"params\":{\"state\":true}}";
            SendUdpPayload(ip, port, payload);
        }

        public static void TurnOffLights(List<string> ips, int port)
        {

        }

        public static void TurnOffLight(string ip, int port)
        {
            string payload = "{\"method\":\"setPilot\",\"params\":{\"state\":false}}";
            SendUdpPayload(ip, port, payload);
        }

        public static void SetBrightness(string ip, int port, int brightnessLevel)
        {
            if (brightnessLevel < 10 || brightnessLevel > 100)
            {
                throw new ArgumentOutOfRangeException("Brightness must be between 10 and 100.");
            }
            string payload = $"{{\"method\":\"setPilot\",\"params\":{{\"state\":true,\"dimming\":{brightnessLevel}}}}}";
            SendUdpPayload(ip, port, payload);            
        }

        public static void SetTemperature(string ip, int port, int kelvins)
        {
            if (kelvins < 2200 || kelvins > 6500)
            {
                throw new ArgumentOutOfRangeException("Temperature must be between 2200 and 6500.");
            }
            string payload = $"{{\"method\":\"setPilot\",\"params\":{{\"state\":true,\"temp\":{kelvins}}}}}";
            SendUdpPayload(ip, port, payload);
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
    }
}
