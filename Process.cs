using System;
using System.Diagnostics;
using System.Threading;

namespace ResourceProcessing
{
    public class Process
    {
        public int processIndex;
        private Resource q1;
        private Resource q2;
        private Resource q3;
        public Process(Resource q1, Resource q2, Resource q3, int processIndex)
        {
            this.q1 = q1;
            this.q2 = q2;
            this.q3 = q3;
            this.processIndex = processIndex;

        }
        public Process(Resource q1, Resource q2, int processIndex)
        {
            this.q1 = q1;
            this.q2 = q2;
            this.processIndex = processIndex;

        }

        public void run()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {

                q1.ProcessResource(this);

                q2.ProcessResource(this);
                if (q3 != null)
                {
                    q3.ProcessResource(this);
                }

                Thread.Sleep(100);


                stopWatch.Stop();

                Console.WriteLine($"Процес {processIndex} завершився, час роботи {stopWatch.ElapsedMilliseconds} мiлiсекунд");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
