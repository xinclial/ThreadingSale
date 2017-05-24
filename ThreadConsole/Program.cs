using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole
{
    class Program
    {
        private static Timer _timer;//定时器

        static void Main(string[] args)
        {
            Console.WriteLine("开始: " + DateTime.Now.ToString());
            _timer = new Timer(new TimerCallback(Processor), null, 5000, 0);

            Console.WriteLine("结束: " + DateTime.Now.ToString());

            //_timer.Dispose();

            Console.ReadLine();
        }

        private static void Processor(object state)
        {
            Console.WriteLine("处理事件: " + DateTime.Now.ToString());
            
        }
    }
}
