using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using DevWork.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DevWorkTests
{
    [TestClass]
    public class EmployerControllerTests
    {
        [TestMethod]
        public void PostEmployer_Success()
        {
            var service = new Mock<IEmployerService>();
            service.Setup(S => S.CreateEmployer(It.IsAny<EmployerCreate>())).Returns(true);
            var controller = new EmployerController(service.Object);
            
            var model = new EmployerCreate();

            var result = controller.Post(model);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void PostEmployer_Failure_CreateEmployerFailed()
        {
            var service = new Mock<IEmployerService>();
            service.Setup(S => S.CreateEmployer(It.IsAny<EmployerCreate>())).Returns(false);
            var controller = new EmployerController(service.Object);

            var model = new EmployerCreate();

            var result = controller.Post(model);
            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }

        public void PostEmployer_Failure_ModelInvalid()
        {

        }
    }
}
