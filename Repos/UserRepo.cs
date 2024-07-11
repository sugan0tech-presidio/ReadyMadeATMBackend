using Microsoft.EntityFrameworkCore;
using ReadyMadeATMBackend.Context;
using ReadyMadeATMBackend.Interfaces;
using ReadyMadeATMBackend.Models;
using ReadyMadeATMBackend.Models.DTO;

namespace ReadyMadeATMBackend.Repos;

public class UserRepo(ReadyMadeATMContext context) : IUserRepo
{
}