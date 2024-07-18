using System;
using System.Threading;

namespace Tasks
{
    public class Task1
    {
        Mutex mutex = new Mutex();

        public void RunMutex()
        {
            Thread thread1 = new Thread(Print10);
            Thread thread2 = new Thread(Print20Reverse);

            Console.WriteLine("Two threads started its work!");

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Two threads finished its work!");
        }

        private void Print10()
        {
            mutex.WaitOne();
            Console.WriteLine("  Print10 function started:");
            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine($"    {i}");
            }
            Console.WriteLine("  Print10 function finished:");
            mutex.ReleaseMutex();
        }

        private void Print20Reverse()
        {
            mutex.WaitOne();
            Console.WriteLine("  Print20Reverse function started:");
            for (int i = 20; i >= 0; i--)
            {
                Console.WriteLine($"    {i}");
            }
            Console.WriteLine("  Print20Reverse function finished:");
            mutex.ReleaseMutex();
        }
    }
}
