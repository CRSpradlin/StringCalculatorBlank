using System;

namespace StringCalculatorBlank
{
    class LoggerException : Exception
    {
        public LoggerException(IWebService webService, string message) : base(message)
        {
            webService.LoggingError(message);
        }
    }
}