namespace ContainerLoader.Containers;

using ContainerLoader.Exceptions;
using ContainerLoader.Interfaces;
using ContainerLoader.Products;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }


    public GasContainer(double height, double tareWeight, double depth, double maximumPayload, double pressure)
        : base(height, tareWeight, depth, maximumPayload)
    {
        SerialNumber = "KON-G-" + IdSetter;
        IdSetter++;
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
        //Console.WriteLine(CargoMass);
    }


    public override void Unload()
    {
        CargoMass = (CargoMass * 0.05);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine("Hazardous situation for the gas container with id:" + SerialNumber + "\n" + message);
    }

    public override string? ToString()
    {
        string info = "________________________________________________\n"
                      + "Serial number: " + SerialNumber + "\n" +
                      "Height: " + Height + " cm\n" +
                      "Tare Weight: " + TareWeight + " kg\n" +
                      "Depth: " + Depth + " cm\n" +
                      "Maximum Payload: " + MaxPayload + " kg\n" +
                      "Cargo Mass: " + CargoMass + " kg\n" +
                      "Pressure: " + Pressure + " atmospheres\n" + 
                      "________________________________________________";
        return info;
    }
}