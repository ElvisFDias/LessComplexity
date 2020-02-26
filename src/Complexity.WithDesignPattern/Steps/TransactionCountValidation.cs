using Complexity.Core;
using System;
using System.Linq;

namespace Complexity.WithDesignPattern
{
    public class TransactionCountValidation : AbstractStep
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionCountValidation(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public override bool Execute(TransactionAccountRequest request)
        {
            return transactionRepository.LatestTransaction(request.AccountNumberA, DateTime.Now.AddHours(-24)).Count() > 2 ? false : base.Execute(request);
        }
    }
}
