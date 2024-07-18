using AutoMapper;
using Sistema_de_Gestion_de_Hospitales.API.Models;
using Sistema_de_Gestion_de_Hospitales.Shared.Doctor;
using Sistema_de_Gestion_de_Hospitales.Shared.Enfermera;
using Sistema_de_Gestion_de_Hospitales.Shared.Paciente;

namespace Sistema_de_Gestion_de_Hospitales.API.Mapping
{
    public class PersonasProfile : Profile
    {
        public PersonasProfile()
        {
            CreateMap<DoctorGetDTO, Doctor>()
                .ForPath(dest => dest.IdDepartamentoNavigation.Nombre, opt => opt.MapFrom(src => src.NombreDepartamento))
                .ForPath(dest => dest.IdEspecialidadNavigation.Nombre, opt => opt.MapFrom(src => src.NombreEspecialidad))
                .ReverseMap();
            CreateMap<DoctorInsertDTO, Doctor>().ReverseMap();
            CreateMap<DoctorUpdateDTO, Doctor>().ReverseMap();

            CreateMap<EnfermeraGetDTO, Enfermera>()
                .ForPath(dest => dest.IdDepartamentoNavigation.Nombre, opt => opt.MapFrom(src => src.NombreDepartamento))
                .ReverseMap();
            CreateMap<EnfermeraInsertDTO, Enfermera>().ReverseMap();
            CreateMap<EnfermeraUpdateDTO, Enfermera>().ReverseMap();

            CreateMap<PacienteGetDTO, Paciente>().ReverseMap();
            CreateMap<PacienteInsertDTO, Paciente>().ReverseMap();
            CreateMap<PacienteUpdateDTO, Paciente>().ReverseMap();


        }
    }
}
