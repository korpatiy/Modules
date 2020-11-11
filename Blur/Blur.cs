using PluginInterface;
using System;
using System.Drawing;

namespace Blur
{
    [Version(1, 0)]
    public class Blur : IPlugin
    {
        public string Name
        {
            get
            {
                return "Размытие";
            }
        }

        public string Author
        {
            get
            {
                return "Размывальщик";
            }
        }

        public static UInt32[,] pixel;
        public static Bitmap image;

        public void Transform(Bitmap bitmap)
        {
            image = bitmap;

            pixel = new UInt32[image.Height, image.Width];
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                    pixel[y, x] = (UInt32)(image.GetPixel(x, y).ToArgb());

            pixel = Filter.matrix_filtration(image.Width, image.Height, pixel, Filter.N2, Filter.blur);

            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                    image.SetPixel(x, y, Color.FromArgb((int)pixel[y, x]));

            bitmap = image;
        }

    }
}
