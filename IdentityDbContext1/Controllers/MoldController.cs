using IdentityDbContext1.Entities;
using IdentityDbContext1.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDbContext1.Controllers;

[Route("api/[controller]")]
[ApiController]
public  class MoldController<TEntity, TService> : ControllerBase where TEntity : class, IEntity where TService : IGenericRepository<TEntity>
{
    private readonly IGenericRepository<TEntity> _genericRepository;
    public MoldController(IGenericRepository<TEntity> genericRepository) => _genericRepository = genericRepository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TEntity>>> Get() => await _genericRepository.GetAll();

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TEntity>> GetById(int id)
    {
        var movie = await _genericRepository.GetById(id);
        if (movie == null) return NotFound();
        return movie;
    }

    [HttpPost]
    public virtual async Task<ActionResult<TEntity>> Post([FromForm]TEntity movie)
    {
        await _genericRepository.Add(movie);
        return movie;
    }
    [HttpPut]
    public virtual async Task<IActionResult> Put(int id, TEntity movie)
    {
        if (id != movie.Id)
            return BadRequest();
        await _genericRepository.Update(id,movie);
        return NoContent();
    }


    [HttpDelete("{id}")]
    public virtual async Task<ActionResult<TEntity>> Delete(int id)
    {
        var movie = await _genericRepository.Delete(id);
        return movie;
    }

}
