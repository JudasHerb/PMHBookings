using PMHBooking.DAL.Interfaces;
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

        //private RestoreRequestRepository _restoreRequestRepository;
        //public DbSet<RestoreRequest> RestoreRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public void Save()
        {
            SaveChanges();
        }

        //public IRestoreRequestRepository RestoreRequestRepository
        //{
        //    get { return _restoreRequestRepository ?? (_restoreRequestRepository = new RestoreRequestRepository(this)); }
        //}
    }
}