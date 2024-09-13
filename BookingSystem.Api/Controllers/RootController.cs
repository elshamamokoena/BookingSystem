using BookingSystem.Domain.Entities.Events;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{

    [ApiController]
    [Route("api")]
    public class RootController : ControllerBase
    {


        [HttpGet(Name = "GetRoot")]
        public ActionResult<EventStatus> GetRoot()
        {

            return Ok(new EventStatus());
        }
  
    }
}
