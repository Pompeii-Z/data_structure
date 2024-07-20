using System;
using System.Threading;

namespace 多线程_轮流打印AB
{
    internal class Program
    {
        private int count = 50;
        private readonly object lockObject = new object();
        private bool turnA = true;  // 初始设置为A打印
        static void Main(string[] args)
        {
            Program printer = new Program();
            Thread threadA = new Thread(printer.PrintA);
            Thread threadB = new Thread(printer.PrintB);

            threadA.Start();
            threadB.Start();

            threadA.Join();
            threadB.Join();
        }

        public void PrintA()
        {
            for (int i = 0; i < count; i++)
            {
                lock (lockObject)
                {
                    while (!turnA)  // 如果不是A打印，就等待
                        Monitor.Wait(lockObject);

                    Console.Write("A ");
                    Thread.Sleep(100); // 暂停100毫秒
                    turnA = false;  // 设置为B的打印
                    Monitor.Pulse(lockObject);  // 通知等待的线程
                }
            }
        }

        public void PrintB()
        {
            for (int i = 0; i < count; i++)
            {
                lock (lockObject)
                {
                    while (turnA)  // 如果是A打印，就等待
                        Monitor.Wait(lockObject);

                    Console.Write("B ");
                    Thread.Sleep(100); // 暂停100毫秒
                    turnA = true;  // 设置回A的打印
                    Monitor.Pulse(lockObject);  // 通知等待的线程
                }
            }
        }

    }
}
