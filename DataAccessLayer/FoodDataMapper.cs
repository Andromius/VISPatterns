using BusinessLayer;
using System.Reflection.Metadata.Ecma335;

namespace DataAccessLayer
{
    public class FoodDataMapper
    {
        public bool Delete(Food f)
        {
            if(!f.Id.HasValue)
            {
                return false;
            }
            try
            {
                FoodMockDB.database.RemoveAt(f.Id.Value);
                FoodIdentityMap.Clear();
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        public Food FindById(int id)
        {
            Food f = FoodIdentityMap.GetFood(id);
            if (f != null)
            {
                return f;
            }
            try
            {
                DataRow dr = FoodMockDB.database.ElementAt(id);
                switch (dr.type)
                {
                    case 'D':
                        Dessert d = new Dessert(id, dr.name, dr.price, dr.cherryAmount.Value);
                        FoodIdentityMap.Add(id, d);
                        return d;
                    case 'M':
                        MainCourse m = new MainCourse(id, dr.name, dr.price, dr.isFried.Value);
                        FoodIdentityMap.Add(id, m);
                        return m;
                    default:
                        f = new Food(id, dr.name, dr.price);
                        FoodIdentityMap.Add(id, f);
                        return f;
                };
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"\u001b[31mItem with id {id} doesn't exist in DB\u001b[0m");
                return null;
            }

        }

        public List<Food> FindByType(char type)
        {
            if (type != 'N' && type != 'M' && type != 'D')
            {
                Console.WriteLine($"\u001b[31mItem of type {type} doesn't exist in the DB\u001b[0m");
                return null;
            }

            List<Food> foods = FoodIdentityMap.GetFood(type);
            if (foods != null)
            {
                return foods;
            }

            foods = new List<Food>();
            foreach (var item in FoodMockDB.database)
            {
                if (item.type == type)
                {
                    switch (type)
                    {
                        case 'D':
                            foods.Add(new Dessert(FoodMockDB.database.IndexOf(item), item.name, item.price, item.cherryAmount.Value));
                            break;
                        case 'M':
                            foods.Add(new MainCourse(FoodMockDB.database.IndexOf(item), item.name, item.price, item.isFried.Value));
                            break;
                        case 'N':
                            foods.Add(new Food(FoodMockDB.database.IndexOf(item), item.name, item.price));
                            break;
                    }
                }
            }
            if(foods.Count > 0) 
            { 
                FoodIdentityMap.Add(type, foods);
                return foods;
            }
            return null;
        }

        public void Insert(Food f)
        {
            if(f is MainCourse m)
            {
                FoodMockDB.database.Add(new DataRow { name = m.Name, price = m.Price, type = 'M', cherryAmount = null, isFried = m.IsFried});
            }
            else if(f is Dessert d)
            {
                FoodMockDB.database.Add(new DataRow { name = d.Name, price = d.Price, type = 'D', cherryAmount = d.CherryAmount, isFried = null });
            }
            else
            {
                FoodMockDB.database.Add(new DataRow { name = f.Name, price = f.Price, type = 'N', cherryAmount = null, isFried = null });
            }
        }

        public bool Update(Food f)
        {
            if(!f.Id.HasValue)
            {
                return false;
            }
            try
            {
                DataRow dr = FoodMockDB.database.ElementAt(f.Id.Value);
                dr.name = f.Name;
                dr.price = f.Price;
                if (f is Dessert d)
                {
                    dr.cherryAmount = d.CherryAmount;
                }
                else if(f is MainCourse m)
                {
                    dr.isFried = m.IsFried;
                }
                FoodMockDB.database[FoodMockDB.database.IndexOf(FoodMockDB.database.ElementAt(f.Id.Value))] = dr;
                FoodIdentityMap.Clear();
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
    }
}