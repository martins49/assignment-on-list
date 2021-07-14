using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;


namespace assignment.on.list
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person { FullName = "Ade tayo", Age = 17, DOB = new DateTime(2004, 12, 31), BloodType = "AA" };
            var person2 = new Person { FullName = "Adekunle Bright", Age = 20, DOB = new DateTime(2001, 08, 10), BloodType = "AA" };
            var person3 = new Person { FullName = "Ola Darasimi", Age = 19, DOB = new DateTime(2002, 04, 17), BloodType = "AS" };
            var person4 = new Person { FullName = "Elegba Mercy", Age = 33, DOB = new DateTime(1988, 01, 12), BloodType = "AS" };
            var person5 = new Person { FullName = "Akin Taiwo", Age = 29, DOB = new DateTime(1992, 06, 13), BloodType = "AA" };
            var person6 = new Person { FullName = "Aluko Emannuel ", Age = 15, DOB = new DateTime(2006, 05, 19), BloodType = "AS" };
            var person7 = new Person { FullName = "Aje Samuel", Age = 27, DOB = new DateTime(1994, 02, 8), BloodType = "AA" };
            var person8 = new Person { FullName = "Babatunde Caleb", Age = 23, DOB = new DateTime(1998, 11, 27), BloodType = "AS" };
            var person9 = new Person { FullName = "Oyewale David", Age = 18, DOB = new DateTime(2003, 03, 24), BloodType = "AA" };
            var person10 = new Person { FullName = "Onisile Marvellous", Age = 25, DOB = new DateTime(1996, 09, 01), BloodType = "AS" };

            List<Person> listOfPeople = new List<Person>();
            listOfPeople.Add(person1);
            listOfPeople.Add(person2);
            listOfPeople.Add(person3);
            listOfPeople.Add(person4);
            listOfPeople.Add(person5);
            listOfPeople.Add(person6);
            listOfPeople.Add(person7);
            listOfPeople.Add(person8);
            listOfPeople.Add(person9);
            listOfPeople.Add(person10);

            Console.WriteLine("Before sorting");
            foreach (var item in listOfPeople)
            {
                Console.WriteLine($"{item.FullName}, {item.Age}, {item.BloodType}, {item.DOB.ToLongDateString()}");
            }
            Console.WriteLine();

            Console.WriteLine("After sorting by Age \n ");
            listOfPeople.Sort();
            foreach (var item in listOfPeople)
            {
                Console.WriteLine($" {item.Age}, {item.FullName}, {item.BloodType}, {item.DOB.ToLongDateString()}");
            }
            Console.WriteLine();

            Console.WriteLine("Sorting by BloodType \n");
            SortByBloodType sortByName = new SortByBloodType();
            listOfPeople.Sort(sortByName);
            foreach (var item in listOfPeople)
            {
                Console.WriteLine($"{item.BloodType}, {item.FullName}, {item.Age},  {item.DOB.ToLongDateString()}");
            }
            Console.WriteLine();

            Console.WriteLine("Sorting by Month, then remove from september to December  \n");
            SortByMonth sortByMonth = new SortByMonth();
            listOfPeople.Sort(sortByMonth);
            //listOfPeople.RemoveAll(p=> p.DOB==new DateTime());
            List<Person> Month =listOfPeople.GetRange(0, 7);
            
            foreach (var item in Month)
            {
                Console.WriteLine($"{item.DOB.ToShortDateString()}, {item.FullName}, {item.Age}, {item.BloodType}");
            }
        }
    }

    public class Person : IComparable<Person>
    {
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string BloodType { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Age > other.Age)
                return 1;
            else if (this.Age < other.Age)
                return -1;
            else
                return 0;
        }

    }
    public class SortByBloodType : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.BloodType.CompareTo(y.BloodType);
        }
    }

    public class SortByMonth : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.DOB.Month.CompareTo(y.DOB.Month);
        }
    }
}
