using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net;
using static System.Configuration.ConfigurationSettings;

namespace ZPL_Printer
{
  class Program
  {
    static void Main(string[] args)
    {
      string ipAddress = AppSettings["ipaddress"];
      var exit = false;

      do
      {
        Console.WriteLine("This program is meant to  create/send ZPL code to print labels from a Zebra printer");
        Console.WriteLine();
        Console.WriteLine("Select a label type to print:");
        Console.WriteLine("1 = Goods Receipt");
        Console.WriteLine("2 = Pick Label");
        Console.WriteLine("3 = Exit");



        Console.WriteLine(" ");
        Console.Write("Current Printer IP: ");
        Console.WriteLine(ipAddress);

        bool @continue = false;
        do
        {
          var select = Console.ReadKey(true).Key;

          switch (select)
          {
            case ConsoleKey.D1:
              new grLabel().ProcessBarcode();
              @continue = true;
              break;
            case ConsoleKey.D2:
              new pickLabel().ProcessBarcode();
              @continue = true;
              break;
            case ConsoleKey.D3:
              @continue = true;
              exit = true;
              break;
              default:
              Console.WriteLine("Invalid selection, please try again.");
              @continue = false;
              break;
          }
        } while (!@continue);

        if (!exit)
        {
          Console.Clear();
        }

      } while (!exit);
    }
  }
}
