using System;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{
    static int countUpVar = 0;
    static int countDounVar = 100;
    static bool stop = false;
    
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
        for (int i = 0; i <= 100; i++)
        {
            countUpVar = i;
            Console.WriteLine(i);

            if (countDounVar == countUpVar)
            {
                Console.WriteLine("Var Up: " + countUpVar);
                stop = true;
                break;
            }
            if (stop == true) break;
            Thread.Sleep(100); 
        }
    }
    
    private static void CountDownThreadB()
    {
       for (int i = 100; i >= 0; i--)
        {
            countDounVar = i;
            Console.WriteLine(i);

            if (countDounVar == countUpVar)
            {
                Console.WriteLine("Var Down: " + countDounVar);
                stop = true;
                break;
            }
            if (stop == true) break;
            Thread.Sleep(100); 
        }
    }
}
