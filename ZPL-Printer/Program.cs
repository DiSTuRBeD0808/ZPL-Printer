using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZPL_Printer.Enums;

namespace ZPL_Printer
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("This program is meant to  create/send ZPL code to print labels from a Zebra printer");
      Console.WriteLine();
      Console.WriteLine("Select a label type to print:");
      Console.WriteLine("1 = Goods Receipt");
      Console.WriteLine("2 = Pick Label");

      int select = Convert.ToInt32(Console.ReadLine());

      switch (select)
      {
        case (int)LabelEnums.Gr:
          new grLabel();
          break;
        default: Console.WriteLine("That invalid selection, please try again.");
          break;

      }

      Console.ReadKey();
    }
  }
}
