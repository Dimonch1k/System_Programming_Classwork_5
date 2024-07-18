using System;
using System.Threading;

namespace Tasks
{
    public class Task5
    {
        Semaphore semaphore = new Semaphore(3, 3);

        public void RunSemaphore()
        {
            Thread[] threads = new Thread[10];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(ThreadFunction);
                threads[i].Start(i + 1);
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine("Press any key to exit...");
        }

        void ThreadFunction(object threadNum)
        {
            int threadId = (int)threadNum;

            try
            {
                semaphore.WaitOne();

                Random rand = new Random();
                Console.WriteLine($"Thread {threadId} started. Generating random number...");
                int randomNumber = rand.Next(1, 100);

                Console.WriteLine($"Thread {threadId}: Random number {threadId + 1}: {randomNumber}");
                Console.WriteLine($"Thread {threadId} finished.");

                semaphore.Release();
            }
            catch
            {

            }
        }
    }
}
