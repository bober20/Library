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
    public async Task<IActionResult> Get([FromRoute] int pageNo, CancellationToken cancellationToken)
    {
        var books = await _mediator.Send(new GetAllBooksQuery(pageNo, _itemsPerPage), cancellationToken);
        
        return Ok(books);
    }

    // GET api/<BookController>/5
    [HttpGet("getById/{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var book = await _mediator.Send(new GetBookByIdQuery(id), cancellationToken);
        
        return Ok(book);
    }
    
    [HttpGet("getByISBN/{ISBN}")]
    public async Task<IActionResult> Get([FromRoute] string ISBN, CancellationToken cancellationToken)
    {
        var book = await _mediator.Send(new GetFirstOrDefaultQuery(b => b.ISBN == ISBN), cancellationToken);
        
        return Ok(book);
    }
    
    [HttpGet("getByAuthor/{authorId:guid}/{pageNo:int}")]
    public async Task<IActionResult> GetByAuthor([FromRoute] Guid authorId, int pageNo, CancellationToken cancellationToken)
    {
        var book = await _mediator.Send(new GetBooksQuery(pageNo,_itemsPerPage, b => b.AuthorId == authorId), cancellationToken);
        
        return Ok(book);
    }
    
    [HttpGet("getByGenre/{genreId:guid}/{pageNo:int}")]
    public async Task<IActionResult> GetByGenre([FromRoute] Guid genreId, int pageNo, CancellationToken cancellationToken)
    {
        var book = await _mediator.Send(new GetBooksQuery(pageNo, _itemsPerPage, b => b.GenreId == genreId), cancellationToken);
        
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
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Book book, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new UpdateBookCommand(id, book), cancellationToken);

        return Ok(response);
    }
    
    // DELETE api/<BookController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteBookCommand(id), cancellationToken);

        return Ok(response);
    }
}