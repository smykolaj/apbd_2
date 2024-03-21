namespace ContainerLoader.Exceptions;

public class BadTemperatureException : Exception
{
    public BadTemperatureException()
    {
        Console.Error.Write("The temperature of the container is too low. Product won't be loaded.");
    }
}