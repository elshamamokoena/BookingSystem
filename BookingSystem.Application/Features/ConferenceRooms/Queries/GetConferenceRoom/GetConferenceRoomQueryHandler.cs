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

namespace BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom
{
    public class GetConferenceRoomQueryHandler : IRequestHandler<GetConferenceRoomQuery, ConferenceRoomVm>
    {
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IMapper _mapper;
        public GetConferenceRoomQueryHandler(IConferenceRoomRepository conferenceRoomRepository,
            IMapper mapper)
        {
            _conferenceRoomRepository = conferenceRoomRepository;
            _mapper = mapper;
        }
        public async Task<ConferenceRoomVm> Handle(GetConferenceRoomQuery request, CancellationToken cancellationToken)
        {

                if(!await _conferenceRoomRepository.EntityExistsAsync(request.ConferenceRoomId))
                    throw new NotFoundException(nameof(ConferenceRoom), request.ConferenceRoomId);

                var conferenceRoom = await _conferenceRoomRepository.GetEntityAsync(request.ConferenceRoomId);
                
                return  _mapper.Map<ConferenceRoomVm>(conferenceRoom);
        }
    }
}
