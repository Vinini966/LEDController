using LEDController.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDController.SerialComunications
{
    [Serializable]
    internal class SerialLEDProperties
    {
        public Color C;
        public int N;

       public SerialLEDProperties(LEDs.LEDProperties led)
       {
            N = led.LEDsInSegment == null ? -1 : (int)led.LEDsInSegment;

            if (!led.IsOn)
            {
                C = Color.off;
                return;
            }

            C = led.LEDSetColor * led.Brightness;
       }
    }
}
