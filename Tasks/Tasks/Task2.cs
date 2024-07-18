using System;
using System.Threading;

namespace Tasks
{
    public class Task2
    {
        Mutex mutex = new Mutex();
        int[] array = new int[] { 1, 2, 3, 4, 5 };

        public void RunMutex()
        {
            Thread modifierThread = new Thread(ModifyArr);
            Thread getMaxThread = new Thread(GetMaxNum);

            modifierThread.Start();
            getMaxThread.Start();

            modifierThread.Join();
            getMaxThread.Join();

        }

        private void ModifyArr()
        {
            mutex.WaitOne();

            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] += rand.Next(1, 20);
                Console.WriteLine($"Modified element at index {i}: {array[i]}");
                Thread.Sleep(1000);
            }

            mutex.ReleaseMutex();
        }

        private void GetMaxNum()
        {
            mutex.WaitOne();

            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max) max = array[i];

            }
            Console.WriteLine($"Maximum value in array: {max}");

            mutex.ReleaseMutex();
        }
    }
}
