using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProMax
{
    class CALCULATOR
    {
        public CALCULATOR()
        {
        }
        public CALCULATOR(float num1, float num2)
        {
            number1 = num1;
            number2 = num2;
        }
        public float number1;
        public float number2;
        public float degrees;

        public void changeValue(float num1, float num2)
        {
            number1 = num1;
            number2 = num2;
        }
        public float sum()
        {
            return number1 + number2;
        }

        public float subtraction()
        {
            return number1 - number2;
        }

        public float multiplication()
        { return number1 * number2; }

        public float division()
        {
            if (number2 != 0)
                return number1 / number2;
            else return -1;
        }

        public float mod()
        {
            return number1 % number2;
        }

        public double squareRoot(double num)
        {
            return Math.Sqrt(num);
        }

        public double exponent(double num)
        {
            return Math.Pow(number1, num);
        }

        public double log(double num)
        {
            return Math.Log(num);
        }

        public double sin(double num)
        {
            return (Math.Sin(num));
        }

        public double cos(double num)
        {
            return Math.Cos(num);
        }

        public double tan(double num)
        { return Math.Tan(num); }

    }
}
