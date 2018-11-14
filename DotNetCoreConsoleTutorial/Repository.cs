using System;

namespace DotNetCoreConsoleTutorial
{
    public class Repository : IRepository
    {
        public void DoWork()
        {
            var input = Console.ReadLine();

            Console.WriteLine($"Input value: {input}");
        }
    }
}