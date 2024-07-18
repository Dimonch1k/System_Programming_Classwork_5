using System.Threading;
using System;

namespace Tasks
{
    public class Task4
    {
        Mutex mutex;

        public void RunUniqueMutex()
        {
            const string mutexName = "UniqueAppMutexName";

            bool createdNew;
            mutex = new Mutex(true, mutexName, out createdNew);

            if (!createdNew)
            {
                Console.WriteLine("Application is already running. Only one instance allowed.");
                Thread.Sleep(2000);
                return;
            }

            Console.WriteLine("Application started successfully.");

            mutex.ReleaseMutex();
        }
    }
}
