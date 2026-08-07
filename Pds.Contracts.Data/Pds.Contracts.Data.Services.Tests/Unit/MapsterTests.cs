using Mapster;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pds.DocumentExchange.Data.Services.Mapster;

namespace Pds.Contracts.Data.Services.Tests.Unit
{
    [TestClass, TestCategory("Unit")]
    public class MapsterTests
    {
        [TestMethod]
        public void MapsterTypeAdapterConfigExtensionsMeetsExpectation()
        {
            // arrange
            TypeAdapterConfig config = new ();
            config.Configure();

            // act / assert
            TypeAdapterConfig.GlobalSettings.Compile();
        }
    }
}
