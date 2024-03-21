namespace ContainerLoader.Exceptions;

public class TooManyContainersException : Exception
{
    public TooManyContainersException()
    {
        Console.Error.WriteLine("This ship is full.");
    }
    
}