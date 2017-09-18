using System;
using System.Threading;

namespace Lab3_MPP
{
    class Program
    {
        delegate void Func(int task_ident, ref int value_check);

        const 
            int THREAD_CAPACITY = 5,
                ITERATION_CAPACITY = 2;

        private static void Function(int task_ident, ref int value_check)
        {
            var mutex = new Mutex();
            for (int j = 0; j < ITERATION_CAPACITY; j++)
            {
                mutex.Lock();
                Console.WriteLine("Task {0}, value test variable: {1}", task_ident + 1, value_check++);
                mutex.Unlock();
                Thread.Sleep(300);
            }
        }

        static void Main(string[] args)
        {
            var mutex = new Mutex();
            int checkedValue = 0;
            var threads = new Thread[THREAD_CAPACITY];
            for (int i = 0; i < THREAD_CAPACITY; i++)
            {
                int numberOfTask = i;
                threads[i] = new Thread(() =>
                {
                    Function(numberOfTask, ref checkedValue);
                });
                threads[i].Start();
            }
            Console.ReadLine();
        }
    }
}
