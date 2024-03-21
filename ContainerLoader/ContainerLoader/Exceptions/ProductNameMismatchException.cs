namespace ContainerLoader.Exceptions;

public class ProductNameMismatchException : Exception
{
    public ProductNameMismatchException()
    {
        Console.Error.Write("You are trying to load the product in the container with \n" +
                            " another product already present ");
    }
}