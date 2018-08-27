using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Vueling.Common;
using Vueling.Infrastructure.Repository;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Test.Integration
{
    [TestClass] // testearemos client repository
    public class ClientRepositoryTest
    {
        IUnitOfWork UoW { get; set; }

        [TestInitialize]
        public void Setup()
        {
            var context = new VInsuranceContext();

            UoW = new UnitOfWork(context);

            UoW.ClientRepository.Insert(new Model.Client {
                Id = Guid.NewGuid(),
                Email = "test@vueling.com",
                Name = "John",
                Role = "user"
            });

            UoW.Save();
        }

        [ClassCleanup]
        public void Cleanup()
        {
            UoW.ClientRepository.Delete(UoW.ClientRepository.GetByName("John"));
        }

        [DataRow("test@vueling.com")] //como esto no existe en la base de datos, se pone en el setup para testearlo
        [TestMethod]
        public void GetByEmailTest(string email)
        {
            var client = UoW.ClientRepository.GetByEmail(email);
            Assert.AreEqual(email, client.Email); //importa el orden, se pone primero el expected
        }

        [DataRow("John")]
        [TestMethod]
        public void GetByName(string name)
        {
            var client = UoW.ClientRepository.GetByName(name);
            Assert.AreEqual(name, client.Name);
        }
    }
}
