using LEDController.SerialComunications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDController.LEDs
{
    enum LEDPatterns
    {
        None,
        Interlaced,
    }
    [Serializable]
    internal struct LEDJSON
    {
        public int P;
        public List<SerialLEDProperties> List;

        public LEDJSON(int pattern, List<SerialLEDProperties> list)
        {
            P = pattern;
            List = list;
        }
    }

    static internal class LEDProcesser
    {
        static int _totalLEDs;

        public static LEDJSON ProcessLEDList(List<LEDProperties> properties, LEDPatterns pattern)
        {
            _totalLEDs = LEDComunicator.Config.LEDAmount;

            List<SerialLEDProperties> serialLED = new List<SerialLEDProperties>();

            foreach(LEDProperties led in properties)
            {
                serialLED.Add(new SerialLEDProperties(led));
            }

            if(properties.Any(x=>x.StartLED != null))
            {
                FillStartLEDPosition(properties, ref serialLED);
            }

            FillOutNulledValues(ref serialLED);

            LEDJSON output = new LEDJSON((int)LEDPatterns.None, serialLED);
            return output;
        }

        static void FillOutNulledValues(ref List<SerialLEDProperties> serialLED)
        {
            if (serialLED.All(x => x.N > 0))
                return;

            _totalLEDs -= serialLED.Sum(x => x.N > 0 ? x.N : 0);

            int needsfill = serialLED.Count(x => x.N < 0);

            int add = 0;

            List<SerialLEDProperties> fillLED = serialLED.Where(x => x.N < 0).ToList();
            fillLED.ForEach(x => x.N = 0);

            while(_totalLEDs > 0)
            {
                fillLED[add].N++;
                _totalLEDs--;
                add++;
                if (add >= fillLED.Count)
                    add = 0;
            }
        }

        static void FillStartLEDPosition(List<LEDProperties> properties, ref List<SerialLEDProperties> serialLED)
        {

            List<int> nonNulledIndexs = properties.Select((value, index) => new { value, index }).Where(x => x.value.StartLED != null).Select(x=>x.index).ToList();

            int lastIndex = 0;

            foreach(int index in nonNulledIndexs)
            {
               List<SerialLEDProperties> nulledValues = serialLED.Skip(lastIndex).Take(index - lastIndex).ToList();
            }
        }

        static void CompressLEDAmounts(ref List<SerialLEDProperties> serialLED)
        {

        }
    }
}
