using PluginInterface;
using System;
using System.Drawing;

namespace ShadesOfGray
{
    [Version(1, 0)]
    public class ShadesOfGray : IPlugin
    {
        public string Name
        {
            get
            {
                return "Оттенки серого";
            }
        }

        public string Author
        {
            get
            {
                return "NoName";
            }
        }

        public void Transform(Bitmap bitmap)
        {
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    int grayScale = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    Color newColor = Color.FromArgb(pixelColor.A, grayScale, grayScale, grayScale);
                    bitmap.SetPixel(x, y, newColor);
                }

        }
    }
}
