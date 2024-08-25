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

public class Person: object
{
    #region Fields: Data or state for this person.

    public string? Name; // ? means it can be null.
    public DateTimeOffset Born;
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    #endregion

    public List<Person> Children = new();

    // Constant fields: Values that are fixed at compilation.
    public const string Species = "Homo Sapien";

    // Read-only fields: Values that can be set at runtime.
    public readonly string HomePlanet = "Earth";
}
