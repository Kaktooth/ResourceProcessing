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




                    lock (locker)
                    {
                        if (!Monitor.TryEnter(this))
                        {
                            //Thread.Sleep(10);
                            Console.WriteLine($"Ресурс: {name} заблокований, процес: " + Process.processIndex + " не може обробити ресурс");

                        }
                        resourceClosed = true;
                        Console.WriteLine($"Ресурс: {name} виконується з " + Process.processIndex + " процесом");
                        Thread.Sleep(100);
                        Console.WriteLine($"Ресурс: {name} виконався " + Process.processIndex + " процесом");

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
