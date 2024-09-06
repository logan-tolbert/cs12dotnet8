using Packt.Shared; // To user person
using Fruit = (string Name, int Number); // Aliasing a tuple type.

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

#region Storing a value using an enum type
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
    


WriteLine(
    format: "{0}'s favorite wonder is {1}. Its integer is {2}.",
    arg0: bob.Name,
    arg1: bob.FavoriteAncientWonder,
    arg2: (int)bob.FavoriteAncientWonder);

//bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon;

// bob.BucketList =
//     WondersOfTheAncientWorld.HangingGardensOfBabylon
//     | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

//bob.FavoriteAncientWonder = (WondersOfTheAncientWorld)128;


// bob.BucketList = (WondersOfTheAncientWorld)18;

WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
#endregion

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

// Constructor for use with object initializer syntax
/*
Book book = new()
{
    Isbn = "978-1803237800",
    Title = "C#12 and .NET8 - Modern Cross-Platform Development Fundamentals"
};
*/

Book book = new(isbn: "978-1803237800",
title: "C# and .NET 8 - Modern Cross-Platform Development Fundamentals")
{
    Author = "Mark J. Price",
    PageCount = 821
};

WriteLine("{0}: {1} written by {2} has {3} pages.",
book.Isbn, book.Title, book.Author, book.PageCount);

Person blankPerson = new();
WriteLine(format:
"{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
  arg0: blankPerson.Name,
  arg1: blankPerson.HomePlanet,
  arg2: blankPerson.Instantiated);


Person gunny = new(initialName: "Gunny", homePlanet: "Mars");

WriteLine(format:
"{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
    arg0: gunny.Name,
    arg1: gunny.HomePlanet,
    arg2: gunny.Instantiated
);

bob.WriteToConsole();
WriteLine(bob.GetOrigin());
WriteLine(bob.SayHello());

// Method overloading
WriteLine(bob.SayHello("Emily"));

WriteLine(bob.OptionalParameters(3));
WriteLine(bob.OptionalParameters(3, "Jump", 98.5));

// Naming a parameter allows it to be passed in any order
WriteLine(bob.OptionalParameters(3, number: 52.7, command: "Hide!"));

WriteLine(bob.OptionalParameters(3, "Poke!", active: false));

int a = 10;
int b = 20;
int c = 30;
int d = 40;

WriteLine($"Before: a={a}, b={b}, c={c}, d={d}");

bob.PassingParameters(a, b, ref c, out d);

WriteLine($"After: a={a}, b={b}, c={c}, d={d}");

int e = 50;
int f = 60;
int g = 70;

WriteLine($"Before: e={e}, f={f}, c={g}, h doesn't exist yet!");

// Simplified C# 7 or later syntax for the out parameter
bob.PassingParameters(e, f, ref g, out int h);

WriteLine($"After: e={e}, f={f}, g={g}, h={h}");

(string, int) fruit = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

// Without an aliased tuple type
// var fruitNamed = bob.GetNamedFruit();

// With an aliased type 
Fruit fruitNamed = bob.GetNamedFruit();
WriteLine($"Ther are {fruitNamed.Number} {fruitNamed.Name}");

var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children");

(string fruitName, int fruitNumber) = bob.GetFruit();
WriteLine($"Deconstructed tuple: {fruitName}, {fruitNumber}");

var (name1, dob1) = bob; // Implicitly calls the Deconstruct method.
WriteLine($"Deconstrcuted person: {name1}, {dob1}");

var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed person: {name2}, {dob2}, {fav2}");

// Change to -1 to make the exception handling code exectue.
int number = -1;

try
{
    WriteLine($"{number}! is {Person.Factorial(number)}");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says: {ex.Message} number was {number}.");
}

Person sam = new()
{
    Name = "Sam",
    Born = new(1969, 6, 25, 0, 0, 0, TimeSpan.Zero)
};

WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);

sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine($"Sam's favortie ice-cream flavor is {sam.FavoriteIceCream}.");

string color = "Black";

try
{
    sam.FavoritePrimaryColor = color;
    WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}");
}
catch (Exception ex)
{
    WriteLine("Tried to set {0} to '{1}': {2}",
    nameof(sam.FavoritePrimaryColor), color, ex.Message);
}

#region Defining indexers

sam.Children.Add(new()
{
    Name = "Charlie",
    Born = new(2010, 3, 18, 0, 0, 0, TimeSpan.Zero)
});

sam.Children.Add(new()
{
    Name = "Ella",
    Born = new(2020, 12, 24, 0, 0, 0, TimeSpan.Zero)
});

// Get using Children list.
WriteLine($"Sam's first child is {sam.Children[0].Name}.");
WriteLine($"Sam's second child is {sam.Children[1].Name}");

// Get using the int indexer.
WriteLine($"Sam's first child is {sam[0].Name}");
WriteLine($"Sam's second child is {sam[1].Name}");

// Get using the string indexer.
WriteLine($"Sam's child named Ella is {sam["Ella"].Age} years old.");

#endregion


#region Pattern matching fligh passengers
// An array containg a mix of passenger types.
Passenger[] passengers = {
    new FirstClassPassenger { AirMiles = 1_1419, Name = "Suman"},
    new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
    new BusinessClassPassenger { Name = "Janice"},
    new CoachClassPassenger { CarryOnKG = 25.7, Name = "Dave" },
    new CoachClassPassenger { CarryOnKG = 0, Name = "Amit" },
};

foreach(Passenger passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        // C# 8 Syntax
        // FirstClassPassenger p when p.AirMiles > 35_000 => 1_500M,
        // FirstClassPassenger p when p.AirMiles > 15_000 => 1_750M,
        // FirstClassPassenger _ => 2_000M,

        // another option
        // FirstClassPassenger { AirMiles: > 35000 } => 1500M,
        // FirstClassPassenger { AirMiles: > 1500 } => 1750M,
        // FirstClassPassenger                      => 2000M,

        // C# 9 Syntax
        FirstClassPassenger p => p.AirMiles switch
        {
            > 35_000 => 1_500M,
            > 15_000 => 1_750M,
            _ => 2_000M
        },
        BusinessClassPassenger _ => 1_000M,
        CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
        CoachClassPassenger _ => 650M,
        _ => 800M
    };
    WriteLine($"Flight costs {flightCost:C} for {passenger}");
}
#endregion

#region Init-only record types

ImmutablePerson jeff = new()
{
    FirstName = "Jeff",
    LastName = "Winger"
};
//jeff.FirstName = "Geoff";

#endregion

#region Defining record types

ImmutableVehicle car = new()
{
    Brand = "Mazda MX-5 RF",
    Color = "Soul Red Crystal Metallic",
    Wheels = 4
};

ImmutableVehicle repaintedCar = car
    with { Color = "Polymetal Grey Metallic" };
WriteLine($"Original car color was {car.Color}");
WriteLine($"New car color is {repaintedCar.Color}.");

#endregion

#region Equality of record types

AnimalClass ac1 = new() { Name = "Rex" };
AnimalClass ac2 = new() { Name = "Rex" };

WriteLine($"ac1 == ac2: {ac1 == ac2}");

AnimalRecord ar1 = new() { Name = "Rex" };
AnimalRecord ar2 = new() { Name = "Rex" };

WriteLine($"ar1 == ar2: {ar1 == ar2}");


#endregion 

#region Positional data members in records

ImmutableAnimal oscar = new("Oscar", "Labrador");
var (who, what) = oscar; // Calls the Deconstruct methood.
WriteLine($"{who} is a {what}");

#endregion

#region Defining a primary constructor for a class

Headset vp = new("Apple", "Vision Pro");
WriteLine($"{vp.ProductName} is made by {vp.Manufacturer}.");

Headset holo = new(); 
WriteLine($"{holo.ProductName} is made by {holo.Manufacturer}.");

Headset mq = new() { Manufacturer = "Meta", ProductName = "Quest 3" };
WriteLine($"{mq.ProductName} is made by {mq.Manufacturer}");

#endregion