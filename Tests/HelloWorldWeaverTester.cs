using System;
using NUnit.Framework;

namespace TeoVincent.Tests
{
    [TestFixture]
    public class HelloWorldWeaverTester
    {
        private WeaverTests weaverTests;

        [TestFixtureSetUp]
        public void Setup()
        {
            weaverTests = new WeaverTests();
            weaverTests.Setup();
        }

        [Test]
        public void ValidateHelloWorldIsInjected()
        {
            var type = weaverTests.Assembly.GetType("Hello");
            var instance = (dynamic)Activator.CreateInstance(type);

            Assert.AreEqual("Hello World", instance.World());
        }
    }
}