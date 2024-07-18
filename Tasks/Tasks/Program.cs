using System;

namespace Tasks
{
    public class Program
    {
        static void Main(string[] args)
        {

            // ================================
            //Task1 task1 = new Task1();
            //task1.RunMutex();

            // ================================
            //Task2 task2 = new Task2();
            //task2.RunMutex();

            // ================================
            //Task3 task3 = new Task3();
            //task3.RunMutex();
            //Console.Write("Modified array:");
            //foreach (var num in task3.array)
            //{
            //    Console.Write($" {num}");
            //}
            //Console.WriteLine($"\nMax value is: {task3.maxValue}");

            // ================================
            //Task4 task4 = new Task4();
            //task4.RunUniqueMutex(); // Create mutex with 'unique' name
            //task4.RunUniqueMutex(); // Second mutex showed Error message

            // ================================
            Task5 task5 = new Task5();
            task5.RunSemaphore();

            Console.ReadKey();
        }
    }
}
