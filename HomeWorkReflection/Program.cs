using System;
using System.Reflection;

namespace HomeWorkReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(@"c:\Users\ygrek\RiderProjects\FiguresSerialize\FiguresSerialize\FiguresSerialize\bin\Debug\net5.0\FiguresSerialize.dll");
                Console.WriteLine(assembly.FullName);
                var myType = assembly.GetType("FiguresSerialize.Figure", false, true);
                Object[] arguments = new object[] { "triangle", 3, 2 }; 
                Object obj = Activator.CreateInstance(myType, arguments);
                MethodInfo method = myType.GetMethod("Display");
                method.Invoke(obj,null);
                PropertyInfo closedProperty = myType.GetProperty("closedProperty",BindingFlags.Instance | BindingFlags.NonPublic);
                
                if (closedProperty !=null)
                {
                    Console.WriteLine($"Closed Property: {closedProperty.Name}");
                }
                else
                {
                    Console.WriteLine("Closed property not found!");
                }
                closedProperty.SetValue(obj, "Set by Reflection");
                method.Invoke(obj,null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}