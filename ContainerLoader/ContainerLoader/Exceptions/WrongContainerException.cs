namespace ContainerLoader.Exceptions;

public class WrongContainerException : Exception
{
    public WrongContainerException()
    {
        Console.Error.Write("You are trying to load the product in the wrong container. Product won't be loaded.");
    }
}