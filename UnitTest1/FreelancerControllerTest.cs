using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using System.Web.Http.Results;
using Contracts;
using DevWork.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Freelancer;
using Models.Message;
using Moq;

namespace DevWorkTests
{
    [TestClass]
    public class FreelancerControllerTests
    {
        [TestMethod]
        public void PostFreelancer_Success()
        {
            var service = new Mock<IFreelancerService>();
            service.Setup(S => S.CreateFreelancer(It.IsAny<FreelancerCreate>())).Returns(true);
            var controller = new FreelancerController(service.Object);

            var model = new FreelancerCreate();

            var result = controller.Post(model);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void PostFreelancer_Failure_CreateFreelancerFailed()
        {
            var service = new Mock<IFreelancerService>();
            service.Setup(S => S.CreateFreelancer(It.IsAny<FreelancerCreate>())).Returns(false);
            var controller = new FreelancerController(service.Object);

            var model = new FreelancerCreate();

            var result = controller.Post(model);
            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }
    }
}