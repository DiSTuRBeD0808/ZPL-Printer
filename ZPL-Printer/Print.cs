using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPL_Printer
{
  class Print
  {
    public Print()
    {
      Console.WriteLine("This program is meant to  create/send ZPL code to print labels from a Zebra printer");

      Console.WriteLine(grLabel.barcode);
      

      Console.ReadKey();
    }
  }
}
/*
      // Printer IP Address and communication port
      string ipAddress = "192.168.1.201";
      int port = 9100;

      // ZPL Command(s)
      string ZPLString = docno;

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
*/