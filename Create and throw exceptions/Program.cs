using System.Threading.Tasks;

namespace Create_and_throw_exceptions
{
    #region SampleClass
    public class SampleClass
    {

    }
    #endregion

    #region Toast class
    public class Toast
    {
    }
    #endregion

    #region Define exception classes
    [Serializable]
    public class InvalidDepartmentException : Exception
    {
        public InvalidDepartmentException() : base() { }
        public InvalidDepartmentException(string message) : base(message) { }
        public InvalidDepartmentException(string message, Exception inner) : base(message, inner) { }
    }
    #endregion

    //2.An inappropriate call to an object is made, based on the object state. One example might be trying to
    //write to a read-only file. In cases where an object state doesn't allow an operation, throw an instance of
    //InvalidOperationException or an object based on a derivation of this class. The following code is an
    //example of a method that throws an InvalidOperationException object:
    #region Example 2
    public class ProgramLog
    {
        FileStream logFile = null!;
        public void OpenLog(FileInfo fileName, FileMode mode) { }

        public void WriteLog()
        {
            if (!logFile.CanWrite)
            {
                throw new InvalidOperationException("Logfile cannot be read-only");
            }
            // Else write data to the log and return.
        }
    }
    #endregion


    internal class Program
    {
        static void Main(string[] args)
        {
            //Programmers should throw exceptions when one or more of the following conditions are true:

            //1.The method can't complete its defined functionality. For example, if a parameter to a method has an invalid value:
            #region Example 1
            static void CopyObject(SampleClass original)
            {
                _ = original ?? throw new ArgumentException("Parameter cannot be null", nameof(original));
            }
            #endregion

            //3.When an argument to a method causes an exception. In this case, the original exception should be caught
            //and an ArgumentException instance should be created. The original exception should be passed to the
            //constructor of the ArgumentException as the InnerException parameter:
            #region Example 3
            static int GetValueFromArray(int[] array, int index)
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

            #region Exceptions in task-returning methods
            // Non-async, task-returning method.
            // Within this method (but outside of the local function),
            // any thrown exceptions emerge synchronously.
            static Task<Toast> ToastBreadAsync(int slices, int toastTime)
            {
                if (slices is < 1 or > 4)
                {
                    throw new ArgumentException(
                        "You must specify between 1 and 4 slices of bread.",
                        nameof(slices));
                }

                if (toastTime < 1)
                {
                    throw new ArgumentException(
                        "Toast time is too short.", nameof(toastTime));
                }

                return ToastBreadAsyncCore(slices, toastTime);

                // Local async function.
                // Within this function, any thrown exceptions are stored in the task.
                static async Task<Toast> ToastBreadAsyncCore(int slices, int time)
                {
                    for (int slice = 0; slice < slices; slice++)
                    {
                        Console.WriteLine("Putting a slice of bread in the toaster");
                    }
                    // Start toasting.
                    await Task.Delay(time);

                    if (time > 2_000)
                    {
                        throw new InvalidOperationException("The toaster is on fire!");
                    }

                    Console.WriteLine("Toast is ready!");

                    return new Toast();
                }
            }
            #endregion

        }
    }

    
}
