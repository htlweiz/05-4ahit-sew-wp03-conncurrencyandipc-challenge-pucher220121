using System;
using System.Threading;

namespace A2_RaceConditionBank;
public class BankAccount
{
    static Object _lock = new Object();
    private int balance;
   
    
    public BankAccount(int initial) 
    { 
        balance = initial; 
    }
    
    public void Deposit(int amount)
    {
        lock (_lock)
        {
            balance += amount;
        }
    }
    
    public void Withdraw(int amount) 
    {
        lock (_lock)
        {
            balance -= amount;
        }
    }
    
    public int GetBalance() 
    {
        return balance;
    }
}
