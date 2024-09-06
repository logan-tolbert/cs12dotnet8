// All types in this file will be defined in this file scoped namespace.
namespace Packt.Shared;
#region Notes

/* Pillars of OOP
* Abstraction
* Polymorphism
* Inheritance
* Encapsulation


/* 
* cLass(type): blueprint or template for an object 
* fields: contain data, 'variables that belong to a type'
*       Constant: data that never changes
*       readonly: data cannot change after the class is instantiated, but can be accesed at the time of instantiation
*       event: data references on or more methods that execute based on a certain condition
* methods: excute one or more statements within its code block when called      
* object: an instance of a class
*/

//  ** if an access modifier is not explicitly set the class will only be accessible within the assembly that created it

/* Access Modifiers
 * internal: class is only accesible within the assembly that created it
 * public: allows for any other code to access a class from anywhere
 * private: allows for access only within it's parent class
 * file: allows access only within the code file
*/

#endregion

public partial class Person : object
{
    #region Fields: Data or state for this person.

    public string? Name; // ? means it can be null.
    public DateTimeOffset Born;

    //This has been moved to PersonAutoGen.cs 
    //public WondersOfTheAncientWorld FavoriteAncientWonder;
    
    public WondersOfTheAncientWorld BucketList;


    public List<Person> Children = new();

    // Constant fields: Values that are fixed at compilation.
    public const string Species = "Homo Sapien";

    // Read-only fields: Values that can be set at runtime.
    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;
    #endregion

    #region Methods: Actions the type can perform

    public void WriteToConsole()
    {
         WriteLine($"{Name} was born on a {Born:dddd}.");
    }

    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}.";
    }

    public string SayHello()
    {
        return $"{Name} says 'Hello!'";
    }

    public string SayHello(string name)
    {
        return $"{Name} says 'Hello, {name}!'";
    }

    public string OptionalParameters(int count, string command = "Run!",
    double number = 0.0, bool active = true)
    {
        return string.Format(
            format: "command is {0}, number is {1}, active is {2}",
            arg0: command,
            arg1: number,
            arg2: active);
    }
    
    public void PassingParameters(int w, in int x, ref int y, out int z)
    {
        // out parameters cannot have a default and they
        // must be initialized inside the method.
        z = 100;

        // Increment each parameter except the read-only x.
        w++;
        // x++; // Gives a compiler error
        y++;
        z++;
        WriteLine($"In the method: w={w}, x={x}, y={y}, z={z}");
    }

    // Method that returns a tuple: (string, int)
    public (string, int) GetFruit()
    {
        return ("Apples", 5);
    }

    // Method that returns a tuple with named fields.
    public (string Name, int Number) GetNamedFruit()
    {
        return (Name: "Apples", Number: 5);
    }

    // Deconstructors: Break down this object into parts.

    public void Deconstruct(out string? name,
        out DateTimeOffset dob)
        {
        name = Name;
        dob = Born;
        }

    public void Deconstruct(out string? name,
        out DateTimeOffset dob, 
        out WondersOfTheAncientWorld fav)
        {
        name = Name;
        dob = Born;
        fav = FavoriteAncientWonder;
        }

    //Method with a local function
    public static int Factorial(int number)
    { 
        if (number < 0)
        {
            throw new ArgumentException(
                $"{nameof(number)} cannot be less than zero.");
        }
        return localFactorial(number);

        int localFactorial(int localNumber) // local function
        {
            if (localNumber == 0) return 1;
            return localNumber * localFactorial(localNumber - 1);
        }
    }
    #endregion

    #region Constructors: Called when using new to instantiate a type
    public Person()
    {
        // Constructors can set default values for fields 
        // Including any read-only fields like instantiated.
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }
    #endregion

   

}
