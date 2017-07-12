using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            //Method1();
            Method2();
            Console.WriteLine("Main Thread");
            Console.ReadLine();
        }

        private static void Method1()
        {
            Task.Run(new Action(LongTask));
            Console.WriteLine("新线程");
        }

        private static async void Method2()
        {
            //await 等待执行完成后,在执行后续(必须用在异步中)
            await Task.Run(new Action(LongTask));
            Console.WriteLine("新线程");
        }

        private static void LongTask()
        {
            Thread.Sleep(5000);
            Console.WriteLine("线程中");
        }


        
    }
}
