using ReadyMadeATMBackend.Exceptions;
using ReadyMadeATMBackend.Models;
using ReadyMadeATMBackend.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyMadeATMBackend.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IBaseRepo<User> _userRepo;
        private readonly IBaseRepo<Transaction> _transactionRepo;

        public TransactionService(IBaseRepo<User> userRepo, IBaseRepo<Transaction> transactionRepo)
        {
            _userRepo = userRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task<string> Deposit(int userid, double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidDataException("Amount must be greater than zero");
            }
            else if (amount > 20000)
            {
                throw new ExceedingOneTimeLimit("You are exceeding one time limit");
            }

            var user = await _userRepo.GetById(userid);
            user.Balance += amount;
            var transaction = new Transaction
                { Type = "Deposit", Amount = amount, Timestamp = DateTime.Now, CurrentBalance = user.Balance };
            transaction = await _transactionRepo.Add(transaction);
            user.Transactions.Add(transaction);
            await _userRepo.Update(user);
            return "Amount Successfully Deposited";
        }

        public async Task<string> Withdraw(int userid, double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidDataException("Amount must be greater than zero");
            }

            var user = await _userRepo.GetById(userid);
            if (user.Balance == 0)
            {
                throw new LoanPromotionException("Our bank also provides easy 2 mins Loan approval");
            }
            if (user.Balance < amount)
            {
                throw new InsufficientBalanceException("Insufficient Balance");
            }
            else if (amount > 10000)
            {
                throw new ExceedingOneTimeLimit("You are exceeding one time limit");
            }

            user.Balance -= amount;
            var transaction = new Transaction
            {
                Type = "Withdraw",
                Amount = amount,
                Timestamp = DateTime.Now,
                CurrentBalance = user.Balance,
                Description = "Withdraw"
            };
            transaction = await _transactionRepo.Add(transaction);
            user.Transactions.Add(transaction);
            await _userRepo.Update(user);
            return "Amount Successfully Withdrawn";
        }
    }
}