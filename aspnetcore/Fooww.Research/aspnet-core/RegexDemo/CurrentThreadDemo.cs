using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RegexDemo
{
    public class CurrentThreadDemo
    {
        public void operatorDemo()
        {
            Thread.CurrentThread.Name = "Main_Thread";
            Thread t = new Thread(PrintValue);
            t.Name = "T_Thread";
            t.Start();

            Console.WriteLine(Thread.CurrentThread.Name);

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("main thread.");
            }
        }
        public void operatorJoinDemo()
        {
            #region Join and Sleep

            Thread t = new Thread(PrintValue);
            t.Start();
            t.Join();//等待PrintValue执行完成
            Console.WriteLine("End.");

            #endregion
        }

        static void PrintValue()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("thread t.");
            }
        }
   

    }
}
