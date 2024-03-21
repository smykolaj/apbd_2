using ContainerLoader.Exceptions;
using ContainerLoader.Interfaces;
using ContainerLoader.Products;


namespace ContainerLoader.Containers;

public class RefrigeratedContainer : Container
{
    public PossibleProducts ProductType { get;  set; }
    public double Temperature { get;  set; }

    public RefrigeratedContainer(double height, double tareWeight, double depth, double maximumPayload, double temperature)
        : base(height, tareWeight, depth,  maximumPayload)
    {
        SerialNumber = "KON-C-" + IdSetter;
        IdSetter++;
        Temperature = temperature;
    }


    public override void Load(Product addedProduct)
    {
        if (!addedProduct.RequiredContainerType!.Equals("C"))
            throw new WrongContainerException();
            
        if (addedProduct.Weight > MaxPayload - CargoMass)
            throw new OverfillException(
                "The product you are trying to add exceeds the max payload for container +" +
                SerialNumber);
        
        if (CargoMass == 0)
            ProductType = addedProduct.Name;
        
        if (Temperature < TemperatureMapping[addedProduct.Name] )
            throw new BadTemperatureException();
        
        if (ProductType != addedProduct.Name)
            throw new ProductNameMismatchException();

        CargoMass += addedProduct.Weight;

    }


    public override void Unload()
    {
        CargoMass = 0;
    }

    public override string? ToString()
    {
        string info = "Serial number: " + SerialNumber + "\n" +
                      "Height: " + Height + " cm\n" +
                      "Tare Weight: " + TareWeight + " kg\n" +
                      "Depth: " + Depth + " cm\n" +
                      "Maximum Payload: " + MaxPayload + " kg\n" +
                      "Cargo Mass: " + CargoMass + " kg\n" +
                      "Temperature: " + Temperature + " Cº\n" +
                      "Stored product: " + ProductType;
    return info;
    }

    

    public static readonly Dictionary<PossibleProducts, double> TemperatureMapping =
        new()
        {
            { PossibleProducts.Bananas, 13.3 },
            { PossibleProducts.Chocolate, 18 },
            { PossibleProducts.Fish, 2 },
            { PossibleProducts.Meat, -15 },
            { PossibleProducts.IceCream, -18 },
            { PossibleProducts.FrozenPizza, -30 },
            { PossibleProducts.Cheese, 7.2 },
            { PossibleProducts.Sausages, 5 },
            { PossibleProducts.Butter, 20.5 },
            { PossibleProducts.Eggs, 19 }
        };
}