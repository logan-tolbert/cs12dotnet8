using System.Xml.Linq;// to use XDocument
using System; // To use String

XDocument doc = new();

String s1 = "Hello";
String s2 = "World";

WriteLine($"{s1} {s2}");

#region Understanding native=sized integers

WriteLine($"Environment.Is64BitProcess = {Environment.Is64BitProcess}");
WriteLine($"int.MaxValue = {int.MaxValue}");
WriteLine($"nint.MaxValue = {nint.MaxValue}");

#endregion