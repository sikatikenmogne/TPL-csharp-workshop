using System; // Importing the System namespace.
using System.Collections.Generic; // Importing the System.Collections.Generic namespace.
using System.Linq; // Importing the System.Linq namespace.
using System.Text; // Importing the System.Text namespace.

namespace test // Declaring a namespace named 'test'.
{
    class Program // Declaring a class named 'Program'.
    {
        delegate void DELG(); // Declaring a delegate 'DELG' that takes no parameters and returns void.
        delegate void EVT(object o); // Declaring a delegate 'EVT' that takes an object as a parameter and returns void.
        static event EVT evt; // Declaring a static event 'evt' of type 'EVT'.
        static int loop; // Declaring a static integer 'loop'.
        static object LOCK; // Declaring a static object 'LOCK'.

        static void Main(string[] args) // Declaring the Main method, which is the entry point of the program.
        {
            DELG dlG_time = new DELG(time); // Creating an instance of the 'DELG' delegate and assigning the 'time' method to it.
            DELG dlg_multiCast; // Declaring a variable 'dlg_multiCast' of type 'DELG'.
            IAsyncResult asyncR; // Declaring a variable 'asyncR' of type 'IAsyncResult', which represents the result of an asynchronous operation.
            LOCK = new object(); // Initializing 'LOCK' with a new object.
            loop = 0; // Initializing 'loop' with 0.
            evt += new EVT(state_display); // Adding the 'state_display' method to the 'evt' event.

            // Creating an anonymous type with two properties: 'msg_pext' and 'msg_noext'.
            var an_type = new {msg_pext = "pextension",msg_noext="noextension"};

            // Creating a new thread 'thd_timeInvok' that invokes the 'time' method.
            System.Threading.Thread thd_timeInvok = 
                new System.Threading.Thread(new System.Threading.ThreadStart(dlG_time.Invoke));

            // Creating a new thread 'thd_paraExt' that writes 'msg_pext' to the console in parallel.
            System.Threading.Thread thd_paraExt =
                new System.Threading.Thread(
                    new System.Threading.ThreadStart(() =>
                    {
                        System.Threading.Tasks.Parallel.For(0, 10, i =>
                        {
                            Console.WriteLine(@"{0}",an_type.msg_pext);
                            System.Threading.Thread.Sleep(1000);
                        });
                        evt((object)an_type.msg_pext);
                    }));

            // Creating a new thread 'thd_noParaExt' that writes 'msg_noext' to the console sequentially.
            System.Threading.Thread thd_noParaExt = 
                new System.Threading.Thread(
                    new System.Threading.ThreadStart(()=>
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine(@"{0}",an_type.msg_noext);
                            System.Threading.Thread.Sleep(1000);
                        };
                        evt((object)an_type.msg_noext);
                    }));

            // Invoking the 'time' method asynchronously and waiting for it to complete.
            asyncR = dlG_time.BeginInvoke((async) =>
                {
                    DELG d = (DELG)((System.Runtime.Remoting.Messaging.AsyncResult)async).AsyncDelegate;
                    d.EndInvoke(async);
                    Console.Write("Fin des traveaux");
                }, dlG_time);

            // Starting the 'thd_paraExt' and 'thd_noParaExt' threads using a multicast delegate 'dlg_multiCast'.
            dlg_multiCast = thd_paraExt.Start;
            dlg_multiCast += thd_noParaExt.Start;
            dlg_multiCast.Invoke();

            // Writing "Travaux en cours..." to the console every 5 seconds until the 'time' method completes.
            while (!asyncR.IsCompleted) { Console.WriteLine("Travaux en cours..."); System.Threading.Thread.Sleep(5000); }

            Console.Read(); // Waiting for a key press before the program ends.
        }

        static void time() // Declaring the 'time' method.
        {
            long t = 0; // Declaring a long 't' and initializing it with 0.
            lock (LOCK) // Using a lock to ensure that only one thread can enter the following block of code at a time.
            {
                while (loop < 2) // Looping until 'loop' is less than 2.
                {
                    Console.WriteLine(t.ToString()); // Writing the value of 't' to the console.
                    t += 1; // Incrementing 't' by 1.
                    System.Threading.Thread.Sleep(1000); // Pausing the current thread for 1 second.
                }
            }  
        }

        static void state_display(object o) // Declaring the 'state_display' method.
        {
            Console.ForegroundColor = ConsoleColor.Red; // Changing the console color to red.
            Console.WriteLine("{0} STOP", (string)o); // Writing a stop message to the console.
            Console.ForegroundColor = ConsoleColor.Gray; // Changing the console color back to gray.
            System.Threading.Interlocked.Increment(ref loop); // Incrementing 'loop' in a thread-safe manner.
        }
    }
}