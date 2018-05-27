using System;

namespace SeleniumDemo
{
    class spinner
    {
        /// <summary>
        /// This class makes a simple animation in the console window to let the user know that things are still running
        /// </summary>
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
                if (!Console.IsOutputRedirected)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
                System.Threading.Thread.Sleep(60);
            }
        }
    }
}
