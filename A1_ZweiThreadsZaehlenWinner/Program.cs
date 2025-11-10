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

        if (countUpVar > countDounVar) { Console.WriteLine("Winnes is thread up"); }
        if (countUpVar < countDounVar) { Console.WriteLine("Winnes is thread down"); }
        if(countUpVar == countDounVar) { Console.WriteLine("Draw"); }
    }
    
    private static void CountUpThreadA()
    {
        for (int i = 0; i <= 100; i++)
        {
            countUpVar = i;
            Console.WriteLine(i);

            if (countDounVar == countUpVar)
            {
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
                stop = true;
                break;
            }
            if (stop == true) break;
            Thread.Sleep(100); 
        }
    }
}
