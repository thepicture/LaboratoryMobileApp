using LaboratoryMobileApp.Models;
using LaboratoryMobileApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ServiceGetterUnitTestProject
{
    [TestClass]
    public class ServiceGetterUnitTest
    {
        private static ServiceGetter _getter;

        [ClassInitialize]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", 
            "IDE0060:Remove unused parameter", 
            Justification = "Context is not needed")]
        public static void ServiceGetterUnitTestInitialize(TestContext context)
        {
            _getter = new ServiceGetter();
        }

        [TestMethod]
        public void Get_GetFirstElement_EqualsBilirubinCommon()
        {
            // Arrange.
            string expected = "Билирубин общий";

            // Act.
            ResponseService actual = _getter.Get().ToList().First();

            // Assert.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Get_GetSecondElement_EqualsAIDS()
        {
            // Arrange.
            string expected = "СПИД";

            // Act.
            ResponseService actual = _getter.Get().ToList().Skip(1).First();

            // Assert.
            Assert.AreEqual(expected, actual);
        }
    }
}
