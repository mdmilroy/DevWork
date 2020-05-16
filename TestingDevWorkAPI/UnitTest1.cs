using System;
using System.Collections.Generic;
using Data;
using DevWork.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace TestingDevWorkAPI
{
    [TestClass]
    public class UnitTest1
    {
        public Guid _userId { get; set; } = new Guid();

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var controller = new ProfileController(repository);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.Get(10);

            // Assert
            Product product;
            Assert.IsTrue(response.TryGetContentValue<Product>(out product));
            Assert.AreEqual(10, product.Id);
        }

        private List<Employer> GetEmployers()
        {
            var testProducts = new List<Employer>();
            testProducts.Add(new Employer
            {
                UserId = _userId,
                Email = "new@gmail.com",
                FirstName = "Mike",
                LastName = "Milr",
                Organization = "Gaggle",

            });

            return testProducts;
        }
    }
}
