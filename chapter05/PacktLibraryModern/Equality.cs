namespace Packt.Shared;

#region Equality of record types
public class AnimalClass
{
    public string? Name { get; set; }
}

public record AnimalRecord
{
    public string? Name { get; set;}
}

#endregion