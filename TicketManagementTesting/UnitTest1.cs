
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using TicketManagement.Controllers;
using TicketManagement.Model;


namespace TicketManagementTesting
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void GetTicketByTicketNo()
        {

            RaiseTicketRepository raiseTicketRepository = new RaiseTicketRepository();
            var result = raiseTicketRepository.getTicketNumber(5);
            Assert.IsNotNull(result);
            Assert.AreEqual("akhil", result.UserName);
            Assert.AreEqual("Approved", result.status);

        }
        [Test]
        public void GetAllTickets()
        {
            RaiseTicketRepository raiseTicketRepository = new RaiseTicketRepository();
            var result = raiseTicketRepository.GetAllTickets();
            Assert.IsNotNull(result);
            //RaiseTicketRepository raiseTicketRepository = new RaiseTicketRepository();
            //var result = raiseTicketRepository;
            //var testProducts = result.GetAllTickets();
            //var controller = new RaiseTicketRepository(testProducts);
            //var controller = new RaiseTicketController();

            //var res = controller.GetallTickets().Result;
            //Assert.AreEqual(5, res);

        }
        //[Test]
        //public void GetAllTest()
        //{
        //    //Arrange
        //    //Act
        //    var result = new RaiseTicketController();
        //    var res = result.GetallTickets();
        //    //Assert
        //    //Assert.IsInstanceOf<ObjectResult>(res.Result);
        //    //Assert.IsType<OkObjectResult>(result.Result);

        //    var list = res.Result as OkObjectResult;

        //    Assert.IsInstanceOf<List<RaiseTicket>>(list.Value);



        //    var listBooks = list.Value as List<RaiseTicket>;

        //    Assert.AreEqual(5, listBooks.Count);
        //}


        //[Test]
        //public void GetAllTickets()
        //{

        //    RaiseTicketRepository raiseTicketRepository = new RaiseTicketRepository();
        //    var result = raiseTicketRepository.GetAllTickets();
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(GetAllTickets, result.);
        //    Assert.AreEqual("Approved", result.status);

        //}

        //    [Test]
        //    public void getTicketByStatus()
        //    {

        //        RaiseTicketRepository raiseTicketRepository = new RaiseTicketRepository();
        //        var result = raiseTicketRepository.GetTicketStatus("Approved");
        //        //result.tol
        //        Assert.IsNotNull(result);
        //        Assert.AreEqual("Approved", result);
        //       // Assert.AreEqual("Approved", result);

        //    }
    }
}


