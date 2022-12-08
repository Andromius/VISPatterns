using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    struct DataRow
    {
        public string name;
        public char type;
        public double price;
        public int? cherryAmount;
        public bool? isFried;    
    }
    internal class FoodMockDB
    {
        public static List<DataRow> database = new List<DataRow>()
        {
            new DataRow{name = "Koblizek", type = 'D', price = 50.99, cherryAmount = 0, isFried = null},
            new DataRow{name = "Zakusek", type = 'D', price = 60.99, cherryAmount = 5, isFried = null},
            new DataRow{name = "SmazenySyr", type = 'M', price = 100.99, cherryAmount = null, isFried = true},
            new DataRow{name = "Svickova", type = 'M', price = 50.99, cherryAmount = 0, isFried = false },
            new DataRow{name = "Okurek", type = 'N', price = 7.99, cherryAmount = null, isFried = null }
        };
    }
}
