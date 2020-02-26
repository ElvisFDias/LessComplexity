using Complexity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complexity.WithDesignPattern
{
    public class TransactionProcessor
    {
        private readonly ITransactionStep transactionSteps;

        public TransactionProcessor(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            this.transactionSteps =
                new AccountNumberAValidation()
                .SetNext(new AccountNumberBValidation())
                .SetNext(new AccountAValidation(accountRepository))
                .SetNext(new AccountBValidation(accountRepository))
                .SetNext(new TransactionCountValidation(transactionRepository))
                .SetNext(new DuplicateTransactionValidation(transactionRepository))
                .SetNext(new SaveTransaction(transactionRepository));
        }
        public bool Proccess(TransactionAccountRequest request)
        {
            return transactionSteps.Execute(request);
                
        }
    }
}
