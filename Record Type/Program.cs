namespace Record_Type
{
    public record Person(string FirstName, string LastName);
    public record Person_2(string FirstName, string LastName, string[] PhoneNumbers);

    public record Person_3(string FirstName, string LastName)
    {
        public required string[] PhoneNumbers { get; init; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Person

            Person person = new("Nancy", "Davolio");
            Console.WriteLine(person);
            // output: Person { FirstName = Nancy, LastName = Davolio }

            #endregion

            #region Person_2

            var phoneNumbers = new string[2];
            Person_2 person3 = new("Nancy", "Davolio", phoneNumbers);
            Person_2 person4 = new("Nancy", "Davolio", phoneNumbers);
            Console.WriteLine(person3 == person4); // output: True

            person3.PhoneNumbers[0] = "555-1234";
            Console.WriteLine(person3 == person4); // output: True

            Console.WriteLine(ReferenceEquals(person3, person4)); // output: False

            #endregion

            #region Person_3

            Person_3 person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[1] };
            Console.WriteLine(person1);
            // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }

            //The following example demonstrates use of a with expression to copy an immutable object and change one of the properties:

            Person_3 person2 = person1 with { FirstName = "John" };
            Console.WriteLine(person2);
            // output: Person { FirstName = John, LastName = Davolio, PhoneNumbers = System.String[] }
            Console.WriteLine(person1 == person2); // output: False

            person2 = person1 with { PhoneNumbers = new string[1] };
            Console.WriteLine(person2);
            // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }
            Console.WriteLine(person1 == person2); // output: False

            person2 = person1 with { };
            Console.WriteLine(person1 == person2); // output: True

            #endregion

        }
    }
}
