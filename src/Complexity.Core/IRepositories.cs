using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complexity.Core
{
    public interface IAccountRepository
    {
        Account Get(int accountNumber);
    }

    public interface ITransactionRepository
    {
        //IReadOnlyCollection<Transaction> Get(int accountNumber, DateTime initialDate, DateTime endDate);
        IEnumerable<Transaction> LatestTransaction(int accountNumber, DateTime date);

        Transaction Get(TransactionAccountRequest transactionAccountRequest);

        bool Save(TransactionAccountRequest transaction);
    }
}
