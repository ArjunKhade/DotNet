using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ThreadingExamples1
{
    class Program
    {
        //static void Main()
        //{
        //    //Thread t = new Thread(new ThreadStart(Display));
        //    Thread t = new Thread(Display);
        //    t.Start();  //function is called here on a separate thread

        //}
        //static void Display()
        //{
        //}

        static void Main1()
        {
            Thread t1 = new Thread(Func1);
            Thread t2 = new Thread(Func2);

            //t1.IsBackground = true;
            //t1.Priority = ThreadPriority.Highest;
            //if(t1.ThreadState == ThreadState.)

            t1.Start();
            t2.Start();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Main : " + i);
                //if(i==50)
                //    t1.Abort();

            }
            //t1.Suspend();  //obsolete - has no effect on code
            //t1.Resume();  //obsolete- has no effect on code

            //instead of suspend, use this
            //WaitHandle wh = new AutoResetEvent(false);
            //wh.WaitOne();


            //t1.Resume();//deprecated
            // instead of resume, use this
            //((AutoResetEvent)wh).Set();


            //t1.Join(); //waiting call for t1 to join back again
            //Console.WriteLine("this code should run only after func1");
            Console.ReadLine();
            ///main thread waiting for foreground thread to complete
        }

        static void Func1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("First : " + i);
            }

        }
        static void Func2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Second : " + i);
            }

        }
    }
}
namespace ThreadingExamples2
{
    class Emp { public int EmpNo { get; set; } }
    class Program1
    {
        static void Main2()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));
            //Thread t2 = new Thread(new ParameterizedThreadStart(Func2));
            Thread t2 = new Thread(Func2);

            t1.Start("o1");
            t2.Start("o2");
            object[] a = new object[2];
            Thread t3 = new Thread(F3);
            t3.Start(a);


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main Thread " + i.ToString());
            }
            Console.ReadLine();
        }
        static void F3(object o)
        {

        }
        static void Func1(object o)
        {
            //Employee obj = (Employee) o;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First Thread " + i.ToString() + o.ToString());
            }
        }
        static void Func2(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Second Thread " + i.ToString() + o.ToString());
            }
        }
    }
}
//ThreadPool
namespace ThreadingExamples3
{
    class MainClass
    {
        static void PoolFunc1(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First Thread " + i.ToString() + o.ToString());
            }
        }
        static void PoolFunc2(object o)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Second Thread " + i.ToString());
            }
        }
        static void Main()
        {
            //ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc1), "aaa");
            ThreadPool.QueueUserWorkItem(PoolFunc1, "aaa");
            ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc2));


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main Thread " + i.ToString());
            }
            int workerthreads, iothreads;

            ThreadPool.GetAvailableThreads(out workerthreads, out iothreads);
            //ThreadPool.SetMinThreads
            //ThreadPool.SetMaxThreads
            //ThreadPool.GetMinThreads
            Console.WriteLine(workerthreads);
            Console.WriteLine(iothreads);

            Console.ReadLine();
        }
    }
}


//synchronization
namespace Eg3
{
    class MainClass
    {
        static object lockObject = new object();
        static int i = 0;
        static void Main1()
        {
            Thread t1 = new Thread(new ThreadStart(FuncLock));
            Thread t2 = new Thread(new ThreadStart(FuncMonitor));
            Thread t3 = new Thread(new ThreadStart(FuncInterlocked));
            t1.Start();
            t2.Start();
            t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();

            Console.WriteLine("Finished Main");
            Console.ReadLine();
        }
        static void FuncLock()
        {
            lock (lockObject) //Monitor.Enter(lockObject)
            {
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;


                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
            }
        }

        static void FuncMonitor()
        {
            Monitor.Enter(lockObject);
            {
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
            }
            Monitor.Exit(lockObject);

        }

        static void FuncInterlocked()
        {

            Interlocked.Add(ref i, 10);   //i+=10
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Increment(ref i); //++i;
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Decrement(ref i); //--i;
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Exchange(ref i, 100); //i = 100;
            Console.WriteLine("Third Interlocked " + i.ToString());
        }

    }
}


*****************************Task**************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//calling a method with void return type using taskobj.Start
namespace Example1
{
    class Program
    {
        static void Main1()
        {

            Task t1 = new Task(Func1);

            //Action objAction1 = Func1;
            //Task t1 = new Task(objAction1);


            //Task t3 = new Task(new Action(Func1));

            Action objAction2 = Func2;
            Task t2 = new Task(objAction2);

            t1.Start();
            t2.Start();

            Console.ReadLine();
        }
        static void Func1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("first Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("second Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
    }
}

//calling a method with void return type using Task.Run and Task.Factory.StartNew
namespace Example2
{
    class Program
    {
        static void Main2()
        {
            //Action objAction1 = Func1;
            //Task t1 = Task.Run(objAction1); 
            Task t1 = Task.Run(Func1);


            //Action objAction2 = Func2;
            //Task t2 = Task.Factory.StartNew(objAction2);
            Task t2 = Task.Factory.StartNew(Func2);

            Console.ReadLine();
        }
        static void Func1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("first Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("second Func called from {0},{1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }
    }
}

//calling a method with void return type and parameters 
namespace Example3
{
    class Program
    {
        static void Main3()
        {
            
            //Action<object> objAction1 = Func1;
            //Task t1a = new Task(objAction1, "aaa");
            Task t1 = new Task(Func1, "aaa");
            //Task.Run - cannot be used with parameters. 
            //use anonymous methods instead to access variables declared in calling code

            string s = "aaa";
            Task.Run(delegate () { Console.WriteLine(s); });
            Task.Run( ()=> { Console.WriteLine(s); });

            //Action<object> objAction2 = Func2;
            //Task t2 = Task.Factory.StartNew(objAction2, "bbb");
            Task t2 = Task.Factory.StartNew(Func2, "bbb");

            t1.Start();
            Console.ReadLine();
        }
        static void Func1(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("first Func called {0}{1}", i, obj.ToString());
            }
        }
        static void Func2(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("second Func called {0},{1}", i, obj.ToString());
            }
        }
    }
}

//calling methods with return type 
namespace Example4
{
    class Program
    {
        static void Main()
        {
            //Task<int> t1 = new Task<int>(new Func<int>(Func1));
            
            //Func<int> objFunc1 = Func1;
            //Task<int> t1 = new Task<int>(objFunc1);
            
            Task<int> t1 = new Task<int>(Func1);

            t1.Start();

            //Func<object, int> objFunc2 = Func2;
            //Task<int> t2 = new Task<int>(objFunc2, "bbb");
            Task<int> t2 = new Task<int>(Func2, "bbb");

            t2.Start();

            //to do
            //try calling func with return value with Task.Run and Task.Factory.StartNew
            //Task.Run<int>()
            //Task.Factory.StartNew<int>()

            if (!t1.IsCompleted)
                t1.Wait();
            Console.WriteLine(t1.Result);

            if (!t2.IsCompleted)
                t2.Wait();
            Console.WriteLine(t2.Result);

            Console.ReadLine();
        }
        static int Func1()
        {
            int i;
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine("first Func called {0}", i);
            }
            return i;
        }
        static int Func2(object obj)
        {
            int i;
            for (i = 0; i < 20; i++)
            {
                Console.WriteLine("second Func called {0},{1}", i, obj.ToString());
            }
            return i;
        }
    }
}

*******************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Before");
            string message = await DoWorkAsync();  //waiting call
            Console.WriteLine(message);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static async Task<string> DoWorkAsync()  //awaitable
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5000);
                return "Done with work!";
            });
        }

        static async Task Main2()
        {
            Console.WriteLine("Before");
            
            Task<Task<string>> t1 = new Task<Task<string>>(DoWorkAsync);
            t1.Start();
            Console.WriteLine("After");

            string message = await t1.Result;
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}

***************************************************************