namespace MLS.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key) : base($"({name}) with property whose value ({key}) was not found.")
    {
    }
}