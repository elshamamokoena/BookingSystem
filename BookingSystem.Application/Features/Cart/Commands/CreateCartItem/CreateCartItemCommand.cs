﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Cart.Commands.CreateCartItem
{
    public class CreateCartItemCommand:IRequest<Guid>
    {
        public Guid CartId { get; set; }
        public Guid ConsumableId { get; set; }
        public int Quantity { get; set; }
    }
}
