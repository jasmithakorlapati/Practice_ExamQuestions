using System.ComponentModel;

namespace Question2_Overloading
{
     class Source
     {
        public  int Add(int a,int b,int c)
        {
            return a + b + c;
        }
        public  double Add(double a, double b, double c)
        {
            return a + b + c;
        }
        static void Main(string[] args)
        {
            Source source = new Source();
            Console.WriteLine(source.Add(1,2,3));
            Console.WriteLine(source.Add(4.9,7,0));
        }
     }
}
