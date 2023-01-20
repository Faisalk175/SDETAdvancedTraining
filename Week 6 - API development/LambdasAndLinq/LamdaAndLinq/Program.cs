using System;
using System.Diagnostics;
using System.Xml;

namespace LambdasAndLinq;

public class Program
{
    static void Main(string[] args)
    {
        //Language Integrate Queries
        var nums = new List<int> { 3, 7, 1, 2, 8, 3, 0, 4, 5 };

        var numsCount = nums.Count();

        //int countEven = 0;
        //foreach(int num in nums)
        //{
        //    if (IsEven(num)) countEven++;
        //}

        int countEven = nums.Count(IsEven);

        List<Person> people = new List<Person> {
           new Person { Name = "Cathy", Age = 40, City = "Ottawa"},
           new Person { Name = "Nish", Age = 55,City = "Birmingham"},
           new Person { Name = "Martin", Age = 20, City = "London"}
        };

        var countYoungPeople = people.Count(IsYoung);

        //int sumOfEven = nums.Sum(IsEven);

        // anonymous method using delegates
        int countDEven = nums.Count(delegate (int num) { return num % 2 == 0; });
        

        //lambda expressions

        // given something => return something
        int sumOfSquares = nums.Sum(x => x * x);

        int countLEven = nums.Count(num => num % 2 == 0);

        var peopleInLondonQuery = people.Where(p => p.City == "London").ToList();

        var peopleByAge = people.OrderBy(p => p.Age);

        foreach(var person in peopleByAge)
        {
            Console.WriteLine(person);
        }

        var namesOfThoseOver20 = people.Where(p => p.Age > 20).Select(p => p.Name).First();

        string newString = ModifyString("Hello World",  s => s.Replace(" ", "_").ToUpper());
    }

    private static string ModifyString(string str, Func<string, string> strModify)
    {
        return strModify(str);
    }

    private static int Square(int x)
    {
        return x * x;
    }

    private static bool IsEven(int num)
    {
        return num % 2 == 0;
    }

    private static bool IsYoung(Person p)
    {
        return p.Age < 30;
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public override string ToString()
    {
        return $"{Name} - {City} - {Age}";
    }
}


