using ReadyMadeATMBackend.Interfaces;
using ReadyMadeATMBackend.Models;
using ReadyMadeATMBackend.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadyMadeATMBackend.Exceptions;
using ReadyMadeATMBackend.Repos;

namespace ReadyMadeATMBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepo<User> _userRepo;
        private readonly ITokenService _tokenService;

        public UserService(IBaseRepo<User> userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }


        public async Task<User> CreateAccount(CreateAccountDTO createAccountDTO)
        {
            var users = await _userRepo.GetAll();
            var Duplicate = users.FindAll(user1 => user1.Phone.Equals(createAccountDTO.Phone));
            if (Duplicate.Count < 0)
            {
                
            }
            foreach (var item in Duplicate)
            {
                if (item.Name == createAccountDTO.Name)
                {
                }
            }
            User user = new User()
            {
                Name = createAccountDTO.Name,
                Phone = createAccountDTO.Phone,
                Balance = 0,
                AtmNumber = Guid.NewGuid().ToString("N").Substring(0, 16),
                Pin = int.Parse(Guid.NewGuid().ToString("N").Substring(0, 4))
            };

            var AccountDetails = await _userRepo.Add(user);
            return AccountDetails;

        }

        public async Task<User> GetUserByAccountNumber(string atmNumber)
        {
            var users = await _userRepo.GetAll();
            var user = users.Find(user => user.AtmNumber.Equals(atmNumber));
            if (user == null)
                throw new EntityNotFoundException("No user found for the card");
            return user;
        }

        public async Task<VerifyDto> UserLogin(LoginDTO loginDTO)
        {
            var users = await _userRepo.GetAll();
            var login = users.Find(user => user.AtmNumber.Equals(loginDTO.AtmNumber) && user.Pin.Equals(loginDTO.Pin));
            if(login == null)
            {
                throw new Exception("Invalid Login");
            }
            var token = _tokenService.GenerateToken(login, DateTime.Now.AddSeconds(30));
            return new VerifyDto { Token = token, UserId = login.Id };

        }
    }
}
