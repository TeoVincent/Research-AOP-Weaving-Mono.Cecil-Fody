using System;
using NUnit.Framework;

namespace TeoVincent.Tests
{
    public class EventsWeavingTester
    {
        private WeaverTests weaverTests;

        [TestFixtureSetUp]
        public void Setup()
        {
            weaverTests = new WeaverTests();
            weaverTests.Setup();
        }
        
        [Test]
        public void ChildType_Property_Of_MyExampleEvent_Validate()
        {
            // 1) arrange
            var type = weaverTests.Assembly.GetType("TeoVincent.AssemblyToProcess.Events.MyExampleEvent");
            dynamic instance = Activator.CreateInstance(type);

            // 2) act
            string actual = instance.ChildType;
            string expected = "MyExampleEvent";

            // 3) assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ChildType_Property_Of_MyWeavedEvent_Validate()
        {
            // 1) arrange
            var type = weaverTests.Assembly.GetType("TeoVincent.AssemblyToProcess.Events.MyWeavedEvent");
            dynamic instance = Activator.CreateInstance(type);

            // 2) act
            string actual = instance.ChildType;
            string expected = "MyWeavedEvent";

            // 3) assert
            Assert.AreEqual(expected, actual);
        }
    }
}