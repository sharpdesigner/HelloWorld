using System.Diagnostics;

namespace HelloWorldAPI
{
    public class OutputSourceEventViewer : IOutputSource
    {
        public  OutputSourceTypes SourceType => OutputSourceTypes.EventViewer;

        public void Write(string message)
        {
            //TODO: Add implementation logic
        }
    }
}
