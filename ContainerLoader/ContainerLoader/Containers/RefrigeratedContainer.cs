using ContainerLoader.Exceptions;
using ContainerLoader.Interfaces;
using ContainerLoader.Products;


namespace ContainerLoader.Containers;

public class RefrigeratedContainer : Container
{
    public PossibleProducts ProductType { get; private set; }
    public double Temperature { get; private set; }

    public RefrigeratedContainer(int height, int tareWeight, int depth, string serialNumber, int maximumPayload,
        string productType, double temperature)
        : base(height, tareWeight, depth, serialNumber, maximumPayload)
    {
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
        {
            throw new 
        }

        if (ProductType != addedProduct.Name)
            throw new ProductNameMismatchException();

       
        
        

    }


    public override void Unload()
    {
        CargoMass = 0;
    }

    // Set or update the temperature of the refrigerated container
    // You can add logic here to ensure the temperature is not lower than required for the product type
    public void SetTemperature(int newTemperature)
    {
        Temperature = newTemperature;
    }

    public static readonly Dictionary<PossibleProducts, double> TemperatureMapping =
        new Dictionary<PossibleProducts, double>
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