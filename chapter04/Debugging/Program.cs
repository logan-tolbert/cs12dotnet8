using System.ComponentModel;


double a = 2.5;
double b = 2.5;
double answer = Add(a, b);

WriteLine($"{a} + {b} = {answer}");
WriteLine("Press Enter to end the app.");
 // wait for user to press Enter.

double Add( double a, double b )
{
    return a + b;// Deliberate bug!
}

