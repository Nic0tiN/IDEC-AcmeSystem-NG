using System;
using AcmeSystem.Presentation.ClientWeb.Infrastructure;
using NUnit.Framework;

namespace AcmeSystem.InfrastructureTest.HelpersTest
{
    public class FlashMessageTest
    {
        [Test]
        public void CanSetError()
        {
            var expected_message = "This is an error";
            var expected_type = FlashMessage.FlashType.danger;

            FlashMessage.Error("This is an error");

            Assert.AreEqual(expected_message, FlashMessage.Message);
            Assert.AreEqual(expected_type, FlashMessage.Type);
        }

        [Test]
        public void CanSetSuccess()
        {
            var expected_message = "This is a success";
            var expected_type = FlashMessage.FlashType.danger;

            FlashMessage.Error("This is a success");

            Assert.AreEqual(expected_message, FlashMessage.Message);
            Assert.AreEqual(expected_type, FlashMessage.Type);
        }

        [Test]
        public void MessageEmptyAfterUsage()
        {
            FlashMessage.Error("This is an error");

            Assert.AreEqual("This is an error", FlashMessage.Message);
            Assert.AreEqual(String.Empty, FlashMessage.Message);
        }
    }
}
