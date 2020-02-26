using Complexity.Core;
using System.Collections.Generic;
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
}
