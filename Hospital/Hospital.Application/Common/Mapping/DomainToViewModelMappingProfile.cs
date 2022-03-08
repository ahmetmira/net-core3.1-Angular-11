using AutoMapper;
using Hospital.Application.Response;
using Hospital.Entities.Models;

namespace Hospital.Application.Common.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Patient, PatientResponse>();

        }
    }
}
