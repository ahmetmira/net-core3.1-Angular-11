using AutoMapper;
using Hospital.Application.Response;
using Hospital.DataAccess.AbstractRepo;
using Hospital.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital.Application.Requests.PatientServices.Commands.CreatePatient
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientQuery, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePatientHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreatePatientQuery query, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Patient>(query);
            await _unitOfWork.Patient.AddAsync(entity);
            return await _unitOfWork.CommitAsync() > 0 ? new Response<Guid>().Ok(entity.Id) : new Response<Guid>().ServiceUnavailable();
        }
    }
}
