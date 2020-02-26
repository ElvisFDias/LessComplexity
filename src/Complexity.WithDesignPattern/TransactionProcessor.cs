using Complexity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complexity.WithoutDesignPattern
{
    public class TransactionProcessor
    {
        private readonly IAccountRepository accountRepository;
        private readonly ITransactionRepository transactionRepository;

        public TransactionProcessor(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            this.accountRepository = accountRepository;
            this.transactionRepository = transactionRepository;
        }
        public bool Proccess(TransactionAccountRequest request)
        {
            if (request.AccountNumberA <= 0)
                return false;

            if (request.AccountNumberB <= 0)
                return false;

            var accountA = accountRepository.Get(request.AccountNumberA);
            if (accountA == null)
                return false;

            var accountB = accountRepository.Get(request.AccountNumberB);
            if (accountB == null)
                return false;


            var lastTransaction = transactionRepository.LatestTransaction(request.AccountNumberA, DateTime.Now.AddHours(-24));

            if (lastTransaction.Count() > 2)
                return false;

            var duplicateTransaction = transactionRepository.Get(request);

            if (duplicateTransaction != null)
                return false;

            var result = transactionRepository.Save(request);

            return result;
        }
    }
}
