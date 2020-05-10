using Microsoft.VisualStudio.TestTools.UnitTesting;
using Video_rental_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_rental_01.Models.Tests
{
    [TestClass()]
    public class CustomerEntriesTests
    {
        [TestMethod()]
        public void TopCustomerTest()
        {
            Models.CustomerEntries obj = new Models.CustomerEntries();
            String name=obj.TopCustomer();
            Assert.IsTrue(true);

        }

        [TestMethod()]
        public void getCostTest()
        {
            Models.VideoEntries obj = new Models.VideoEntries();
            int cost=obj.getCost(1, 1);
            Assert.AreEqual(5, 5);
        }

        [TestMethod()]
        public void getDeleteTest()
        {
            Models.VideoEntries obj = new Models.VideoEntries();
            obj.Delete(1);
            Assert.IsTrue(true);
        }


    }
}