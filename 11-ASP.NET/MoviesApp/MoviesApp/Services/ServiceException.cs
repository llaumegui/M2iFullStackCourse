namespace MoviesApp.Services;

public class ServiceException : Exception
{
    public ServiceException(string message) : base(message)
    {
    }
}