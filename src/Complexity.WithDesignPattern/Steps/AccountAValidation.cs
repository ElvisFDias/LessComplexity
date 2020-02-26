using Complexity.Core;

namespace Complexity.WithDesignPattern
{
    public class AccountAValidation : AbstractStep
    {
        private readonly IAccountRepository accountRepository;

        public AccountAValidation(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public override bool Execute(TransactionAccountRequest request)
        {
            if (accountRepository.Get(request.AccountNumberA) == null)
                return false;

            return base.Execute(request);
        }
    }
}
