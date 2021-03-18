using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculatorBlank
{

    // https://osherove.com/tdd-kata-1
    public class CalculatorTests
    {
        Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator(new Mock<ILogger>().Object);
        }

        [Fact]
        public void EmptyStringReturnsZero()
        {
            var response = _calculator.Add("");

            Assert.Equal(0, response);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void SingleNumberAdditionReturnsThatNumber(string numbers, int expected)
        {
            var response = _calculator.Add(numbers);
            
            Assert.Equal(expected, response);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("1,-1", 0)]
        [InlineData("55,-50", 5)]
        public void AddsTwoNumbersSeparatedByCommas(string numbers, int expected)
        {
            var response = _calculator.Add(numbers);

            Assert.Equal(expected, response);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("33,56,-81", 8)]
        public void AddsAnyNumberOfIntegersSeparatedByCommas(string numbers, int expected)
        {
            var response = _calculator.Add(numbers);

            Assert.Equal(expected, response);
        }
    }
}
