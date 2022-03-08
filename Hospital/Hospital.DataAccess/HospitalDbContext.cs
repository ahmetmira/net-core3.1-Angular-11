using Hospital.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital.DataAccess
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=MIRA;Database=HospitalDb;uid=ahmet;pwd=1234;");
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void AddAuditInfo()
        {
            var entities = ChangeTracker.Entries<BaseEntities>().Where(w => w.State == EntityState.Added || w.State == EntityState.Modified);
            var utcNow = DateTime.UtcNow;
            var list = entities.ToList();

            foreach (var entity in list)
            {
                if (entity.State == EntityState.Added)
                    entity.Entity.CreatedDate = utcNow;
                else if (entity.State == EntityState.Modified)
                    entity.Entity.UpdatedDate = utcNow;
            }
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
