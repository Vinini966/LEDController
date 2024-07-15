using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDController.Utilities
{
    static class MathUtls
    {

        public static float Lerp(float a, float b, float t)
        {
            float output = a + (b - a) * t;

            return Clamp(output, a, b);
        }


        public static float Clamp(float a, float min, float max)
        {
            if (a < min)
                return min;
            else if (a > max)
                return max;
            else
                return a;
        }

    }
}
