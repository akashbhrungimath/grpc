using System;
using System.IO;
using System.Reflection;

namespace fileImplementation
{
    class FileClass
    {
        static void Main(string[] args)
        {
            //File class implementation:

            /*StreamWriter sw = new StreamWriter("C:/Users/aanandku/Documents/ExampleText.txt");
            Console.WriteLine("Enter the data to write to the file");
            sw.WriteLine(Console.ReadLine());
            sw.Flush();
            sw.Close();
            StreamReader sr = new StreamReader("C:/Users/aanandku/Documents/ExampleText.txt");
            var line = sr.ReadLine();
            sr.Close();
            Console.WriteLine("The data stored in file is");
            Console.WriteLine(line);
            Console.WriteLine("Hit ENTER to close.....!");
            Console.ReadLine();
            */

            //Path class implementation

            /*Console.WriteLine("The address of the file AuthDemo is = ");
            Console.WriteLine(Path.GetFullPath("../AuthDemo.sln"));
            Console.WriteLine("Sub-Directories in the directory C:/Users/aanandku/Source are = ");
            DirectoryInfo d = new DirectoryInfo("C:/Users/aanandku/Source");
            DirectoryInfo[] d1 = d.GetDirectories("A*", SearchOption.AllDirectories);
            foreach (var dir in d1)
            {
                Console.WriteLine(dir.FullName);
            }*/

            //Assembly class implementation

            Assembly assembly = typeof(FileClass).Assembly;
            Console.WriteLine("Assembly Name is = {0}",assembly.GetName());
            Console.WriteLine(Assembly.GetExecutingAssembly().Location);
        }
    }
}


/*namespace Hello
{

    //User-defined exception class implementation :

    class Out_of_range : Exception
    {
        public Out_of_range()
        {
            Console.WriteLine("Out of bounds !\n");
        }
    }

    //abstract class implementation :

    abstract class Demo
    {
        public abstract void override_method();
    }
    class Sub_abstract:Demo
    {
        public override void override_method()
        {
            Console.WriteLine("This method is overriden from abstract.");
        }
    }

    //Inheritance :

    class use2:use
    {
        public use2() : base()
        {
            Console.WriteLine("This is the constructor of use2 class.");
        }

        static void Main(String[] args)
        {
            int[] a = { 1, 2, 3 };
            use2 u=new use2();
            //Console.WriteLine("Hey, does it work ?");
            try
            {
                use.print(a);
            }
            catch (Exception e)
            {
                Console.WriteLine("Inside catch\n" + e.Message);
            }

            Console.WriteLine("............................................");

            Sub_abstract d1= new Sub_abstract();
            d1.override_method();
            int num = 16;
            string n = num.ToString();
            Console.WriteLine("After converting '16' to string = "+n);
            int num1 = Int32.Parse(n);
            Console.WriteLine("After string back to int = " + num1);
            //Console.WriteLine("This is how it works.");

            Console.WriteLine("..............................................................");

            //Explicitly datatype conversion from string to int :

            Console.WriteLine("Enter two no.s to find their sum = ");
            int x = Int32.Parse(Console.ReadLine());
            int y = Int32.Parse(Console.ReadLine());
            int result = new use2().add(x , y);
            Console.WriteLine("The sum of the above entered no.s is = {0}", result);
        }
    }
    class use
    {
        public use()
        {
            Console.WriteLine("This is the constructor of use class.");
        }
        public static void print(int[] a)
        {
            for(int i=0;i<a.Length;i++)
            {
                if (i>2)
                    throw new Out_of_range();
                Console.WriteLine(a[i]);
            }
        }
        public int add(int x , int y)
        {
            return x + y;
        }
    }
}*/