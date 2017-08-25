namespace HelloWorldAPI
{
    public interface IOutputSource
    {
        OutputSourceTypes SourceType { get; }
        void Write(string message);
    }
}
