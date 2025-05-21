namespace VotumServer.Exceptions;

public class IncorrectCredentialException : Exception
{
    public IncorrectCredentialException() : base("Incorrect credentials") { }

    public IncorrectCredentialException(string message) : base(message) { }

    public IncorrectCredentialException(string message, Exception inner) : base(message, inner) { }
}