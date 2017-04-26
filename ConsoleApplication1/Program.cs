using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 0;
            while (capacity++ < 10)
                Console.WriteLine(Fibonacci.Take(10).ToArray()[capacity - 1]);
            Console.ReadLine();
        }
    }
}
