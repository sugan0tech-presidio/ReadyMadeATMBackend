using ReadyMadeATMBackend.Models;
using ReadyMadeATMBackend.Models.DTO;
using ReadyMadeATMBackend.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyMadeATMBackend.Interfaces
{
    public interface IUserRepo : IBaseRepo<User>
    {
        public Task<User> AddAsync(User user);
        public Task<User> GetAsync(LoginDTO loginDTO);
        public Task<List<User>> GetByPhone(string phone);

    }
}
