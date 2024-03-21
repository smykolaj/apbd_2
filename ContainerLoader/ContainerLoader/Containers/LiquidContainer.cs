using ContainerLoader.Exceptions;
using ContainerLoader.Interfaces;
using ContainerLoader.Products;

namespace ContainerLoader.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(int height, int tareWeight, int depth, string serialNumber, int maxPayload)
        : base(height, tareWeight, depth, serialNumber, maxPayload)
    {
    }

    public override void Load(Product addedProduct)
    {
        if (!addedProduct.RequiredContainerType!.Equals("L"))
        {
            throw new WrongContainerException();
        }
        double allowedWeightToBeAdded;
        if (addedProduct.IsHazardous)
        {
            allowedWeightToBeAdded = MaxPayload * 0.5;
        }
        else
        {
            allowedWeightToBeAdded = MaxPayload * 0.9;
        }

        if (addedProduct.Weight > allowedWeightToBeAdded)
        {
            NotifyHazard("The liquid you are trying to load may exceed safe norm.");
        }

        if (addedProduct.Weight > MaxPayload - CargoMass)
        {
            NotifyHazard("The liquid is too heavy. It will not be added");
            throw new OverfillException();
        }

        CargoMass += addedProduct.Weight;
    }

    public override void Unload()
    {
        CargoMass = 0;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine("Hazardous situation for the liquid container with id:" + SerialNumber + "\n" + message);
    }
}