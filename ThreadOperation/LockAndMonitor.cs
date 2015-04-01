using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadOperation
{
    class LockAndMonitor
    {
        private static int count = 0;
        private static object syncObj = new object();
        private delegate void Counting();

        private static void Run(Counting counting)
        {
            for (int i = 1; i < 10; i++)
            {
                Thread th = new Thread(new ThreadStart(counting));
                th.Name = "线程" + i;
                th.IsBackground = true;
                th.Start();
            }
        }

        public static void CountingWithoutLock()
        {
            Run(() =>
            {
                while (true)
                {
                    if (count < 24)
                    {
                        Console.WriteLine("{0}正在操作count", Thread.CurrentThread.Name);
                        Thread.Sleep(60);
                        count++;
                        Console.WriteLine("{0}此时的count值——{1}", Thread.CurrentThread.Name, count);
                    }
                }
            });
        }

        public static void CountingWithLock()
        {
            Run(() =>
            {
                while (true)
                {
                    lock (syncObj)
                    {
                        if (count < 24)
                        {
                            Console.WriteLine("{0}正在操作count", Thread.CurrentThread.Name);
                            Thread.Sleep(60);
                            count++;
                            Console.WriteLine("{0}此时的count值——{1}", Thread.CurrentThread.Name, count);
                        }
                    }
                }
            });
        }

        public static void CountingWithMonitor()
        {
            Run(() =>
            {
                while (true)
                {
                    try
                    {
                        Monitor.Enter(syncObj);
                        if (count < 24)
                        {
                            Console.WriteLine("{0}正在操作count", Thread.CurrentThread.Name);
                            Thread.Sleep(60);
                            count++;
                            Console.WriteLine("{0}此时的count值——{1}", Thread.CurrentThread.Name, count);
                        }
                    }
                    finally
                    {
                        Monitor.Exit(syncObj);
                    }
                }
            });
        }
    }
}
