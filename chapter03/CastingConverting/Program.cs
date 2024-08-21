using System.Buffers.Text;
using System.Globalization;
using static System.Convert; // To use the ToInt32 method
#region Casting numbers inplicitly and explicitly
// declare and assign an int variable and a double variable,
// and then implicitly cast the integer's value when assigning it to the double variable
int a = 10; 
double b = a; // An int can be safely cast into a double.
WriteLine($"a is {a}, b is {b}");

double c = 9.8;
int d = (int)c; // Compiler gives error if you do not explicitly cast.
WriteLine($"c is {c}, d is {d}"); // d loses .8 part.

long e = 10;
int f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}");

// e = long.MaxValue;
e = 5_000_000_000;
f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}"); // overflow
#endregion

WriteLine();

#region Negative numbers in binary
WriteLine("{0,12} {1,34}", "Decimal", "Binary");
WriteLine("{0,12} {0,34:B32}", int.MaxValue);
for (int i = 8; i >= -8; i--)
{
    WriteLine("{0,12} {0,34:B32}", i);

}
WriteLine("{0,12} {0,34:B32}", int.MinValue);
#endregion

WriteLine("");

#region Converting with the System.Convert type

double g = 9.8;
int h = ToInt32(g); // A method of System.Convert
WriteLine($"g is {g}, h is {h}");

#endregion

WriteLine("");


#region Rounding numbers and the default rounding rules

double[ , ] doubles = {
    { 9.49, 9.5, 9.51},
    { 10.49, 10.5, 10.51 },
    { 11.49, 11.5, 11.51 },
    { 12.49, 12.5, 12.51 }, 
    { -12.49, -12.5, -12.51 },
    { -11.49, -11.5, -11.51 },
    { -10.49, -11.5, -11.51 },
    { -9.49, -9.5, -9.51 }
};

WriteLine($"| double | ToInt32 | double | ToInt32 | double | ToInt32 |");
for (int x = 0; x < 8; x++)
{
    
    for (int y = 0; y < 3; y++)
    {
        Write($"| {doubles[x, y],6} | {ToInt32(doubles[x, y]),7} ");
    }
    WriteLine("|");
}
WriteLine();

#endregion

WriteLine();

#region taking control of rounding rules 
// round each of the double values using th " away from zero" rounding rule AKA: "rounding up"
foreach (double n in doubles)
{
    WriteLine(format:
    "Math.Round({0}, 0, MidpointRounding.AwayFromZero) is {1}",
    arg0: n,
    arg1: Math.Round(value: n, digits: 0,
        mode: MidpointRounding.AwayFromZero));
}

#endregion

WriteLine();

#region Converting from any type to a string
int number = 12;
WriteLine(number.ToString());
bool boolean = true;
WriteLine(boolean.ToString());
DateTime now = DateTime.Now;
WriteLine(now.ToString());  
object me = new();
WriteLine(me.ToString());

#endregion

WriteLine("");

#region Converting from a binary object to a string
// Allocate an array of 128 bytes.
byte[] binaryObject = new byte[128];

// Populate the array with random bytes.
Random.Shared.NextBytes(binaryObject);

WriteLine("Binary Object as bytes:");
for(int index = 0; index < binaryObject.Length; index++)
{
    Write($"{binaryObject[index]:X2} ");
}
WriteLine();

//Convert the array To Base64 string and output as text.
string encoded = ToBase64String(binaryObject);
WriteLine($"Binary Object as Base64: {encoded}");
#endregion

WriteLine();

#region Parsing from strings to numbers or dates and times
// Set the current culture to make sure date parsing works. 
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

int friend = int.Parse("27");
DateTime birthday = DateTime.Parse("4 June 1980");
WriteLine($"I have {friend} friends to invite to the party");
WriteLine($"My birthday is {birthday}.");
WriteLine($"My birthday is {birthday:D}.");

#endregion

WriteLine();

#region Avoiding Parse exceptions by using the TryParse method

Write("How many eggs are there? ");
string? input = ReadLine();

if (int.TryParse(input, out int count))
{
    WriteLine($"There are {count} eggs.");
}
else 
{
    WriteLine("I could not parse the input.");
}

#endregion

WriteLine();

