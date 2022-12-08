using BusinessLayer;
using DataAccessLayer;

namespace VISPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Demonstrace přidání nového itemu do databáze(FoodMockDB)
            Food f = new Food("Ryba", 15.90);
            Console.WriteLine(f);
            FoodDataMapper dataMapper = new FoodDataMapper();
            dataMapper.Insert(f);
            Console.WriteLine();

            //Tady by měl item přijít z databáze(FoodMockDB)
            f = new FoodDataMapper().FindById(5);
            Console.WriteLine(f is null ? "f is null" : f);
            Console.WriteLine();

            //Tady by měl item přijít z Identitní mapy
            f = new FoodDataMapper().FindById(5);
            Console.WriteLine(f is null ? "f is null" : f);
            Console.WriteLine();

            //Tady by měl item být null, index 6 není v databázi
            Food f1 = new FoodDataMapper().FindById(6);
            Console.WriteLine(f1 is null ? "f is null" : f1);
            Console.WriteLine();

            //Demonstrace updatu dat v databázi
            Food f2 = new FoodDataMapper().FindById(3);
            Console.WriteLine(f2 is null ? "f is null" : f2);
            Console.WriteLine();

            f2.Price = 68.79;
            dataMapper.Update(f2);
            
            f2 = new FoodDataMapper().FindById(3);
            Console.WriteLine(f2 is null ? "f is null" : f2);
            Console.WriteLine();

            //Demonstrace deletu dat z databáze
            dataMapper.Delete(f);
            f = new FoodDataMapper().FindById(5);
            Console.WriteLine(f is null ? "f is null" : f);
            Console.WriteLine();

            //Demonstrace hledání dat v databázi pomocí typu jídla D pro dezerty, N pro "bez typu", M pro hlavní jídla
            List<Food> foods = new FoodDataMapper().FindByType('D');
            if (foods != null)
            {
                foreach (var item in foods)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
            else { Console.WriteLine("No items found"); }

            //Tady by to mělo přijít z identitní mapy
            foods = new FoodDataMapper().FindByType('D');
            if (foods != null)
            {
                foreach (var item in foods)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
            else { Console.WriteLine("No items found"); }

            //Tady nic nepřijde, je zadán nesprávný typ
            foods = new FoodDataMapper().FindByType('A');
            Console.WriteLine(foods is null ? $"List of foods is null" : foods);

        }
    }
}