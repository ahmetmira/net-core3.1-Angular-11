using Hospital.DataAccess.AbstractRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccess.ConcreteRepo
{
    public class UnitOfWork : IUnitOfWork
    {
        private HospitalDbContext context;
        private PatientRepository patientRepository;

        public UnitOfWork(HospitalDbContext context)
        {
            this.context = context;
        }

        public IPatientRepository Patient=> patientRepository = patientRepository ?? new PatientRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
