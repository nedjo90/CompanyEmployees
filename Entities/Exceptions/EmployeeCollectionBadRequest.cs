namespace Entities.Exceptions;

public class EmployeeCollectionBadRequest : BadRequestException
{
    public EmployeeCollectionBadRequest() : base("Employ collection sent from a client is null.")
    {
    }
}