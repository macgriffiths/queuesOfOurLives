using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Services.Tests
{
    [TestClass]
    public class ConnectionServicesTests
    {
        private ConnectionService _connectionService;

        [TestInitialize]
        public void Init()
        {
            _connectionService = new ConnectionService();
        }

        [TestMethod]
        public void PublishMessage_GivenInvalidMessage_ShouldBeFalse_Test()
        {
            var result = _connectionService.PublishMessage(null, "TestQueue");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PublishMessage_GivenValidMessage_ShouldBeTrue_Test()
        {
            var result = _connectionService.PublishMessage("Hello World", "TestQueue");

            Assert.IsTrue(result);
        }

    }
}
