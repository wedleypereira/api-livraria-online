namespace LivrariaOnline.Exceptions;

public class NotFoundException : LivrariaException
{
    public NotFoundException(string message) : base(message)
    {
    }
}
