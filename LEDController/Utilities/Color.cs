using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDController.Utilities
{
    [Serializable]
    struct Color
    {
        /// <summary>
        /// Red expression in terms of 0-255
        /// </summary>
        public int R;
        /// <summary>
        /// Green expression in terms of 0-255
        /// </summary>
        public int G;
        /// <summary>
        /// Blue expression in terms of 0-255
        /// </summary>
        public int B;

        /// <summary>
        /// creates a color based on a input of a 0 to 255 color value
        /// </summary>
        /// <param name="r">Red expression in terms of 0-255</param>
        /// <param name="g">Green expression in terms of 0-255</param>
        /// <param name="b">Blue expression in terms of 0-255</param>
        public Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        /// <summary>
        /// translates a float input form 0-1 to a 0 to 255 color value
        /// </summary>
        /// <param name="r">Red expression in terms of 0-1</param>
        /// <param name="g">Green expression in terms of 0-1</param>
        /// <param name="b">Blue expression in terms of 0-1</param>
        public Color(float r, float g, float b)
        {
            R = (int)MathUtls.Lerp(0, 255, r);
            G = (int)MathUtls.Lerp(0, 255, g);
            B = (int)MathUtls.Lerp(0, 255, b);
        }

        public static readonly Color red = new Color(1f, 0f, 0f);
        public static readonly Color blue = new Color(0f, 0f, 1f);
        public static readonly Color green = new Color(0f, 1f, 0f);
        public static readonly Color yellow = new Color(1f, 1f, 0f);
        public static readonly Color purple = new Color(1f, 0f, 1f);
        public static readonly Color teal = new Color(0f, 1f, 1f);
        public static readonly Color white = new Color(1f, 1f, 1f);

        /// <summary>
        /// Same as Color.off
        /// </summary>
        public static readonly Color black = new Color(0f, 0f, 0f);
        /// <summary>
        /// Same as Color.black
        /// </summary>
        public static readonly Color off = black;

        public static Color operator *(Color color, float brightness)
        {
            Color output = color;
            output.R = (int)(color.R * brightness);
            output.G = (int)(color.G * brightness);
            output.B = (int)(color.B * brightness);
            return output;
        }
    }
}
