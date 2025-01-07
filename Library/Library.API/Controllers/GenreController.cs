using Library.Application.GenreUseCases.Commands;
using Microsoft.AspNetCore.Mvc;
using Library.Application.GenreUseCases.Queries;
using Library.Core.Models;
using MediatR;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IMediator _mediator;

    public GenreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<GenreController>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var genres = await _mediator.Send(new GetAllGenresQuery(), cancellationToken);
        
        return Ok(genres);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Genre genre, CancellationToken cancellationToken)
    {
        var updatedGenre = await _mediator.Send(new AddGenreCommand(genre), cancellationToken);
        
        return Ok(updatedGenre);
    }
}