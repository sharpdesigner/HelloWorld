namespace HelloWorldAPI
{
    public class OutputSourceCustomLogger : IOutputSource
    {
        public OutputSourceTypes SourceType => OutputSourceTypes.CustomLogger;

        public void Write(string message)
        {
            //This may use SLAB or some other logging framework to perform logging
        }
    }
}