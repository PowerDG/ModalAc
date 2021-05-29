using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RegexDemo
{
    public  class ThreadTestDemo
    {
        static Thread t1, t2;

        public static void MainTitle()
        {
            t1 = new Thread(ThreadTest);
            t1.Name = "t1";
            t1.Start();
            t2 = new Thread(ThreadTest);
            t2.Name = "t2";
            t2.Start();
        }

        private static void ThreadTest()
        {
            Console.WriteLine("Current thread:{0}", Thread.CurrentThread.Name);

            if (Thread.CurrentThread.Name == "t1" && t2.ThreadState != ThreadState.Unstarted)
            {
                if (t2.Join(1000))
                {
                    Console.WriteLine("t2 join 2000ms.");
                }
                else
                {
                    Console.WriteLine("the time out.");
                }
            }

            Thread.Sleep(4000);
            Console.WriteLine("thread 1:{0}", t1.ThreadState);
            Console.WriteLine("thread 2:{0}", t2.ThreadState);
        }
    }
}
