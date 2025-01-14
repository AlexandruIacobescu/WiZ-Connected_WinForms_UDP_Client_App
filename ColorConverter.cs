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

    }
}
