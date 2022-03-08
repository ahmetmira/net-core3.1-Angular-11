using Hospital.DataAccess.AbstractRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccess.ConcreteRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private HospitalDbContext context;
        private DbSet<T> db;

        public GenericRepository(HospitalDbContext context)
        {
            this.context = context;
            db = context.Set<T>();
        }

        public async Task<T> AddAsync(T t)
        {
            await db.AddAsync(t);
            return t;
        }

        public async Task<T> FindByIdAsync(Guid id)
        {
            return await db.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.ToListAsync();
        }

        public void Remove(Guid id)
        {
            var delete = db.Find(id);
            db.Remove(delete);
        }

        public T Update(T t)
        
        {

            //db.Attach(t);
            //var entry = context.Entry(t);
            //entry.State = EntityState.Modified;
            context.Set<T>().Update(t);
            return t;
        }
    }
}
