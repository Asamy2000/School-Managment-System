using AutoMapper;
using SchoolManagment.Models;

namespace SchoolManagment.MappingProfile
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<Instructor, _InstructorVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Imag, opt => opt.MapFrom(src => src.Imag))
                .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.dept_Id, opt => opt.MapFrom(src => src.dept_Id))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.crs_id, opt => opt.MapFrom(src => src.crs_id))
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course));

            CreateMap<_InstructorVM, Instructor>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Imag, opt => opt.MapFrom(src => src.Imag))
                .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.dept_Id, opt => opt.MapFrom(src => src.dept_Id))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.crs_id, opt => opt.MapFrom(src => src.crs_id))
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course));
        }

    }
}