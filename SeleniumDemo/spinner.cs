using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo
{
    class spinner
    {
        public class ConsoleSpiner
        {
            int counter;
            public ConsoleSpiner()
            {
                counter = 0;
            }
            public void Turn()
            {
                counter++;
                switch (counter % 8)
                {
                    case 0: Console.Write(">"); break;
                    case 1: Console.Write(">>"); break;
                    case 2: Console.Write(">>>"); break;
                    case 3: Console.Write(">>>>"); break;
                    case 4: Console.Write(" >>>"); break;
                    case 5: Console.Write("  >>"); break;
                    case 6: Console.Write("   >"); break;
                    case 7: Console.Write("    "); break;

                }
                if (!Console.IsOutputRedirected /*&& Console.CursorLeft - 1 >= 0*/)
                {
                    //Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
                System.Threading.Thread.Sleep(60);

            
            }
        }
    }
}
