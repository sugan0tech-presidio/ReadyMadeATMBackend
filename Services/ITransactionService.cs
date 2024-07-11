using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyMadeATMBackend.Services
{
    public interface ITransactionService
    {
        Task<string> Deposit(int userid, double amount);

        Task<string> Withdraw(int userid, double amount);
    }
}
