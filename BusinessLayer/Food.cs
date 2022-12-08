using System.Text;

namespace BusinessLayer
{
    public class Food : DomainObject
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Food(int id, string name, double price) : base(id)
        {
            Name = name;
            Price = price;
        }
        public Food(string name, double price) : base()
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Id.HasValue ? $"Id: {Id.Value}" : "Id: no id");
            stringBuilder.AppendLine($"Food name: {Name}");
            stringBuilder.AppendLine($"Price: {Price} CZK");
            return stringBuilder.ToString();
        }

    }
}