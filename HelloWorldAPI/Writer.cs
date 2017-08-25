using System;

namespace HelloWorldAPI
{
    public static class Writer
    {
        public static void Write(string sourceType,string message)
        {
            if (sourceType == null)
            {
                //In real world, we might be logging it, sending alerts etc. Here I am just reusing one of the Source Types to log it
                ErrorLogger.LogError("Output Souce can't be null");
                return;

            }
            GetRequestedSource(sourceType)?.Write(message);
        }

        public static IOutputSource GetRequestedSource(string sourceType)
        {
            return OutputSourceFactory.CreateSource(sourceType);
        }

    }
}
