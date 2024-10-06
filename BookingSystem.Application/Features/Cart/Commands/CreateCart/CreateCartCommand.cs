﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Cart.Commands.CreateCart
{
    public class CreateCartCommand:IRequest<Guid>
    {
        public Guid UserId { get; set; }
    }
}
