using Complexity.Core;

namespace Complexity.WithDesignPattern
{
    public class AccountBValidation : AbstractStep
    {
        private readonly IAccountRepository accountRepository;

        public AccountBValidation(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public override bool Execute(TransactionAccountRequest request)
        {
            if (accountRepository.Get(request.AccountNumberB) == null)
                return false;

            return base.Execute(request);
        }
    }
}
