namespace Exception_Handling
{
    //An exception filter that always returns false can be used to examine all exceptions but not process them.
    // A typical use is to log exceptions:

    #region ExceptionFilter class
    public class ExceptionFilter
    {
        public static void Main()
        {
            try
            {
                string? s = null;
                Console.WriteLine(s.Length);
            }
            catch (Exception e) when (LogException(e))
            {
            }
            Console.WriteLine("Exception must have been handled");
        }

        private static bool LogException(Exception e)
        {
            Console.WriteLine($"\tIn the log routine. Caught {e.GetType()}");
            Console.WriteLine($"\tMessage: {e.Message}");
            return false;
        }
    }
    #endregion


    internal class Program
    {
        static void Main(string[] args)
        {
            //A try block is used by C# programmers to partition code that might be affected by an exception. Associated
            //catch blocks are used to handle any resulting exceptions. A finally block contains code that is run whether or not
            //an exception is thrown in the try block, such as releasing resources that are allocated in the try block. A try
            //block requires one or more associated catch blocks, or a finally block, or both.

            //The following examples show a try-catch statement, a try-finally statement, and a try-catch-finally statement.

            #region Example 1
            try
            {
                // Code to try goes here.
            }
            catch (Exception ex)
            {
                // Code to handle the exception goes here.
                // Only catch exceptions that you know how to handle.
                // Never catch base class System.Exception without
                // rethrowing it at the end of the catch block.
            }
            #endregion

            #region Example 2
            try
            {
                // Code to try goes here.
            }
            finally
            {
                // Code to execute after the try block goes here.
            }
            #endregion

            #region Example 3
            try
            {
                // Code to try goes here.
            }
            catch (Exception ex)
            {
                // Code to handle the exception goes here.
            }
            finally
            {
                // Code to execute after the try (and possibly catch) blocks
                // goes here.
            }
            #endregion

            //Catch exceptions when the following conditions are true:
            //1.You have a good understanding of why the exception might be thrown, and you can implement a specific
            //recovery, such as prompting the user to enter a new file name when you catch a FileNotFoundException object.

            //2.You can create and throw a new, more specific exception

            #region Catch block 
            int GetInt(int[] array, int index)
            {
                try
                {
                    return array[index];
                }
                catch (IndexOutOfRangeException e)
                {
                    throw new ArgumentOutOfRangeException(
                        "Parameter index is out of range.", e);
                }
            }
            #endregion

            //You can also specify exception filters to add a boolean expression to a catch clause. Exception filters indicate that
            //a specific catch clause matches only when that condition is true. In the following example, both catch clauses
            //use the same exception class, but an extra condition is checked to create a different error message:

            #region Another example
            int GetInt_2(int[] array, int index)
            {
                try
                {
                    return array[index];
                }
                catch (IndexOutOfRangeException e) when (index < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Parameter index cannot be negative.", e);
                }
                catch (IndexOutOfRangeException e)
                {
                    throw new ArgumentOutOfRangeException(
                        "Parameter index cannot be greater than the array size.", e);
                }
            }
            #endregion

        }
    }
}
