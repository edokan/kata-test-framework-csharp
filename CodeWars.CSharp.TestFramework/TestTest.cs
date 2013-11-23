using System;
using NUnit.Framework;

namespace CodeWars.CSharp.TestFramework
{
    [TestFixture]
    public class TestTest
    {
        [Test]
        public void MustSerialize()
        {
            var obj = new {s = "String", i = 1};
            Assert.AreEqual(Test.Inspect(obj), "{\"s\":\"String\",\"i\":1}");
        }

        [Test]
        public void MessageMustAllowString()
        {
            Assert.AreEqual(Test.Message("test"), "test");
        }

        [Test]
        public void MessageMustAllowStringWithPrefix()
        {
            Assert.AreEqual(Test.Message("test", "prefix"), "prefix - test");
        }

        [Test]
        public void MessageMustAllowArrays()
        {
            var message = new[] { "t", "e", "s", "t" };
            Assert.AreEqual(Test.Message(message), "t - e - s - t");
        }

        [Test]
        public void MessageMustAllowArraysWithPrefix()
        {
            var message = new[] { "t", "e", "s", "t" };
            Assert.AreEqual(Test.Message(message, "prefix"), "prefix - t - e - s - t");
        }

        [Test]
        public void MessageMustAllowFunctions()
        {
            Func<string> message = () => "test";
            Assert.AreEqual(Test.Message(message), "test");
        }

        [Test]
        public void MessageMustAllowFunctionsWithPrefix()
        {
            Func<string> message = () => "test";
            Assert.AreEqual(Test.Message(message, "prefix"), "prefix - test");
        }

        [Test]
        public void FailedCase()
        {
            Assert.Throws(typeof(Test.Error), () =>
            {
                var obj1 = new {A = "a", B = 1, C = false};
                var obj2 = new {A = 1, B = 1, C = false};

                Test.AssertEquals(obj1, obj2, "I hope they are same", new ExpectOptions {SuccessMsg = "Yes! Yes, they are."});
            });
        }

        [Test]
        public void SuccessCase()
        {
            Assert.DoesNotThrow(() =>
            {
                var obj1 = new { A = "a", B = 1, C = false };
                var obj2 = new { A = "a", B = 1, C = false };

                Test.AssertEquals(obj1, obj2, "I hope they are same", new ExpectOptions { SuccessMsg = "Yes! Yes, they are." });
            });
        }
    }

}
