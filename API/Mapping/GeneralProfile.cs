using AutoMapper;
using Sistema_de_Gestion_de_Hospitales.API.Models;
using Sistema_de_Gestion_de_Hospitales.Shared.CategoriasCita;
using Sistema_de_Gestion_de_Hospitales.Shared.Cita;
using Sistema_de_Gestion_de_Hospitales.Shared.Departamento;
using Sistema_de_Gestion_de_Hospitales.Shared.Diagnostico;
using Sistema_de_Gestion_de_Hospitales.Shared.Especialidad;
using Sistema_de_Gestion_de_Hospitales.Shared.Estado;
using Sistema_de_Gestion_de_Hospitales.Shared.Habitacion;
using Sistema_de_Gestion_de_Hospitales.Shared.Tratamiento;

namespace Sistema_de_Gestion_de_Hospitales.API.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CategoriaCitaGetDTO, CategoriasCita>().ReverseMap();
            CreateMap<CategoriaCitaInsertDTO, CategoriasCita>().ReverseMap();
            CreateMap<CategoriaCitaUpdateDTO, CategoriasCita>().ReverseMap();

            CreateMap<CitaGetDTO, Cita>()
                .ForPath(dest => dest.IdPacienteNavigation.NombreCompleto, opt => opt.MapFrom(src => src.NombrePaciente))
                .ForPath(dest => dest.IdDoctorNavigation.NombreCompleto, opt => opt.MapFrom(src => src.NombreDoctor))
                .ForPath(dest => dest.IdEnfermeraNavigation.NombreCompleto, opt => opt.MapFrom(src => src.NombreEnfermera))
                .ForPath(dest => dest.IdCategoriaCitaNavigation.Nombre, opt => opt.MapFrom(src => src.CategoriaCitaNombre))
                .ReverseMap();
            CreateMap<CitaInsertDTO, Cita>().ReverseMap();
            CreateMap<CitaUpdateDTO, Cita>().ReverseMap();

            CreateMap<DepartamentoGetDTO, Departamento>().ReverseMap();
            CreateMap<DepartamentoInsertDTO, Departamento>().ReverseMap();
            CreateMap<DepartamentoUpdateDTO, Departamento>().ReverseMap();

            CreateMap<DiagnosticoGetDTO, Diagnostico>()
                .ForPath(dest => dest.IdPacienteNavigation.NombreCompleto, opt => opt.MapFrom(src => src.NombrePaciente))
                .ForPath(dest => dest.IdDoctorNavigation.NombreCompleto, opt => opt.MapFrom(src => src.NombreDoctor))
                .ReverseMap();
            CreateMap<DiagnosticoInsertDTO, Diagnostico>().ReverseMap();
            CreateMap<DiagnosticoUpdateDTO, Diagnostico>().ReverseMap();

            CreateMap<EspecialidadGetDTO, Especialidad>().ReverseMap();
            CreateMap<EspecialidadInsertDTO, Especialidad>().ReverseMap();
            CreateMap<EspecialidadUpdateDTO, Especialidad>().ReverseMap();

            CreateMap<EstadoGetDTO, Estado>().ReverseMap();
            CreateMap<EstadoInsertDTO, Estado>().ReverseMap();
            CreateMap<EstadoUpdateDTO, Estado>().ReverseMap();

            CreateMap<HabitacionGetDTO, Habitacion>()
                .ForPath(dest => dest.IdEstadoNavigation.Nombre, opt => opt.MapFrom(src => src.NombreEstado))
                .ReverseMap();
            CreateMap<HabitacionInsertDTO, Habitacion>().ReverseMap();
            CreateMap<HabitacionUpdateDTO, Habitacion>().ReverseMap();

            CreateMap<TratamientoGetDTO, Tratamiento>()
                .ForPath(dest => dest.IdDoctorNavigation.NombreCompleto, opt => opt.MapFrom(src => src.NombreDoctor))
                .ForPath(dest => dest.IdDiagnosticoNavigation.Descripcion, opt => opt.MapFrom(src => src.DescripcionDiagnostico))
                .ReverseMap();
            CreateMap<TratamientoInsertDTO, Tratamiento>().ReverseMap();
            CreateMap<TratamientoUpdateDTO, Tratamiento>().ReverseMap();
        }
    }
}
