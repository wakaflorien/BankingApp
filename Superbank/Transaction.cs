using System;

namespace Superbank
{
    public class Transaction
    {
        public decimal AmountRwf { get; }
        public decimal AmountUsd { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amountRwf, decimal amountUsd, DateTime date, string notes)
        {
            this.AmountRwf = amountRwf;
            this.AmountUsd = amountUsd;
            this.Date = date;
            this.Notes = notes;
        }
    }
}