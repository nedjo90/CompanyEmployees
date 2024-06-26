namespace Shared.DataTransfertObjects;

public record CompanyDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? FullAddress { get; init; }
}

//A record type is immutable and has a default constructor
//This means, record's instance property cannot be changed
//the purpose of DTO is to transfer data between layers of the application
//without changing the data itself
//we use them to return data from a web api or to represent events in the application