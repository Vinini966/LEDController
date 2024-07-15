using LEDController.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDController.LEDs
{
    class LEDProperties
    {

        public bool IsOn;

        public Color LEDSetColor;

        /// <summary>
        /// Number of LEDs in this controled segment
        /// Set to null to auto calculate based on total segments
        /// </summary>
        public int? LEDsInSegment;

        public int? StartLED;

        public float Brightness;
    }
}
