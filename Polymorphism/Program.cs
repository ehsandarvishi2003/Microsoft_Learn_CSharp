namespace Polymorphism
{
    #region Shape
    public class Shape
    {
        // A few example members
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }

        // Virtual method
        public virtual void Draw()
        {
            Console.WriteLine("Performing base class drawing tasks");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            // Code to draw a circle...
            Console.WriteLine("Drawing a circle");
            base.Draw();
        }
    }
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            // Code to draw a rectangle...
            Console.WriteLine("Drawing a rectangle");
            base.Draw();
        }
    }
    public class Triangle : Shape
    {
        public override void Draw()
        {
            // Code to draw a triangle...
            Console.WriteLine("Drawing a triangle");
            base.Draw();
        }
    }
    #endregion

    #region Base Class
    public class BaseClass
    {
        public virtual void DoWork() { }
        public virtual int WorkProperty
        {
            get { return 0; }
        }
    }
    public class DerivedClass : BaseClass
    {
        public override void DoWork() { }
        public override int WorkProperty
        {
            get { return 0; }
        }
    }
    #endregion

    #region Hide base class members with new members
    public class BaseClass_2
    {
        public void DoWork() { WorkField++; }
        public int WorkField;
        public int WorkProperty
        {
            get { return 0; }
        }
    }

    public class DerivedClass_2 : BaseClass_2
    {
        public new void DoWork() { WorkField++; }
        public new int WorkField;
        public new int WorkProperty
        {
            get { return 0; }
        }
    }
    #endregion

    #region Prevent derived classes from overriding virtual members
    public class A
    {
        public virtual void DoWork() { }
    }
    public class B : A
    {
        public override void DoWork() { }
    }
    public class C : B
    {
        public override void DoWork() { }
    }
    public class D : C
    {
        public override void DoWork() { }
    }
    #endregion

    #region Access base class virtual members from derived classes
    public class Base
    {
        public virtual void DoWork() {/*...*/ }
    }
    public class Derived : Base
    {
        public override void DoWork()
        {
            //Perform Derived's work here
            //...
            // Call DoWork on base class
            base.DoWork();
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Shape operations
            // Polymorphism at work #1: a Rectangle, Triangle and Circle
            // can all be used wherever a Shape is expected. No cast is
            // required because an implicit conversion exists from a derived
            // class to its base class.
            var shapes = new List<Shape>
            {
                new Rectangle(),
                new Triangle(),
                new Circle()
            };

            // Polymorphism at work #2: the virtual method Draw is
            // invoked on each of the derived classes, not the base class.
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
            /* Output:
                Drawing a rectangle
                Performing base class drawing tasks
                Drawing a triangle
                Performing base class drawing tasks
                Drawing a circle
                Performing base class drawing tasks
            */
            #endregion

            #region Base Class operations
            DerivedClass B = new DerivedClass();
            B.DoWork();  // Calls the new method.

            BaseClass A = B;
            A.DoWork();  // Also calls the new method.
            #endregion

            #region Hide base class members with new members operations
            DerivedClass_2 C = new DerivedClass_2();
            B.DoWork();  // Calls the new method.

            BaseClass_2 D = (BaseClass_2)C;
            A.DoWork();  // Calls the old method.
            #endregion
        }
    }
}
