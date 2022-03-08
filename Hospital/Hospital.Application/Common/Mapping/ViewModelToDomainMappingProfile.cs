using AutoMapper;
using Hospital.Application.Requests.PatientServices.Commands.CreatePatient;
using Hospital.Application.Requests.PatientServices.Commands.UpdatePatient;
using Hospital.Entities.Models;

namespace Hospital.Application.Common.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    { 
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreatePatientQuery, Patient>();
            CreateMap<UpdatePatientQuery, Patient>();

        }
    }
}
