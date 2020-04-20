using AcmeSystem.Infrastructure.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeSystem.InfrastructureTest.HelpersTest
{
    public class IdContactGeneratorTest
    {
        [Test]
        public void Can_get_Next_Contact_By_Id()
        {
            int expected = 101;

            Assert.AreEqual(expected, IdContactGenerator.GetNext());
        }
    }
}
