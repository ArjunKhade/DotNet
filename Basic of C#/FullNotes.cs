****************Day1*****************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBasics
{
    class Program
    {
      
        static void Main1()
        {
            //System.Console.WriteLine("Hello World");
            //System.Console.ReadLine();
            System.Console.WriteLine("Hello World");
            System.Console.ReadLine();
        }
        static void Main2()
        {
            Console.WriteLine("Hello World");
            Console.ReadLine();
        }
        static void Main()
        {
            Class1 o; // o is a reference of type Class1
            o = new Class1(); //new Class1() is an instance of Class1
            o.Display();
            o.Display("Hello");
            int ans;
            ans = o.Add(10, 20);
            Console.WriteLine(ans);
            ans = o.Add(10, 20, 30);
            Console.WriteLine(ans);

            Console.ReadLine();
        }
    }

    public class Class1
    {
        public void Display()
        {
            Console.WriteLine("Display");
        }
        public void Display(string s)
        {
            Console.WriteLine("Display"+ s);
        }

        //,method overloading
        //public int Add(int a, int b)
        //{
        //    return a + b;
        //}
        //public int Add(int a, int b, int c)
        //{
        //    return a + b + c;
        //}

        //optional parameters with default values
        public int Add(int a=0, int b=0, int c=0)
        {
            return a + b + c;
        }
    }
   
}

namespace MyNamespace
{
    namespace n2
    {
        public class Class1
        {

        }

    }
    public class Class1
    {

    }
}

*************************day 2 ***********************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBasics
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();

            int ans;
            ans = o.Add(10, 20, 30); //positional parameters
            Console.WriteLine(ans);

            ans = o.Add(c: 30, b: 20, a: 10); //named parameters
            //ans = o.Add(c: 30); //named parameters
            //ans = o.Add(b: 20); //named parameters
            ans = o.Add(b: 20, a: 10); //named parameters
            ans = o.Add(10,c:30); //named parameters

            Console.ReadLine();
        }
        static void Main()
        {
            Class1 o = new Class1();

            o.Display();

            Console.ReadLine();
        }
    }
    //class Program2
    //{
    //    static void Main()
    //    {
    //        Console.ReadLine();
    //    }
    //    static void Main(string[] args)
    //    {
    //        Console.ReadLine();
    //    }
    //}

    public class Class1
    {
        public void Display()
        {

            int i = 100;
            //Console.WriteLine("display");
            //local functions
            //local func can be defined within another func
            //local func can only be called from the outer func
            //local func can access variables defined in outer func
            //local func is implicitly private 
            void Show()
            {
                Console.WriteLine("Show");
                Console.WriteLine(i);
            }
            Show();
        }
        public int Add(int a=0, int b = 0, int c = 0)
        {
            return a + b + c;
        }
    }
}

**********
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorsAndObjectInitializers
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            Console.WriteLine(o.P3);

            Class1 o2 = new Class1(40, 50, 60);
            Console.WriteLine(o2.P3);

            Console.ReadLine();
        }
        static void Main2()
        {
            Class3 o1 = new Class3(10, 20, 30);
            o1.P4 = 40;
            o1.P5 = 50;
            o1.P6 = 60;
            o1.P7 = 70;

            //object initializer
            Class3 o2 = new Class3(10, 20, 30) { P4 = 40, P5 = 50, P6 = 60, P7 = 70 };
            Class3 o3 = new Class3() { P4 = 40, P5 = 50, P6 = 60, P7 = 70 };
            Class3 o4 = new Class3{ P4 = 40, P5 = 50, P6 = 60, P7 = 70 };

            //Class3 o5 = new Class3(10, 20, 30);



            //Class3 o6 = new Class3 { I = 10,P2= 20, P3= 30 };
            //is same as
            //Class3 o6 = new Class3();
            //o.I = 10;
            //o.P2 = 20;
            //o.P3 = 30;



            Console.ReadLine();
        }

        static void Main()
        {
            Class1 o = new Class1();
            Class1 o2 = new Class1();
            Class1 o3 = new Class1();

            o = null;
            o2 = null;
            o3 = null;

            //do not do this
            Console.ReadLine();
            //GC.Collect();

            Console.ReadLine();
        }
    }
    public class Class1
    {
        #region properties
        private int i;
        public int I  //property
        {
            set
            {
                if (value < 100)
                    i = value;
                else
                    Console.WriteLine("Invalid value for i");
            }
            get
            {
                return i;
            }
        }
        private int p2;
        public int P2
        {
            get { return p2; }
        }
       
        public int P3 { get; set; }
        #endregion

        public Class1()
        {
            I = 10;
            p2 = 20;
            P3 = 30;
            Console.WriteLine("no param cons called");
        }
        public Class1(int I, int P2,int P3)
        {
            this.I = I;
            this.p2 = P2;
            this.P3 = P3;
            Console.WriteLine("int param cons called");
        }
        ~Class1()
        {
            Console.WriteLine("destructor called");
        }
    }
    public class Class2
    {
        #region properties
        private int i;
        public int I  //property
        {
            set
            {
                if (value < 100)
                    i = value;
                else
                    Console.WriteLine("Invalid value for i");
            }
            get
            {
                return i;
            }
        }
        private int p2;
        public int P2
        {
            get { return p2; }
        }

        public int P3 { get; set; }
        #endregion

       
        public Class2(int I=10, int P2=20, int P3=30)
        {
            this.I = I;
            this.p2 = P2;
            this.P3 = P3;
            Console.WriteLine("int param cons called");
        }
    }

    public class Class3
    {
        #region properties
        private int i;
        public int I  //property
        {
            set
            {
                if (value < 100)
                    i = value;
                else
                    Console.WriteLine("Invalid value for i");
            }
            get
            {
                return i;
            }
        }
        private int p2;
        public int P2
        {
            get { return p2; }
        }

        public int P3 { get; set; }
        public int P4 { get; set; }
        public int P5{ get; set; }
        public int P6{ get; set; }
        public int P7 { get; set; }
        public int P8 { get; set; }
        #endregion


        public Class3(int I = 10, int P2 = 20, int P3 = 30)
        {
            this.I = I;
            this.p2 = P2;
            this.P3 = P3;
            Console.WriteLine("int param cons called");
        }
    }
}

********
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExamples1
{
    class Program
    {
        static void Main1()
        {
            DerivedClass o = new DerivedClass();
            //o.
        }
    }
    public class BaseClass 
    {
        public int i;
    }
    public class DerivedClass : BaseClass 
    {
        public int j;
    }
}
//private -same class
//public -everywhere
//protected -same class, derived class
//internal -same class, same assembly(same project)
//protected internal -same class, derived class,same assembly(same project)
//private protected -same class, derived class which is in the same assembly
namespace InheritanceExamples2
{
    class Program
    {
        static void Main()
        {
            //BaseClass o = new BaseClass();
            //o.
            TestAccessSpecifiers.BaseClass o2 = new TestAccessSpecifiers.BaseClass();
            //o2.
        }
    }
    public class BaseClass
    {
        public int PUBLIC;
        private int PRIVATE;
        protected int PROTECTED;
        internal int INTERNAL;
        protected internal int PROTECTED_INTERNAL;
        private protected int PRIVATE_PROTECTED;
        int a; //private

    }
    public class DerivedClass : TestAccessSpecifiers.BaseClass     //: BaseClass   
    {

        void DoNothing()
        {
            //this.
        }
    }
}

*****************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class Program
    {
        static void Main1()
        {
            //Class1 o = new Class1();
            ////o.i = 500;
            ////Console.WriteLine(o.i);
            ////o.i = ++o.i + o.i++ - --o.i - o.i--;
            //o.Seti(++o.Geti());
            //o.Seti(500);
            //Console.WriteLine(o.Geti());
            Console.ReadLine();
        }
        static void Main2()
        {
            Class1 o = new Class1();
            o.I = 200; //set
            Console.WriteLine(o.I); //get

            //Console.WriteLine(o.StudentName);
            //o.P2 = 200;

            Console.ReadLine();
        }
        static void Main()
        {
            Class1 o = new Class1();
            
            o.P3 = 1000;
            Console.WriteLine(o.P3);
            Console.ReadLine();
        }
    }
    //public class Class1
    //{
    //    private int i;
    //    public void Seti(int VALUE )
    //    {
    //        if(VALUE <100)
    //            i = VALUE;
    //        else
    //            //throw new Exception("...");
    //            Console.WriteLine("Invalid value for i");
    //    }
    //    public int Geti()
    //    {
    //        return i;
    //    }
    //}
    public class Class1
    {
        private int i;
        public int I  //property
        {
            set
            {
                if(value < 100)
                    i = value;
                else
                    Console.WriteLine("Invalid value for i");
            }
            get
            {
                return i;
            }
        }

        //private string studentName;
        //public string StudentName
        //{
        //    get { return studentName; }
        //    set { }
        //}


        //read only
        private int p2;
        public int P2
        {
            get { return p2; }
        }
        #region commented code
        //public int P3; //----> field

        //private int p3;
        //public int P3
        //{
        //    set { p3 = value; }
        //    get { return p3; }
        //}
        #endregion
        //automatic property (auto)
        //property with no validations
        //compiler generates a private variable
        //compiler generates code for get and set
        public int P3 { get; set; }
    }
}

***************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMembers
{
    class Program
    {
        static void Main()
        {
            Class1 o1;
            o1 = new Class1();
            Class1.static_Display();
            Class1.static_i = 1000;
            Class1.J = 10;
            o1.i = 100;
            o1.Display();
            Class1 o2 = new Class1();
            o2.i = 200;

            Console.ReadLine();
        }
    }
    public class Class1
    {
        public int i;
        public static int static_i; //single copy for class

        public void Display()
        {
            Console.WriteLine("display");
            Console.WriteLine(i);
            Console.WriteLine(static_i);
        }
        public static void static_Display()
        {
            //Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("static display");
            //Console.WriteLine(i);
            Console.WriteLine(static_i);
        }
        private static int j;
        public static int J  //property
        {
            set
            {
                if (value < 100)
                    j = value;
                else
                    Console.WriteLine("Invalid value for j");
            }
            get
            {
                return j;
            }
        }
        static Class1()
        {
            Console.WriteLine("static cons called");
            static_i = 1;
            j = 2;

        }
    }

    //to do :
    //create a static class
    //it can only contain static members
    //cannot be instantiated
    //cannot be used as a base class

}
//why static variable? --> single copy
//why property? --> validations

//why static property? --> single copy with validations
//why constructor? -->  to initialize data members
//why static constructor? --> to initialize static members

//when is the static constructor called? --> when the class is loaded
//when is the class loaded? --> when the first object is created
//OR when a static member is accessed for the first time

//static cons is implicitly called
//static cons cant have parameters
//static cons cannot be overloaded
//static cons does not have any access specifier(implicitly private)

******************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAccessSpecifiers
{
    public class BaseClass
    {
        public int PUBLIC;
        private int PRIVATE;
        protected int PROTECTED;
        internal int INTERNAL;
        protected internal int PROTECTED_INTERNAL;
        private protected int PRIVATE_PROTECTED;
    }
}

************************************day 3 ******************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//overloading, hiding and overriding
namespace InheritanceExamples
{
    class Program
    {
        static void Main1()
        {
            DerivedClass o = new DerivedClass();
            //o.Display1();
            //o.Display1("aaa");
            o.Display2();
            o.Display3();
            Console.ReadLine();
        }

        static void Main2()
        {
            BaseClass o;
            o = new BaseClass();
            o.Display2();
            o.Display3();

            Console.WriteLine();
            o = new DerivedClass();
            o.Display2();
            o.Display3();

            Console.WriteLine();
            o = new SubDerivedClass();
            o.Display2();
            o.Display3();

            Console.WriteLine();
            o = new SubSubDerivedClass();
            o.Display2();
            o.Display3();

            Console.ReadLine();
        }
    }
    public class BaseClass
    {
        public void Display1()
        {
            Console.WriteLine("baseclass display1");
        }
        public void Display2()
        {
            Console.WriteLine("baseclass display2");
        }
        public virtual void Display3()
        {
            Console.WriteLine("baseclass display3");
        }
    }
    public class DerivedClass : BaseClass
    {
        //overloading a base class method
        public void Display1(string s)
        {
            Console.WriteLine("derivedclass display1" + s);
        }

        //hiding a base class method
        public new void Display2()
        {
            Console.WriteLine("derivedclass display2");
        }

        ////overriding a base class method
        public override void Display3()
        {
            Console.WriteLine("derivedclass display3");
        }
    }

    public class SubDerivedClass : DerivedClass
    {
       
        ////overriding a base class method
        public sealed override void Display3()
        {
            Console.WriteLine("subderivedclass display3");
        }
    }
    public class SubSubDerivedClass : SubDerivedClass
    {
        //public override void Display3()  --- error
        public new void Display3()
        {
            Console.WriteLine("subsubderivedclass display3");
        }
    }
}
//1.derived class can overload base class method
//derived class method has diff signature
//derivedobj.GetNetSalary(); --base class method
//derivedobj.GetNetSalary(...); --derived clas method

//2.derived class can hide the base class method
//derived class method has same signature
//derivedobj.GetNetSalary(); --derived clas method
//ANY method can be hidden


//3.derived class can override the base class method
//derived class method has same signature
//derivedobj.GetNetSalary(); --derived clas method
//only a VIRTUAL method can be overridden


//Virtual methods are late bound
//run time binding/ run time polymorphism



namespace InheritanceExamples3
{
    class Program
    {

        static void Main()
        {
            //BaseClass o1 = new BaseClass(); //error - cannot instantiate an abstract class
            DerivedClass o = new DerivedClass();
            //o.
            Console.ReadLine();

        }

    }

    //abstract class without any abstract members
    public abstract class BaseClass
    {
        public void Display()
        {
            Console.WriteLine("display");
        }
    }


    public class DerivedClass : BaseClass
    {
        public void DerivedMethod()
        {
            Console.WriteLine("derived");

        }
    }



    //abstract class with abstract members
    public abstract class BaseClass2
    {
        public abstract void Display(); //abstract method - contains only signature, no code body
        public abstract void Show(); //abstract method - contains only signature, no code body

    }
    public class DerivedClass2 : BaseClass2
    {
        public override void Display()
        {
            Console.WriteLine("display");
        }

        public override void Show()
        {
            Console.WriteLine("show");
        }
    }
    public abstract class DerivedClass3 :BaseClass2
    {

    }
}
/*
                                Abstract Class         Sealed Class 
Can be instantiated             NO                      YES
Can be used as a base class     YES                     NO
 

TO DO - create a sealed class
 */
 
 ***********
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces1
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            //method 1
            o.Insert();

            //method 2
            IDbFunctions oIDb;
            oIDb = o;
            oIDb.Insert();

            //method 3
            ((IDbFunctions)o).Insert();

            //method 4
            (o as IDbFunctions).Insert();

            Console.ReadLine();
        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Delete");
        }
        public void Insert()
        {
            Console.WriteLine("Insert");
        }
        public void Update()
        {
            Console.WriteLine("Update");
        }
        public void Display()
        {
            Console.WriteLine("Display");
        }
    }
}


namespace Interfaces2
{
    class Program
    {
        static void Main2()
        {
            Class1 o = new Class1();
            //o.Delete();

            (o as IDbFunctions).Delete();

            IFileFunctions oIFile;
            oIFile = o;
            oIFile.Delete();

            Console.ReadLine();
        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
    public interface IFileFunctions
    {
        void Open();
        void Close();
        void Delete();
    }
    public class Class1 : IDbFunctions, IFileFunctions
    {
        void IDbFunctions.Delete()
        {
            Console.WriteLine("idb.Delete");
        }
        public void Insert()
        {
            Console.WriteLine("Insert");
        }
        public void Update()
        {
            Console.WriteLine("Update");
        }
        public void Display()
        {
            Console.WriteLine("Display");
        }

        //void IFileFunctions.Open()
        //{
        //    Console.WriteLine("Open");
        //}

        //void IFileFunctions.Close()
        //{
        //    Console.WriteLine("Close");
        //}

        void IFileFunctions.Delete()
        {
            Console.WriteLine("ifile.Delete");
        }

        public void Open()
        {
            Console.WriteLine("Open");
        }

        public void Close()
        {
            Console.WriteLine("Close");
        }
    }
}

namespace Interfaces3
{
    class Program
    {
        static void Main1()
        {
            Class1 o1 = new Class1();
            Class2 o2 = new Class2();

            IDbFunctions oIDb;
            oIDb = o1;
            oIDb.Insert();

            oIDb = o2;
            oIDb.Insert();


            Console.ReadLine();
        }

        static void Main()
        {
            Class1 o1 = new Class1();
            Class2 o2 = new Class2();
            InsertMethod(o1);
            InsertMethod(o2);
            Console.ReadLine();
        }
        static void InsertMethod(IDbFunctions oIDb) //can receive an object of any class that implements IDbFunctions
        {
            oIDb.Insert();
        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
      
    }
    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("CLASS1 Delete");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 Update");
        }
        public void Display()
        {
            Console.WriteLine("Class1 Display");
        }
    }

    public class Class2 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("CLASS2 Delete");
        }

        public void Insert()
        {
            Console.WriteLine("Class2 Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class2 Update");
        }
        public void Display()
        {
            Console.WriteLine("Class2 Display");
        }
    }
}
//advantages of interfaces

//contract - class MUST implement all the interface methods
//similar code in entire project for all developers
//polymorphic code
//design patterns 

//to do -- inheritance with interfaces
//i1 - a(),b()
//i2 : i1 - c(), d()
//
 
 ***********
 using System;

namespace Interfaces1
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            //o.Select();

            (o as IDbFunctions).Select();

            Console.ReadLine();
        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
        public void Select()
        {
            Console.WriteLine("default implementation of select");
        }
    }
    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Delete");
        }
        public void Insert()
        {
            Console.WriteLine("Insert");
        }
        public void Update()
        {
            Console.WriteLine("Update");
        }
        public void Display()
        {
            Console.WriteLine("Display");
        }
    }
}

namespace Interfaces2
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            o.Select();

            //(o as IDbFunctions).Select();

            Console.ReadLine();
        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
        public void Select()
        {
            Console.WriteLine("default implementation of select");
        }
    }
    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Delete");
        }
        public void Insert()
        {
            Console.WriteLine("Insert");
        }
        public void Update()
        {
            Console.WriteLine("Update");
        }
        public void Display()
        {
            Console.WriteLine("Display");
        }
        public void Select()
        {
            Console.WriteLine("public Select");
        }
    }
}

namespace Interfaces3
{
    class Program
    {
        static void Main()
        {
            Class1 o = new Class1();
            //o.Select();

            (o as IDbFunctions).Select();

            Console.ReadLine();
        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
        public void Select()
        {
            Console.WriteLine("default implementation of select");
        }
    }
    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Delete");
        }
        public void Insert()
        {
            Console.WriteLine("Insert");
        }
        public void Update()
        {
            Console.WriteLine("Update");
        }
        public void Display()
        {
            Console.WriteLine("Display");
        }
        void IDbFunctions.Select()
        {
            Console.WriteLine("explicit Select");
        }
    }
}

**************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefAndValueTypes
{
    class Program
    {
        static void Main1()
        {
            Class1 o1 = new Class1();
            Class1 o2 = new Class1();
            o1.i = 100;
            o2.i = 200;
            o1 = o2;
            o2.i = 300;
            Console.WriteLine(o1.i);
            Console.WriteLine(o2.i);

            //200,300
            //300,300
            Console.ReadLine();
        }

        static void Main2()
        {
            int o1, o2;
            o1 = 100;
            o2 = 200;
            o1 = o2;
            o2 = 300;
            Console.WriteLine(o1);
            Console.WriteLine(o2);
            Console.ReadLine();
        }
        static void Main3()
        {
            string o1, o2;
            o1 = "100";
            o2 = "200";
            o1 = o2;
            o2 = "300";
            Console.WriteLine(o1);
            Console.WriteLine(o2);
            Console.ReadLine();
        }

        static void DataTypes()
        {
            byte b1;
            sbyte b2;
            char ch;
            short sh1;
            ushort sh2;
            int i1; //System.Int32 //4
            uint i2;//System.UInt32 //4
            long l1;
            ulong l2;
            float f;
            double d;
            decimal d2;
            bool b;

            string s;
            object o;

        }

        static void Main()
        {
            int i;
            int j;

            Init(out i, out j);
            //Swap(ref i,ref j);
            Swap2( i, j);
            Console.WriteLine(i);
            Console.WriteLine(j);
            Console.ReadLine();
        }
        static void Swap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
        //out is similar to ref - changes made in func reflect back in calling code
        //the initial value is discarded
        //out variables MUST be initialized in the function
        static void Init(out int i, out int j)
        {
            //Console.WriteLine(i); //error
            i = 10;
            j = 20;
            Console.WriteLine(i);
        }
        
    }
    public class Class1
    {
        public int i;
    }
}

******************************************Day 4 Array Generic Collections***********************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//structs
namespace ValueTypes1
{
    class Program
    {
        static void Main1()
        {
            int i = new int();
            //int i=0;
            Console.WriteLine(i);
            Console.ReadLine();
        }
        static void Main2()
        {
            MyPoint p = new MyPoint(10, 20, 30);
            Console.WriteLine(p.A);
            Console.ReadLine();
        }
    }
    //structs are Value Types - stored on stack. Faster than Heap operations
    //No Inheritance allowed in structs
    //Parameterless constructor not allowed in structs
    public struct MyPoint
    {
        public int A
        {
            get; set;
        }
        public int X, Y;
        private int b;
        public int B
        {
            get { return b; } set { b = value; }
        }
        public MyPoint(int X = 0, int Y = 0, int A = 0)
        {
            Console.WriteLine("cons called");
            this.b = 0;
            this.X = X;
            this.Y = Y;
            this.A = A;
        }
        
    }
}

namespace ValueTypes2
{
    class Program
    {
        static void Main()
        {
            object o;
            int i = 100;
            o = i;  //ref type = value type
            //BOXING a value type

            int j;
            j =(int) o;
            //UNBOXING

            Console.ReadLine();
        }
        static void Main2()
        {
            //Display1(0);
            Display2(TimeOfDay.Morning);
            Console.ReadLine();
        }
        static void Display1(int t)
        {
            if (t == 10)
                Console.WriteLine("Good Morning");
            else if (t == 11)
                Console.WriteLine("Good Afternoon");
            else if (t == 12)
                Console.WriteLine("Good Evening");
            else if (t == 13)
                Console.WriteLine("Good Night");
        }
        static void Display2(TimeOfDay t)
        {
            if (t == TimeOfDay.Morning)
                Console.WriteLine("Good Morning");
            else if (t == TimeOfDay.Afternoon)
                Console.WriteLine("Good Afternoon");
            else if (t == TimeOfDay.Evening)
                Console.WriteLine("Good Evening");
            else if (t == TimeOfDay.Night)
                Console.WriteLine("Good Night");
        }
    }
    public enum TimeOfDay //: long
    {
        Morning = 10,
        Afternoon=20,
        Evening,
        Night
    }
}


*********
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefAndValueTypes
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            o.i = 100;
            //DoSomething1(o);
            //DoSomething2(o);
            DoSomething3(ref o);
            Console.WriteLine(o.i);
            Console.ReadLine();
        }
        static void DoSomething1(Class1 obj) //obj =o
        {
            //changes made in func (changing value of properties) is reflected in calling code o
            obj.i = 200;
        }
        static void DoSomething2(Class1 obj)  //obj = o
        {
            //changes made in func (obj pointing to some other block) is NOT reflected in calling code o

            obj = new Class1();
            obj.i = 200;
        }
        static void DoSomething3(ref Class1 obj)  //obj = o
        {
            //changes made in func (obj pointing to some other block) is reflected in calling code o

            obj = new Class1();
            obj.i = 200;
        }
        static void DoSomething1(in Class1 obj, in int i) //obj =o
        {

            //in is readonly - cant change 
            //i = 10;
            //obj = new Class1();
            obj.i = 200;
        }
        static void Main()
        {
            Emp o = new Emp();
            Emp2 o2 = new Emp2();
            //o2.EmpNo = 10;

            Console.ReadLine();
        }
    }
    public class Class1
    {
        public int i;
    }

    public class Emp
    {
        private int empNo;
        public int EmpNo
        {
            get { return empNo; }
        }
        public Emp()
        {
            empNo = 10;
        }
    }
    public class Emp2
    {
        private int empNo;
        public int EmpNo
        {
            get { return empNo; }
            //property accessor
            //can only be given for one out of get/set
            //access can only be reduced, not increased
            //public
            //protected internal
            //protected   OR   internal
            //private protected
            //private
            private set { empNo = value; }
        }
        public Emp2()
        {
            EmpNo = 10;
        }
    }
    public class Emp3
    {
        public int EmpNo
        {
            get;
        }
        public Emp3()
        {
            EmpNo = 10;
        }
    }
}

***********
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a;
            //a = 100;
            //a = null;
            //a = ReadValueFromDb();

            int? i = 10;
            i = null;

            int j;
            if (i != null)
                j = (int)i;
            else
                j = 0;
            
            if (i.HasValue)
                j = i.Value;
            else
                j = 0;

            j = i.GetValueOrDefault(); 
            j = i.GetValueOrDefault(10);
            j = i ?? 10; //null coalescing operator

            Console.WriteLine(j);
            Console.ReadLine();
        }
    }
}

**************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableExample
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            o.Display();
            o.Dispose();
            //o.Display();
            Console.ReadLine();
        }
        static void Main2()
        {
            using (Class1 o = new Class1())
            {
                o.Display();
            }
            
            Console.ReadLine();
        }
        static void Main()
        {
            Class2 o = new Class2();
            o.Display();
            o.Dispose();

            o.Display();
            Console.ReadLine();
        }
    }
    public class Class1 : IDisposable
    {
        public Class1()
        {
            //open file here
            //open db here
            Console.WriteLine("class1 constructor");
        }
        public void Display()
        {
            Console.WriteLine("Display called");
        }
        public void Dispose()
        {
            //close file
            //close db
            Console.WriteLine("Dispose code called. Write code here instead of Destructor");
        }
    }

    public class Class2 : IDisposable
    {
        public Class2()
        {
            //open file here
            //open db here
        }
        bool isDisposed;
        public void Display()
        {
            CheckForDisposed();
            Console.WriteLine("Display called");
        }

        public void Dispose()
        {
            CheckForDisposed();
            //close file
            //close db conn
            Console.WriteLine("Dispose code called. Write code here instead of Destructor");
            isDisposed = true;
        }
        private void CheckForDisposed()
        {
            if (isDisposed)
                throw new ObjectDisposedException("Class1");

        }
    }

}

**************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main1()
        {
            IntegerStack o = new IntegerStack(3);
            o.Push(10);
            o.Push(20);
            o.Push(30);

            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());
            Console.ReadLine();
        }
        static void Main2()
        {
            StringStack o = new StringStack(3);
            o.Push("aa");
            o.Push("baa");
            o.Push("pa");

            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());
            Console.ReadLine();
        }
        static void Main()
        {
            //int? x = null;
            //Nullable<int> x1 = new Nullable<int>();


            //IntegerStack o = new IntegerStack(3);
            MyStack<int> o = new MyStack<int>(3);
            o.Push(10);
            o.Push(20);
            o.Push(30);

            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());
            Console.WriteLine(o.Pop());

            //StringStack o2 = new StringStack(3);
            MyStack<string> o2 = new MyStack<string>(3);
            o2.Push("aa");
            o2.Push("baa");
            o2.Push("pa");

            Console.WriteLine(o2.Pop());
            Console.WriteLine(o2.Pop());
            Console.WriteLine(o2.Pop());
            Console.ReadLine();
        }
    }

    class IntegerStack
    {
        int[] arr;
        public IntegerStack(int Size)
        {
            arr = new int[Size];
        }
        int Pos = -1;
        public void Push(int i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public int Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }

    class StringStack
    {
        string[] arr;
        public StringStack(int Size)
        {
            arr = new string[Size];
        }
        int Pos = -1;
        public void Push(string i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public string Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }

    class MyStack<T>
    //where T : class  //T must be a reference type
    //where T : struct  //T must be a value type
    //where T : ClassName  //T must be the class specified or its derived class
    //where T : InterfaceName  //T must be a class that implements the specified interface
    //where T : new() //T must have a no param constructor
    //where T : ClassName,InterfaceName,new()
    {
        T[] arr;
        public MyStack(int Size)
        {
            //T obj = new T();

            arr = new T[Size];
        }
        int Pos = -1;
        public void Push(T i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public T Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }
}

*********************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CollectionsExamples
{
    class Program
    {
        static void Main()
        {
            ArrayList o = new ArrayList();
            o.Add(10);
            o.Add("vikram");
            o.Add(10.34);
            o.Insert(0, "new");
            Console.WriteLine(o.Count);
            o.Remove("vikram");
            o.RemoveAt(0);
            o.RemoveRange(0, 3);

            //o.AddRange(o2);
            //o.InsertRange(0, o2);
            //o.IndexOf
            //o.LastIndexOf
            //o.BinarySearch
            //o.Clear
            //bool ans = o.Contains(10);
            //o.CopyTo(arr)
            ArrayList o2 = o.GetRange(0, 3);
            //o.SetRange(0,o2)
            object[] arr2 = o.ToArray();

            //o.CopyTo(arr2);


            //o.Capacity = large_number
            //add elements in a loop
            //o.TrimToSize();

            foreach (object item in o)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}

******************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main1()
        {
            int[] arr = new int[5];
            //arr[0] ..... arr[4]

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("enter value for arr[{0}]:", i);
                arr[i] = int.Parse(Console.ReadLine());
                //arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("value for arr[{0}] is {1}", i, arr[i]);
            }
            
            Console.WriteLine();
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static void Main2()
        {
            int[] arr = new int[5];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("enter value for arr[{0}]:", i);
                arr[i] = int.Parse(Console.ReadLine());
            }

            int index= Array.IndexOf(arr, 30);
            //if(index==-1) //not found
            index = Array.LastIndexOf(arr, 30);
            index = Array.BinarySearch(arr, 30);

            Array.Clear(arr,0,arr.Length);
            //Array.Copy(arr,arr2,arr.Length)
            //Array.ConstrainedCopy(arr, 0, arr2, 0, arr.Length);

            Array.Reverse(arr);
            Array.Sort(arr);
            Console.WriteLine();
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static void Main3()
        {
            int[,] arr = new int[3, 2];

            //arr[0,0] arr[0,1]
            //arr[1,0] arr[1,1]
            //arr[2,0] arr[2,1]

            Console.WriteLine(arr.Length);  //6
            Console.WriteLine(arr.Rank);  //number of dimensions - 2

            Console.WriteLine(arr.GetLength(0));  //3
            Console.WriteLine(arr.GetLength(1));  //2

            Console.WriteLine(arr.GetUpperBound(0));  //2
            Console.WriteLine(arr.GetUpperBound(1));  //1

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    //Console.Write("Enter arr[{0},{1}] : ", i, j);
                    Console.Write($"Enter arr[{i},{j}] : ");//string interpolation

                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine($"The value of arr[{i},{j}] is {arr[i, j]} ");  //string interpolation

                }
            }
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        static void Main4()
        {
            //jagged
            int[][] arr = new int[4][];
            arr[0] = new int[3]; // arr[0][0] arr[0][1] arr[0][2]
            arr[1] = new int[4]; // arr[1][0] arr[1][1] arr[1][2] arr[1][3]
            arr[2] = new int[2];//  arr[2][0] - arr [2][1]
            arr[3] = new int[3];//  arr[3][0] arr[3][1] arr[3][2]

            // arr[4] = new int[4];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("enter value for subscript [{0}][{1}] : ", i, j);
                    arr[i][j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine("value for subscript {0},{1} is {2}  ", i, j, arr[i][j]);

                }
            }
            Console.ReadLine();
        }

        static void Main()
        {
            Employee[] arrEmps = new Employee[4];
            for (int i = 0; i < arrEmps.Length; i++)
            {
                arrEmps[i] = new Employee();
                //other code
            }
        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }

    }
}


//array of totalmarks for 5 students
//int[] arr = new int[5];

//array of totalmarks for 3 batches 5 students
//int[,] arr = new int[3, 5];

//array of totalmarks for 2 centres, 3 batches 5 students
//int[,,] arr = new int[2, 3, 5];

//array of totalmarks for 4 cities, 2 centres, 3 batches 5 students
//int[,,,] arr = new int[4, 2, 3, 5];

**********************************Day5***************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Collections
{
    class Program
    {
        static void Main1()
        {
            //Hashtable o = new Hashtable();
            SortedList o = new SortedList();
            o.Add(1, "Vikram");
            o.Add(2, "Shweta");
            o.Add(3, "Harsh");

            o[1] = "changed"; 
            o[4] = "Ananya";

            o.Remove(1);

            bool ispresent = o.Contains(2);
            ispresent = o.ContainsKey(2);
            ispresent = o.ContainsValue("Harsh");
            //o.GetByIndex
            //o.GetKey
            IList lst = o.GetKeyList();
            //o.GetValueList
            //o.IndexOfKey
            //o.IndexOfValue
            //o.Keys
            //o.SetByIndex
            //o.Values
            foreach (DictionaryEntry item in o)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }

            Console.ReadLine();
        }
        static void Main2()
        {
            Stack o = new Stack();
            o.Push(10);
            Console.WriteLine(o.Peek());
            Console.WriteLine(o.Pop());

            Queue o2 = new Queue();
            o2.Enqueue(10);
            Console.WriteLine(o2.Peek());
            Console.WriteLine(o2.Dequeue());

            Console.ReadLine();
        }
        static void Main4()
        {
            List<int> o = new List<int>();
            o.Add(10);
            foreach (int item in o)
            {

            }
            Console.ReadLine();
        }
        static void Main5()
        {
            SortedList<int, string> o = new SortedList<int, string>();

            o.Add(1, "Vikram");
            o.Add(2, "Shweta");
            o.Add(3, "Harsh");

            o[1] = "changed";
            o[4] = "Ananya";

            o.Remove(1);
            foreach (KeyValuePair<int,string> item in o)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }
            Console.ReadLine();
        }
        static void Main6()
        {
            Stack<int> o = new Stack<int>();
            o.Push(10);
            Console.WriteLine(o.Peek());
            Console.WriteLine(o.Pop());

            Queue<int> o2 = new Queue<int>();
            o2.Enqueue(10);
            Console.WriteLine(o2.Peek());
            Console.WriteLine(o2.Dequeue());

            Console.ReadLine();
        }
        static void Main()
        {
            List<Employee> o = new List<Employee>();
            o.Add(new Employee { EmpNo = 1, Name = "Vikram" });
            o.Add(new Employee { EmpNo = 2, Name = "Harsh" });
            o.Add(new Employee { EmpNo = 3, Name = "Shweta" });

            foreach (Employee item in o)
            {
                Console.WriteLine(item.Name);
            }

            SortedList<int, Employee> o2 = new SortedList<int, Employee>();
            o2.Add(1, new Employee { EmpNo = 1, Name = "Vikram" });
            o2.Add(2, new Employee { EmpNo = 2, Name = "Harsh" });
            o2.Add(3, new Employee { EmpNo = 3, Name = "Shweta" });

            foreach (KeyValuePair<int, Employee> item in o2)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value.Name);
            }

            Console.ReadLine();
        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }

    }
}
namespace Collections2
{
    public class Employee
    {
        public int EmpNo { get; set; }
        private int x;
        protected int y;
        static void Main()
        {
            Employee o1 = new Employee();
            Console.ReadLine();
        }
    }

}

******************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    //step 1 : create a delegate class having the same signature as the method to call
    public delegate void Del1();
    //Object
    //Delegate
    //MulticastDelegate
    //Del1
    public delegate int DelAdd(int a, int b);
    //public delegate int DelAdd2(int a = 0, int b = 0, int c = 0);
    class Program
    {
        
        static void Main1()
        {
            //step 2: create an object of the delegate class, pass it function name as a paramter
            Del1 objDel = new Del1(Display);

            //step 3 : call the function via the delegate object
            objDel();
            Console.ReadLine();
        }
        static void Main2()
        {
            Del1 objDel = Display;
            objDel();
            Console.ReadLine();
        }
        static void Main3()
        {
            Del1 objDel = Display;
            objDel();
            objDel = Show;
            objDel();
            Console.ReadLine();
        }
        static void Main4()
        {
            Del1 objDel = Display;
            objDel();

            Console.WriteLine();
            objDel += Show;
            objDel();

            Console.WriteLine();
            objDel += Display;
            objDel();

            Console.WriteLine();
            objDel -= Display;
            objDel();

            Console.ReadLine();
        }
        static void Main5()
        {
            Del1 o =(Del1) Delegate.Combine(new Del1(Display), new Del1(Show), new Del1(Display));
            o();

            Console.WriteLine();
            //o = (Del1)Delegate.Remove(o, new Del1(Display));
            //o = (Del1)Delegate.RemoveAll(o, new Del1(Display));
            o();
            Console.ReadLine();
        }
        static void Main6()
        {
            DelAdd objDel = Add;
            Console.WriteLine(objDel(10,20));
            Console.ReadLine();
        }
        static void Main7()
        {
            Del1 objDel = Class1.Display;
            objDel();

            Class1 o = new Class1();
            objDel = o.Show;
            Console.ReadLine();
        }
        //to do - try calling a multicast delegate for a function that has return values
        static void Display()
        {
            Console.WriteLine("Display");
        }
        static void Show()
        {
            Console.WriteLine("Show");
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        //static int Add2(int a=0, int b=0, int c=0)
        //{
        //    return a + b;
        //}
    }
    public class Class1
    {
        public static void Display()
        {
            Console.WriteLine("Display");
        }
        public void Show()
        {
            Console.WriteLine("Show");
        }
    }
}

//Call Function Passed as a Parameter
namespace Delegates2
{
    public delegate int DelAdd(int a, int b);
    class Program
    {
        static void Main()
        {
            Console.WriteLine(CallFunctionPassedAsAParameter(Add, 20, 10));
            Console.WriteLine(CallFunctionPassedAsAParameter(Subtract, 20, 10));
            Console.WriteLine(CallFunctionPassedAsAParameter(Multiply, 20, 10));
            Console.WriteLine(CallFunctionPassedAsAParameter(Divide, 20, 10));
            Console.ReadLine();
        }
        static int CallFunctionPassedAsAParameter(DelAdd objFunc, int a, int b) 
        {
            return objFunc(a,b);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }
        static int Divide(int a, int b)
        {
            return a / b;
        }

    }

}

*******************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncActionPredicate
{
    class Program
    {
        static void Main1()
        {
            Action o1 = Display;
            o1();
            Action<string> o2 = Display;
            o2("hello");

            Action<string, int> o3 = Display;
            o3("hello", 10);
            Console.ReadLine();
        }
        static void Main()
        {
            Func<int> o1 = GetNum;
            Console.WriteLine(o1());

            Func<int, int, int> o2 = Add;
            Console.WriteLine(o2(20,10));
            Func<string, decimal, bool, int> o3 = DoSomething1;
            Console.WriteLine(o3("a",1.1M, true));
            
            Func<int, bool> o4 = IsEven;
            Console.WriteLine(o4(10));

            Predicate<int> o5 = IsEven;
            Console.WriteLine(o5(10));


            Console.ReadLine();
        }
        static void Display()
        {
            Console.WriteLine("Display");
        }
        static void Display(string s)
        {
            Console.WriteLine("Display" + s);
        }
        static void Display(string s, int i)
        {
            Console.WriteLine("Display" + s + i);
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int DoSomething1(string a, decimal b, bool c)
        {
            return a.Length;
        }
        static int GetNum()
        {
            return 10;
        }
        static bool IsEven(int a)
        {
            if (a % 2 == 0)
                return true;
            else
                return false;
        }
    }
}

****************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonMethodsAndLambdas1
{
    class Program
    {
        static void Main1()
        {
            int i = 100;
            Action o1 = delegate()
            {
                Console.WriteLine("Anon method");
                Console.WriteLine(i);
            };
            o1();

            Func<int, int, int> o2 = delegate (int a, int b) { return a + b; };
            Console.WriteLine(o2(10,20));

            Predicate<int> o3 = delegate (int a) {
                if (a % 2 == 0)
                    return true;
                else
                    return false;
            };
            Console.WriteLine(o3(10));
            Console.ReadLine();
        }
        static bool IsEven(int a)
        {
            if (a % 2 == 0)
                return true;
            else
                return false;
        }
    }
}
namespace AnonMethodsAndLambdas2
{
    class Program
    {
        static void Main()
        {
            Func<int, int> o1 = delegate (int a) { return a * 2; };
            Console.WriteLine(o1(10));

            //Func<int, int> o2 = (a) => a * 2;
            Func<int, int> o2 = a => a * 2;
            Console.WriteLine(o2(10));

            Func<int, int, int> o3 = (a, b) => a + b;
            Console.WriteLine(o3(10,20));

            Predicate<int> o4 = a => a % 2 == 0;
            Console.WriteLine(o4(10));

            Predicate<int> o5 = a => {
                if (a % 2 == 0)
                    return true;
                else
                    return false;
            };
            Console.WriteLine(o4(10));


            Console.ReadLine();
        }
        static bool IsEven(int a)
        {
            if (a % 2 == 0)
                return true;
            else
                return false;
        }
        static int MakeDouble(int a)
        {
            return a * 2; 
        }
    }
}

*************************Exception Handling**************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling1
{
    public class Class1
    {
        private int p1;
        public int P1
        {
            get { return p1; }
            set
            {
                p1 = value;
            }
        }
    }
    class Program
    {
        static void Main0()
        {
            Class1 obj = new Class1();
            obj = null;
            int x = Convert.ToInt32(Console.ReadLine());
            obj.P1 = 100 / x;
            Console.WriteLine(obj.P1);
            Console.ReadLine();
        }
        static void Main1() //simple try block with catch
        {
            Class1 obj = new Class1();
            try
            {
                obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }
            catch
            {
                Console.WriteLine("Exception occurred");
            }
            Console.ReadLine();
        }
        static void Main2()//try with multiple catch blocks
        {
            Class1 obj = new Class1();
            try
            {
                obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("DBException occurred");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occurred");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException occurred");
            }
            Console.ReadLine();
        }
        static void Main3()// catching base class exceptions
        {
            Class1 obj = new Class1();
            try
            {
                obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }

            //catch (SystemException ex)
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException occurred");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occurred");
            }
            catch (DivideByZeroException ex)
            //catch (ArithmeticException ex) 
            //catch (SystemException ex) //base class exception has to caught after derived class exceptions
            {
                Console.WriteLine("DBException occurred");
            }
            catch (Exception ex) //catches all unhandled exceptions
            {
                Console.WriteLine(ex.TargetSite);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadLine();
        }
        static void Main4()// finally block
        {
            Class1 obj = new Class1();
            try
            {
                //obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }

            catch (FormatException ex)
            {
                Console.WriteLine("FormatException occurred");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occurred");
            }
            //catch (DivideByZeroException ex) 
            //catch (ArithmeticException ex) 
            catch (SystemException ex) //base class exception has to caught after derived class exceptions
            {
                Console.WriteLine("DBException occurred");
            }
            catch (Exception ex) //catches all unhandled exceptions
            {
                Console.WriteLine(ex.Message);
            }
            //finally runs when Exception does not occur, 
            //or Exception occurs and is handled or 
            //Exception occurs and is NOT handled 
            finally
            {
                Console.WriteLine("finally");
            }
            Console.ReadLine();
        }

        static void Main5()// nested try block
        {
            Class1 obj = new Class1();
            try
            {
                //obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = 100 / x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }

            catch (FormatException ex)
            {
                try
                {
                    Console.WriteLine("FormatException occurred. Enter only numbers");
                    int x = Convert.ToInt32(Console.ReadLine());
                    obj.P1 = 100 / x;
                    Console.WriteLine(obj.P1);
                }
                catch
                {
                    Console.WriteLine("nested try catch example");
                }
                finally
                {
                    Console.WriteLine("nested try finally example");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occurred");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DBException occurred");
            }
            catch (Exception ex) //catches all unhandled exceptions
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("outer finally");

            }
            Console.ReadLine();
        }
    }

}

namespace ExceptionHandling2
{
    class Program
    {
        static void Main()
        {
            Class1 obj = new Class1();
            try
            {
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P1 = x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException occurred");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NRException occurred");
            }
            catch (InvalidP1Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)  //all exceptions thrown by .net base classes
            {
                Console.WriteLine(ex.Message);
            }

            catch (ApplicationException ex) //all user defined exceptions
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) //all other exceptions
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
        }
    }

    public class Class1
    {
        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //Console.WriteLine("invalid P1");   //DONT EVER DO THIS
                    //Exception ex;
                    //ex = new Exception();
                    //throw ex;

                    //Exception ex;
                    //ex = new Exception("invalid P1");
                    //throw ex;

                    //throw new Exception("Invalid P1");

                    throw new InvalidP1Exception("Invalid P1");
                }
            }
        }
    }
    
    public class InvalidP1Exception : ApplicationException
    {
        public InvalidP1Exception(string message) : base(message)
        {
        }
    }


}

*********************************Day6 Form Event  Asysnc Function*****************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

***********
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button1 click code called");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.MouseMove += Button1_MouseMove;
        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

***********************EventHandling********************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling
{
    class Program
    {
        //static void Main()
        //{
        //    Class1 o = new Class1();
        //    o.InvalidP1 += o_InvalidP1;
        //    o.P1 = 1000;
        //    Console.ReadLine();
        //}
        //static void o_InvalidP1()
        //{
        //    Console.WriteLine("event handled here");
        //}
        static void Main1()
        {
            Class1 o = new Class1();
            o.InvalidP1 += O_InvalidP1;
            o.InvalidP1 += Handler2;
            o.P1 = 200;
            
            Console.WriteLine();
            o.InvalidP1 -= Handler2;
            o.P1 = 200;

            Console.WriteLine();
            o.InvalidP1 -= O_InvalidP1;
            o.P1 = 200;
            Console.ReadLine();
        }

        private static void O_InvalidP1()
        {
            Console.WriteLine("event handled here");
        }
        private static void Handler2()
        {
            Console.WriteLine("event also handled here");
        }
    }
    //step1 : create a delegate class matching the event handling function signature
    public delegate void InvalidP1EventHandler();

    public class Class1
    {
        //step2 : declare the event
        //event is a delegate object
        public event InvalidP1EventHandler InvalidP1;


        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //step 3: raise the event
                    if(InvalidP1!=null)
                        InvalidP1();
                }
            }
        }
    }
}


//event with parameters

namespace EventHandling2
{
    class Program
    {
        
        static void Main()
        {
            Class1 o = new Class1();
            o.InvalidP1 += O_InvalidP1;
            o.P1 = 200;
            Console.ReadLine();
        }

        private static void O_InvalidP1(int InvalidValue)
        {
            Console.WriteLine($"invalidp1 event raised....{InvalidValue}");
        }
    }
    //step1 : create a delegate class matching the event handling function signature
    public delegate void InvalidP1EventHandler(int InvalidValue);

    public class Class1
    {
        //step2 : declare the event
        //event is a delegate object
        public event InvalidP1EventHandler InvalidP1;


        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //step 3: raise the event
                    if (InvalidP1 != null)
                        InvalidP1(value);
                }
            }
        }
    }
}

**************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures
{
    class Program
    {

        //implicit variables
        static void Main1()
        {
            //used only for local variables
            //cant be used for class level vars,fn params and return types

            int i = 100;  //explicit
            var j =10;  //implicit variables
            //j = "qqqq";  //error
            Console.WriteLine(j.GetType());
            Console.ReadLine();
        }
    }
}
namespace AnonymousTypes
{
    class Program
    {
        static void Main1()
        {
            //Class1 obj = new Class1{a=1, b="aaa",c = true};

            var obj = new { a = 1, b = "aaa", c = true };
            var obj2 = new { a = 2, b = "bbb", c = false };
            Console.WriteLine(obj2.a);
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj2.GetType());

            Console.ReadLine(); ;
        }
    }
}

//partial classes
namespace LanguageFeatures5
{
    //PARTIAL CLASSES

    //partial classes must be in the same assembly
    //partial classes must be in the same namespace
    //partial classes must have the same name
    public partial class Class1
    {
        public int i;
    }
    public partial class Class1
    {
        public int j;
    }
    public class Program
    {
        public static void Main1()
        {
            Class1 o = new Class1();
            
        }
    }
}
namespace LanguageFeatures5
{
    public partial class Class1
    {
        public int k;
    }
}

//partial methods
namespace PartialMethods
{
    public class MainClass
    {
        public static void Main1()
        {
            Class1 o = new Class1();

            Console.WriteLine(o.Check());

            Console.ReadLine();
        }
    }

    //Partial methods can only be defined within a partial class.
    //Partial methods must return void.
    //Partial methods can be static or instance level.
    //Partial methods cannnot have out params
    //Partial methods are always implicitly private.

    public partial class Class1
    {
        private bool isValid = true;
        partial void Validate();
        public bool Check()
        {
            //.....
            Validate();
            return isValid;
        }
    }

    public partial class Class1
    {
        partial void Validate()
        {
            //perform some validation code here
            isValid = false;
        }
    }

}

namespace ExtensionMethods
{
    public class MainClass
    {
        public static void Main1()
        {
            int i = 100;
            i = i.Add(5);
            i.Display();
            i.ExtMethodForBaseClass();
            string s = "abcd";
            s.Show();
            s.ExtMethodForBaseClass();
            Console.ReadLine();
        }
        public static void Main2()
        {
            int i = 100;
            //i = i.Add(5);
            //i.Display();
            Class1.Add(i, 5);
            Class1.Display(i);

            string s = "abcd";
            //s.Show();
            Class1.Show(s);
            Console.ReadLine();
        }
        static void Main()
        {
            ClsMaths o = new ClsMaths();
            Console.WriteLine(o.Multiply(10, 5));
            Console.WriteLine(o.Subtract(10, 5));

            Console.ReadLine();
        }
    }
    public static class Class1
    {
        //create a static method in the class
        //first parameter should be the type for which you are writing the ext method
        //precede the 1st parameter with the 'this' keyword
        public static void Display(this int i)
        {
            Console.WriteLine(i);
        }
        public static int Add(this int i, int j)
        {
            return i + j;
        }
        public static void Show(this string s)
        {
            Console.WriteLine(s);
        }
        //if you define an extension method for a base class, 
        // it is also available to all derived classes 
        public static void ExtMethodForBaseClass(this object s)
        {
            Console.WriteLine(s);
        }
        //if you define an extension method for an interface, 
        // it is also available to all classes that implement that interface
        public static int Subtract(this IMathOperations i, int a, int b)
        {
            return a - b;
        }
    }

    public interface IMathOperations
    {
        int Add(int a, int b);
        int Multiply(int a, int b);
    }

    public class ClsMaths : IMathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}

********
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures5
{
    public partial class Class1
    {
        public int l;
    }
}

**************************AsyncWithDelegates************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCodeWithDelegates1
{
    class Program
    {
        static void Main1()
        {
            Action oDel = Display;
            Console.WriteLine("Before");
            //oDel();
            oDel.BeginInvoke(null, null);  //Display called on a separate thread
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static void Display()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Display");
        }
    }
}

namespace AsyncCodeWithDelegates2
{
    class Program
    {
        static void Main2()
        {
            Action<string> oDel = Display;
            Console.WriteLine("Before");
            oDel.BeginInvoke("abc", null, null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static void Display(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
        }
    }
}

namespace AsyncCodeWithDelegates3
{
    class Program
    {
        static void Main3()
        {
            Func<string,string> oDel = Display;
            Console.WriteLine("Before");
            oDel.BeginInvoke("abc", CallbackFunction, null);
            //oDel.BeginInvoke("abc", new AsyncCallback(CallbackFunction), null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }
        static void CallbackFunction(IAsyncResult ar)
        {
            Console.WriteLine("callback func called");
        }
    }
}

//move oDel to the class level
namespace AsyncCodeWithDelegates4
{
    class Program
    {
        static Func<string, string> oDel = Display;
        static void Main1()
        {
            Console.WriteLine("Before");
            IAsyncResult ar = oDel.BeginInvoke("abc", CallbackFunction, null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }
        static void CallbackFunction(IAsyncResult ar)
        {
            Console.WriteLine("callback func called");
            string retval = oDel.EndInvoke(ar);
            Console.WriteLine($"return value is {retval}");
        }
    }
}


//make callback func as a local func/anon method
namespace AsyncCodeWithDelegates5
{
    class Program
    {
        static void Main1()
        {
            Func<string, string> oDel = Display;
            Console.WriteLine("Before");
            IAsyncResult ar1 = oDel.BeginInvoke("abc", delegate(IAsyncResult ar)
            {
                Console.WriteLine("callback func called");
                string retval = oDel.EndInvoke(ar);
                Console.WriteLine($"return value is {retval}");
            }, null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }
        
    }
}

//pass oDel as the last parameter in BeginInvoke. Access it as ar.AsyncState in the callback method
namespace AsyncCodeWithDelegates6
{
    class Program
    {
        static void Main1()
        {
            Func<string, string> oDel = Display;
            Console.WriteLine("Before");
            //oDel.BeginInvoke("abc", CallbackFunction, "extra data");
            oDel.BeginInvoke("abc", CallbackFunction, oDel);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }
        static void CallbackFunction(IAsyncResult ar)
        {
            Console.WriteLine("callback func called");
            //string lastparam = ar.AsyncState.ToString();
            //Console.WriteLine(lastparam);

            Func<string, string> oDel = (Func<string, string>)ar.AsyncState;
            string retval = oDel.EndInvoke(ar);
            Console.WriteLine($"return value is {retval}");

        }
    }
}


//Access it as  result.AsyncDelegate in the callback method. result is of type AsyncResult
namespace AsyncCodeWithDelegates7
{
    class Program
    {
        static void Main1()
        {
            Func<string, string> oDel = Display;
            Console.WriteLine("Before");
            oDel.BeginInvoke("abc", CallbackFunction, null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }
        static void CallbackFunction(IAsyncResult ar)
        {
            AsyncResult result =(AsyncResult) ar;

            Console.WriteLine("callback func called");
            Func<string, string> oDel = (Func<string, string>)result.AsyncDelegate;
            string retval = oDel.EndInvoke(ar);
            Console.WriteLine($"return value is {retval}");

        }
    }
}


//use ar.AsyncWaitHandle.WaitOne() --- wait for the thread to complete -- like Thread.Join
namespace AsyncCodeWithDelegates8
{
    class Program
    {
        static void Main()
        {
            Func<string, string> oDel = Display;
            Console.WriteLine("Before");
            IAsyncResult ar = oDel.BeginInvoke("abc", null, null);
            Console.WriteLine("After");

            //while (!ar.IsCompleted) ;
            ar.AsyncWaitHandle.WaitOne();

            string retval = oDel.EndInvoke(ar);
            Console.WriteLine($"return value is {retval}");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }
        
    }
}

********************************************OperatorOverloading********************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 o = new Class1 { i = 10 };
            Class1 o2 = new Class1 { i = 20 };
            o = o + 5;
            o += 5;

            //o = Class1.operator+(o,5)
            o = o + o2;

            //o = Class1.operator+(o,o2);
            Console.WriteLine(o.i);
            Console.ReadLine();
        }
    }
    public class Class1
    {
        public int i;
        //public int j ;
        public static Class1 operator+(Class1 o, int i)
        {
            Class1 retval = new Class1();
            retval.i = o.i + i;
            return retval;
        }
        public static Class1 operator +(Class1 o, Class1 o2)
        {
            Class1 retval = new Class1();
            retval.i = o.i + o2.i;
            return retval;
        }
    }
}

//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading

**********************************************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            o[0] = 10;
            Console.WriteLine(o[0]);
            o[1] = 20;
            Console.WriteLine(o[1]);
            o[2] = 30;
            Console.WriteLine(o[2]);

            Console.ReadLine();
        }
    }
    class Class1
    {
        private int[] arr = new int[3];
        public int this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }
        //public int Length
        //{
        //    get
        //    {
        //        return arr.Length;
        //    }
        //}
    }
}


namespace Indexer2
{
    class Program
    {
        static void Main()
        {
            Class1 o = new Class1(5,2000);

            //o[0]=100;
            o[2000] = 100;
            o[2001] = 100;
            o[2002] = 100;
            o[2003] = 100;
            o[2004] = 100;
            Console.WriteLine(o[2003]);
            Console.ReadLine();
        }
    }
    public class Class1
    {
        private int[] arr;
        int start;
        public Class1(int Size, int start)
        {
            this.start = start;
            arr = new int[Size];
        }
        public int this[int index]
        {
            get
            {
                return arr[index - start];
            }
            set
            {
                arr[index - start] = value;
            }
        }

    }
}



****************************************************************************