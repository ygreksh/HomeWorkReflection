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
                Object objTriangle = Activator.CreateInstance(myType, arguments);
                Object objHexagon = Activator.CreateInstance(myType, new object[] {"Hexagon", 6,3 });
                MethodInfo methodDisplay = myType.GetMethod("Display");
                MethodInfo methodPerimeter = myType.GetMethod("Perimeter");
                Object[] setSideLenghtArgs = new object[] { 33 };
                MethodInfo methodSetSideLenght = myType.GetMethod("SetSideLenght");
                //  вызов метода без параметров
                methodDisplay.Invoke(objTriangle,null);
                methodDisplay.Invoke(objHexagon,null);
                methodPerimeter.Invoke(objHexagon, null);
                //  вызов метода с параметрами
                methodSetSideLenght.Invoke(objHexagon, setSideLenghtArgs);
                methodDisplay.Invoke(objHexagon,null);
                //  Чтение и запись закрытого свойства
                PropertyInfo closedProperty = myType.GetProperty("closedProperty",BindingFlags.Instance | BindingFlags.NonPublic);
                var closedPropertyValue = closedProperty.GetValue(objTriangle);
                Console.WriteLine($"Closed Property: {closedProperty.Name} = {closedPropertyValue}");
                closedProperty.SetValue(objTriangle, "Set by Reflection");
                methodDisplay.Invoke(objTriangle,null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}