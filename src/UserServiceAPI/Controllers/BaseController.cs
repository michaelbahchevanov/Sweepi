using Sweepi.UserServiceAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using AutoMapper;

namespace Sweepi.UserServiceAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TReadEntity, TEntity, TRepository> : ControllerBase
      where TReadEntity : class, IEntity
      where TEntity : class, IEntity
      where TRepository : IRepository<TEntity>
    {
      TRepository _repository;
      IMapper _mapper;
      public BaseController(TRepository repository, IMapper mapper)
      {
          _repository = repository;
          _mapper = mapper;
      }

      [HttpGet]
      public async Task<ActionResult<List<TReadEntity>>> Get()
      {
        List<TEntity> entities = await _repository.GetAll();

        return Ok(_mapper.Map<List<TReadEntity>>(entities));
      }

      [HttpGet]
      [Route("{id}", Name = "GetById")]
      public async Task<ActionResult<TReadEntity>> Get(string id)
      {
        TEntity entity = await _repository.GetById(id);

        if (entity == null) return NotFound();

        return Ok(_mapper.Map<TReadEntity>(entity));
      }

      [HttpPut]
      [Route("{id}")]
      public async Task<ActionResult<TEntity>> Put(string id, TEntity entity)
      {
        try
        {
            if (entity.Id != id) return BadRequest();

            await _repository.Update(entity);

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
      public async Task<ActionResult<TEntity>> Post(TEntity entity)
      {
        try
        {
          if (ModelState.IsValid)
          {
            await _repository.Create(entity);
            return CreatedAtRoute("GetById", new { id = entity.Id }, entity);
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
      public async Task<ActionResult<TEntity>> Delete(string id)
      {
        try
        {
            TEntity entity = await _repository.Delete(id);

            if (entity == null) return NotFound();

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