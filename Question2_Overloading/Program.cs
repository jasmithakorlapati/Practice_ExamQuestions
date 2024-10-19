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
            int a=int.Parse(Console.ReadLine());
            int b=int.Parse(Console.ReadLine());
            int c=int.Parse(Console.ReadLine());
            double da=double.Parse(Console.ReadLine());
            double db=double.Parse(Console.ReadLine());
            double dc=double.Parse(Console.ReadLine());
            Console.WriteLine(source.Add(a,b,c));
            Console.WriteLine(source.Add(da,db,dc));
        }
     }
}
