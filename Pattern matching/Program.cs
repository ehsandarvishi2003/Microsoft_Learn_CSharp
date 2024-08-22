#region
static T MidPoint<T>(IEnumerable<T> sequence)
{
    if (sequence is IList<T> list)
    {
        return list[list.Count / 2];
    }
    else if (sequence is null)
    {
        throw new ArgumentNullException(nameof(sequence), "Sequence can't be null.");
    }
    else
    {
        int halfLength = sequence.Count() / 2 - 1;
        if (halfLength < 0) halfLength = 0;
        return sequence.Skip(halfLength).First();
    }
}

record Order(int Items, decimal Cost);

#endregion
class Programing
{
    static void Main(string[] args)
    {
        #region Null checks "declaration pattern"
            int? maybe = 12; //`?` indicates that the variable can also accept the value null, which means that it may sometimes have no value.

            //The `as` operator attempts to cast an object to a specific type, and returns null if it fails.
            if (maybe is int number) //The `is` operator checks if an object can be cast to a specific type.
            {
                Console.WriteLine($"The nullable int 'maybe' has the value {number}");
            }
            else
            {
                Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
            }
        #endregion

        #region Relational patterns

        string WaterState(int tempInFahrenheit) =>
        tempInFahrenheit switch
        {
            (> 32) and (< 212) => "liquid",
            < 32 => "solid",
            > 212 => "gas",
            32 => "solid/liquid transition",
            212 => "liquid / gas transition",
        };

        #region Multiple inputs

        decimal CalculateDiscount(Order order) =>
        order switch
        {
            { Items: > 10, Cost: > 1000.00m } => 0.10m,
            { Items: > 5, Cost: > 500.00m } => 0.05m,
            { Cost: > 250.00m } => 0.02m,
            null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
            var someObject => 0m,
        };

        #endregion

        #endregion


    }
}
