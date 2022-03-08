using AutoMapper;
using Hospital.Application.Response;
using Hospital.DataAccess.AbstractRepo;
using Hospital.Entities.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital.Application.Requests.PatientServices.Commands.UpdatePatient
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientQuery, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePatientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(UpdatePatientQuery query, CancellationToken cancellationToken)
        {
            if (query == null || query.Id == Guid.Empty)
                return new Response<bool>().NotFound();

            var pa = _mapper.Map<Patient>(query);
            _unitOfWork.Patient.Update(pa);
            return await _unitOfWork.CommitAsync() > 0 ? new Response<bool>().Ok(true) : new Response<bool>().ServiceUnavailable();
        }
    }
}