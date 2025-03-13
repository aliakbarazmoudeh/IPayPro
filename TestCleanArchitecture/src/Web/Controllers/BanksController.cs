using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCleanArchitecture.Domain.Entities;
using TestCleanArchitecture.Infrastructure.Data;


namespace TestCleanArchitecture.Web.Controllers;

[ApiController]
[Route("api/banks")]
public class BanksController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet("{bankId}")]
    public async Task<IActionResult> GetBank(int bankId)
    {
        PanelBank? bank = await _context.PanelBanks.FirstOrDefaultAsync(b => b.Id == bankId);

        if (bank is not null) return Ok(bank);

        return NotFound(new { msg = "no bank found with this Id" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBanks()
    {
        return Ok(await _context.PanelBanks.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreateBank(PanelBank entity)
    {
        await _context.PanelBanks.AddAsync(entity);
        return Ok();
    }

    [HttpPut("{bankId}")]
    public async Task<IActionResult> UpdateBank(int bankId,[FromBody] PanelBank entity)
    {
        PanelBank? bank = await _context.PanelBanks.FirstOrDefaultAsync(bank => bank.Id == bankId);
        return Ok();
    }

    [HttpDelete("{bankId}")]
    public async Task<IActionResult> DeleteBank(int bankId)
    {
        PanelBank? bank = await _context.PanelBanks.FirstOrDefaultAsync(bank => bank.Id == bankId);
        if (bank is not null)
        {
            _context.PanelBanks.Remove(bank);
            await _context.SaveChangesAsync();
            return Ok(new {msg = "Bank removed successfully!"});
        }

        return NotFound(new {msg = "Can't find any bank with this id"});
    }
}
