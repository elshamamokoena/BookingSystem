using BookingSystem.Application.Responses;

namespace BookingSystem.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandResponse : BaseResponse
    {
        public CreateEventCommandResponse() : base()
        {
            Message = "Event created successfully!";
        }
        public EventDto? Event { get; set; }
    }
}