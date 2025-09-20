using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Model;

namespace TaskManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(MainContext _context) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll() => await _context.Users.AnyAsync() ? Ok(await _context.Users.ToListAsync()) : NotFound(new List<User>());
}
