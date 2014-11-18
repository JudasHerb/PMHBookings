using PMHBooking.DAL.Interfaces;
using PMHBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMHBooking.DAL
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(UnitOfWork entities)
            : base(entities)
        {
        }

    }
}