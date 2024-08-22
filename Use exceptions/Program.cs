
namespace Use_exceptions
{
    #region CustomException class
    class CustomException : Exception
    {
        public CustomException(string message)
        {
        }
    }
    #endregion

    #region CatchOrder class
    public class CatchOrder
    {
        public static void Main()
        {
            try
            {
                using (var sw = new StreamWriter("./test.txt"))//set the file location
                {
                    sw.WriteLine("Hello");
                }
            }
            // Put the more specific exceptions first.
            catch (DirectoryNotFoundException ex)//not found the lacation
            {
                Console.WriteLine(ex);
            }
            catch (FileNotFoundException ex)//not found file
            {
                Console.WriteLine(ex);
            }
            // Put the least specific exception last.
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Done");
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region TestThrow
            static void TestThrow()
            {
                throw new CustomException("Custom exception in TestThrow()");
            }
            #endregion

            #region Try Catch for TestThrow
            try
            {
                TestThrow();
            }
            catch (CustomException ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
            #endregion

            //Before the `catch` block is executed, the runtime checks for `finally` blocks. 
            //`Finally` blocks enable the programmer to clean up any ambiguous state that could be left over from an aborted `try` block, 
            //or to release any external resources (such as graphics handles, database connections, or file streams) 
            //without waiting for the garbage collector in the runtime to finalize the objects. For example:

            #region TestFinaly
            static void TestFinally()
            {
                FileStream? file = null;
                //Change the path to something that works on your machine.
                FileInfo fileInfo = new System.IO.FileInfo("./file.txt");

                try
                {
                    file = fileInfo.OpenWrite();
                    file.WriteByte(0xF);
                }
                finally
                {
                    // Closing the file allows you to reopen it immediately - otherwise IOException is thrown.
                    file?.Close();
                }

                try
                {
                    file = fileInfo.OpenWrite();
                    Console.WriteLine("OpenWrite() succeeded");
                }
                catch (IOException)
                {
                    Console.WriteLine("OpenWrite() failed");
                }
            }
            #endregion
        }
    }
}
