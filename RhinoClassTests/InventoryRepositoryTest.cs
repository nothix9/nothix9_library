using System;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using RhinoClass;
using System.Collections.Generic;

namespace RhinoClassTests
{
    [TestFixture]
    public class InventoryRepositoryTest
    {
        [Test]
        public void DoSomething_WhenInvoked_ShouldSubmitCorrectStubs()
        {
            var mockUnitOfWork = MockRepository.GenerateMock<IUnitOfWork>();
            mockUnitOfWork.Stub(uow => uow.GetTable<Inventory>()).Return(new List<Inventory>(){new Inventory(){Quantity = 1}, new Inventory(){Quantity = 2}}.AsQueryable());


            var rep = new InventoryRepository(mockUnitOfWork);
            rep.DoSomething();


            Assert.Inconclusive();
        }
    }
}
