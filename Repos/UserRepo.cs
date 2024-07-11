using Microsoft.EntityFrameworkCore;
using ReadyMadeATMBackend.Context;
using ReadyMadeATMBackend.Interfaces;
using ReadyMadeATMBackend.Models;
using ReadyMadeATMBackend.Models.DTO;

namespace ReadyMadeATMBackend.Repos;

public class UserRepo(ReadyMadeATMContext context) : IUserRepo
{
    private readonly ReadyMadeATMContext context;

    public Task<User> Add(User ietem)
    {
        throw new NotImplementedException();
    }

    public Task<User> AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User> CreateAccountAsync(CreateAccountDTO createAccount)
    {
        try
        {
            var AccountCreate = await context.Users.AddAsync(new User
            {
                Name = createAccount.Name,
                Phone = createAccount.Phone
            });
            await context.SaveChangesAsync();
            return AccountCreate.Entity;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<User> DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetByPhone(string phone)
    {
        try
        {
            var allUsers = await context.Users.Where(x => x.Phone == phone).ToListAsync();
            return allUsers;
        }
        catch
        {
            throw new Exception("No User Found");
        }
    }

    public Task<User> Update(User entity)
    {
        throw new NotImplementedException();
    }

    async Task<User> IUserRepo.GetAsync(LoginDTO loginDto)
    {
        try
        {
            var login = await context.Users
                .FirstOrDefaultAsync(x => x.AtmNumber == loginDto.AtmNumber && x.Pin == loginDto.Pin);

            if (login == null)
            {
                throw new UnauthorizedAccessException("Invalid ATM Number or Pin");
            }

            return login;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
}