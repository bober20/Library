using Library.API.Requests;
using Library.Application.UserUseCases.Commands;
using Library.Application.UserUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // GET: api/<UserController>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserRequest userRequest)
        {
            var response = await _mediator.Send(new LoginUserQuery(userRequest.Email, userRequest.Password));
            return Ok(response);
        }
        
        // POST api/<UserController>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequest userRequest)
        {
            var response = await _mediator.Send(new RegisterUserCommand(userRequest.Email, userRequest.Password));
            return Ok(response);
        }
    }
}
