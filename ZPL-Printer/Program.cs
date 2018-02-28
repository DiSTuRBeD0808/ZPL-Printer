using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPL_Printer
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("This program is meant to  create/send ZPL code to print labels from a Zebra printer");

      Console.ReadKey();

      // Printer IP Address and communication port
      string ipAddress = "10.3.14.42";
      int port = 9100;

      // ZPL Command(s)
      string ZPLString =
        "^XA" +
        "^FO50,50" +
        "^A0N50,50" +
        "^FDHello, World!^FS" +
        "^XZ";

      try
      {
        // Open connection
        System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
        client.Connect(ipAddress, port);

        // Write ZPL String to connection
        System.IO.StreamWriter writer =
          new System.IO.StreamWriter(client.GetStream());
        writer.Write(ZPLString);
        writer.Flush();

        // Close Connection
        writer.Close();
        client.Close();
      }
      catch (Exception ex)
      {
        // Catch Exception
      }
    }
  }
}
