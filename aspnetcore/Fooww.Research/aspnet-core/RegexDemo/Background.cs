using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RegexDemo
{
    public class Background
    {

        public static void PrintIsBackgroundValue()
        {

            Thread t1 = new Thread(PrintValue);
            t1.IsBackground = true;
            t1.Start();
        }

    public static void PrintValue()
        {
            while (true)
            {
                Console.WriteLine("thread t.");
            }
        }
    }
}
