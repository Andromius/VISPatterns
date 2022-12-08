using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Dessert : Food
    {
        public int CherryAmount { get; set; }
        public Dessert(int id, string name, double price, int cherryAmount) : base(id, name, price)
        {
            CherryAmount = cherryAmount;
        }
        public Dessert(string name, double price, int cherryAmount) : base(name, price)
        {
            CherryAmount = cherryAmount;
        }

        public override string ToString()
        {
            string line = $"Cherry amount: {CherryAmount}\n";
            return base.ToString() + line;
        }
    }
}
