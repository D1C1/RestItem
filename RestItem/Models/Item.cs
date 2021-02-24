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

        public static void ValidateItem(Item newitem)
        {
            if (newitem.Name.Length<=2)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (newitem.Quantity<0)
            {
                throw new ArgumentOutOfRangeException("Må ikke være mindre end 0");
            }
            if (newitem.Itemquality < 0)
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
