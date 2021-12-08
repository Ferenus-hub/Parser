using Parser.Core;
using Parser.Core.Default;
using System;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ParserWorker<string[]> parser;
            int start = 0;
            int end = 0;

            parser = new ParserWorker<string[]>(
                    new DefaultParser()
                );

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;

            Console.WriteLine("Enter start page id: ");
            start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter end page id: ");
            end = Convert.ToInt32(Console.ReadLine());

            parser.Settings = new DefaultSettings(start, end);
            parser.Start();

        }

        private static void Parser_OnNewData(object arg1, string[] arg2)
        {
            foreach (string item in arg2)
            {
                Console.WriteLine(item);
            }
            //save in DB
        }

        private static void Parser_OnCompleted(object obj)
        {
            Console.WriteLine("All works done!");
        }
    }
}
