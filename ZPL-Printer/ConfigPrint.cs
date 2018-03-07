using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ZPL_Printer
{
  public class ConfigPrint
  {
    public void changeprinter()
    {
      Console.Clear();

      Console.Write("Please input the IP for your printer: ");

      string ipaddress = Console.ReadLine();
    }
  }
}
