using Packt.Shared; // To user person

ConfigureConsole(); //Sets current culture to US english

// Alternatives
// ConfigureConsole(useComputeCulture: true); // Use your culture
// ConfigureConsoel(culture:"en-EN")

// Person = "Bob" new Person(); // C# 1 or later.
// var bob = new Person(); // C# 3 or later

Person bob = new(); // C# 9 or later.
//WriteLine(bob); // implicit call ToString();
//WriteLine(bob.ToString()); // Does the same thing

bob.Name = "Bob Smith";

bob.Born = new DateTimeOffset(
    year: 1965, month: 12, day: 22,
    hour: 16, minute: 23, second: 0,
    offset: TimeSpan.FromHours(-5)); // US Eastern Standard Time

WriteLine(format: "{0} was born on {1:D}.", // Long date
arg0: bob.Name, arg1: bob.Born);


Person alice = new()
{
    Name = "Alice Jone",
    Born = new(1988, 3, 7, 16, 28, 0,
    // This is an optional offset from UTC time zone
    TimeSpan.Zero)
};

WriteLine(format: "{0} was born {1:d}.", // Short date.
    arg0: alice.Name, arg1: alice.Born);

bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

WriteLine(
    format: "{0}'s favorite wonder is {1}. Its integer is {2}.",
    arg0: bob.Name,
    arg1: bob.FavoriteAncientWonder,
    arg2: (int)bob.FavoriteAncientWonder);

bob.BucketList =
    WondersOfTheAncientWorld.HangingGardensOfBabylon
    | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

// bob.BucketList = (WondersOfTheAncientWorld)18;

WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

// Works with all versions of C#.
Person alfred = new Person();
alfred.Name = "Alfred";
bob.Children.Add(alfred);

// Works with C# 3 and later.
bob.Children.Add(new Person { Name = "Bella" });

// Works with C# 9 and later.
bob.Children.Add(new() { Name = "Zoe" });

WriteLine($"{bob.Name} has {bob.Children.Count} children:");

for (int childIndex = 0; childIndex < bob.Children.Count; childIndex++)
{
    WriteLine($"> {bob.Children[childIndex].Name}");
}

WriteLine();

WriteLine($"{bob.Name} has {bob.Children.Count} children:");
foreach (Person child in bob.Children)
{
    WriteLine($"> {child.Name}");
}

BankAccount.InterestRate = 0.012M; // Store a shared value in static field

BankAccount jonesAccount = new();
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;
WriteLine(format: "{0} earned {1:C} interest.",
    arg0: jonesAccount.AccountName,
    arg1: jonesAccount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;
WriteLine(format: "{0} earned {1:C} interest.",
arg0: gerrierAccount.AccountName,
arg1: gerrierAccount.Balance * BankAccount.InterestRate);

// Constant fields are accessible via the type
WriteLine($"{bob.Name} is a {Person.Species}.");

// Read-only fields are accessible via the varaible.
WriteLine($"{bob.Name} was born on {bob.HomePlanet}.");
