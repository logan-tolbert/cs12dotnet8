﻿namespace Packt.Shared;

public class Person : IComparable<Person?>
{
    #region Properties
    public string? Name { get; set; }
    public DateTimeOffset Born { get; set; }
    public List<Person> Children = new();

    #region Implementing functionality using methods - Properties

    // Allow multiple spouses to be stored for a person.
    public List<Person> Spouses = new();

    // A read-only property to show if a person is marriedto anyone. 
    public bool Married => Spouses.Count > 0;
    #endregion

    #endregion

    #region Methods
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {Born:dddd}.");
    }

    public void WriteChildrenToConsole()
    {
        string term = Children.Count == 1 ? "child" : "children";
        WriteLine($"{Name} has {Children.Count} {term}.");
    }

    #endregion

    #region Implementing functionality using methods - Methods

    // Static method to marry two people.
    public static void Marry(Person p1, Person p2)
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p2);

        if (p1.Spouses.Contains(p2) || p2.Spouses.Contains(p1))
        {
            throw new ArgumentException(
                string.Format("{0} is already married to {1}.",
                arg0: p1.Name, arg1: p2.Name));
        }

        p1.Spouses.Add(p2);
        p2.Spouses.Add(p1);
    }

    // Instance method to marry another person.
    public void Marry(Person partner)
    {
        Marry(this, partner); // "this" is the current perosn.
    }

    public void OutputSpouses()
    {
        if (Married)
        {
            string term = Spouses.Count == 1 ? "person" : "people";
            WriteLine($"{Name} is married to {Spouses.Count} {term}.");

            foreach (Person spouse in Spouses)
            {
                WriteLine($"  {spouse.Name}");
            }
        }
        else
        {
            WriteLine($"{Name} is a singleton.");
        }
    }

    /// <summary>
    /// Static method to "multiply" aka procreate and have a child toogether.
    /// </summary>
    /// <param name="p1">Parent 1</param>
    /// <param name="p2">Parent 2</param>
    /// <returns>A Person object that is the child of Parent 1 and Parent 2.</returns>
    /// <exception cref="ArgumentNullException"> if p1 or p2 are null.</exception>
    /// <exception cref="ArgumentNullException"> if p1 and pw are not married.</exception>

    public static Person Procreate(Person p1, Person p2)
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p2);

        if (!p1.Spouses.Contains(p2) && !p2.Spouses.Contains(p1))
        {
            throw new ArgumentException(string.Format("{0} must be married to {1} to procreate with them.",
            arg0: p1.Name, arg1: p2.Name));
        }

        Person baby = new()
        {
            Name = $"Baby of {p1.Name} and {p2.Name}",
            Born = DateTimeOffset.Now
        };

        p1.Children.Add(baby);
        p2.Children.Add(baby);

        return baby;
    }

    // Instance method to "multiply".
    public Person ProcreateWith(Person partner)
    {
        return Procreate(this, partner);
    }

    #endregion

    #region Operators

    // Define the + operator to "marry"
    public static bool operator +(Person p1, Person p2)
    {
        Marry(p1, p2);

        // Confirm they are both now married.
        return p1.Married && p2.Married;
    }

    // Define the * operator to "multiply".
    public static Person operator *(Person p1, Person p2)
    {
        // Return a reference to the baby that results from multiplying.
        return Procreate(p1, p2);
    }
    #endregion 

    #region Events

    // Delegate field to define the event
    public event EventHandler? Shout; // null initially.

    // Data field related to the event.
    public int AngerLevel;

    // Method to trigger the even in certain conditions.
    public void Poke()
    {
        AngerLevel++;

        if (AngerLevel < 3) return;

        // If something is listening to the event...
        if (Shout is not null)
        {
            // then call the delegate to "raise the event
            Shout(this, EventArgs.Empty);
        }
    }

    #endregion

    public int CompareTo(Person? other)
    {
        int position;

        if (other is not null)
        {
            if ((Name is not null) && (other.Name is not null))
            {
                // if both Name values are not null, then
                //use the string implementation of CompareTo.
                position = Name.CompareTo(other.Name);
            }
            else if ((Name is not null) && (other.Name is null))
            {
                position = -1; // this Person precedes other Person.
            }
            else if ((Name is null) && (other.Name is not null))
            {
                position = 1; // this Person follows other Person.
            }
            else
            {
                position = 0; // this and other are at same position.
            }
        }
        else if (other is null)
        {
            position = -1; // this Person preceds other Person.
        }
        else
        {
            position = 0; // this and other are at same position.
        }
        return position;
    }


    #region Overridden methods

    public override string ToString()
    {
        return $"{Name} is a {base.ToString()}.";
    }

    #endregion

    #region Inheriting exceptions

    public void TimeTravel(DateTime when)
    {
        if (when <= Born)
        {
            throw new PersonException("If you travel back in time to a date ealier than your own birth, then the universe wi ll explode!");
        }
        else
        {
            WriteLine($"Welcome to {when:yyyy}");
        }
    
    }

     #endregion
}
