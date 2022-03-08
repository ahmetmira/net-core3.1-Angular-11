using Hospital.Application.Response;
using MediatR;
using System.Collections.Generic;

namespace Hospital.Application.Requests.PatientServices.Queries.GetAllPatients
{
    public class GetAllPatientsQuery :PaginationFilter, IRequest<Response<List<PatientResponse>>>
    {
        public string Name { get; set; }
        public int? FileNo { get; set; } = null;
        public string PhoneNumber { get; set; }
    }
}
