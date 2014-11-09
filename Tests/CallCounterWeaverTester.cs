using System;
using NUnit.Framework;

namespace TeoVincent.Tests
{
    [TestFixture]
    public class CallCounterWeaverTester
    {
        private WeaverTests weaverTests;

        [TestFixtureSetUp]
        public void Setup()
        {
            weaverTests = new WeaverTests();
            weaverTests.Setup();
        }

        [Test]
        public void Validate_One_Time_Call_Of_Method()
        {
            // 1) arrange
            var type = weaverTests.Assembly.GetType("TeoVincent.AssemblyToProcess.Student");
            dynamic instance = Activator.CreateInstance(type);

            // 2) act
            instance.PassTheExam();
            int expected = 1;
            int actual = instance.PassTheExamCallsCount;

            // 3) assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Validate_No_Call_Of_Method()
        {
            // 1) arrange
            var type = weaverTests.Assembly.GetType("TeoVincent.AssemblyToProcess.Student");
            dynamic instance = Activator.CreateInstance(type);

            // 2) act
            int expected = 0;
            int actual = instance.PassTheExamCallsCount;

            // 3) assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Validate_Two_Times_Call_Of_Method()
        {
            // 1) arrange
            var type = weaverTests.Assembly.GetType("TeoVincent.AssemblyToProcess.Student");
            dynamic instance = Activator.CreateInstance(type);

            // 2) act
            instance.PassTheExam();
            instance.PassTheExam();
            int expected = 2;
            int actual = instance.PassTheExamCallsCount;

            // 3) assert
            Assert.AreEqual(expected, actual);
        }
    }
}