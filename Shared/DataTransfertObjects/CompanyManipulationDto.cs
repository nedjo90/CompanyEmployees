using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransfertObjects;

public abstract record CompanyManipulationDto
{
    [Required(ErrorMessage = "Company name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters")]
    public string? Name { get; init; }
    
    [Required(ErrorMessage = "Company address is a required field.")]
    [MaxLength(120, ErrorMessage = "Maximum length for the Address is 120 characters")]
    public string? Address { get; init; }
    
    [Required(ErrorMessage = "Company country is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Country is 60 characters")]
    public string? Country { get; init; }
    
    public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
}