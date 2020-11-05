using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sweepi.ProductServiceAPI.Models;
using Sweepi.ProductServiceAPI.Repository;
using Sweepi.ProductServiceAPI.Mappers;

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
      public async Task<ActionResult<IEnumerable<Product>>> Get()
      {
        IEnumerable<Product> products = await _repository.GetAll();

        return Ok(products.Select(p => p.MapToReadDto()));
      }

      [HttpGet]
      [Route("{id}", Name = "GetById")]
      public async Task<ActionResult<Product>> Get(string id)
      {
        var product = await _repository.GetById(id);

        if (product == null) return NotFound();

        return Ok(product.MapToReadDto());
      }

      [HttpPut]
      [Route("{id}")]
      public async Task<ActionResult<Product>> Put(string id, Product product)
      {
        try
        {
            if (product.Id != id) return BadRequest();

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
      public async Task<ActionResult<Product>> Post(Product product)
      {
        try
        {
          if (ModelState.IsValid)
          {
            await _repository.Create(product);
            return CreatedAtRoute("GetById", new { id = product.Id }, product.MapToCreatedDto());
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
      public async Task<ActionResult<Product>> Delete(string id)
      {
        try
        {
            var product = await _repository.Delete(id);

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