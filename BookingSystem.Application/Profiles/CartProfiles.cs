using AutoMapper;
using BookingSystem.Application.Features.Cart.Commands.CreateCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Profiles
{
    public class CartProfiles:Profile
    {
        public CartProfiles()
        {
            CreateMap<CreateCartCommand, Domain.Entities.InternalCart.Cart>();
        }
    }
}
