using System;

namespace Superbank
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 1st test*/
            var account = new BankAccount("Waka","Flocka","Male", 50000, 50);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.BalanceRwf} RWF and {account.BalanceUsd} USD.");
            /* 2nd test Making withdrawal and deposit*/
            account.MakeWithdrawal(500,10, DateTime.Now, "Rent payment");
            
            Console.WriteLine($"Amount in local currency is {account.BalanceRwf}Rwf.");
            Console.WriteLine($"Amount in foreign currency is {account.BalanceUsd}Usd.");
            
            account.MakeDeposit(100,50, DateTime.Now, "Friend paid me back");
            
            Console.WriteLine($"Amount in local currency is {account.BalanceRwf}Rwf.");
            Console.WriteLine($"Amount in foreign currency is {account.BalanceUsd}Usd.");
            
            // Test that the initial balances must be positive.
            try
            {
                var invalidAccount = new BankAccount("invalid","Invalid","Invalid", -55, -29);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }
            // Test for a negative balance.
            try
            {
                account.MakeWithdrawal(101750,1000, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }
        }
    }
}