using CannonLoader;
using NUnit.Framework;
using System;

namespace CannonLoaderTests
{
    [TestFixture]
    public class SolutionTests
    {
        private CannonLoaderSolution sut;

        [SetUp]
        public void SetUp()
        {
            sut = new CannonLoaderSolution();
        }

        [Test]
        public void Example_Test()
        {
            int solution = sut.Solution(new int[] { 1, 6, 4, 5, 4, 5, 1, 2, 3, 4, 7, 2 });
            Assert.AreEqual(3, solution);
        }

        [Test]
        public void Example2_Test()
        {
            int solution = sut.Solution(new int[] { 1, 5, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 });
            Assert.AreEqual(3, solution);
        }

        [Test]
        public void NullInput_Test()
        {
            Assert.Throws<ArgumentException>(() => sut.Solution(null));
        }

        [Test]
        public void VoidInputArray_Test()
        {
            Assert.Throws<ArgumentException>(() => sut.Solution(new int[] { }));
        }

        [Test]
        public void NoPicksArray_Test()
        {
            Assert.Throws<ArgumentException>(() => sut.Solution(new int[] { 1, 1, 1, 1 }));
        }

        [TestCase(new[] { 1, 2, 1 }, ExpectedResult = 1)]
        [TestCase(new[] { 1, 3, 1, 2, 1 }, ExpectedResult = 2)]
        [TestCase(new[] { 1, 4, 1, 1, 2, 1 }, ExpectedResult = 2)]
        [TestCase(new[] { 1, 5, 1, 1, 2, 1, 2, 1 }, ExpectedResult = 2)]
        [TestCase(new[] { 1, 6, 1, 1, 2, 1, 1, 2, 1 }, ExpectedResult = 3)]
        [TestCase(new[] { 1, 7, 1, 1, 2, 1, 2, 1, 1, 2, 1 }, ExpectedResult = 3)]
        [TestCase(new[] { 1, 1, 1, 1, 1, 8, 1, 1, 2, 1, 2, 1, 1, 2, 1 }, ExpectedResult = 3)]
        public int ValidArray_Tests(int[] picks)
        {
            return sut.Solution(picks);
        }
    }
}