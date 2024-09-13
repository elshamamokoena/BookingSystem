using BookingSystem.Application.Features.Events.Queries.GetEvent;
using BookingSystem.Application.Responses;

namespace BookingSystem.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandResponse : BaseResponse
    {
        public UpdateEventCommandResponse() : base()
        {
            Message = "Event updated successfully!";
        }
        public EventVm? Event { get; set; }
    }
}