using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObjects;

namespace CompanyEmployees;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAddress,
                opt => 
                    opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
        
        // CreateMap<Company, CompanyDto>()
        //     .ForCtorParam("FullAddress",
        //         opt => 
        //             opt.MapFrom(src => string.Join(' ', src.Address, src.Country))
        //     );
        
        CreateMap<Employee, EmployeeDto>();

        CreateMap<CompanyForCreationDto, Company>();

        CreateMap<EmployeeForCreationDto, Employee>();

        CreateMap<EmployeeForUpdateDto, Employee>();

        CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
        
    }
}