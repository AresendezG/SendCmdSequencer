/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
*/

using System.IO.Ports;
using System;

namespace SerialSequencer
{
    class Program
    {
        static SerialPort ComPort;
        static void Main(string[] args)
        {
            string cmd = "none";
            string param = "none";
            ComPort = new SerialPort();

            // Set the ComPort Settings
            ComPort.PortName = "COM3";
            ComPort.BaudRate = 19200;
            ComPort.Parity = Parity.None;
            ComPort.DataBits = 8;
            ComPort.StopBits = StopBits.One;

            ComPort.ReadTimeout = 500;
            ComPort.WriteTimeout = 500;

            ComPort.Open();

            while (cmd.Equals("exit") != true)
            {
                Console.WriteLine("Enter Command: >");
                cmd = Console.ReadLine();
                
                switch (cmd)
                {
                    case "send_single_line":
                        Console.WriteLine("Data to Send: >");
                        param = Console.ReadLine();
                        
                        ComPort.WriteLine(param);
                        break;
                    case "send_data":
                        Console.Write("Data: ");
                        param = Console.ReadLine();
                        Console.Write(param);
                        break;
                    case "send_sequence":
                        Console.WriteLine("Command sequence: >");
                        param = Console.ReadLine();
                        send_command_seq(param);
                        break;
                    case "show_ports":
                        PrintAvailableCOMs();
                        break;

                    case "arrows":

                    case "exit":
                        Console.WriteLine("Exit");
                        break;

                }
            }

            ComPort.Close();

        }


        public static void PrintAvailableCOMs()
        {            
            Console.WriteLine("Available Ports:");
            foreach (string s in SerialPort.GetPortNames())
            {
                Console.WriteLine("   {0}", s);
            }
        }

        public static void send_command_seq(string filename)
        {

        }
    }
}
