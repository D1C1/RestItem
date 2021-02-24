using RestItem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RestItem.Managers
{
    public class ItemsManager
    {
        private static int _nextId = 1;

        private static readonly List<Item> Data = new List<Item>()
        {
            new Item() {Id = _nextId++, Itemquality = 1, Name = "mad", Quantity = 4},
            new Item() {Id = _nextId++, Itemquality = 2, Name = "malk", Quantity = 5},
            new Item() {Id = _nextId++, Itemquality = 6, Name = "terning", Quantity = 3}
        };

        public List<Item> GetAll(string name = null, string sortBy = null)
        {
            List<Item> item = new List<Item>(Data);

            if (name!=null)
            {
                item = item.FindAll(item => item.Name != null && item.Name.StartsWith(name));
            }
            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    case "name":
                        item = item.OrderBy(item => item.Name).ToList();
                        break;
                    case "itemquality":
                        item = item.OrderBy(item => item.Itemquality).ToList();
                        break;
                    case "quantity":
                        item = item.OrderBy(item => item.Quantity).ToList();
                        break;
                    // skip any other properties in the query string
                }
            }
            return item;
        }

        public Item GetById(int id)
        {
           return Data.Find(item => item.Id == id);
        }

        public Item Add(Item value)
        {
            Item.ValidateItem(value);
            value.Id = _nextId++;
            Data.Add(value);
            return value;
        }

        public void Delete(int id)
        {
            Item item = Data.Find(item1 => item1.Id == id);
            if (item == null) return;
            Data.Remove(item);
        }

        public Item Update(int id, Item value)
        {
            Item item = Data.Find(item1 => item1.Id == id);
            if (item == null) return null;
            item.Itemquality = value.Itemquality;
            item.Quantity = value.Quantity;
            item.Name = value.Name;
            return item;
        }
    }
}
