using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
    public class Helper
    {
        static public void Pause()
        {
            Console.ReadKey();        
        }
        static public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
        
        static void Main(string[] args)
        {
        }
    }
}
