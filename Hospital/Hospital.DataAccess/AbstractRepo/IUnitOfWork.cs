using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccess.AbstractRepo
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patient { get; }
        Task<int> CommitAsync();
    }
}
