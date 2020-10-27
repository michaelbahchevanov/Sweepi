using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Sweepi.UserServiceAPI.Repository;
using Sweepi.UserServiceAPI.Mappers;
using Sweepi.UserServiceAPI.Models;
using System.Linq;

namespace Sweepi.UserServiceAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
    readonly UserRepository _repository;
      public UsersController(UserRepository repository)
      {
          _repository = repository;
      }

      [HttpGet]
      public async Task<ActionResult<IEnumerable<User>>> Get()
      {
        IEnumerable<User> users = await _repository.GetAll();

        return Ok(users.Select(u => u.MapToDTO()));
      }

      [HttpGet]
      [Route("{id}", Name = "GetById")]
      public async Task<ActionResult<User>> Get(string id)
      {
        var user = await _repository.GetById(id);

        if (user == null) return NotFound();

        return Ok(user.MapToDTO());
      }

      [HttpPut]
      [Route("{id}")]
      public async Task<ActionResult<User>> Put(string id, User user)
      {
        try
        {
            if (user.Id != id) return BadRequest();

            await _repository.Update(user);

            return NoContent();
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Unable to save changes");
            return StatusCode(StatusCodes.Status500InternalServerError);
            throw;
        }
      }

      [HttpPost]
      public async Task<ActionResult<User>> Post(User user)
      {
        try
        {
          if (ModelState.IsValid)
          {
            await _repository.Create(user);
            return CreatedAtRoute("GetById", new { id = user.Id }, user.MapToCreatedDTO());
          }
          return BadRequest();
        } 
        catch (DbUpdateException) {
          ModelState.AddModelError("", "Unable to save changes");
          return StatusCode(StatusCodes.Status500InternalServerError);
          throw;
        }
      }

      [HttpDelete]
      [Route("{id}")]
      public async Task<ActionResult<User>> Delete(string id)
      {
        try
        {
            var user = await _repository.Delete(id);

            if (user == null) return NotFound();

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