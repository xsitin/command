namespace oop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var fw = new FileWorker(args[0], args[1]=="r");
            fw.Add(new SHAExecutor());
            fw.Run();
            fw.Dump(new ConsoleResulter());
        }
    }
}