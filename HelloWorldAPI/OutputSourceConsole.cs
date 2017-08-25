using System;

namespace HelloWorldAPI
{
    public class OutputSourceConsole : IOutputSource
    {
        public OutputSourceTypes SourceType => OutputSourceTypes.Console;

        public void Write(string message)
        {
            Console.WriteLine(message??"Hello World!");
        }
    }
}
