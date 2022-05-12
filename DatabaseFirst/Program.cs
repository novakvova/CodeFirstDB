using DatabaseFirst.Models;
using System;
using System.Linq;

namespace DatabaseFirst
{
    interface IRepository
    {

    } 
    class User
    {
        protected User() { }
        public void Show()
        {
            Console.WriteLine("Hello");
        }
    }
    class Ivan : User
    {
        public Ivan() : base()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //User user1 = new User();
            User user = new Ivan();
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
