using System;

namespace HelloWorldAPI
{
    public static class OutputSourceFactory
    {
        static IOutputSource CreateSource(OutputSourceTypes type)
        {
            IOutputSource source = null;
            switch (type)
            {
                case OutputSourceTypes.Console:
                    source = new OutputSourceConsole();
                    break;
                case OutputSourceTypes.CustomLogger:
                    source = new OutputSourceCustomLogger();
                    break;
                case OutputSourceTypes.Database:
                    source = new OutputSourceDatabase();
                    break;
                case OutputSourceTypes.EventViewer:
                    source = new OutputSourceEventViewer();
                    break;
                case OutputSourceTypes.None:
                    break;
            }

            return source;
        }


        public static IOutputSource CreateSource(string sourceType)
        {
            return CreateSource(GetRequestedSourceType(sourceType));
        }

        public static OutputSourceTypes GetRequestedSourceType(string source)
        {
            OutputSourceTypes type;
            if (!Enum.TryParse(source, out type))
            {
                //In real world, we might be logging it, sending alerts etc. Here I am just reusing one of the Source Types to log it
                ErrorLogger.LogError($"Failed to created Output Source Type {source}");
                return OutputSourceTypes.None;
            }
            return type;
        }
    }
}
