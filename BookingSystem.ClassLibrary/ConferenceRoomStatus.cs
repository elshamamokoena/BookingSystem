﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.ClassLibrary
{
    public enum ConferenceRoomStatus
    {
        OccupiedAndBooked,
        OccupiedAndNotBooked,
        BookedAndNotOccupied,
        VacantAndNotBooked
    }
}