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
    // [HttpGet("{id}")]
    // public string Get(int id)
    // {
    //     return "value";
    // }

    // POST api/<BookController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Book book, CancellationToken cancellationToken)
    {
        await _mediator.Send(new AddBookCommand(book), cancellationToken);
        return Ok();
    }

    // // PUT api/<BookController>/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }
    //
    // // DELETE api/<BookController>/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }
}