using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace ZPL_Printer
{
  public class pickLabel : Print
  {
    private string _barcode;
    private string _itemname;
    private string _zplString;

    public void ProcessBarcode()
    {
      bool confirmlabel = false;
      ConsoleKey response;
      ConsoleKey confirmAnother;



      do
      {
        do
        {
          Console.Clear();

          Console.WriteLine("Please enter a name for this item: ");

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

          Console.Write("Please ensure this barcode is correct:");
          Console.WriteLine(_itemname);

          _barcode = "P" + docNo + "-" + itemNo + "-" + matNo;

          Console.WriteLine(_barcode);

          Console.WriteLine(" ");

          Console.WriteLine("Is this label correct? (Y/N)");

          response = Console.ReadKey(true).Key;

          confirmlabel = response == ConsoleKey.Y;

        } while (response != ConsoleKey.Y);

        if (confirmlabel)
        {
          PrintBarcode();
        }

        Console.WriteLine();
        Console.WriteLine("Do you want to print another? (Y/N)");

        confirmAnother = Console.ReadKey(true).Key;

      } while (confirmAnother != ConsoleKey.N);
    }


    protected override string GenerateLabel()
    {

      _zplString =
        "^XA" +
        "^FS" +
        @"^FT200,80^A0N,30,30^FH\^FN1^FDPick Label^FS" +
        @"^FT200,120^A0N,30,30^FH\^FN2^FD" +
        _itemname + "^FS" +
        @"^FT200,180^A0N,30,30^FH\^FN3^FD" +
        _barcode + "^FS" +
        @"^MMT^LH0,0^CI0^BY110,110^FT26,300^BXN,5,200,24,24,1^FH\^FN3^FD" + _barcode + "^FS" +
        "^XZ";

      return _zplString;
    }
  }
}

