namespace HelloWorldAPI
{
    public class OutputSourceDatabase : IOutputSource
    {
        public OutputSourceTypes SourceType => OutputSourceTypes.Database;

        public void Write(string message)
        {
            //Do work to write it to the DB. Can itself be an abstract class
            //with DB specific implementations
        }
    }
}
