using NUnit.Framework;

namespace Laboratorna_6_4_REC.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestFindMaxIndex()
        {
            int[] array = { 3, 2, 5, 0, 6, 9, 7, 0, 5, 4 };
            int maxIndex = Program.FindMaxIndexRecursive(array, array.Length);
            Assert.AreEqual(5, maxIndex);
        }

        [Test]
        public void TestCalculateProductBetweenZeros()
        {
            int[] array = { 3, 2, 5, 0, 6, 9, 7, 0, 5, 4 };
            int product = Program.CalculateProductBetweenZerosRecursive(array, array.Length);
            Assert.AreEqual(378, product);
        }

        [Test]
        public void TestTransformArray()
        {
            int[] array = { 3, 2, 5, 0, 6, 9, 7, 0, 5, 4 };
            Program.TransformArrayRecursive(array, array.Length);

            int[] expectedArray = { 2, 0, 9, 0, 4, 3, 5, 6, 7, 5 };
            CollectionAssert.AreEqual(expectedArray, array);
        }
    }
}