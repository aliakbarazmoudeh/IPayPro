using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Domain.Entities;
using TestCleanArchitecture.Infrastructure.Data;

namespace TestCleanArchitecture.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpPost("Temp")]
    public async Task<IActionResult> Temp([FromBody]TempLoginDto entity)
    {
        if (string.IsNullOrEmpty(entity.Username) || string.IsNullOrEmpty(entity.Password))
        {
            return BadRequest(new { message = "Username and password are required" });
        }

        TempLogin? account = await _context.TempLogins.FirstOrDefaultAsync(x => x.Username == entity.Username && x.Password == entity.Password);
            

        if (account is null) return NotFound(new {msg = "there is no account with this credentials"});
        
        bool isValidPassword = account.CheckPassword(entity.Password);

        if (!isValidPassword) return BadRequest(new { msg = "invalid credentials" });
        
        return Ok(account);
    }
}
