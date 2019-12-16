using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        public static void HelloWorldTask()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Hello from thread {0} inside HelloWorldTask.", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(50);
            }
            Thread.Sleep(5000);
        }

        static async Task TaskRunner()
        {
            Console.WriteLine("Hey from task runner, the thread id I'm running on is {0}", Thread.CurrentThread.ManagedThreadId);
            var task = Task.Run(HelloWorldTask);
            Thread.Sleep(20);

            Console.WriteLine("Kicked off task: task status is {0} on thread {1}.", task.Status, Thread.CurrentThread.ManagedThreadId);

            await task;

            Console.WriteLine("Task status is now {0}", task.Status);

            Console.WriteLine("Leaving main!!");
        }

        static async Task Main(string[] args)
        {
            var task = TaskRunner();
            Console.WriteLine("okay we got the task back and its status is now {0} which is actually referring to the task of TaskRunner duh and we are on thread {1}", task.Status, Thread.CurrentThread.ManagedThreadId);
            await task;
            Console.WriteLine("okay again we may have words between now and then and we are on thread {0}", Thread.CurrentThread.ManagedThreadId);
            Console.ReadLine();
        }
    }
}
