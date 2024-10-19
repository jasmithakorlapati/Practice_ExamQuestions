using System;
class Person
{
    public string Name { set; get; }
    public string Address { set; get; }
    public int Age { set; get; }

    //Creating constructor
    public Person(string name, string address, int age)
    {
        this.Name = name;
        this.Address = address;
        this.Age = age;
    }
    public Person()
    {
    }
}
class PersonImplementation
{
    public string GetName(IList<Person> person)
    {
        var res = "";
        foreach (var item in person)
        {
            res += item.Name + " " + item.Address + " ";
        }
        return res;
    }
    public double Average(IList<Person> person)
    {
        double sum = 0;
        double count = 0;
        foreach (var p in person)
        {
            count++;
            sum = sum + p.Age;
        }
        return sum / count;
    }
    public int Max(IList<Person> person)
    {
        int maxAge = 0;
        foreach (var item in person)
        {
            if (item.Age > maxAge)
            {
                maxAge = item.Age;
            }
        }

        return maxAge;
    }

public static void Main(string[] args)
    {
        IList<Person> p = new List<Person>();
        p.Add(new Person { Name = "Aarya", Address = "A2101", Age = 69 });
        p.Add(new Person { Name = "Daniel", Address = "D104", Age = 40 });
        p.Add(new Person { Name = "Ira", Address = "H801", Age = 25 });
        p.Add(new Person { Name = "Jennifier", Address = "I1704", Age = 33 });
        PersonImplementation personimpli=new PersonImplementation();
        Console.WriteLine(personimpli.GetName(p));
        Console.WriteLine(personimpli.Average(p));
        Console.WriteLine(personimpli.Max(p));

    }

}



