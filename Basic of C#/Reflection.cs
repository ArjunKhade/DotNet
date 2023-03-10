using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace ReflectionExample
{
    class Program
    {

        //D:\Trainings\ActsAug22\Day2\InheritanceExamples\bin\Debug\InheritanceExamples.exe
        static void Main()
        {
            Assembly asm = Assembly.LoadFrom(@"C:\Users\DELL\OneDrive\Desktop\PG-DAC\09Ms.Net\Day2\Day2\InheritanceExamples\bin\Debug\InheritanceExamples.exe");
            //Assembly.GetAssembly(typeof(string));
            //Console.WriteLine(asm.FullName);
            Console.WriteLine(asm.GetName().Name);
            Type[] arrTypes = asm.GetTypes();
            foreach (Type t in arrTypes)
            {
                Console.WriteLine("    "+ t.Name);
                MethodInfo[] arrMethods = t.GetMethods();
                //for...
            }
            Console.ReadLine();
        }
    }
}
