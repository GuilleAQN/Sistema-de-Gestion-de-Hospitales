using AutoMapper;
using API.Models;
using Shared.Doctor;
using Shared.Enfermera;
using Shared.Paciente;

namespace API.Mapping
{
    public class PersonasProfile : Profile
    {
        public PersonasProfile()
        {
            CreateMap<DoctorGetDTO, Doctor>().ReverseMap();
            CreateMap<DoctorInsertDTO, Doctor>().ReverseMap();
            CreateMap<DoctorUpdateDTO, Doctor>().ReverseMap();

            CreateMap<EnfermeraGetDTO, Enfermera>().ReverseMap();
            CreateMap<EnfermeraInsertDTO, Enfermera>().ReverseMap();
            CreateMap<EnfermeraUpdateDTO, Enfermera>().ReverseMap();

            CreateMap<PacienteGetDTO, Paciente>().ReverseMap();
            CreateMap<PacienteInsertDTO, Paciente>().ReverseMap();
            CreateMap<PacienteUpdateDTO, Paciente>().ReverseMap();


        }
    }
}
