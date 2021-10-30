using System.Threading;

namespace ResourceProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Resource r1 = new Resource("1", 3);
            Resource r2 = new Resource("2", 2);
            Resource r3 = new Resource("3", 2);
            Process p1 = new Process(r1, r2, r3, 1);
            Process p2 = new Process(r1, r2, 2);
            Process p3 = new Process(r1, r3, 3);
            Process[] processes = new Process[] { p1, p2, p3 };
            //Parallel.ForEach(processes, p => new Thread(p.run).Start());
            new Thread(p1.run).Start();
            new Thread(p2.run).Start();
            new Thread(p3.run).Start();

        }
    }
}
