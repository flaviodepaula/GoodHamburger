using System.Xml.Linq;

namespace Domain.Models
{
    public class Product
    {
        private decimal _value;

        public string Name { get; set; }
        public decimal Value => _value;
        public CaterogyOfProduct Caterogy { get; set; }

        public void UpdatePrice(decimal price)
        {
            _value = price;
        }

    }
}