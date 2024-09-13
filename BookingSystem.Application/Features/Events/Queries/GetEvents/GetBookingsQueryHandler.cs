using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Features.Events.Queries.GetEvent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Events.Queries.GetEvents
{
    public class GetBookingsQueryHandler : IRequestHandler<GetEventsQuery, IEnumerable<EventVm>>
    {
        private readonly IEventRepository _bookingRepository;
        private readonly IMapper _mapper;
        public GetBookingsQueryHandler(IEventRepository bookingRepository,
            IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EventVm>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var bookings = await _bookingRepository.GetEventsAsync(request);
            return _mapper.Map<IEnumerable<EventVm>>(bookings);
        }
    }
}
