using Hospital.Application.Response;
using Hospital.DataAccess.AbstractRepo;
using Hospital.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital.Application.Requests.PatientServices.Commands.DeletePatient
{
    public class DeletePatientHandler : IRequestHandler<DeletePatientQuery, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Handle(DeletePatientQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Patient.FindByIdAsync(query.Id);
            if (entity == null)
            {
                return new Response<bool>().NotFound();
            }
            _unitOfWork.Patient.Remove(entity.Id);
            return await _unitOfWork.CommitAsync() > 0 ? new Response<bool>().Ok(true) : new Response<bool>().ServiceUnavailable();

        }
    }
}
