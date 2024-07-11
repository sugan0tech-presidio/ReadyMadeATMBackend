using ReadyMadeATMBackend.Context;
using ReadyMadeATMBackend.Models;

namespace ReadyMadeATMBackend.Repos;

public class UserRepo(ReadyMadeATMContext context) : BaseRepo<User>(context)
{
    
}