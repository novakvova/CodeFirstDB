using DatabaseFirst.Models;
using System;
using System.Linq;

namespace DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal
            {
                Name = "Носоріг"
            };
            testContext context = new testContext();
            context.Animals.Add(animal);
            context.SaveChanges();
            int count = context.Animals.Count();
            Console.WriteLine("Кількість тварин в БД: "+count);
        }
    }
}
