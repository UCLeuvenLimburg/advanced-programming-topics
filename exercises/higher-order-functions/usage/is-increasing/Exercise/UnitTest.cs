
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Exercise.Solution;

namespace Exercise
{
    public class UnitTest
    {
        [Fact]
        public void Test()
        {
            Assert.True(new List<int> {}.IsIncreasing());
            Assert.True(new List<int> {1}.IsIncreasing());
            Assert.True(new List<int> {1, 2, 3, 4, 5}.IsIncreasing());
            Assert.True(new List<int> {4, 7, 9}.IsIncreasing());
            Assert.True(new List<int> {2, 2, 2}.IsIncreasing());

            Assert.False(new List<int> {2, 1}.IsIncreasing());
            Assert.False(new List<int> {1, 4, 7, 8, 5}.IsIncreasing());
            Assert.False(new List<int> {5, 7, 1, 5}.IsIncreasing());
        }
    }
}
