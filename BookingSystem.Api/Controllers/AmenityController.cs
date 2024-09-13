using BookingSystem.Application.Features.Amenities.Commands.AddAmenityToRoom;
using BookingSystem.Application.Features.Amenities.Commands.CreateAmenity;
using BookingSystem.Application.Features.Amenities.Commands.CreateAmenityCategory;
using MediatR;
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
        public async Task<ActionResult<CreateAmenityCommandResponse>>
            CreateAmenityAsync([FromBody] CreateAmenityCommand createAmenityCommand)
        {
            return Ok(await _mediator.Send(createAmenityCommand));
        }

        [HttpPut(Name = "UpdateAmenityRoomAsync")]
        public async Task<ActionResult<AddAmenityToRoomCommandResponse>> UpdateAmenityRoomAsync([FromBody] AddAmenityToRoomCommand updateAmenityRoomCommand)
        {
            return Ok(await _mediator.Send(updateAmenityRoomCommand));
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

        //[HttpGet(Name = "GetAmenityCategoriesAsync")]
        //public async Task<ActionResult<AmenityCategoryListVm>> GetAmenityCategoriesAsync([FromQuery] AmenityCategoryResourceParameters amenityCategoryResourceParameters)
        //{
        //    var query = new GetAmenityCategoriesQuery(amenityCategoryResourceParameters);
        //    return Ok(await _mediator.Send(query));
        //}

        //[HttpDelete("{amenityCategoryId}", Name = "DeleteAmenityCategoryAsync")]
        //public async Task<ActionResult<bool>> DeleteAmenityCategoryAsync(Guid amenityCategoryId)
        //{
        //    return Ok(await _mediator.Send(
        //        new DeleteAmenityCategoryCommand { AmenityCategoryId = amenityCategoryId }));
        //}
   
    }
}
