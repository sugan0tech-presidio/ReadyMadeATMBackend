using ReadyMadeATMBackend.Interfaces;
using ReadyMadeATMBackend.Models;
using ReadyMadeATMBackend.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyMadeATMBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }


        public async Task<User> CreateAccount(CreateAccountDTO createAccountDTO)
        {
            var Duplicate = _userRepo.GetByPhone(createAccountDTO.Phone);
            if (Duplicate.Result.Count<0)
            {
                
            }
            foreach (var item in Duplicate.Result)
            {
                if (item.Name == createAccountDTO.Name)
                {
                    throw new Exception("Name already exists");
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

            var AccountDetails =await _userRepo.AddAsync(user);
            return AccountDetails;

        }


        public async Task<bool> UserLogin(LoginDTO loginDTO)
        {
            var Login = await _userRepo.GetAsync(loginDTO);
            if(Login == null)
            {
                throw new Exception("Invalid Login");
            }
            return true;

        }
    }
}
