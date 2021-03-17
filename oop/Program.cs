using oop.Executors;

namespace oop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var fac = new CommandFactory("/home/xsitin/Desktop/testData",
                true);
            var queue = CommandQueue.GetInstance();
            queue.Push(fac
                .CreateFileCommand(
                    new Md5FilesHash(),
                    new ConsoleResulter()));
            queue.Run();
        }
    }
}