using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Abstractions.Services;
using OnlineShop.Core.Models.Dtos.Accounts;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("/api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("get-all-accounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var result = await _accountService.GetAllAccountsAsync();
            return Ok(result);
        }

        [HttpGet("get-account-by-id/{id}")]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            var result = await _accountService.GetAccountByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto accountDto)
        {
            var result = await _accountService.CreateAccountAsync(accountDto);
            return Ok(result);
        }

        [HttpPut("update-account")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountDto accountDto)
        {
            var result = await _accountService.UpdateAccountAsync(accountDto);
            return Ok(result);
        }

        [HttpPut("remove-account/{id}")]
        public async Task<IActionResult> RemoveAccount(Guid id)
        {
            await _accountService.RemoveAccountAsync(id);
            return Ok();
        }
    }
}
