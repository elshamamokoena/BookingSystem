using BookingSystem.Application.Contracts.Services;
using BookingSystem.Application.Features.Cart.Commands.CreateCart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public CartController(IMediator mediator, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _authenticatedUserService = authenticatedUserService;
        }

        [HttpPost(Name ="CreateCartAsync")]

        public async Task<ActionResult<Guid>> CreateCart(CreateCartCommand command)
        {
            var userId = _authenticatedUserService.UserId;
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
