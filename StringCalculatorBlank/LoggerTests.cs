using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculatorBlank
{
    public class LoggerTests
    {
        Mock<ILogger> _loggerMock;
        
        public LoggerTests()
        {
            _loggerMock = new Mock<ILogger>();
        }

        [Theory]
        [InlineData("1,2,3",6)]
        public void TestLoggerIsCalledWhenAddIsCalled(string numbers, int expected)
        {
            var calculator = new Calculator(_loggerMock.Object);
            calculator.Add(numbers);

            _loggerMock.Verify(f => f.Write(expected));
        }

        [Theory]
        [InlineData("blamo")]
        [InlineData("tacos")]
        public void WebServiceCalledOnLoggerException(string message)
        {
            var stubbedLogger = new Mock<ILogger>();
            var mockedWebService = new Mock<IWebService>();
            stubbedLogger.Setup(logger => logger.Write(It.IsAny<int>())).Throws(new LoggerException(mockedWebService.Object, message));
            var calculator = new Calculator(_loggerMock.Object);

            calculator.Add("");

            mockedWebService.Verify(f => f.LoggingError(message));
        }
    }
}
