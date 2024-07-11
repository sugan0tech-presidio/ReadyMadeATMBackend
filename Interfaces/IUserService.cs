using ReadyMadeATMBackend.Models;
using ReadyMadeATMBackend.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyMadeATMBackend.Interfaces
{
    public interface IUserService
    {
        public Task<VerifyDto> UserLogin(LoginDTO loginDTO);
        public Task<User> GetUserByAccountNumber(string atmNumber);
        public Task<User> CreateAccount(CreateAccountDTO createAccountDTO);
    }
}
