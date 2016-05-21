using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace BTC.Shared.Automapper.UnitTests
{
    [TestClass]
    public class AutomaperTests
    {
        [TestMethod]
        public void MapperTest()
        {
            var kernel = new StandardKernel();
            kernel.Get<AutoMapperSerivce>().RegisterMapperConfigs<TestMapperConfig>();
            var model = new TestModel { Id = 1 };

            var viewModel = model.MapTo(new TestViewModel());

            Assert.AreEqual(model.Id, viewModel.Id);
        }


        [TestMethod]
        public void MapperMultipleConfigsTest()
        {
            var kernel = new StandardKernel();
            kernel.Get<AutoMapperSerivce>().RegisterMapperConfigs<TestMapperConfig>();
            var model = new TestModel { Id = 1 };

            var viewModel = model.MapTo(new TestViewModel());
            new TestModel2().MapTo(new TestViewModel());

            Assert.AreEqual(model.Id, viewModel.Id);
        }
    }
}
