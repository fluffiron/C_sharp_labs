using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sem4_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < 10; ++i)
                {
                    arr[i] = 10 - i;
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Choose method: 1- Sort; 2 - Lind; 3 - Map (\"exit\" for exit )");
                string st = Console.ReadLine();
                if (st == "exit")
                {
                    break;
                }
                while (st != "1" && st != "2" && st != "3")
                {
                    Console.Clear();
                    Console.WriteLine("Choose again: 1- Sort; 2 - Lind; 3 - Map");
                    st = Console.ReadLine();
                    if (st == "exit")
                    {
                        break;
                    }
                }
                switch (st)
                {
                    case "1":
                        {
                            Sort(arr, (x, y) => x > y);
                            for (int i = 0; i < 10; ++i)
                            {
                                Console.Write(arr[i] + " ");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "2":
                        {
                            int a = Lind(arr, (x) => (x % 5) == 0);
                            Console.WriteLine(a);
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            arr = Map(arr, (x) => x / 5 + 1);

                            for (int i = 0; i < 10; ++i)
                            {
                                Console.Write(arr[i] + " ");
                            }
                            Console.ReadKey();
                            break;
                        }
                }
            }
            
        }

        

        static int[] Map(int[] array, Func<int, int> f)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                 array[i] = f(array[i]);
            }
            return array;
        }

        static int Lind(int[] array, Func<int, bool> isCondition)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                if (isCondition(array[i]))
                {
                    return array[i];
                }
            }
            throw new Exception("Not found");
        }

        static int[] Sort(int[] array, Func<int, int, bool>isMore)
        {
            for (int j = 0; j < array.Length; ++j)
            {
                for (int i = 0; i < array.Length - 1 - j; ++i)
                {
                    if (isMore(array[i], array[i + 1]))
                    {
                        int tmp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tmp;
                    }
                }
            }
            return array;
        }
    }
}
