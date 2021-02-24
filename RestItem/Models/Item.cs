using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestItem.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Itemquality { get; set; }
        public int Quantity { get; set; }

        public void ValidateItem()
        {
            if (this.Name.Length<=2)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Quantity<0)
            {
                throw new ArgumentOutOfRangeException("Må ikke være mindre end 0");
            }
            if (this.Itemquality < 0)
            {
                throw new ArgumentOutOfRangeException("Må ikke være mindre end 0");
            }
        }

        public override string ToString()
        {
            return $"id: {Id} name: {Name} itemquality {Itemquality} quantity {Quantity}";
        }
    }
}
