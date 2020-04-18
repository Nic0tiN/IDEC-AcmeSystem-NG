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
        public void Can_get_NexT_Contact_By_Id()
        {
            var _idcontactgenerator = new IdContactGenerator();

            int expected = 112;

            Assert.AreEqual(expected, _idcontactgenerator.GetNext());
        }
    }
}
