using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SizeDB2.Model;
using System.Data.Entity;

namespace SizeDB2
{
    [TestClass]
    public class SizeDB2Tests
    {
        static ApplicationContext db;
        [TestMethod]
        public void TestMethod1()
        {
            
            db = new ApplicationContext();
            var context = new People()
            {
            Fio= "Тестовый И.И.",
            Phone = "+79251487565",
            Date = DateTime.Parse("2019-12-14 00:00:00"),
            Address = "уд. Тестовая д.134 кв. 23",
            CityId = 1
            };
            //context.Fio = "Тестовый И.И.";
            //context.Phone = "+79251487565";
            //context.Date = DateTime.Parse("2019-12-14 00:00:00");
            //context.Address = "уд. Тестовая д.134 кв. 23";
            //context.CityId = 1;
            db.Peoples.Add(context);
            db.SaveChanges();
           

        }
    }
}
