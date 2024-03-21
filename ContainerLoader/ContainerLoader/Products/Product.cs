namespace ContainerLoader.Products;

public class Product
{
    public string? RequiredContainerType { get; set; }
    public PossibleProducts Name { get; set; }
    public bool IsHazardous { get; set; }
    public double Weight { get; set; }

    public Product(PossibleProducts name,double weight , bool isHazardous, string? requiredContainerType)
    {
        RequiredContainerType = requiredContainerType;
        Name = name;
        IsHazardous = isHazardous;
        Weight = weight;
    }
}