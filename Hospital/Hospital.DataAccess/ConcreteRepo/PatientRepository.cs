using Hospital.DataAccess.AbstractRepo;
using Hospital.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.DataAccess.ConcreteRepo
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private HospitalDbContext _context;

        public PatientRepository(HospitalDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllPatientsWithFilters(int pageSize, int pageNumber, string Name, string PhoneNumber, int? FileNo = null)
        {
            var entites = await _context.Patients.ToListAsync();
            if (entites.Any())
            {
                if (Name != null)
                {
                    entites = entites.Where(x => x.Name.ToLower().Contains(Name.ToLower())).ToList();
                }
                else if (FileNo != null)
                {
                    entites = entites.Where(x => x.FileNo == FileNo).ToList();
                }
                else if (PhoneNumber != null)
                {
                    entites = entites.Where(x => x.PhoneNumber.ToLower().Contains(PhoneNumber.ToLower())).ToList();
                }
            }
            return entites.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();

        }
        public async Task<int> GetAllPatientsCount(string Name = null, int? FileNo = null, string PhoneNumber = null)
        {
            var entites = await _context.Patients.ToListAsync();
            if (!entites.Any())
            {
                if (Name != null)
                {
                    entites = entites.Where(x => x.Name.ToLower().Contains(Name.ToLower())).ToList();
                }
                else if (FileNo != null)
                {
                    entites = entites.Where(x => x.FileNo == FileNo).ToList();
                }
                else if (PhoneNumber != null)
                {
                    entites = entites.Where(x => x.PhoneNumber.ToLower().Contains(PhoneNumber.ToLower())).ToList();
                }
            }
            return entites.Count;

        }
    }
}
