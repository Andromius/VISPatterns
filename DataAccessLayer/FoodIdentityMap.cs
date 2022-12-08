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
        public static void Add(int id, Food f)
        {
            identityMap.Add(id, f);
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
        public static void Clear()
        {
            Console.WriteLine($"\u001b[31m{nameof(FoodIdentityMap)} cleared\u001b[0m");
            identityMap.Clear();
        }
    }
}
