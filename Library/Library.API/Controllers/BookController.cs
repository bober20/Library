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
    private readonly int _itemsPerPage;
    
    public BookController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _itemsPerPage = configuration.GetValue<int>("ItemsPerPage");
    }
    
    // GET: api/<BookController>
    [HttpGet("{pageNo:int}")]
    public async Task<IActionResult> Get(int pageNo, CancellationToken cancellationToken)
    {
        var books = await _mediator.Send(new GetAllBooksQuery(pageNo, _itemsPerPage), cancellationToken);
        
        return Ok(books);
    }

    // GET api/<BookController>/5
    [HttpGet("getById/{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var book = await _mediator.Send(new GetBookByIdQuery(id), cancellationToken);
        
        return Ok(book);
    }
    
    [HttpGet("getByISBN/{ISBN}/{pageNo:int}")]
    public async Task<IActionResult> Get(string ISBN, int pageNo, CancellationToken cancellationToken)
    {
        var book = await _mediator.Send(new GetFirstOrDefaultQuery(b => b.ISBN == ISBN), cancellationToken);
        
        return Ok(book);
    }
    
    [HttpGet("getByAuthor/{authorId:guid}")]
    public async Task<IActionResult> GetByAuthor(Guid authorId, CancellationToken cancellationToken)
    {
        var book = await _mediator.Send(new GetFirstOrDefaultQuery(b => b.Author.Id == authorId), cancellationToken);
        
        return Ok(book);
    }
    
    [HttpGet("getByGenre/{authorId:guid}")]
    public async Task<IActionResult> GetByGenre(Guid genreId, CancellationToken cancellationToken)
    {
        var book = await _mediator.Send(new GetFirstOrDefaultQuery(b => b.Genre.Id == genreId), cancellationToken);
        
        return Ok(book);
    }

    // POST api/<BookController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Book book, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new AddBookCommand(book), cancellationToken);
        
        return Ok(response);
    }

    // PUT api/<BookController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromBody] Book book, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new UpdateBookCommand(book), cancellationToken);

        return Ok(response);
    }
    
    // DELETE api/<BookController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromBody] Book book, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteBookCommand(book), cancellationToken);

        return Ok(response);
    }
}