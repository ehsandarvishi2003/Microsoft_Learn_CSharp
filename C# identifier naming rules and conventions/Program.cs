//Use pascal casing ("PascalCasing") when naming a class, interface, struct, or delegate type.
#region Pascal case
public class DataService
{
}

public record PhysicalAddress(
    string Street,
    string City,
    string StateOrProvince,
    string ZipCode);

public struct ValueCoordinate
{
}

public delegate void DelegateType(string message);

//When naming an interface, use pascal casing in addition to prefixing the name with an I. This prefix clearly
//indicates to consumers that it's an interface.
public interface IWorkerQueue { }

//When naming public members of types, such as fields, properties, events, use pascal casing. Also, use pascal
//casing for all methods and local functions.
public class ExampleEvents
{
    // A public field, these should be used sparingly
    public bool IsValid;

    // An init-only property
    public IWorkerQueue? WorkerQueue { get; init; }

    // An event
    public event Action EventProcessing;

    // Method
}

//When writing positional records, use pascal casing for parameters as they're the public properties of the record.
//public record PhysicalAddress(
//    string Street,
//    string City,
//    string StateOrProvince,
//    string ZipCode);

#endregion

//Use camel casing ("camelCasing") when naming private or internal fields and prefix them with _. Use camel
//casing when naming local variables, including instances of a delegate type.
#region Camel case
public class DataService_1
{
    private IWorkerQueue _workerQueue;
}

//When working with static fields that are private or internal, use the s_ prefix and for thread static use t_.
public class DataService_2
{
    private static IWorkerQueue s_workerQueue;

    [ThreadStatic]
    private static TimeSpan t_timeSpan;
}

//When writing method parameters, use camel casing.
//public T SomeMethod<T>(int someNumber, bool isValid)
//{
//}

#endregion

//The following guidelines apply to type parameters on generic type parameters. Type parameters are the
//placeholders for arguments in a generic type or a generic method. You can read more about generic type
//parameters in the C# programming guide.
#region Type parameter naming guidelines

//1.Do name generic type parameters with descriptive names, unless a single letter name is completely self
//explanatory and a descriptive name wouldn't add value.
public interface ISessionChannel<TSession> { /*...*/ }
public delegate TOutput Converter<TInput, TOutput>(TInput from);
public class List<T> { /*...*/ }

//2.Consider using T as the type parameter name for types with one single letter type parameter.
//public int IComparer<T>() { return 0; }  -->Due to writing all contents in one file, when writing generic methods, we get topLevel statement error, and I comment those codes.
public delegate bool Predicate<T>(T item);
public struct Nullable<T> where T : struct { /*...*/ }

//3.Do prefix descriptive type parameter names with "T".
public interface ISessionChannel_2<TSession>
{
    TSession Session { get; }
}

#endregion

//Examples that don't include using directives, use namespace qualifications. If you know that a namespace
//is imported by default in a project, you don't have to fully qualify the names from that namespace.
//Qualified names can be broken after a dot (.) if they're too long for a single line, as shown in the following
//example.
#region Extra naming conventions

//var currentPerformanceCounterCategory = new System.Diagnostics.
//    PerformanceCounterCategory();

#endregion