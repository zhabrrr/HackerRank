using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Threading
    {
        int _cnt = 1000;
        static readonly object _lock = new object();

        public void Run()
        {
            Thread t = new Thread(WriteY);
            t.Start();
            while (_cnt >= 0)
                lock (_lock)
                {
                    if(_cnt >= 0)
                        Console.Write($"{_cnt--}.");
                }
        }

        void WriteY()
        {
            while (_cnt > 0)
                lock (_lock)
                {
                    Console.Write($"{_cnt--}#");
                }
        }
    }
}
