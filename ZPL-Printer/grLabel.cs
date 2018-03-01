using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPL_Printer
{
  public class grLabel : Print
  {
    private string _barcode;
    private string _itemname;
    private string _zplString;
    public void ProcessBarcode()
    {
      do
      {

        Console.Clear();

        Console.Write("Please enter a name for this item: ");

        _itemname = Console.ReadLine();

        Console.WriteLine();
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
          Console.WriteLine(_itemname);
          _barcode = docNo + "-" + itemNo + "-" + matNo + serial;
          Console.WriteLine("Barcode = " + _barcode);

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

          if (confirmed)
          {
            PrintBarcode();
          }
          

        } while (!confirmed);

        Console.WriteLine("Do you want to do another? (Y/N)");


      } while (Console.ReadKey().Key == ConsoleKey.Y);
    }

    protected override string GenerateLabel()
    {

      _zplString =
        "^XA" +
        "^FS" +
        "^FT10,70^XGE:LOGO.GRF,1,1^FS" +
        @"FT200,120^A0N,30,30^FH\^FN1^FD" +
        _itemname + "^FS" +
        @"^FT200,180^A0N,30,30^FH\^FN1^FD" +
        _barcode + "^FS" +
        @"^MMT^LH0,0^CI0^BY110,110^FT26,300^BXN,5,200,24,24,1^FH\^FN3^FD" + _barcode + "^FS" +
        "^XZ";
      
      return _zplString;
    }
  }
}
