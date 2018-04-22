using System;

public class AddObjectException : Exception
{
    public AddObjectException()
    {
    }

    public AddObjectException(string message) : base(message)
    {
    }

    public AddObjectException(string message, Exception innerException) : base(message, innerException)
    {
    }
}