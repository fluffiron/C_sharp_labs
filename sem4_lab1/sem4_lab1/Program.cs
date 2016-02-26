using System;
using System.Threading;
using System.Collections.Generic;


namespace sem4_lab1
{
    public class lab1_class
    {
        private static List<string> ClassNames1 = new List<string>();
        private static List<string> ClassNames2 = new List<string>();
        private static Semaphore _pool;

        public static void WriteInListFirst(object ThreadNum)
        {
            //Console.WriteLine("Start adding (first)" + ThreadNum);
            _pool.WaitOne();
            Thread.Sleep(10);
            ClassNames1.Add(ThreadNum.ToString());
            ClassNames2.Add(ThreadNum.ToString());
            _pool.Release();

            Console.WriteLine(ThreadNum + " is added in lists");
        }

        public static void WriteInListSecond(object ThreadNum)
        {
            //Console.WriteLine("Start adding (second)" + ThreadNum);
            _pool.WaitOne();
            Thread.Sleep(100);
            ClassNames1.Add(ThreadNum.ToString());
            ClassNames2.Add(ThreadNum.ToString());
            _pool.Release();

            Console.WriteLine(ThreadNum + " is added in lists");
        }

        private static void Main()
        {
            List<Thread> TreadList = new List<Thread>();
            _pool = new Semaphore(1, 1);

            for (int i = 0; i < 25; ++i)
            {
                Thread item1 = new Thread(WriteInListFirst);
                Thread item2 = new Thread(WriteInListSecond);
                TreadList.Add(item1);
                TreadList.Add(item2);
            }

            // starting 50 threads
            int j = 1;
            foreach(Thread item in TreadList)
            {
                item.Start(j++);
                //item.Join();
            }
            Console.WriteLine("Enter \"stop\"");
            while (true)
            {
                string st = Console.ReadLine();
                if (st == "stop" || st == "ыещз")
                {
                    break;
                }
            } 
        }

    }
}
