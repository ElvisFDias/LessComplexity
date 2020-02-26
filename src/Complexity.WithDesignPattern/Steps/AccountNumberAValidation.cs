using Complexity.Core;

namespace Complexity.WithDesignPattern
{
    public class AccountNumberAValidation : AbstractStep
    {
        public override bool Execute(TransactionAccountRequest request)
        {
            return request.AccountNumberA <= 0 ? false : base.Execute(request);
        }
    }
}
