using System.Reflection;

namespace Inheritance_in_c__and_.net
{
    #region SimpleClass
    public class SimpleClass
    { }

    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            #region SimpleClass Methods
            Type t = typeof(SimpleClass);
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                 BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
            MemberInfo[] members = t.GetMembers(flags);
            Console.WriteLine($"Type {t.Name} has {members.Length} members: ");
            foreach (MemberInfo member in members)
            {
                string access = "";
                string stat = "";
                var method = member as MethodBase;
                if (method != null)
                {
                    if (method.IsPublic)
                        access = " Public";
                    else if (method.IsPrivate)
                        access = " Private";
                    else if (method.IsFamily)
                        access = " Protected";
                    else if (method.IsAssembly)
                        access = " Internal";
                    else if (method.IsFamilyOrAssembly)
                        access = " Protected Internal ";
                    if (method.IsStatic)
                        stat = " Static";
                }
                string output = $"{member.Name} ({member.MemberType}): {access}{stat}, Declared by {member.DeclaringType}";
                Console.WriteLine(output);
            }
            #endregion

            Console.WriteLine("");

            #region Publication
            var book = new Book("The Tempest", "0971655819", "Shakespeare, William",
                    "Public Domain Press");
            ShowPublicationInfo(book);
            book.Publish(new DateTime(2016, 8, 18));
            ShowPublicationInfo(book);

            var book2 = new Book("The Tempest", "Classic Works Press", "Shakespeare, William");
            Console.Write($"{book.Title} and {book2.Title} are the same publication: " +
                  $"{((Publication)book).Equals(book2)}");
            #endregion

            Console.WriteLine("");

            #region Shape clases
            Shape[] shapes = { new Rectangle(10, 12), new Square(5),
                    new Circle(3) };
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"{shape}: area, {Shape.GetArea(shape)}; " +
                                  $"perimeter, {Shape.GetPerimeter(shape)}");
                if (shape is Rectangle rect)
                {
                    Console.WriteLine($"   Is Square: {rect.IsSquare()}, Diagonal: {rect.Diagonal}");
                    continue;
                }
                if (shape is Square sq)
                {
                    Console.WriteLine($"   Diagonal: {sq.Diagonal}");
                    continue;
                }
            }
            #endregion

        }

        #region ShowPublicationInfo method
        public static void ShowPublicationInfo(Publication pub)
        {
            string pubDate = pub.GetPublicationDate();
            Console.WriteLine($"{pub.Title}, " +
                      $"{(pubDate == "NYP" ? "Not Yet Published" : "published on " + pubDate):d} by {pub.Publisher}");
        }
        #endregion

    }
}

#region SimpleClass output
// The example displays the following output:
//	Type SimpleClass has 9 members:
//	ToString (Method):  Public, Declared by System.Object
//	Equals (Method):  Public, Declared by System.Object
//	Equals (Method):  Public Static, Declared by System.Object
//	ReferenceEquals (Method):  Public Static, Declared by System.Object
//	GetHashCode (Method):  Public, Declared by System.Object
//	GetType (Method):  Public, Declared by System.Object
//	Finalize (Method):  Internal, Declared by System.Object
//	MemberwiseClone (Method):  Internal, Declared by System.Object
//	.ctor (Constructor):  Public, Declared by SimpleClass
#endregion

#region Publication and book classes output
// The example displays the following output:
//        The Tempest, Not Yet Published by Public Domain Press
//        The Tempest, published on 8/18/2016 by Public Domain Press
//        The Tempest and The Tempest are the same publication: False
#endregion

#region Shape clases output
// The example displays the following output:
//         Rectangle: area, 120; perimeter, 44
//            Is Square: False, Diagonal: 15.62
//         Square: area, 25; perimeter, 20
//            Diagonal: 7.07
//         Circle: area, 28.27; perimeter, 18.85
#endregion