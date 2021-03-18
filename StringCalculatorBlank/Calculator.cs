using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorBlank
{
    public class Calculator
    {
        ILogger _resultLogger;

        public Calculator(ILogger resultLogger)
        {
            _resultLogger = resultLogger;
        }

        public int Add(string numbers)
        {
            var result = 0;

            if(!numbers.Equals("")){
                var numbersStringArray = numbers.Split(",");
                for(int i=0; i<numbersStringArray.Length; i++)
                {
                    result += int.Parse(numbersStringArray[i]);
                }
            }

            _resultLogger.Write(result);
            return result;
        }

    }
}
