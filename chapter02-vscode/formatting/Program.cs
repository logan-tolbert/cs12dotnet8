namespace formatting;

class Program
{
    static void Main(string[] args)
    {
        int numberOfApples = 32; 
        decimal pricePerApple = 0.35M;

        Console.WriteLine(
            format: "{0} apples cost {1:C}",
            arg0: numberOfApples,
            arg1: pricePerApple * numberOfApples);

        string formatted = string.Format(
            format: "{0} apples cost {1:C}",
            arg0: numberOfApples,
            arg1: pricePerApple * numberOfApples);
        //WriteToFile(Formatted); // would write string to a file

        // Three parameter values can use named arguments.
        Console.WriteLine("{0} {1} lived in {2}.",
        arg0: "Roger", arg1: "Cevung", arg2: "Stockholm");
        
        // Four or more parameter values cannot use named arguments.
        Console.WriteLine("{0} {1} lived in {2} and worked in the {3} team at {4}.",
        "Roger", "Cevung", "Stockholm", "Education", "Optimizely");

        // The following statement must be all on one line when using C# 10 
        // or earlier. If using C# 11 or later, we can include a line break
        // in the middle of an expression but not in the string text.
        Console.WriteLine($"{numberOfApples} apples cost {pricePerApple * 
        numberOfApples:C}");
        
    }
}
