﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{
    class Program
    {
        delegate void DELG();
        delegate void EVT(object o);
        static event EVT evt;
        static int loop;
        static object LOCK;
        static void Main(string[] args)
        {
            DELG dlG_time = new DELG(time);
            DELG dlg_multiCast;
            IAsyncResult asyncR;
            LOCK = new object();
            loop = 0;
            evt += new EVT(state_display);
            var an_type = new {msg_pext = "pextension",msg_noext="noextension"};
            System.Threading.Thread thd_timeInvok = 
                new System.Threading.Thread(new System.Threading.ThreadStart(dlG_time.Invoke));
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
            asyncR = dlG_time.BeginInvoke((async) =>
                {
                    DELG d = (DELG)((System.Runtime.Remoting.Messaging.AsyncResult)async).AsyncDelegate;
                    d.EndInvoke(async);
                    Console.Write("Fin des traveaux");
                }, dlG_time);
            dlg_multiCast = thd_paraExt.Start;
            dlg_multiCast += thd_noParaExt.Start;
            dlg_multiCast.Invoke();
            while (!asyncR.IsCompleted) { Console.WriteLine("Travaux en cours..."); System.Threading.Thread.Sleep(5000); }
            Console.Read();
        }
        static void time()
        {
            long t = 0;
            lock (LOCK)
            {
                while (loop < 2)
                {
                    Console.WriteLine(t.ToString());
                    t += 1;
                    System.Threading.Thread.Sleep(1000);
                }
            }  
        }
        static void state_display(object o)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} STOP", (string)o);
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Threading.Interlocked.Increment(ref loop);
        }
    }
}