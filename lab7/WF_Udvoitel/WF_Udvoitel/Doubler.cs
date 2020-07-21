using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Udvoitel
{
    static class Doubler
    {
        public static int counter = 0;
        public static int target = 0;
        public static int min = 0;
        public static bool game = false;
        public static Stack<int> stack = new Stack<int>();

        public static void Start()
        {
            Random rnd = new Random();
            target = rnd.Next(1, 51);
            int pow = (Math.Log(target, 2) >= 2.0d) ? (int)Math.Log(target, 2) : 0;
            min = pow + 1 + (target - (int)Math.Pow(2.0d, (double)pow));
        }

        public static void PushStack(int v)
        {
            stack.Push(v);
        }        
    }    
}
