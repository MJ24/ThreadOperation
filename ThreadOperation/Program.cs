using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Lock同步线程
            //LockAndMonitor.CountingWithoutLock();
            //LockAndMonitor.CountingWithLock(); 
            LockAndMonitor.CountingWithMonitor();
            #endregion

            Console.ReadLine();
        }
    }
}
