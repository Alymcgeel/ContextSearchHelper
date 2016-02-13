using System;

namespace ConetxtSearchHelper
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Context Search Helper starting up...");

            ContextSearchHelperMain mainProgram = new ContextSearchHelperMain();
            mainProgram.Start();

            Console.WriteLine("Context Search Helper shutting down...");
        } 
    }
}
