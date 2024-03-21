using ContainerLoader.Exceptions;

namespace ContainerLoader;
using ContainerLoader.Containers;
using ContainerLoader.Products;


public class Ship
{
    private List<Container> transportedContainers;
    private double Speed { get; set; }
    private int MaxNoOfContainers { get; set; }
    private double MaxWeight { get; set; }

    public Ship(double speed, int maxNoOfContainers, double maxWeight)
    {
        Speed = speed;
        MaxNoOfContainers = maxNoOfContainers;
        MaxWeight = maxWeight;
        transportedContainers = new List<Container>();
    }

    public double GetWeightOfAllContainers()
    {
        double containersWeight =0;
        foreach (Container container in transportedContainers)
        {
            containersWeight += container.TareWeight + container.CargoMass;

        }

        return containersWeight;
    }

    public void LoadContainer(Container containerToLoad)
    {
        if (transportedContainers.Count >= MaxNoOfContainers)
        {
            throw new TooManyContainersException();
        }
        if (containerToLoad.CargoMass + containerToLoad.TareWeight + GetWeightOfAllContainers() > MaxWeight*1000)
            throw new ContainerTooHeavyException();
        transportedContainers.Add(containerToLoad);
        Console.WriteLine("Container " + containerToLoad.SerialNumber + " loaded to the ship successfully");
    }
    
    public void LoadListOfContainers(List<Container> containersToLoad)
    {
        foreach (var container in containersToLoad)
        {
            LoadContainer(container);
        }
    }
    
    public void UnloadContainer(string serialNumber)
    {
        foreach (var container in transportedContainers)
        {
            if (container.SerialNumber.Equals(serialNumber))
            {
                container.Unload();
                Console.WriteLine("Container " + serialNumber+" unloaded");
            }
        }
    }
    
    public void RemoveContainer(string serialNumber)
    {
        foreach (var container in transportedContainers)
        {
            if (container.SerialNumber.Equals(serialNumber))
            {
                transportedContainers.Remove(container);
                Console.WriteLine("Container " + serialNumber + " removed.");
                return;
            }
        }
        Console.WriteLine("Container " + serialNumber + " doesnt exist" );
        
        
       
    }
    
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        var index = -1;
        for (int i = 0; i < transportedContainers.Count; i++)
        {
            if (transportedContainers[i].SerialNumber.Equals(serialNumber))
            {
                index = i;
                break;
            }
        }
        
        if (index != -1)
        {
            transportedContainers[index] = newContainer;
            Console.WriteLine("Container " + serialNumber + " replaced successfully by " + newContainer.SerialNumber );
            return;
        }
        Console.WriteLine("Couldnt find an id of a container for replacement.");
        
    }
    
    public void PrintContainerInfo(string serialNumber)
    {
        foreach (var container in transportedContainers)
        {
            if (container.SerialNumber.Equals(serialNumber))
            {
                Console.WriteLine(container);
            }
        }
    }

    public void GetShipInfo()
    {
        Console.WriteLine(this);
    }

    public void PrintAllContainers()
    {
        foreach (var container in transportedContainers)
        {
            Console.WriteLine(container);
        }
    }

    public void TransferContainerToOtherShip(String serialNumber, Ship otherShip)
    { 
        foreach (var container in transportedContainers)
        {
            if (container.SerialNumber.Equals(serialNumber))
            {
                try{otherShip.LoadContainer(container);}
                catch(Exception e){return;}
                RemoveContainer(container.SerialNumber);
                return;
            }
           
        }
    }

    public override string? ToString()
    {
        string info = "Speed: " + Speed + " knots\n" +
                      "Maximum number of containers: " + MaxNoOfContainers + " \n" +
                      "Maximum weight the ship can carry: " + MaxWeight + " tonns\n" +
                      "Current weight the ship is carrying: " + GetWeightOfAllContainers() + " kg\n";
        return info;
    }
}