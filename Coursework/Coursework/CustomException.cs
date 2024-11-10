namespace Coursework;

public class CustomException : Exception
{
    public CustomException() { }

    public CustomException(string message) { }

    public CustomException(string message, Exception inner) { }
}