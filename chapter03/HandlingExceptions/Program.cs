﻿#region Wrapping error-prone code in a try block
WriteLine("Before Parsing");
WriteLine("What is your age? ");
string? input = ReadLine();
if (input == null)
{
    WriteLine("You did not enter a value so the app has ended.");
    return; // Exit the app
}
try
{
    int age = int.Parse(input!);
    WriteLine($"You are {age} years old.");
}
catch (OverflowException)
{
    WriteLine("Your age is a valid number format but it is either too big or small.");
}
catch (FormatException)
{
    WriteLine("The age you entered is not a valid number format.");
}
catch (Exception ex) 
{
    WriteLine($"{ex.GetType()} says {ex.Message}");
}
WriteLine("Aftr parsing");

#endregion

WriteLine();

#region Catching with filters
Write("Enter an amount: ");
string amount = ReadLine()!;
if (string.IsNullOrEmpty(amount)) return;

try
{
    decimal amountValue = decimal.Parse(amount);
    WriteLine($"Amount formatted as a currency: {amountValue:C}");
}
catch (FormatException) when (amount.Contains("$"))
{
    WriteLine("Amounts cannot use the dollar sign.");
}
catch (FormatException)
{
    WriteLine("Amounts must only contain digits!");
}

#endregion

WriteLine();

#region Throwing overflow exceptions with the checked statement
try 
{  
    checked
    {
        int x = int.MaxValue - 1 ;
        WriteLine($"Initial value: {x}");
        x++;
        WriteLine($"After incrementing: {x}");
        x++;
        WriteLine($"After incrementing: {x}");
        x++;
        WriteLine($"After incrementing: {x}");
    }
}
catch (OverflowException)
{
    WriteLine("The code overflowed but I caught the exception.");
}    
#endregion

WriteLine();

#region Disabling compiler overflow checks with the `unchecked` keyword

unchecked
{
    int y = int.MaxValue + 1; // compile time overflow
    WriteLine($"Initial value: {y}");
    y--;
    WriteLine($"After decrementing: {y}");
    y--;
    WriteLine($"After decrementing: {y}");
}

#endregion