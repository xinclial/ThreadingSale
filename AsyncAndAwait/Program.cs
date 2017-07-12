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
            //Method2();
            //Console.WriteLine("Main Thread");
            //Console.ReadLine();


            //Task<int> task = new Task<int>(() => Sum());//新建任务实例        
            //task.Start();//开始任务
            //Console.WriteLine("任务已开始");
            //task.Wait();//等待任务执行完成
            //Console.WriteLine(task.Result);

            //DateTime pbgtime = DateTime.Now;
            //for (int i = 0; i < 50; i++)
            //{
            //    MethodC(pbgtime, i);
            //    Console.WriteLine("普通方法{0}调用完成", i);
            //}

            DateTime abgtime = DateTime.Now;
            for (int i = 0; i < 50; i++)
            {
                MethodA(abgtime, i);
                Console.WriteLine("异步方法{0}调用完成", i);
            }


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


        static int Sum()
        {
            Console.WriteLine("任务正在执行");
            int sum = 0;
            for (int num = 1; num <= 100; num++)
            {
                Thread.Sleep(5);
                sum += num;
            }
            return sum;
        }



        //异步方法
        public static async Task<int> MethodA(DateTime bgtime, int i)
        {
            int r = await Task.Run(() =>
            {
                Console.WriteLine("异步方法{0}Task被执行", i);
                Thread.Sleep(100);
                return i * 2;
            });
            Console.WriteLine("异步方法{0}执行完毕，结果{1}", i, r);

            if (i == 49)
            {
                Console.WriteLine("用时{0}", (DateTime.Now - bgtime).TotalMilliseconds);
            }
            return r;
        }
        //普通方法
        public static int MethodC(DateTime bgtime, int i)
        {
            int r = Task.Run(() =>
            {
                Console.WriteLine("普通多线程方法{0}Task被执行", i);
                Thread.Sleep(100);
                return i * 2;
            }).Result;
            Console.WriteLine("普通方法{0}执行完毕，结果{1}", i, r);

            if (i == 49)
            {
                Console.WriteLine("用时{0}", (DateTime.Now - bgtime).TotalMilliseconds);
            }
            return r;
        }

    }
}
