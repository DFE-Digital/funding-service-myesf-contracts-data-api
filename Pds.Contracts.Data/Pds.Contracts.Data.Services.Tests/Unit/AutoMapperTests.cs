using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pds.Contracts.Data.Services.AutoMapperProfiles;

namespace Pds.Contracts.Data.Services.Tests.Unit
{
    [TestClass, TestCategory("Unit")]
    public class AutoMapperTests
    {
        [TestMethod]
        public void AutoMapper_Configuration_IsValid()
        {
            var autoMapperConfig = new MapperConfiguration(c => c.AddProfile<ContractMapperProfile>());
            autoMapperConfig.AssertConfigurationIsValid();
        }
    }
}
