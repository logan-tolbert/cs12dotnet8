using Packt.Shared;

partial class Program
{
    #region Comparing objects when sorting
    private static void OutputPeopleNames(
        IEnumerable<Person?> people, string title)
    {
        WriteLine(title);
        foreach (Person? p in people)
        {
            WriteLine("  {0}",
               p is null ? "<null> Person" : p.Name ?? "<null> Name");

            /* if p is null the outpt: <null> Person
                else output: p.Name
                unless p.Name is null the output: <null> Name */
        }
    }
    #endregion
    
}
