using ReadyMadeATMBackend.Context;
using ReadyMadeATMBackend.Models;

namespace ReadyMadeATMBackend.Repos;

public class TransactionRepo(ReadyMadeATMContext context) : BaseRepo<Transaction>(context)
{
}