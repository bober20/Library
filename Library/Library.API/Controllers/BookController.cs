using Library.Application.BookUseCases.Commands;
using Library.Application.BookUseCases.Queries;
using Library.Core.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // GET: api/<BookController>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var books = await _mediator.Send(new GetAllBooksQuery(), cancellationToken);
        return Ok(books);
    }

    // // GET api/<BookController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var book = await _mediator.Send(new GetBookByIdQuery(id), cancellationToken);
        return Ok(book);
    }

    // POST api/<BookController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Book book, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new AddBookCommand(book), cancellationToken);
        return Ok(response);
    }

    // // PUT api/<BookController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromBody] Book book, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new UpdateBookCommand(book), cancellationToken);

        return Ok(response);
    }
    //
    // // DELETE api/<BookController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromBody] Book book, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteBookCommand(book), cancellationToken);

        return Ok(response);
    }
}