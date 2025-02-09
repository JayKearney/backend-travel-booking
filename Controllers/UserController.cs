using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly AppDbContext _dbContext;
    public UserController(ILogger<UserController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
        
    }
    [HttpPost("Login")]
   public async Task<IActionResult> Login([FromBody] User user)
    {
        // Check if the user exists in the database
        var userInDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.Name == user.Name && u.Password == user.Password);
        if (userInDb == null)
        {
            return Unauthorized();
        }
        await _dbContext.SaveChangesAsync();
        return Ok("Login successful!");
    }
   

}