using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Queries.GetAmenityCategories
{
    public class GetAmenityCategoriesQuery:IRequest<IEnumerable<AmenityCategoryListVm>>
    {
    }
}
