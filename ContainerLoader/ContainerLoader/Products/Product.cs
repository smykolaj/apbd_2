namespace ContainerLoader.Products;

public class Product
{
    public string? RequiredContainerType { get; set; }
    public PossibleProducts Name { get; set; }
    public bool IsHazardous { get; set; }
    public double Weight { get; set; }
}