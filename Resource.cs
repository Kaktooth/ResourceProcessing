using System;
using System.Threading;

namespace ResourceProcessing
{
    public class Resource
    {
        static object locker = new object();
        public string name { get; set; }
        public int semaphoreCount { get; set; }

        public Resource(string name, int semaphoreCount)
        {
            this.semaphoreCount = semaphoreCount;
            this.name = name;
            resourceClosed = false;
        }

        public bool resourceClosed;
        public void ProcessResource(Process Process)
        {
            try
            {
                if (resourceClosed == false)
                {
                    if (!Monitor.TryEnter(this))
                    {
                        Console.WriteLine($"Ресурс: {name} не може бути виконаним " + Process.processIndex + " процесом, тому що ресурс був зайнятий");
                    }
                    lock (locker)
                    {
                        resourceClosed = true;
                        Console.WriteLine($"Ресурс: {name} виконується з " + Process.processIndex + " процесом");
                        Thread.Sleep(100);
                    }
                }

                //Console.WriteLine($" Ресурс {name} користувався процессом: "+ Process.processIndex);
                resourceClosed = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine("ex: " + ex.Message);
            }
        }
    }
}
