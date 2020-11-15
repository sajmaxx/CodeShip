using System;
using System.ComponentModel.Design;


/// <summary>
/// why handle errors?
///     First and foremost by catching errors, we can gracefully escape a crash condition
///     Prevent unhappy users, prevent data loss.
///     Fix or retry the operation!
///
/// Outdated way to handle errors is using a custom error handling code!
/// Use custome exceptions instead!
/// </summary>
///
/// Disadvantages of using custom error messages
///     errors do not bubble up the call stack
///     cannot catch some errors at higher level is not automatically possible
///     cannot catch some errors at a lower level.
///     every time the error returning method is called, you need an if or switch method!
///
///
///
/// Why are exceptions better at error handling!
///     1) Don't need to know all the error or success codes
///     2) Don't need if/switch statements
///     3) more readable, less clutter
///     4) no magic numbers
///     5) exceptions bubble up
///     6) catch exceptions in higher up in one place 
///     7) handle system errors
///     8) generate exceptions from constructors as well
///
///
/// HIGHER LEVEL DEFINITION OF EXCEPTIONS
///     All exceptions inherit from System.Exception
///     


namespace HandleErrors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var baba = Calculate(4,6, '*');
            var gogo = Calculate(4,5,'/');

            //causing an exception

            var ecc = Calculate(4, 0, '/');

            var coco = Calculate(6,5,'?');

            try
            {
                Employee someworkah = new Employee();
                var something = someworkah.FirstName;
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine("was aaaaaaaaaaaaaaaap ArgumentNullException");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            

        }


        public static int Calculate(int number1, int number2, char operato)
        {
            try
            {
                switch (operato)
                {
                    case '*':
                    {
                        return number1 * number2;

                    }

                    case '/':
                    {
                        return number1 / number2;
                    }
                    default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(operato), "Operator was an invalid selection");
                    }
                }

                return 0;
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine("Argument Null Exception Custom Message");
                Console.WriteLine(ae.Message);
            }
            catch (ArgumentOutOfRangeException aree)
            {
                Console.WriteLine("Arg Out of R E Type");
            }
            catch (Exception e)
            {
                Console.WriteLine("wawaaaa " + e.Message);

            }
            finally
            {
                Console.WriteLine("Clean up code for example Dispose() or some other finalizations");

            }
            return  0;            
        }
    }
}
