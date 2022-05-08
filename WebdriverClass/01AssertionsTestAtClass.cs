using NUnit.Framework;
using System.Collections.Generic;

namespace WebdriverClass
{
    class AssertionsTestAtClass
    {
        [Test]
        public void AssertionsBasicExample()
        {
            //These examples are correct they are going to pass
            Assert.IsTrue(true);
            Assert.IsFalse(false);

            Assert.IsNull(null);
            Assert.IsNotNull(1);

            Assert.IsEmpty("");
            Assert.IsEmpty(new List<int>());
            Assert.IsNotEmpty("not empty");
            Assert.IsNotEmpty(new int[2]);
        }

        [Test]
        public void AssertionsAdvancedExample()
        {
            var array1 = new int[2] { 1, 2 };
            var array2 = new int[2] { 1, 2 };
            var array3 = array1;
            var array4 = new int[2] { 1, 3 };

            //Correct the assertions to pass this test!
            Assert.AreEqual(array1, array2, "The values are not equal!");
            Assert.AreNotEqual(array1, array4, "The values are equal!");

            // Ez itt memória területet ellenőriz
            Assert.AreSame(array1, array3, "The objects are not same!");

            Assert.AreNotSame(array1, array4, "The objects are same!");

            Assert.Contains(3, array4, "The objects are equal!");

            Assert.Greater(2, 1, "First parameter is not greater!");
            Assert.Less(1, 2, "First parameter is not less!");


            // Ezek pedig defaultban jók voltak :P
            Assert.IsInstanceOf(typeof(int), 1);
            Assert.IsNotInstanceOf(typeof(string), 1);
        }

        [Test]
        public void AssertionsStringExample()
        {
            //These examples are correct they are going to pass
            StringAssert.Contains("waking", "Hope is a waking dream");
            StringAssert.StartsWith("Hope", "Hope is a waking dream");
            StringAssert.EndsWith("dream", "Hope is a waking dream");
            StringAssert.IsMatch("is\\s.*\\sdream", "Hope is a waking dream");
        }
    }
}
