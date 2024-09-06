
using System.Runtime;
using System.Runtime.InteropServices;
using System.Xml;
namespace variables;

class Program
{
    static void Main(string[] args)
    {
        object height = 1.88; // storing a double in an object.
        object name = "Amir"; // Storing a string in an object.
        Console.WriteLine($"{name} is {height} metres tall.");

        //int length1 = name.Length; // This gives a compile error!
        int length2 = ((string)name).Length; // Cast naem to a string.
        Console.WriteLine($"{name} has {length2} characters.");

        dynamic something;

        // Storing an array of in values in a dynamic object.
        // An array of any type has a length property.
        something = new[] { 3, 5, 7 };

        // Storing in int a dynamic odject.
        // int does not have a length property.
        //something = 12;

        // Storing string in a dynamic object
        // string has a length property
        //something = "Ahmed";

        // This compiles but might throw an exception error
        Console.WriteLine($"The length of something is {something.Length}.");

        // Output the type of the something varaiable
        Console.WriteLine($"something is a {something.GetType()}.");

        var population = 76_000_000; // 67 millioin in UK.
        var weight = 1.88; // in kilograms.
        var price = 4.99M; // in pounds sterling
        var fruit = "Apples"; // string values use double-quotes
        var letter = '2'; // char values use single-quotes.
        var happy = true; // Booleans can only be true or false.

        // Good use of var because it avoids the repeated type
        // as shown in the more verbose second statement.
        var xml = new XmlDocument(); // Works with C# 3 and later.
        XmlDocument xml2 = new XmlDocument(); // Works with all C# versions

        // Bad use of var because we cannot tell the type, so we
        // Should use a specific type declaration as shown in
        // the second statement.
        var file1 = File.CreateText("something1.txt");
        StreamWriter file2 = File.CreateText("Something2.txt");

        XmlDocument xml3 = new(); // Target-typed new in C# 9 or later

        Person kim = new();
        kim.Birthdate = new(1967, 12, 26); // i.e. new DateTime(1967, 12, 26)

        List<Person> persons = new() // Instead of: new List<Person>()
        {
        new() { FirstName = "Alice" }, // Instead of: newPerson() {...}
        new() { FirstName = "Bob" },
        new() { FirstName = "Charlie"}
         };

        Console.WriteLine($"default(int) = {default(int)}");
        Console.WriteLine($"default(bool) = {default(bool)}");
        Console.WriteLine($"default(DateTime) = {default(DateTime)}");
        Console.WriteLine($"default(string) = {default(string)}");

        int number = 13;
        Console.WriteLine($"number set to {number}");
        number = default;
        Console.WriteLine($"number reset to its default: {number}");

    }

    class Person
    {
        public DateTime Birthdate;
        public string FirstName = string.Empty;
    }
}
