using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class FoodIdentityMap
    {
        private static Dictionary<int, Food> identityMap = new Dictionary<int, Food>();
        private static Dictionary<char, List<Food>> identityMapByType = new Dictionary<char, List<Food>>();
        public static void Add(int id, Food f)
        {
            identityMap.Add(id, f);
        }
        public static void Add(char type, List<Food> foods) 
        {
            identityMapByType.Add(type, foods);
        }
        public static Food GetFood(int id)
        {
            Food f = null;
            if(identityMap.TryGetValue(id, out f))
            {
                Console.WriteLine($"\u001b[32mFrom {nameof(FoodIdentityMap)}\u001b[0m");
                return f;
            }
            return f;
        }
        public static List<Food> GetFood(char type)
        {
            List<Food> foods = null;
            if(identityMapByType.TryGetValue(type, out foods))
            {
                Console.WriteLine($"\u001b[32mFrom {nameof(FoodIdentityMap)}\u001b[0m");
                return foods;
            }
            return foods;
        }
        public static void Clear()
        {
            Console.WriteLine($"\u001b[31m{nameof(FoodIdentityMap)} cleared\u001b[0m");
            identityMap.Clear();
            identityMapByType.Clear();
        }
    }
}
