using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sweepi.ProductServiceAPI.DTOs;
using Sweepi.ProductServiceAPI.Models;
using Sweepi.ProductServiceAPI.Repository;

namespace Sweepi.ProductServiceAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    readonly ProductRepository _repository;
    public ProductsController(ProductRepository repository)
    {
        _repository = repository;
    }

      [HttpGet]
      public ActionResult<IEnumerable<Product>> Get()
      {
            return Ok(new { Message = "Nothing to see here" });
      }

      [HttpPut]
      public async Task<ActionResult<Product>> Put([FromBody] Product product)
      {
        try
        {
            if (product.UserId == null) return BadRequest();

            await _repository.Update(product);

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
      public async Task<ActionResult<Product>> Post([FromBody] Product product)
      {
        try
        {
          if (ModelState.IsValid)
          {
            await _repository.Create(product);
            return Created("Get", new Product { Id = product.Id, Name = product.Name, Category = product.Category });
          }
          return BadRequest();
        } 
        catch (DbUpdateException) {
          ModelState.AddModelError("", "Unable to save changes");
          return StatusCode(StatusCodes.Status500InternalServerError);
          throw;
        }
      }

      [HttpPost("all")]
      public async Task<ActionResult<List<Product>>> Post([FromBody] ProductGet request)
      {
            try
            {
                await _repository.GetById(request.UserId);
            }
            catch
            {
                return NotFound();
            }

            var products = await _repository.GetAll(request.UserId);
            if (products == null) return NotFound();
            return Ok(products);
      }
      [HttpPost("delete")]
      public async Task<ActionResult<Product>> Delete([FromBody] ProductRemove request)
      {
        try
        {
            var product = await _repository.Delete(request.Id);

            if (product == null) return NotFound();

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