using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalclulatorTwo
{
    [TestFixture]
    public class StrintCalculatorTests
    {
        [Test]
        public void Add_GivenEmptyString_ShouldReturnZero()
        {
            //Arrange
            var numbers = string.Empty;
            int expected = 0;
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }     

        [Test]
        public void Add_GivenOne_ShouldReturnOne()
        {
            //Arrange
            var numbers = "1";
            int expected = 1;
            var sut = CreateStringCalculator();

            //Act'
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase("1 ,2", 3)]
        [TestCase("1,2,4,4", 11)]
        [TestCase("2,3,1,5,54", 65)]
        public void Add_GivenMultipleNumbers_ShouldReturnTheirSum(string numbers, int expected)
        {   
            //Arrange
            var sut = CreateStringCalculator();

            //Act'
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Add_GivenNumbersWithNewLinesBetweenThem_ShouldReturnSum()
        {
            //Arrange
            var numbers = "1\n2,3";
            int expected = 6;
            var sut = CreateStringCalculator();

            //Act'
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersWithDifferentDelimiters_ShouldReturnTheirSum()
        {
            //Arrange
            var numbers = "//;\n1;2";
            int expected = 3;       
            var sut = CreateStringCalculator();

            //Act'
            var actual = sut.Add(numbers);  

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenANegativeNumber_ShouldThrowExceptionAndReturnThatNumber()
        {
            //Arrange
            var numbers = "-10";
            string expected = $"negatives not allowed {numbers}";       
            var sut = CreateStringCalculator();

            //Act'
            var actual = Assert.Throws<Exception>(() => sut.Add(numbers));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_GivenMultipleNegativeNumbers_ShouldThrowExceptionAndReturnNumbers()
        {
            //Arrange
            var numbers = "-10,-1,-2,-2";
            string expected = $"negatives not allowed {numbers}";
            var sut = CreateStringCalculator();

            //Act'
            var actual = Assert.Throws<Exception>(() => sut.Add(numbers));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_GivenNumbersBiggerThan1000_ShouldIgnoreThem()
        {
            //Arrange   
            var numbers = "1001, 2";    
            int expected = 2;
            var sut = CreateStringCalculator();

            //Act'
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersBetween0And1000_ShouldIgnoreThem()
        {
            //Arrange   
            var numbers = "1000, 2";
            int expected = 1002;
            var sut = CreateStringCalculator();

            //Act'
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
