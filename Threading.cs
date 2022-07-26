using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Threading<TResult>
    {
        volatile int _cnt = 1000;
        static readonly object _lock = new object();

        private static void Write()
        {
            lock (_lock)
            {
                Console.WriteLine("test");
            }
        }

        public void Run()
        {
            lock (_lock)
            {
                Write();
            }
            Thread t = new Thread(WriteY);
            t.Start("#");
            WriteY(".");
        }

        void WriteY(object ch)
        {
            while (_cnt > 0)
                lock (_lock)
                {
                    if (_cnt >= 0)
                        Console.Write($"{_cnt--}{(string)ch}");
                }
        }

        static IEnumerable<int> Square(IEnumerable<int> a)
        {
            foreach (var r in a)
            {
                Console.WriteLine(r * r);
                yield return r * r;
            }
        }

        class Wrap
        {
            private static int init = 0;
            public int Value
            {
                get { return ++init; }
            }
        }

        public void Test()
        {
            var w = new Wrap();
            var wraps = new Wrap[3];
            for (int i = 0; i < wraps.Length; i++)
            {
                wraps[i] = w;
            }

            var values = wraps.Select(x => x.Value);
            var results = Square(values);
            int sum = 0;
            int count = 0;
            foreach (var r in results)
            {
                count++;
                sum += r;
            }
            Console.WriteLine("Count {0}", count);
            Console.WriteLine("Sum {0}", sum);

            Console.WriteLine("Count {0}", results.Count());
            Console.WriteLine("Sum {0}", results.Sum());
        }

        public void TestSignals()
        {
            ManualResetEvent signal = new ManualResetEvent(false);
            new Thread(() =>
            {
                Console.WriteLine("Waiting for signal...");
                signal.WaitOne();
                signal.Dispose();
                Console.WriteLine("Got signal!");
            }).Start();
            Thread.Sleep(2000);
            signal.Set();
        }

        public void TestAwaiter()
        {
            Task<int> primeNumberTask = Task.Run(() => Enumerable.Range(2, 26).Count
                                                 (n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
            Console.WriteLine("Counting...");
            System.Runtime.CompilerServices.TaskAwaiter<int> awaiter = primeNumberTask.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                Console.WriteLine(result);
            });
            Console.ReadLine();
        }

        Task<TResult> Run<TResult> (Func<TResult> function)
        {
            var tcs = new TaskCompletionSource<TResult>();
            new Thread(() =>
            {
                try { tcs.SetResult(function()); }
                catch (Exception ex) { tcs.SetException(ex); }
            }).Start();
            return tcs.Task;
        }

        public void TestTaskCompletionSource()
        {
            Task<int> task = Run(() => { Thread.Sleep(5000); return 42; });
            Console.WriteLine(task.Result);
        }
    }
}

