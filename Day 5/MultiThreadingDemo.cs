using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace SampleConApp
{
    class ThreadingDemo
    {
        static int ThreadWithArgs(object args)
        {
            var array = (Array)args;
            var res = 0;
            for (int i = 0; i < array.Length; i++)
            {
                Thread.Sleep(1000);
                res += i;
            }
            return res;
        }

        static void ThreadFunc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread Beep#" + i);
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            //To provide parallel invocation....
            //Thread th = new Thread(new ThreadStart(ThreadFunc));
            //th.Start();
            //threadPoolDemo();
            //asnycDemo();
            asyncCallBackDemo();
        }

        private static void asyncCallBackDemo()
        {
            //Action<object> action = new Action(ThreadWithArgs; 
            Func<object, int> func = ThreadWithArgs;
            IAsyncResult res = func.BeginInvoke(new int[] { 12, 12, 13, 14, 15, 16 }, (iRes) => {
                var info = (AsyncResult)iRes;
                var actualDel = info.AsyncDelegate as Func<object, int>;
                var result = actualDel.EndInvoke(iRes);
                Console.WriteLine("The Result of this operation is " + result);
            }, null);
            while (!res.IsCompleted)
            {
                Console.WriteLine("Please wait while we get the result...");
                Thread.Sleep(1000);
            }
        }

        private static void asnycDemo()
        {
            Action myFunc = ThreadFunc;
            var res = myFunc.BeginInvoke(null, null);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("From Main");
                Thread.Sleep(1000);
            }
            myFunc.EndInvoke(res);
        }

        private static void threadPoolDemo()
        {
            int active, total;
            ThreadPool.GetMaxThreads(out active, out total);
            Console.WriteLine("The total no of threads available are " + active);
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                int loops = Convert.ToInt32(obj);
                for (int i = 0; i < loops; i++)
                {
                    Console.WriteLine("Thread Beep#" + i);
                    Thread.Sleep(1000);
                }
            }, 3);//background Threads.......
            Console.WriteLine("Testing 123");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Main Function loop");
            }
            ThreadPool.GetMaxThreads(out active, out total);
            Console.WriteLine("The total no of threads available are " + active);
        }
    }
}