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
        [Fact]
        public void EmptyStringReturnsZero()
        {
            var calculator = new Calculator();

            var response = calculator.Add("");

            Assert.Equal(0, response);
        }
    }
}
