#region Looping / While
//int x = 0;
//while (x < 10)
//{
//    WriteLine(x);
//    x++;
//}

#endregion

#region Looping / Do..While
//string? actualPassword = "Pa$$w0rd";
//string? password;
//int attempts = 0;
//bool limitReached = false;
//do
//{
//    if (attempts is 3)
//    {
//        limitReached = true;
//        break;
//    }
//    Write("Enter your password: ");
//    password = ReadLine();
//    if (password != actualPassword)
//    {
//        attempts++;
//    }
//} while (password != actualPassword);

//if (limitReached is true)
//{
//    WriteLine("Attempt limit reached. Check your password and try again in 5 mins.");
//}
//else
//{
//    WriteLine("Correct!");
//}
#endregion

#region Looping / For
//for (int y = 1; y <= 10; y++)
//{
//    WriteLine(y);
//}
//WriteLine();
//for (int y = 0; y <= 10; y += 3)
//{
//    WriteLine(y);
//}
#endregion

#region Looping / Foreach
string[] names = { "Adam", "Barry", "Charlie" };

foreach (string name in names)
{
    WriteLine($"{name} has {name.Length} characters.");
}

#endregion
