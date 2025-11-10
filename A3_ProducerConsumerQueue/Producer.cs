using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace A3_ProducerConsumerQueue;

public class Producer
{
    private readonly int producerId;
    private readonly Random random;
    private volatile bool shouldStop = false;
    private Thread? producerThread;
    public int number = 0;
    public Queue<int> q1 = new Queue<int>();
    public Producer(int id, Queue<int> q1)
    {
        this.producerId = id;
        this.q1 = q1;
        this.random = new Random(id * 1000); // Verschiedene Seeds für verschiedene Producer

        // Thread im Konstruktor starten
        producerThread = new Thread(ProduceNumbers);
        producerThread.Start();
    }

    public void ProduceNumbers()
    {
        while (!shouldStop)
        {
            number = random.Next(1, 101); // Zufällige Zahl zwischen 1 und 100
            q1.Enqueue(number);
            Thread.Sleep(1000); // 1 Sekunde Takt
        }
    }

    public void Stop()
    {
        shouldStop = true;
    }
}
