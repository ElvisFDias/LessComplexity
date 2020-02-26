using Complexity.Core;

namespace Complexity.WithDesignPattern
{
    public class DuplicateTransactionValidation : AbstractStep
    {
        private readonly ITransactionRepository transactionRepository;

        public DuplicateTransactionValidation(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public override bool Execute(TransactionAccountRequest request)
        {
            return transactionRepository.Get(request) != null ? false : base.Execute(request); 
        }
    }
}
