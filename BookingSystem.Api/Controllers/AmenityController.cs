using BookingSystem.Application.Features.Amenities.Commands.CreateAmenity;
using BookingSystem.Application.Features.Amenities.Commands.CreateAmenityCategory;
using BookingSystem.Application.Features.Amenities.Commands.DeleteAmenity;
using BookingSystem.Application.Features.Amenities.Commands.UpdateAmenity;
using BookingSystem.Application.Features.Amenities.Queries.GetAmenities;
using BookingSystem.Application.Features.Amenities.Queries.GetAmenity;
using BookingSystem.Application.Features.Amenities.Queries.GetAmenityCategories;
using BookingSystem.AuthorizationPolicies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/amenities")]

    public class AmenityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AmenityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("categories",Name = "CreateAmenityCategoryAsync")]
        public async Task<ActionResult<CreateAmenityCategoryCommandResponse>> CreateAmenityCategoryAsync([FromBody] CreateAmenityCategoryCommand createAmenityCategoryCommand)
        {
            return Ok(await _mediator.Send(createAmenityCategoryCommand));
        }
        [HttpPost(Name = "CreateAmenityAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> CreateAmenityAsync([FromBody] CreateAmenityCommand createAmenityCommand)
        {
            return Ok(await _mediator.Send(createAmenityCommand));
        }

        [HttpPut(Name = "UpdateAmenityAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateAmenityAsync([FromBody] UpdateAmenityCommand updateAmenityRoomCommand)
        {
            await _mediator.Send(updateAmenityRoomCommand);
            return NoContent();
        }

        [HttpGet("detail", Name = "GetAmenityAsync")]
        public async Task<ActionResult<AmenityVm>> GetAmenityAsync([FromQuery] GetAmenityQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        //[HttpPut(Name = "UpdateAmenityCategoryAsync")]
        //public async Task<ActionResult<UpdateAmenityCategoryCommandResponse>> UpdateAmenityCategoryAsync([FromBody] UpdateAmenityCategoryCommand updateAmenityCategoryCommand)
        //{
        //    return Ok(await _mediator.Send(updateAmenityCategoryCommand));
        //}

        //[HttpGet("{amenityCategoryId}", Name = "GetAmenityCategoryAsync")]
        //public async Task<ActionResult<AmenityCategoryVm>> GetAmenityCategoryAsync(Guid amenityCategoryId)
        //{
        //    var query = new GetAmenityCategoryQuery(amenityCategoryId);
        //    return Ok(await _mediator.Send(query));
        //}

        [HttpGet("categories",Name = "GetAmenityCategoriesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<AmenityCategoryListVm>>> GetAmenityCategoriesAsync()
        {
            return Ok(await _mediator.Send(new GetAmenityCategoriesQuery()));
        }
        [HttpGet("list",Name = "GetAmenitiesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<AmenityListVm>>> GetAmenitiesAsync([FromQuery] GetAmenitiesQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpDelete("{amenityId}", Name = "DeleteAmenityAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteAmenityAsync(Guid amenityId)
        {
            await _mediator.Send(new DeleteAmenityCommand { AmenityId = amenityId });
            return NoContent();
        }

        //[HttpDelete("{amenityCategoryId}", Name = "DeleteAmenityCategoryAsync")]
        //public async Task<ActionResult<bool>> DeleteAmenityCategoryAsync(Guid amenityCategoryId)
        //{
        //    return Ok(await _mediator.Send(
        //        new DeleteAmenityCategoryCommand { AmenityCategoryId = amenityCategoryId }));
        //}

    }
}
