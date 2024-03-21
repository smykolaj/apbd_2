using ContainerLoader;
using ContainerLoader.Containers;
using ContainerLoader.Products;


var myShip = new Ship(20, 10, 200);


var gasContainer = new GasContainer(250, 2, 100, 5000, 1.2);
var liquidContainer = new LiquidContainer(300, 2.5, 150, 8000);
var refrigeratedContainer = new RefrigeratedContainer(200, 2, 150, 6000, 5);

var oxygenProduct =
    new Product(PossibleProducts.Oxygen, 1000, true, "G"); 

var bananaProduct =
    new Product(PossibleProducts.Bananas, 4000, false, "C"); 
var petrolProduct =
    new Product(PossibleProducts.Petrol, 7000, true, "L"); 
// Load products to containers
try
{
    gasContainer.Load(bananaProduct);
}
catch (Exception e)
{
}

gasContainer.Load(oxygenProduct);
try
{
    refrigeratedContainer.Load(bananaProduct);
}
catch (Exception e)
{
    
}
liquidContainer.Load(petrolProduct);



// Load containers onto the ship
try
{
    List<Container> listOfContainers = new List<Container>() { gasContainer, liquidContainer, refrigeratedContainer };
    myShip.LoadListOfContainers(listOfContainers);
    // myShip.LoadContainer(gasContainer);
    // myShip.LoadContainer(liquidContainer);
    // myShip.LoadContainer(refrigeratedContainer);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
// Unload a container
myShip.PrintContainerInfo(gasContainer.SerialNumber);
myShip.UnloadContainer(gasContainer.SerialNumber);
myShip.PrintContainerInfo(gasContainer.SerialNumber);


// Remove a container from the ship
myShip.RemoveContainer(gasContainer.SerialNumber);


// Replace a container on the ship with another container
var newGasContainer = new GasContainer(250, 2, 100, 5000, 1.2);
myShip.ReplaceContainer(refrigeratedContainer.SerialNumber, newGasContainer);

// Print information about a given container
myShip.PrintContainerInfo(newGasContainer.SerialNumber);
Console.WriteLine();

Ship myShip2 = new Ship(20, 2, 200);
myShip.PrintAllContainers();
Console.WriteLine();

// Replace a container on the ship with a given number with another container
myShip.TransferContainerToOtherShip("KON-G-4", myShip2);
myShip.PrintAllContainers();

// Print information about the ship and its cargo
myShip.GetShipInfo();