using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace sem4_lab2
{
    class Program
    {
        private static volatile int x;
        static object Lock = new object();
        static ManualResetEvent stop = new ManualResetEvent(false);


        public static void WriteInFile(object name)
        {
            FileStream fs = new FileStream(name.ToString() + ".txt", FileMode.Create);
            fs.Close();
            StreamWriter file = new StreamWriter(name.ToString() + ".txt", true, System.Text.Encoding.Default);
            int _x = x;
            while (!stop.WaitOne(30))
            { 
                
                if (_x % int.Parse(name.ToString()) == 0)
                {
                    file.WriteLine(_x);
                    //Console.WriteLine("Write in " + name.ToString() + ".txt file x= " + x);
                }
                ++_x; 
                Monitor.TryEnter(Lock, 10);
                if (_x >= x)
                { 
                    lock (Lock)
                    {
                        ++x;    // if none has changed x
                    }  
                }
                Monitor.Exit(Lock);             
                Thread.Sleep(10);
            }
            //Console.WriteLine("_x in " + name.ToString() + " is " + _x);
            file.Close();
        }

        static void Main(string[] args)
        {
            
            x = 1;
            List<Thread> ThreadList = new List<Thread>();

            for (int i = 0; i < 10; ++i)
            {
                Thread item1 = new Thread(WriteInFile);
                ThreadList.Add(item1);
            }

            // starting 10 threads
            int j = 1;
            foreach (Thread item in ThreadList)
            {
                item.Start(j++);
            }
            Console.WriteLine("Enter \"stop\"");
            while (true)
            {
                string st = Console.ReadLine();
                if (st == "stop" || st == "ыещз")
                {
                    stop.Set();
                    break;
                }
            }
            //Console.WriteLine("x is " + x);
            //Console.ReadKey();
        }
    }
}
