namespace Packt.Shared;
#region Init-only properties
public class ImmutablePerson
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}

#endregion

#region Defining record types

public record ImmutableVehicle
{
    public int Wheels { get; init; }
    public string? Color { get; init; }
    public string? Brand { get; init; }
}
#endregion

#region Positional data members in records

// public record ImmutableAnimal 
// {
//     public string Name{ get; init; }
//     public string Species { get; init; }

//     public ImmutableAnimal(string name, string species)
//     {
//         Name = name;
//         Species = species;
//     }
//     public void Decontruct(out string name, out string species)
//     {
//         name = Name;
//         species = Species;
//     }
  //}
    // Simpler syntax to define a record that auto-generates the 
    // Properties, constructor, and deconstructor
    public record ImmutableAnimal(string Name, string Species);

    
#endregion

