using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReadyMadeATMBackend.Interfaces;
using ReadyMadeATMBackend.Models.DTO;
using ReadyMadeATMBackend.Services;

namespace ReadyMadeATMBackend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors(PolicyName = "AllowAll")]
    public class Account : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public Account(IUserService userService, ITokenService tokenService)
        {
            _userService=userService;
            _tokenService = tokenService;
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
        
        [HttpGet("balance/{accountNumber}")]
        public async Task<IActionResult> GetBalance(string accountNumber)
        {
            try
            {
                var result = await _userService.GetUserByAccountNumber(accountNumber);
                return Ok(result.Balance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("verify")]
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
