using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestItem.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using RestItem.Models;

namespace RestItem.Managers.Tests
{
    [TestClass()]
    public class ItemsManagerTests
    {

        [TestMethod()]
        public void GetAllTest()
        {
            ItemsManager im = new ItemsManager();

            List<Item> All = im.GetAll(); 
            Assert.AreEqual(All.Count, 3);

            Item item = new Item();
            item = im.GetById(1);
            Assert.AreEqual("mad",item.Name);
            item = im.GetById(123);
            Assert.IsNull(item);
        
            Item newItem = new Item();
            im.Add(newItem);
            Assert.AreEqual(4,im.GetAll().Count);

            List<Item> Citems2 = im.GetAll(name: "m");
            Assert.AreEqual(2, Citems2.Count);

            newItem.Name = "hej";
            im.Update(4, newItem);
            Assert.AreEqual("hej",im.GetById(4).Name);
            Assert.IsNull(im.Update(5, newItem));

            im.Delete(4);
            Assert.AreEqual(3, im.GetAll().Count);

            List<Item> Citems = im.GetAll(name: "m");
            Assert.AreEqual(2, Citems.Count);

            List<Item> noItems = im.GetAll(name: "None");
            Assert.AreEqual(0, noItems.Count);

            List<Item> sortName = im.GetAll(sortBy: "name");
            Assert.AreEqual("mad", sortName[0].Name);

            List<Item> sortQual = im.GetAll(sortBy: "itemquality");
            Assert.AreEqual("mad", sortQual[0].Name);

            List<Item> sortQuant = im.GetAll(sortBy: "quantity");
            Assert.AreEqual("terning", sortQuant[0].Name);
        }

    }
}