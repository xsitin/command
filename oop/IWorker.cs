namespace oop
{
    public interface IWorker
    {
        void Add(IFileExecutable command);

        void Run();
        void Dump(IResulter resulter);
    }
}