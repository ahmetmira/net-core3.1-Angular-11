using Hospital.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccess.AbstractRepo
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<List<Patient>> GetAllPatientsWithFilters(int pageSize, int pageNumber, string Name, string PhoneNumberl,int? FileNo=null);
        Task<int> GetAllPatientsCount(string Name = null, int? FileNo = null, string PhoneNumber = null);

    }
}
