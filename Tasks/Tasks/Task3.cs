using System.Threading;
using System;

namespace Tasks
{
    public class Task3
    {
        Mutex mutex = new Mutex();
        public int[] array = new int[] { 1, 2, 3, 4, 5 };
        public int maxValue = int.MinValue;

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
                Thread.Sleep(500);
            }

            mutex.ReleaseMutex();
        }

        private void GetMaxNum()
        {
            mutex.WaitOne();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxValue) maxValue = array[i];
            }
            
            mutex.ReleaseMutex();
        }

    }
}
