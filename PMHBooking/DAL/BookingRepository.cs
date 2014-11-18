using PMHBooking.DAL.Interfaces;
using PMHBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMHBooking.DAL
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(UnitOfWork entities)
            : base(entities)
        {
        }

    }
}