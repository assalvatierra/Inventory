using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using scm;
using scm.Controllers;
using scm.Models;

namespace scm.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }


    [TestClass]
    public class DBClassTester
    {
        Models.dbClasses db1 = new dbClasses();

        [TestMethod]
        public void Add_PurchaseRequest()
        {
            //ARRANGE
            //read initial data
            int iData1_In_01 = 0;
            int idata4_out_01 = 0;
            List<Models.EntItems> datalist = db1.getItemInventory();
            var data01 = datalist.Where(d => d.Id == 1).FirstOrDefault(); //item# 1
            if (data01 != null) iData1_In_01 = (int)data01.ItemIn; //item# 1 -- In
            var data04 = datalist.Where(d => d.Id == 4).FirstOrDefault(); //item# 4
            if (data04 != null) idata4_out_01 = (int)data04.ItemIn; //item# 4 -- out

            //execute actions
            //add hdr
            string sSQL1 = @"
insert [dbo].[scPrHdrs]([dtPr],[Remarks],[Status]) values
('10/19/2017','UnitTest.101','NEW')";

            //add detail
            string sSQL2 = @"
insert into [dbo].[scPrDtls]([scPrHdrId],[scItemId],[scUomId],[Qty]) values
('1','1','1','133')";
            db1.executeSQL(sSQL2);

            //datalist = db1.getItemInventory();

            //read updated data
            int iData1_In_02 = 0;
            int idata4_out_02 = 0;
            datalist = db1.getItemInventory();
            data01 = datalist.Where(d => d.Id == 1).FirstOrDefault(); //item# 1
            if (data01 != null) iData1_In_02 = (int)data01.ItemIn; //item# 1 -- In -- NEW
            data04 = datalist.Where(d => d.Id == 4).FirstOrDefault(); //item# 4
            if (data04 != null) idata4_out_02 = (int)data04.ItemIn; //item# 4 -- out -- NEW

            Assert.AreEqual(iData1_In_01, iData1_In_02 - 133);
            Assert.AreEqual(idata4_out_01, idata4_out_02);

        }

    }


}
