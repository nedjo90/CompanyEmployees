using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransfertObjects;

public abstract record EmployeeForManipulationDto
{
    [Required(ErrorMessage = "Employee Name is required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? Name { get; init; }
    
    [Required(ErrorMessage = "Age is required field")]
    [Range(0, 120, ErrorMessage = "Age is must be greater or equal to 0")]
    public int? Age { get; init; }
    
    [Required(ErrorMessage = "Position is required field")]
    [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters")]
    public string? Position { get; init; }
}