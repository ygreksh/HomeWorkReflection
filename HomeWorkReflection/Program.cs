using System;
using System.Reflection;

namespace HomeWorkReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(@"c:\Users\ygrek\RiderProjects\FiguresSerialize\FiguresSerialize\FiguresSerialize\bin\Debug\net5.0\FiguresSerialize.dll");
            Console.WriteLine(assembly.FullName);
            var myType = assembly.GetType("FiguresSerialize.Figure", false, true);
            Object[] arguments = new object[] { "triangle", 3, 2 }; 
            Object obj = Activator.CreateInstance(myType, arguments);
            MethodInfo method = myType.GetMethod("Display");
            method.Invoke(obj,null);
        }
    }
}