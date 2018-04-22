using System;

internal class TakeObjectException : Exception
{
    public TakeObjectException()
    {
    }

    public TakeObjectException(string message) : base(message)
    {
    }

    public TakeObjectException(string message, Exception innerException) : base(message, innerException)
    {
    }
}