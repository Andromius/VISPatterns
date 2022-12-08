using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MainCourse : Food
    {
        public bool IsFried { get; set; }
        public MainCourse(int id, string name, double price, bool isFried) : base(id, name, price)
        {
            IsFried = isFried;
        }
        public MainCourse(string name, double price, bool isFried) : base(name, price)
        {
            IsFried = isFried;
        }

        public override string ToString()
        {
            return base.ToString() + (IsFried ? "Food is fried\n" : "Food is not fried\n"); 
        }
    }
}
