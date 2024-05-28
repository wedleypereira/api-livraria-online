namespace LivrariaOnline.Exceptions;

public class ErrorOnValidationException : LivrariaException
{
    public ErrorOnValidationException(string message) : base(message)
    {
    }
}
