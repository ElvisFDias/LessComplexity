using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complexity.Core
{
    public class TransactionAccountRequest
    {
        public TransactionAccountRequest(int accountNumberA, int accountNumberB, decimal amount, DateTime date, Reason reason)
        {
            AccountNumberA = accountNumberA;
            AccountNumberB = accountNumberB;
            Amount = amount;
            Date = date;
            Reason = reason;
        }
        public int AccountNumberA { get; }
        public int AccountNumberB { get; }
        public decimal Amount { get; }
        public DateTime Date { get; }
        public Reason Reason { get; }
        public Reason TransferReason { get; }

    }

    public enum Reason
    {
        Transfer = 0,
        Payment = 1
    }

    public class Account
    {

    }

    public class Transaction
    {

    }
}
