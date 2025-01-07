using Library.Application.AuthorUseCases.Commands;
using Library.Application.AuthorUseCases.Queries;
using Library.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // GET: api/<AuthorController>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllAuthorsQuery(), cancellationToken);
        
        return Ok(response);
    }

    // GET api/<AuthorController>/5
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAuthorByIdQuery(id), cancellationToken);

        return Ok(response);
    }
    
    [HttpGet("getAllAuthorBooks/{id:guid}")]
    public async Task<IActionResult> GetAllAuthorBooks(Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllAuthorBooksQuery(id), cancellationToken);

        return Ok(response);
    }

    // POST api/<AuthorController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Author author)
    {
        var response = await _mediator.Send(new AddAuthorCommand(author));

        return Ok(response);
    }

    // PUT api/<AuthorController>/5
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put([FromBody] Author author, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new UpdateAuthorCommand(author), cancellationToken);

        return Ok(response);
    }
    
    // DELETE api/<AuthorController>/5
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromBody] Author author, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteAuthorCommand(author), cancellationToken);

        return Ok(response);
    }
}