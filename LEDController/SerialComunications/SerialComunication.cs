using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDController.SerialComunications
{
    class SerialComunication
    {
        private SerialPort serialPort;

        public SerialComunication(SerialConfig config)
        {
            serialPort = new SerialPort(config.COMPort, config.BaudRate);
            serialPort.Open();

            serialPort.DataReceived += SerialPort_DataReceived;
        }

        public void SendData(string data)
        {
            serialPort.WriteLine(data);
        }

        private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;
            string data = serialPort.ReadLine(); // Read the incoming data
            Console.WriteLine("Received data: " + data);
        }

        public void CloseConnection()
        {
            serialPort.Close();
        }
    }
}
