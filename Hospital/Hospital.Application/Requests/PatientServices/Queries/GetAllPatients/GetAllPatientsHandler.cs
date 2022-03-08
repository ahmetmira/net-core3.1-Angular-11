using AutoMapper;
using Hospital.Application.Response;
using Hospital.DataAccess.AbstractRepo;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital.Application.Requests.PatientServices.Queries.GetAllPatients
{
    public class GetAllPatientsHandler : IRequestHandler<GetAllPatientsQuery, Response<List<PatientResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPatientsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<PatientResponse>>> Handle(GetAllPatientsQuery query, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Patient.GetAllPatientsWithFilters(query.PageSize, query.PageNumber, query.Name, query.PhoneNumber, query.FileNo);
            if (!entities.Any())
                return new Response<List<PatientResponse>>().NoContent();
            var count = await _unitOfWork.Patient.GetAllPatientsCount(query.Name, query.FileNo, query.PhoneNumber);

            var response = _mapper.Map<List<PatientResponse>>(entities);
            return new PagedResponse<List<PatientResponse>>().Ok(response, count, query.PageNumber, query.PageSize);

        }
    }
}
