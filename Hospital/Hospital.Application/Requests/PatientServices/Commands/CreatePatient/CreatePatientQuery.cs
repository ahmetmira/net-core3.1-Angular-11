using Hospital.Application.Response;
using MediatR;
using System;

namespace Hospital.Application.Requests.PatientServices.Commands.CreatePatient
{
    public class CreatePatientQuery : IRequest<Response<Guid>>
    {
        public string Name { get; set; }
        public int FileNo { get; set; }
        public string CitizenId { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public string Natinality { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ContactPerson { get; set; }
        public string ContactRelation { get; set; }
        public string ContactPhone { get; set; }
        public DateTime FirstVisitDate { get; set; }
    }
}
