using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRooms
{
    public class GetConferenceRoomsQueryHandler : IRequestHandler<GetConferenceRoomsQuery, IEnumerable<ConferenceRoomVm>>
    {
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IMapper _mapper;
        public GetConferenceRoomsQueryHandler(IConferenceRoomRepository conferenceRoomRepository,
            IMapper mapper)
        {
            _conferenceRoomRepository = conferenceRoomRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConferenceRoomVm>> Handle(GetConferenceRoomsQuery request, CancellationToken cancellationToken)
        {
                // You should be able to get resources without any parameters provided
                var conferenceRooms = await _conferenceRoomRepository.GetConferenceRoomsAsync(request);
                return _mapper.Map<IEnumerable<ConferenceRoomVm>>(conferenceRooms);
   
        }
    }

}
