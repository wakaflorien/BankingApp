using System;
using System.Collections.Generic;

namespace Superbank
{
    public class BankAccount
    {
        public string Number { get;  }
        public string Owner { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }

        public decimal BalanceRwf
        {
            get
            {
                decimal balanceRwf = 0;
                foreach (var item in _allTransactions)
                {
                    balanceRwf += item.AmountRwf;
                }

                return balanceRwf;
            }

           
        }

        public decimal BalanceUsd
        {
            get
            {
                decimal balanceUsd = 0;
                foreach (var item in _allTransactions)
                {
                    balanceUsd += item.AmountUsd;
                }
                return balanceUsd;
            }

        }

        private static int AccountNumberSeed = 0123456789;
        private List<Transaction> _allTransactions = new List<Transaction>();

        public BankAccount(string Fname,string Lname, string Gender, decimal initialBalanceRwf, decimal initialBalanceUsd)
        {
            this.Firstname = Fname;
            this.Lastname = Lname;
            this.Sex = Gender;
            /*this.BalanceRwf = initialBalanceRwf;
            this.BalanceUsd = initialBalanceUsd;*/
            this.Number = AccountNumberSeed.ToString();
            AccountNumberSeed++;
            
            MakeDeposit(initialBalanceRwf,initialBalanceUsd,DateTime.Now,"Initial Initial Rwf and Usd Balance"   );
        }
        
        public void MakeDeposit(decimal amountRwf, decimal amountUsd, DateTime date, string note)
        {
            if (amountRwf <= 0 ) 
            {
                throw new ArgumentOutOfRangeException(nameof(amountRwf), "Amount of deposit must be positive");
            }
            else if(amountUsd<=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amountUsd), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amountRwf, amountUsd, date, note);
            _allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amountRwf, decimal amountUsd, DateTime date, string note)
        {
            if (amountRwf <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amountRwf), "Amount of withdrawal must be positive");
            }
            if (BalanceRwf - amountRwf < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            if (amountUsd <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amountUsd), "Amount of withdrawal must be positive");
            }

            if (amountUsd <= 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amountRwf, -amountUsd, date, note);
            _allTransactions.Add(withdrawal);
        }
    }
}