namespace MLS.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key) : base($"({name}) with id = ({key}) was not found.")
    {
    }
}