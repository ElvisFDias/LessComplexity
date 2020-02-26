using Complexity.Core;

namespace Complexity.WithDesignPattern
{
    public class SaveTransaction : AbstractStep
    {
        private readonly ITransactionRepository transactionRepository;

        public SaveTransaction(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public override bool Execute(TransactionAccountRequest request)
        {
            return !transactionRepository.Save(request) ? false : base.Execute(request);
        }
    }
}
