﻿using System;
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
        public static (int R, int G, int B, int W) ConvertToRGBW(int red, int green, int blue)
        {
            // Normalize RGB values to the range 0.0 - 1.0
            double rNorm = red / 255.0;
            double gNorm = green / 255.0;
            double bNorm = blue / 255.0;

            // Calculate the white component
            double white = Math.Min(rNorm, Math.Min(gNorm, bNorm));

            // Subtract the white component from the RGB values
            double rPrime = rNorm - white;
            double gPrime = gNorm - white;
            double bPrime = bNorm - white;

            // Scale back to 0-255 and clamp to ensure valid values
            int rFinal = (int)Math.Clamp(rPrime * 255, 0, 255);
            int gFinal = (int)Math.Clamp(gPrime * 255, 0, 255);
            int bFinal = (int)Math.Clamp(bPrime * 255, 0, 255);
            int wFinal = (int)Math.Clamp(white * 255, 0, 255);

            return (rFinal, gFinal, bFinal, wFinal);
        }

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

        public static void SetScene(string hostIp, int port, int sceneId)
        {
            string payload = JsonConvert.SerializeObject(new
            {
                method = "setPilot",
                @params = new
                {
                    state = true,
                    sceneId = sceneId
                }
            });
            SendUdpPayload(hostIp, port, payload);
        }

        public static void SetSpeed(string hostIp, int port, int speed)
        {
            if (speed < 1 || speed > 200)
            {
                throw new ArgumentOutOfRangeException("Speed must be between 1 and 100.");
            }
            string payload = JsonConvert.SerializeObject(new
            {
                method = "setPilot",
                @params = new
                {
                    speed = speed
                }
            });
            SendUdpPayload(hostIp, port, payload);
        }

        public static void TurnOnLight(string ip, int port)
        {
            string payload = JsonConvert.SerializeObject(new
            {
                method = "setPilot",
                @params = new
                {
                    state = true 
                }
            });
            SendUdpPayload(ip, port, payload);
        }

        public static void TurnOffLight(string ip, int port)
        {
            string payload = JsonConvert.SerializeObject(new
            {
                method = "setPilot",
                @params = new
                {
                    state = false
                }
            });
            SendUdpPayload(ip, port, payload);
        }

        public static void SetBrightness(string ip, int port, int brightnessLevel)
        {
            if (brightnessLevel < 10 || brightnessLevel > 100)
            {
                throw new ArgumentOutOfRangeException("Brightness must be between 10 and 100.");
            }
            string payload = JsonConvert.SerializeObject(new
            {
                method = "setPilot",
                @params = new
                {
                    state = true,
                    dimming = brightnessLevel
                }
            });
            SendUdpPayload(ip, port, payload);
        }

        public static void SetTemperature(string ip, int port, int kelvins)
        {
            if (kelvins < 2200 || kelvins > 6500)
            {
                throw new ArgumentOutOfRangeException("Temperature must be between 2200 and 6500.");
            }
            string payload = JsonConvert.SerializeObject(new
            {
                method = "setPilot",
                @params = new
                {
                    state = true,
                    temp = kelvins
                }
            });
            SendUdpPayload(ip, port, payload);
        }

        public static void SetRGBW(string ip, int port, int red, int green, int blue, int white)
        {
            if (red < 0 || red > 255 || green < 0 || green > 255 || blue < 0 || blue > 255 || white < 0 || white > 255)
            {
                throw new ArgumentOutOfRangeException("RGBW values must be between 0 and 255.");
            }
            string payload = JsonConvert.SerializeObject(new
            {
                method = "setPilot",
                @params = new
                {
                    state = true,
                    r = red,
                    g = green,
                    b = blue,
                    w = white
                }
            });
            SendUdpPayload(ip, port, payload);
        }

        public static void SetRGBCW(string ip, int port, int red, int green, int blue, int coolWhite, int white)
        {
            if (red < 0 || red > 255 || green < 0 || green > 255 || blue < 0 || blue > 255 || white < 0 || white > 255 || coolWhite < 0 || coolWhite > 255)
            {
                throw new ArgumentOutOfRangeException("RGBCW values must be between 0 and 255.");
            }
            string payload = JsonConvert.SerializeObject(new
            {
                method = "setPilot",
                @params = new
                {
                    state = true,
                    r = red,
                    g = green,
                    b = blue,
                    c = coolWhite,
                    w = white
                }
            });
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
