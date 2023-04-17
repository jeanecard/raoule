using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        { 
        
            string roger = "roger";
            string truc = null;
            if (roger.Contains(truc))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
                Console.ReadKey();
        }
    }
}
