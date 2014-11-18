using PMHBooking.DAL.Interfaces;
using PMHBooking.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PMHBooking.DAL
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        public UnitOfWork()
            : base("DefaultConnection")
        {
        }

        private BookingRepository _bookingRepository;
        public DbSet<Booking> Bookings { get; set; }

        private InvoiceRepository _invoiceRepository;
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public void Save()
        {
            SaveChanges();
        }

        public IBookingRepository BookingRepository
        {
            get { return _bookingRepository ?? (_bookingRepository = new BookingRepository(this)); }
        }
        public IInvoiceRepository InvoiceRepository
        {
            get { return _invoiceRepository ?? (_invoiceRepository = new InvoiceRepository(this)); }
        }
    }
}