namespace Packt.Shared;
#region Example
// public class Headset //Class definition
// {
//     //Constructor
//     public Headset(string manufacturer, string productName)
//     {
//         // You can reference manufacturer and productName parameters in 
//         // the constructor and the rest of the class.
//     }
    
// }
#endregion 
#region Defining a primary constructor for a class
public class Headset(string manufacturer, string productName)
{
    public string Manufacturer { get; set; } = manufacturer;
    public string ProductName { get; set; } = productName;

    // Default parameterless consturctor calls the primary constuctor.
    public Headset() : this("Microsoft", "HoloLens") { }
}
#endregion