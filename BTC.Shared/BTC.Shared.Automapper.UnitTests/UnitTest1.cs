using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace BTC.Shared.Automapper.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var kernel = new StandardKernel();
            kernel.Get<AutoMapperSerivce>().RegisterMapperConfigs<TestMapperConfig>();
            var model = new TestModel { Id = 1 };

            var viewModel = model.MapTo(new TestViewModel());

            Assert.AreEqual(model.Id, viewModel.Id);
        }
    }
}
