using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vueling.Infrastructure.Repository.Contracts;
using FluentAssertions;

namespace Vueling.Infrastructure.Test.Unit
{
    [TestClass]
    public class ClientRepositoryTest
    {
        private IClientRepository mockObject;

        [TestInitialize]
        public void Setup()
        {
            var mock = new Mock<IClientRepository>();
            mock.Setup(m => m.GetByEmail("test@vueling.com")).Returns(new Model.Client { Email = "test@vueling.com" }); // mockeado estos métodos para que devuelvan un cliente
            mock.Setup(m => m.GetByName("John")).Returns(new Model.Client { Name = "John" });

            mockObject = mockObject;
        }

        [TestMethod]
        public void GetByMailTest()
        {
            var client = mockObject.GetByEmail("test@vueling.com");

            client.Email.Should().Be("test@vueling.com");
        }

        [TestMethod]
        public void GetByNameTest()
        {
            var client = mockObject.GetByEmail("John");

            client.Email.Should().Be("John");
        }
    }
}
