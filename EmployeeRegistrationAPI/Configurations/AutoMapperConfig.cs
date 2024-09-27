using AutoMapper;
using EmployeeRegistrationAPI.Models;

namespace EmployeeRegistrationAPI.Configurations
{
    public class AutoMapperConfig:Profile
    {
      

        public AutoMapperConfig()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            CreateMap<Department, DepartmentDTO>().ReverseMap();

            CreateMap<Gender, GenderDTO>().ReverseMap();

            CreateMap<Salutation, SalutationDTO>().ReverseMap();
        }
    }
}
