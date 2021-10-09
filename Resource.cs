using System;
using System.Threading;

namespace ResourceProcessing
{
    public class Resource
    {
        public string name { get; set; }
        public int semaphoreCount { get; set; }

        public Resource(string name, int semaphoreCount)
        {
            this.semaphoreCount = semaphoreCount;
            this.name = name;
            semaphore = new Semaphore(2, semaphoreCount);
        }

        public Semaphore semaphore;
        public bool resource = false;
        public void ProcessResource(int Process1)
        {
            try
            {
                if (resource)
                {
                    semaphore.WaitOne();
                    Console.WriteLine("waiting...");
                }

                Console.WriteLine($" Ресурс {name} користується процессом " + Process1);
                resource = false;
                semaphore.Release();

            }
            catch (Exception ex)
            {
                Console.WriteLine("ex: " + ex.Message);
            }
        }
    }
}
