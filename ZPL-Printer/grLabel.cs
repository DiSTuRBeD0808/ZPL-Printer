using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPL_Printer
{
  class grLabel
  {
    public string barcode = "";
    public grLabel()
    {
      Console.Write("Enter your Document Number: ");

      string docNoRaw = Console.ReadLine();
      string docNo = docNoRaw.PadLeft(10, '0');

      Console.WriteLine();
      Console.Write("Enter your Item number: ");

      string itemNoRaw = Console.ReadLine();
      string itemNo = itemNoRaw.PadLeft(4, '0');

      Console.WriteLine();
      Console.Write("Enter your Material Number: ");

      string matNo = Console.ReadLine();

      Console.WriteLine();
      Console.Write("Enter your Serial Number: ");

      string serial = "*[SN:" + Console.ReadLine() + "]";

      Console.Write("Please ensure this barcode is correct:");

      bool confirmed = false;
      string Key;

      do
      {

        barcode = "Barcode = " + docNo + "-" + itemNo + "-" + matNo + serial;
        Console.WriteLine(barcode);

        Console.WriteLine();

        ConsoleKey response;
        do
        {
          Console.WriteLine("Is this code correct? (Y/N)");
          response = Console.ReadKey(false).Key; //true is intercept key
          if (response != ConsoleKey.Enter)
            Console.WriteLine();
        } while (response != ConsoleKey.Y && response != ConsoleKey.N);

        confirmed = response == ConsoleKey.Y;
      } while (!confirmed);

      Console.WriteLine("To print, press any key.");
      Console.ReadKey();

      new Print();
    }
  }
}
