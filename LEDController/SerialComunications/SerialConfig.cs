using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LEDController.SerialComunications
{
    public class SerialConfig
    {
        public int BaudRate { get; private set; }
        public string COMPort { get; private set; }
        public int LEDAmount { get; private set; }

        public SerialConfig(string configFile)
        {
            if (!File.Exists(configFile))
            {
                Console.WriteLine("No Config found. Creating a new one.\nMake sure the com port gets set.");

                // Create a new XML document
                XmlDocument doc = new XmlDocument();

                // Create the root node
                XmlElement docRoot = doc.CreateElement("ArduinoConfig");
                doc.AppendChild(docRoot);

                // Add baud rate and COM port nodes
                XmlElement baudRateNode = doc.CreateElement("BaudRate");
                baudRateNode.InnerText = "9600"; // Default value
                docRoot.AppendChild(baudRateNode);

                XmlElement comPortNode = doc.CreateElement("COMPort");
                comPortNode.InnerText = "COM3"; // Default value
                docRoot.AppendChild(comPortNode);

                XmlElement ledStripLengthNode = doc.CreateElement("LEDStripLenght");
                ledStripLengthNode.InnerText = "60"; // Default value
                docRoot.AppendChild(ledStripLengthNode);

                // Save the XML document to the specified file
                doc.Save(configFile);
            }

            // Load configuration from the XML file
            XmlDocument configFileDoc = new XmlDocument();
            configFileDoc.Load(configFile);

            XmlNode root = configFileDoc.DocumentElement;
            BaudRate = int.Parse(root.SelectSingleNode("BaudRate").InnerText);
            COMPort = root.SelectSingleNode("COMPort").InnerText;
            LEDAmount = int.Parse(root.SelectSingleNode("LEDStripLenght").InnerText);
        }

    }
}
