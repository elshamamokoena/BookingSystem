using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.ConferenceRooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.RoomBookingEvents.Queries.GetRoomBookingEvents
{
    public class GetConferenceRoomChangeEventsQueryHandler : IRequestHandler<GetConferenceRoomChangeEventsQuery, ConferenceRoomChangeEventListVm>
    {
        private readonly IConferenceRoomChangeEventRepository _conferenceRoomChangeEventRepository;
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IMapper _mapper;
        public GetConferenceRoomChangeEventsQueryHandler(IConferenceRoomChangeEventRepository roomBookingEventRepository,
            IConferenceRoomRepository conferenceRoomRepository,
            IMapper mapper)
        {
            _conferenceRoomChangeEventRepository = roomBookingEventRepository;
            _conferenceRoomRepository = conferenceRoomRepository;
            _mapper = mapper;
        }

        public async Task<ConferenceRoomChangeEventListVm> Handle(GetConferenceRoomChangeEventsQuery request, CancellationToken cancellationToken)
        {
            if(request.ConferenceRoomId.HasValue && !await _conferenceRoomRepository.EntityExistsAsync(request.ConferenceRoomId.Value))
                throw new NotFoundException(nameof(ConferenceRoom), request.ConferenceRoomId.Value);

            var roomBookingEvents = await _conferenceRoomChangeEventRepository
                .GetConferenceRoomChangeEventsAsync(request);

            return new ConferenceRoomChangeEventListVm 
            {
                Count = roomBookingEvents.Count,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                ConferenceRoomChangeEvents = _mapper.Map<List<ConferenceRoomChangeEventListDto>>(roomBookingEvents)
            };
        }
    }
}
