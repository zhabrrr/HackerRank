﻿namespace HackerRank
{
    class Program
    {
        static void RunDataCenter()
        {
            Console.WriteLine("Running the Data Center task");
            DataCenter dc = new DataCenter();
            List<int> bootingPowers = new List<int> { 5, 10, 15, 20 };
            List<int> processingPowers = new List<int> { 7, 4, 2, 6 };
            int maxCluster = dc.SearchCluster(19, bootingPowers, processingPowers);
            Console.WriteLine($"Result = {maxCluster}");
        }

        static void RunLilysHomework()
        {
            Console.WriteLine("Running the Lily's Homework task");
            LilysHomework lh = new LilysHomework();
            List<int> array = new List<int> 
            //                              { 3, 4, 0, 1, 5, 2 };
            //                              { 5, 4, 0, 1, 3, 2 };
            //                              { 5, 4, 3, 1, 0, 2 };
                                          { 5, 1, 3, 2, 4, 0 };
            //                              { 5, 4, 3, 2, 1, 0 };
            //                              { 0, 1, 2, 3, 4, 5 };
            int result = lh.Do(array);
            Console.WriteLine($"Result = {result}");
        }

        static void RunThreading()
        {
            Console.WriteLine("Running the Threading task");
            Threading threading = new Threading();
            threading.Run();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Choose one of the problems:");
            Console.WriteLine("1 - Data Center");
            Console.WriteLine("2 - Lily's Homework");
            Console.WriteLine("3 - Threading");
            Console.Write("> ");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            switch(key.KeyChar)
            {
                case '1': RunDataCenter(); break;
                case '2': RunLilysHomework(); break;
                case '3': RunThreading(); break;
                default: Console.WriteLine("Invalid choice");  break;
            }
        }
    }
}