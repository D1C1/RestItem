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
        public override string ToString()
        {
            return $"id: {Id} name: {Name} itemquality {Itemquality} quantity {Quantity}";
        }
    }
}
