#region String data
//Use string interpolation to concatenate short strings, as shown in the following code.
//string displayName = $"{nameList[n].LastName}, {nameList[n].FirstName}";

//To append strings in loops, especially when you're working with large amounts of text, use a System.Text.StringBuilder object.
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var phrase = "lalalalalalalalalalalalalalalalalalalalalalalalalalalalalala";
var manyPhrases = new StringBuilder();
for (var i = 0; i < 10000; i++)
{
    manyPhrases.Append(phrase);
}
//Console.WriteLine("tra" + manyPhrases);

#endregion

#region Arrays

//Use the concise syntax when you initialize arrays on the declaration line. 
//In the following example, you can't use var instead of string[].
string[] vowels1 = { "a", "e", "i", "o", "u" };

//If you use explicit instantiation, you can use var.
var vowels2 = new string[] { "a", "e", "i", "o", "u" };

#endregion

#region Delegates

//Use Func<> and Action<> instead of defining delegate types. In a class, define the delegate method.
Action<string> actionExample1 = x => Console.WriteLine($"x is: {x}");

Action<string, string> actionExample2 = (x, y) =>
    Console.WriteLine($"x is: {x}, y is {y}");

Func<string, int> funcExample1 = x => Convert.ToInt32(x);

Func<int, int, int> funcExample2 = (x, y) => x + y;

//Call the method using the signature defined by the Func<> or Action<> delegate.
actionExample1("string for x");

actionExample2("string for x", "string for y");

Console.WriteLine($"The value is {funcExample1("1")}");

Console.WriteLine($"The sum is {funcExample2(1, 2)}");

//If you create instances of a delegate type, use the concise syntax. In a class, 
//define the delegate type and a method that has a matching signature.
public delegate void Del(string message);
//public static void DelMethod(string str)
//{
//    Console.WriteLine("DelMethod argument: {0}", str);
//}

//Create an instance of the delegate type and call it. The following declaration shows the condensed syntax.
//Del exampleDel2 = DelMethod;
//exampleDel2("Hey");

//The following declaration uses the full syntax.
//Del exampleDel1 = new Del(DelMethod);
//exampleDel1("Hey");


#endregion

#region try-catch and using
//static double ComputeDistance(double x1, double y1, double x2, double y2)
//{
//    try
//    {
//        return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
//    }
//    catch (System.ArithmeticException ex)
//    {
//        Console.WriteLine($"Arithmetic overflow or underflow: {ex}");
//        throw;
//    }
//}

//Simplify your code by using the C# using statement. If you have a try-finally statement in which the only
//code in the finally block is a call to the Dispose method, use a using statement instead.

//In the following example, the try-finally statement only calls Dispose in the finally block.
//Font bodyStyle = new Font("Arial", 10.0f);
//try
//{
//    byte charset = bodyStyle.GdiCharSet;
//}
//finally
//{
//    if (bodyStyle != null)
//    {
//        ((IDisposable)bodyStyle).Dispose();
//    }
//}

//You can do the same thing with a using statement.
//using (Font arial = new Font("Arial", 10.0f))
//{
//    byte charset2 = arial.GdiCharSet;
//}

//Use the new using syntax that doesn't require braces:
//using Font normalStyle = new Font("Arial", 10.0f);
//byte charset3 = normalStyle.GdiCharSet;
#endregion

#region && and || operators
//Use && instead of & and || instead of | when you perform comparisons, as shown in the following example.
//Console.Write("Enter a dividend: ");
//int dividend = Convert.ToInt32(Console.ReadLine());

//Console.Write("Enter a divisor: ");
//int divisor = Convert.ToInt32(Console.ReadLine());

//if ((divisor != 0) && (dividend / divisor) is var result)
//{
//    Console.WriteLine("Quotient: {0}", result);
//}
//else
//{
//    Console.WriteLine("Attempted division by 0 ends up here.");
//}

#endregion

#region new operator
//Use one of the concise forms of object instantiation, as shown in the following declarations.
//var firstExample = new ExampleClass();
//ExampleClass instance2 = new();

//The preceding declarations are equivalent to the following declaration.
//ExampleClass secondExample = new ExampleClass();

//ExampleClass secondExample = new ExampleClass();
//var thirdExample = new ExampleClass
//{
//    Name = "Desktop",
//    ID = 37414,
//    Location = "Redmond",
//    Age = 2.3
//};

//The following example sets the same properties as the preceding example but doesn't use initializers.
//var fourthExample = new ExampleClass();
//fourthExample.Name = "Desktop";
//fourthExample.ID = 37414;
//fourthExample.Location = "Redmond";
//fourthExample.Age = 2.3;

#endregion

#region Event handeler
//Use a lambda expression to define an event handler that you don't need to remove later:
//public Form2()
//{
//    this.Click += (s, e) =>
//    {
//        MessageBox.Show(
//            ((MouseEventArgs)e).Location.ToString());
//    };
//}

//The lambda expression shortens the following traditional definition.
//public Form1()
//{
//    this.Click += new EventHandler(Form1_Click);
//}

//void Form1_Click(object? sender, EventArgs e)
//{
//    MessageBox.Show(((MouseEventArgs)e).Location.ToString());
//}


#endregion