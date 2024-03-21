using ContainerLoader.Exceptions;
using ContainerLoader.Interfaces;
using ContainerLoader.Products;

namespace ContainerLoader.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(double height, double tareWeight, double depth,  double maxPayload)
        : base(height, tareWeight, depth,  maxPayload)
    {
        SerialNumber = "KON-L-" + IdSetter;
        IdSetter++;
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
    
    public override string? ToString()
    {
        string info = "Serial number: " + SerialNumber + "\n" +
                      "Height: " + Height + " cm\n" +
                      "Tare Weight: " + TareWeight + " kg\n" +
                      "Depth: " + Depth + " cm\n" +
                      "Maximum Payload: " + MaxPayload + " kg\n" +
                      "Cargo Mass: " + CargoMass + " kg\n";
        return info;
    }
}