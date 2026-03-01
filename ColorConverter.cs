using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class ColorConverter
    {
        public static (int R, int G, int B, int W) RGBToRGBW(int r, int g, int b)
        {
            int w = Math.Min(r, Math.Min(g, b));
            int rPrime = r - w;
            int gPrime = g - w;
            int bPrime = b - w;
            return (rPrime, gPrime, bPrime, w);
        }
        public static (byte R, byte G, byte B) HexToRgb(string hex)
        {
            hex = hex.TrimStart('#');
            
            if (hex.Length != 6)
                throw new ArgumentException("Hex string must be 6 characters (RRGGBB)", nameof(hex));

            byte r = Convert.ToByte(hex.Substring(0, 2), 16);
            byte g = Convert.ToByte(hex.Substring(2, 2), 16);
            byte b = Convert.ToByte(hex.Substring(4, 2), 16);

            return (r, g, b);
        }

    }
}
