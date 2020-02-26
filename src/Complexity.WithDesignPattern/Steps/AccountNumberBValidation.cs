using Complexity.Core;

namespace Complexity.WithDesignPattern
{
    public class AccountNumberBValidation : AbstractStep
    {
        public override bool Execute(TransactionAccountRequest request)
        {
            return request.AccountNumberB <= 0 ? false : base.Execute(request);
        }
    }
}
