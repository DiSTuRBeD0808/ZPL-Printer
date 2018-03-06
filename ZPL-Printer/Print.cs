using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPL_Printer
{
  public abstract class Print
  {
    protected abstract string GenerateLabel();

    protected void PrintBarcode()
    {
      var zpl = GenerateLabel();


      
      Console.WriteLine("Printing ZPL... Check printer");
      
     //Printer IP Address and communication port
      string ipAddress = "127.0.0.1";
      int port = 9100;

      // ZPL Command(s)
      string ZPLString = zpl;

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
