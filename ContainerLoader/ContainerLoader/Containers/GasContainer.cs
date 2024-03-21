namespace ContainerLoader.Containers;
using ContainerLoader.Exceptions;
using ContainerLoader.Interfaces;
using ContainerLoader.Products;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get;set; } 

   
    public GasContainer(int height, int tareWeight, int depth, string serialNumber, int maximumPayload, double pressure)
        : base(height, tareWeight, depth, serialNumber, maximumPayload)
    {
        Pressure = pressure;
    }

   
    public override void Load(Product addedProduct)
    {
        if (!addedProduct.RequiredContainerType.Equals("G"))
        {
            throw new WrongContainerException();
        }
        if (addedProduct.Weight > MaxPayload - CargoMass)
        {
            NotifyHazard("The gas is too heavy. It will not be added");
            throw new OverfillException();
        }

        CargoMass += addedProduct.Weight;
    }

    
    public override void Unload()
    {
        CargoMass = (CargoMass * 0.05);
    }
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine("Hazardous situation for the gas container with id:" + SerialNumber + "\n" + message);
    }
}