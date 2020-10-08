using Sweepi.UserServiceAPI.Models;
using Sweepi.UserServiceAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Sweepi.UserServiceAPI.Contollers
{
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
      UserDbContext _dbContext;

    public UsersController(UserDbContext dbContext)
      {
          _dbContext = dbContext;
      }

      [HttpGet]
      public async Task<IActionResult> GetAllAsync()
      {
        return Ok(await _dbContext.Users.ToListAsync());
      }

      [HttpGet]
      [Route("{userId}", Name = "GetByUserId")]
      public async Task<IActionResult> GetByUserIdAsync(string userId)
      {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserId == userId);

        if (user == null) return NotFound();

        return Ok(user);
      }

      [HttpPost]
      public async Task<IActionResult> RegisterUserAsync([FromBody] User user)
      {
        try
        {
          if (ModelState.IsValid) 
          {
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
            return CreatedAtRoute("GetByUserId", new { userId = user.UserId }, user);
          }
          return BadRequest();
        } 
        catch (DbUpdateException) {
          ModelState.AddModelError("", "Unable to save changes");
          return StatusCode(StatusCodes.Status500InternalServerError);
          throw;
        }
      }

      [HttpPut]
      [Route("{userId}", Name = "UpdateByUserId")]
      public async Task<IActionResult> UpdateUserAsync(string userId, [FromBody] User user)
      {
        if (userId != user.UserId) return BadRequest();

        try
        {
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
            return CreatedAtRoute("UpdateByUserId", new { user = user }, user);
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Unable to save changes");
            return StatusCode(StatusCodes.Status500InternalServerError);
            throw;
        }
      }

      [HttpDelete]
      [Route("{userId}")]
      public async Task<IActionResult> DeleteUserAsync(string userId)
      {
        try
        {
            var user = await _dbContext.Users.FindAsync(userId);

            if (user == null) return NotFound();

            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Unable to save changes");
            return StatusCode(StatusCodes.Status500InternalServerError);
            throw;
        }
      }
    }
}