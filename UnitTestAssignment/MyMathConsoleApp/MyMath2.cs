using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMathConsoleApp
{
    public class MyMath2
    {
        // copied code from MyMath1
        public static byte Add(byte a, byte b)
        {
            checked
            {
                byte c = (byte)(a + b);
                return c;
            }
            
        }
    }
}
