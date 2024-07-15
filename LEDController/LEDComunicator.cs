using LEDController.LEDs;
using LEDController.SerialComunications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDController
{
    public static class LEDComunicator
    {
        static SerialComunication _serialComs;
        public static SerialConfig Config;

        public static void Initilize(string configFile)
        {
            Config = new SerialConfig(configFile);
            _serialComs = new SerialComunication(Config);
        }

        public static void TestLED(bool on, int space)
        {
            List<LEDProperties> test = new List<LEDProperties>
            {
                new LEDProperties{IsOn = true, LEDSetColor = Utilities.Color.red, Brightness = 1, LEDsInSegment = space},
                new LEDProperties{IsOn = true, LEDSetColor = Utilities.Color.blue, Brightness = 1, LEDsInSegment = 1},
                new LEDProperties{IsOn = true, LEDSetColor = Utilities.Color.green, Brightness = 1, LEDsInSegment = null},
            };

            LEDJSON json = LEDProcesser.ProcessLEDList(test, LEDPatterns.None);

            _serialComs.SendData(JsonConvert.SerializeObject(json));
        }
    }
}
