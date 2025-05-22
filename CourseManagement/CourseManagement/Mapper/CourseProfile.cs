using AutoMapper;
using CourseManagement.DTO;
using CourseManagement.Entity;

namespace CourseManagement.Mapper
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseResponse>();
            CreateMap<CourseRequest, Course>();
            CreateMap<Course, Course>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // For updates
        }
    }

}
