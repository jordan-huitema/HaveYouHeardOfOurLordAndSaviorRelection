using System;
using System.Reflection;

namespace HaveYouHeardOfOurLordAndSaviorRelection
{
    public class Program
    {
        Test _Test = new Test();
        public static void Main(string[] args)
        {
            // I am only showing method reflection here because i dont have all day
            // You can use reflection for constructions, fields, properties and attribues and more
            // There are also a lot more useful properties and methods than the ones im showing here but im only showing the most useful to me so you get a good idea of the format and syntax

            // Method Example, See https://docs.microsoft.com/en-us/dotnet/api/system.reflection.methodinfo?view=net-5.0#properties for more info
            // Use typeof(Class) and GetMethods to build array of methods in class
            // It is important to use BindingFlags because by default you will get a base methods of a class and not the declared methods, it is also important to define what access type you want unless you want a blank output.
            MethodInfo[] methodArr = typeof(Test).GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Console.WriteLine("Methods: ");
            Console.WriteLine("");
            Console.WriteLine("Number of Methods: " + methodArr.Length);
            Console.WriteLine("");
            Console.WriteLine("Methods List:");

            foreach (var item in methodArr)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" -" + item.Name);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("   Attributes    : " + item.Attributes);
                Console.WriteLine("   Return Type   : " + item.ReturnType);

                // Building array of parameters in the current item/method, there are binding flags you can use here but the default is sufficent
                ParameterInfo[] parameterArr = item.GetParameters();
                if (parameterArr.Length > 0)
                {
                    Console.WriteLine("     Parameters:");
                    foreach (var itemParam in parameterArr)
                    {
                        Console.WriteLine("   Parameter  : " + itemParam.Name);
                        Console.WriteLine("     -Type    : " + itemParam.ParameterType);
                        Console.WriteLine("     -Default : " + itemParam.DefaultValue);
                        Console.WriteLine("     -Optional: " + itemParam.IsOptional);
                    }
                }
                else {
                    Console.WriteLine("   Parameters    : None");
                }
            }

            Console.ReadKey();
        }
    }
    public class Test
    {
        //Methods
        public string Method1()
        {
            return "string 1";
        }

        private int Method2(int inputInt)
        {
            return 2;
        }

        protected void Method3(string inputString, int inputInt, object inputObject){}

        //Constructors

    }
}
