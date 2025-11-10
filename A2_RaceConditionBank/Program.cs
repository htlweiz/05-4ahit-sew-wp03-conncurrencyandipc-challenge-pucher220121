using System;
using System.Threading;

namespace A2_RaceConditionBank;

class Program
{
    static Object _lock = new Object();
    public static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread>();
        Console.WriteLine("Übung 2: Race Condition – Bankkonto");
        Console.WriteLine("==========================================\n");
        
        // Bankkonto mit Startwert 1000 EUR erstellen
        BankAccount account = new BankAccount(1000);
        Console.WriteLine($"Startkontostand: {account.GetBalance()} EUR\n");
        Thread t1;

        for (int i = 0; i < 10; i++)
        {
            t1 = new Thread(() => PerformBankOperations(account));
            threads.Add(t1);
            t1.Start();
        }
        foreach(Thread t in threads)
        {
            t.Join();
        }
        Console.WriteLine($"Endkontostand: {account.GetBalance()} EUR\n");
    }
    
    private static void PerformBankOperations(BankAccount account)
    {
        account.Deposit(100);
        Thread.Sleep(100);
        account.Withdraw(150);
        Thread.Sleep(100);
    }
}

