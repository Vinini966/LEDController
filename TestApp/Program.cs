using LEDController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string _xml = "ArduinoConfig.xml";

            LEDComunicator.Initilize(_xml);

            bool on = true;

            int space = 0;
            bool rising = true;

            LEDComunicator.TestLED(on, space);

            while (!Console.KeyAvailable)
            {
                // Your loop logic here
                LEDComunicator.TestLED(on, space);
                // Add some delay to avoid high CPU usage
                System.Threading.Thread.Sleep(1); // 1 second delay

                space += rising ? 1 : -1;
                if (space >= LEDComunicator.Config.LEDAmount - 1 || space <= 0)
                    rising = !rising;
                    
            }

        }
    }
}
