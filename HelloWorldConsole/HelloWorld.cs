using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorldAPI;

namespace HelloWorldConsole
{
    public class HelloWorld
    {
        private string _message;
        public HelloWorld(string message="Hello World")
        {
            _message = message;
        }

        public void SayHello()
        {
            Writer.Write(GetOutputSource(),_message);
        }

        public string GetOutputSource()
        {
            return ConfigurationManager.AppSettings["outputSource"] ?? string.Empty;
        }
    }
}
