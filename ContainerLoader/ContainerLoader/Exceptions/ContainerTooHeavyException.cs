namespace ContainerLoader.Exceptions;

public class ContainerTooHeavyException : Exception
{
    public ContainerTooHeavyException()
    {
        Console.Error.WriteLine("Container cannot be loaded onto the ship. It is too heavy");
    }
    
}