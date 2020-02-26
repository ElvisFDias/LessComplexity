using Complexity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complexity.WithDesignPattern
{
    public interface ITransactionStep
    {
        bool Execute(TransactionAccountRequest request);

        ITransactionStep SetNext(ITransactionStep nextStep);
    }

    public abstract class AbstractStep : ITransactionStep
    {
        private ITransactionStep nextHandler;

        public virtual bool Execute(TransactionAccountRequest request)
        {

            return nextHandler?.Execute(request) ?? true;

        }

        public ITransactionStep SetNext(ITransactionStep handler)
        {
            nextHandler = handler;

            return handler;
        }
    }

    public class AccountNumberAValidation : AbstractStep
    {
        public override bool Execute(TransactionAccountRequest request)
        {
            return request.AccountNumberA <= 0 ? false : base.Execute(request);
        }
    }

    public class AccountNumberBValidation : AbstractStep
    {
        public override bool Execute(TransactionAccountRequest request)
        {
            return request.AccountNumberB <= 0 ? false : base.Execute(request);
        }
    }

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
