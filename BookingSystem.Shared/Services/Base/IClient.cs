using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Services
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
