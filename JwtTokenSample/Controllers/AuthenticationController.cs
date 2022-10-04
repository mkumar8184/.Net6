using JwtTokenSample.Entity;
using JwtTokenSample.Jwt;
using JwtTokenSample.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtTokenSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
       

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly JwtTokenTestContext _context;
        private readonly IMediator _mediator;
        public AuthenticationController(ILogger<WeatherForecastController> logger,

            JwtTokenTestContext context,
            IMediator mediator)
        {
            _logger = logger;
            _context = context;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var user = _context.UserInfos.FirstOrDefault(x => x.UserName == command.UserName);
            if (user == null)
            {
                return NotFound();
            }
            var userToken = await _mediator
              .Send(new JwtTokenCommand(user));
            return Ok(userToken);
        }

        [Authorize]
        [HttpGet]
        [Route("my-profile")]
        public IActionResult GetMyprofile()
        {
            var user = SessionUser.GetSessionUser();
            return Ok(user);
        }

    }
}