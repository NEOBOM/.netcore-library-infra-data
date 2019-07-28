using Library.Infra.DataAcess.ConsoleTest.Entity;
using Library.Infra.DataAcess.ConsoleTest.MongoDB;
using MongoDB.Driver;
using System;

namespace Library.Infra.DataAcess.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CustumerRepository custumerRepository = new CustumerRepository(new MongoClient("mongodb://localhost:27017/mongotest"));
            custumerRepository.Watch(Print);

            //custumerRepository.Inset(new Custumer { Id = 1, Name = "Adam", Age = 30 });

            custumerRepository.Update(new Custumer { Id = 1, Name = "Adam", Age = 33 });

            Console.ReadKey();
        }

        public static void Print(Custumer custumer)
        {
            Console.WriteLine($"Nome: {custumer.Name}, Idade: {custumer.Age}");
        }
    }
}