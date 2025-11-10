using System;
using System.Collections.Concurrent;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;

namespace A3_ProducerConsumerQueue;

class Program
{
    public static void Main(string[] args)
    {
        Queue<int> q1 = new Queue<int>();
        Console.WriteLine("Übung 3: Producer-Consumer");
        Console.WriteLine("==========================================\n");

        // TODO
        Producer p1 = new Producer(1, q1);
        Thread.Sleep(10);
        Consumer c1 = new Consumer(q1);

        Console.WriteLine("Producer und Consumer gestartet...\n");

        // Überwachung: Jede Sekunde Queue-Füllstand ausgeben und auf >50 prüfen
        
        // TODO


        // Alle Producer stoppen
       

        // Consumer stoppen
       
       
    }
}
