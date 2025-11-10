using System;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{
   
    
    public static void Main(string[] args)
    {
        Thread countUp = new Thread(CountUpThreadA);
        Thread countDown = new Thread(CountDownThreadB);

        countUp.Start();
        countDown.Start();

        countUp.Join();
        countDown.Join();
    }
    
    private static void CountUpThreadA()
    {
        for (int i = 0; i <= 100; i++) { Console.WriteLine(i);  Thread.Sleep(100); };
    }
    
    private static void CountDownThreadB()
    {
       for (int i = 100; i >= 0; i--) { Console.WriteLine(i); Thread.Sleep(100); };
    }
}
