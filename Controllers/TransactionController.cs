using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadyMadeATMBackend.Exceptions;
using ReadyMadeATMBackend.Models;
using ReadyMadeATMBackend.Services;

namespace ReadyMadeATMBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController(ITransactionService transactionService) : ControllerBase
{
    [HttpPost("deposit")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Deposit([FromBody] TransactionDto dto)
    {
        try
        {
            var result = await transactionService.Deposit(dto.UserId, dto.Amount);
            return Ok(result);
        }
        catch (InvalidDataException ex)
        {
            return BadRequest(new ErrorModel { status = 400, message = ex.Message });
        }
        catch (ExceedingOneTimeLimit ex)
        {
            return BadRequest(new ErrorModel { status = 400, message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new ErrorModel { message = "An unexpected error occurred", status = 500 });
        }
    }

    [HttpPost("withdraw")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Withdraw([FromBody] TransactionDto dto)
    {
        try
        {
            var result = await transactionService.Withdraw(dto.UserId, dto.Amount);
            return Ok(result);
        }
        catch (InvalidDataException ex)
        {
            return BadRequest(new ErrorModel { status = 400, message = ex.Message });
        }
        catch (ExceedingOneTimeLimit ex)
        {
            return BadRequest(new ErrorModel { status = 400, message = ex.Message });
        }
        catch (InsufficientBalanceException ex)
        {
            return BadRequest(new ErrorModel { status = 400, message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new ErrorModel { message = "An unexpected error occurred", status = 500 });
        }
    }
}