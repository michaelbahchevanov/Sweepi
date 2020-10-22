using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sweepi.ImageServiceAPI.Models;
using Sweepi.ImageServiceAPI.Repository;
using Sweepi.ImageServiceAPI.Mappers;

namespace Sweepi.ImageServiceAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ImagesController : ControllerBase
  {

    private readonly ImageRepository _repository;
    public ImagesController(ImageRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Image>>> Get()
    {
      IEnumerable<Image> images = await _repository.Get();
      return Ok(images);
    }

    [HttpGet]
    [Route("{id:length(24)}", Name = "GetImage")]
    public async Task<ActionResult<Image>> Get(string id)
    {
      var image = await _repository.Get(id);

      if(image == null) return NotFound();

      return Ok(image);
    }

    [HttpPost]
    public async Task<ActionResult<Image>> Post(Image image)
    {
      try
      {
        await _repository.Create(image);
        return CreatedAtRoute("GetImage", new { id = image.Id.ToString() }, image.MapToDTO());
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
        throw;
      }
    }

    [HttpDelete]
    [Route("{id:length(24)}")]
    public async Task<ActionResult<Image>> Delete(string id)
    {
      try
      {
        var image = await _repository.Delete(id);

        if (image == null) return NotFound();

        return NoContent();
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);  
        throw;
      }
    }
  }
}