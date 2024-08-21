namespace Classes
{
    #region Customer
    //[access modifier] - [class] - [identifier]
    public class Customer
    {
        // Fields, properties, methods and events go here...
    }
    #endregion

    #region Container
    //You can require callers to provide an initial value by defining 
    //a constructor that's responsible for setting that initial value:
    public class Container
    {
        private int _capacity;

        public Container(int capacity) => _capacity = capacity;
    }
    #endregion

    #region Container_2

    //Beginning with C# 12, you can define a primary constructor as part of the class declaration:

    public class Container_2(int capacity)
    {
        private int _capacity = capacity;
    }

    #endregion

    #region Person

    //You can also use the required modifier on a property and allow callers 
    //to use an object initializer to set the initial value of the property:
    public class Person
    {
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
    }

    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Customer object1 = new Customer();

            Customer object2;

            Customer object3 = new Customer();
            Customer object4 = object3;

            //***************************************

            // var p1 = new Person();  Error! Required properties not set

            var p2 = new Person() { FirstName = "Grace", LastName = "Hopper" };

            //***************************************

        }
    }
}
