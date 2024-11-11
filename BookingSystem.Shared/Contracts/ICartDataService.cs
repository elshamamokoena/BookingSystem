using BookingSystem.Shared.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Contracts
{
    public interface ICartDataService
    {
        Task<ApiResponse<Guid>> CreateCart(string userId);
    }
}
