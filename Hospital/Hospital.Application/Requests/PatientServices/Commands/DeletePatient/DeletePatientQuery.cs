using Hospital.Application.Response;
using Hospital.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Application.Requests.PatientServices.Commands.DeletePatient
{
    public class DeletePatientQuery : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public DeletePatientQuery(Guid id)
        {
            Id = id;
        }
    }
}
