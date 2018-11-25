using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksQueue
{
    // Generic Classes
    // General for data types
    class MyPrinter<T>
    {
        private T _data;
        public MyPrinter(T data_)
        {
            _data = data_;
        }

        public void Print()
        {
            Console.WriteLine(_data);
        }
    }   

    class Program
    {
        static void Main(string[] args)
        {
            //MyPrinter<int> p1 = new MyPrinter<int>(2);
            //MyPrinter<double> p2 = new MyPrinter<double>(2.5);
            //p1.Print();
            //p2.Print();
            //Console.Read();
            StackQue.MyMain();
            Console.ReadLine();
        }
    }
}
