﻿using PMHBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMHBooking.DAL.Interfaces
{
    public interface IBookingRepository: IRepository<Booking>
    {
    }
}