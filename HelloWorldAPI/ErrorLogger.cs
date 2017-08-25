using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldAPI
{
    public static class ErrorLogger
    {
        private static readonly string _outputSourceType;
        private static readonly IOutputSource _errorOutputSource;
        static ErrorLogger()
        {
            _outputSourceType =
                $"{ConfigurationManager.AppSettings["errorOutputSource"] ?? OutputSourceTypes.CustomLogger.ToString()}";
            _errorOutputSource = OutputSourceFactory.CreateSource(_outputSourceType);

        }
        public static void LogError(string errorMessage)
        {
            _errorOutputSource?.Write(errorMessage);
        }
    }
}
