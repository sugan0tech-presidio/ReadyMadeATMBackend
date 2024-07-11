using Microsoft.AspNetCore.Mvc;
using ReadyMadeATMBackend.Interfaces;
using ReadyMadeATMBackend.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyMadeATMBackend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class Account : ControllerBase
    {
        private readonly IUserService _userService;

        public Account(IUserService userService)
        {
            _userService=userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDTO createAccount)
        {
            try
            {
                var result = await _userService.CreateAccount(createAccount);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            try
            {
                var result = await _userService.UserLogin(login);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
