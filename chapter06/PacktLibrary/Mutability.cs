namespace Packt.Shared;

// a mutable record class
public record class C1
{
    public string? Name { get; set; }
}

// An imuutable record class.
public record class C2(string? Name);

// A mutable record struct.
public record struct S1
{
    public string? Name {get; set;}
}

// Another mutable recoord struct.
public record struct S2(string? Name);

// An immutable record struct.
public readonly record struct S3(String? Name);
