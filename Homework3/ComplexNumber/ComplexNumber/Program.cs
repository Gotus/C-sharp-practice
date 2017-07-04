using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumber
{
    class ComplexNumberClass
    {
        public Double realPart { get; private set; }
        public Double imaginaryPart { get; private set; }

        public ComplexNumberClass(Double realPart, Double imaginaryPart)
        {
            this.realPart = realPart;
            this.imaginaryPart = imaginaryPart;
        }

        public ComplexNumberClass Add(ComplexNumberClass complexNumber)
        {
            Double resultRealPart = this.realPart + complexNumber.realPart;
            Double resultImaginaryPart = this.imaginaryPart + complexNumber.imaginaryPart;
            ComplexNumberClass result = new ComplexNumberClass(resultRealPart, resultImaginaryPart);
            return result;
        }

        public ComplexNumberClass Add(ComplexNumberClass first, ComplexNumberClass second)
        {
            return first.Add(second);
        }

        public ComplexNumberClass Add(params ComplexNumberClass[] arrayComplexNumbers)
        {
            ComplexNumberClass result = new ComplexNumberClass(this.realPart, this.imaginaryPart);
            for (int i = 0; i < arrayComplexNumbers.Length; i++)
            {
                result = result.Add(arrayComplexNumbers[i]);
            }

            return result;
        }

        public static ComplexNumberClass AddComplexNumbers(ComplexNumberClass first, ComplexNumberClass second)
        {
            return first.Add(second);
        }

        public static ComplexNumberClass AddComplexNumbers(params ComplexNumberClass[] arrayComplexNumbers)
        {
            ComplexNumberClass result = new ComplexNumberClass(0, 0);
            for (int i = 0; i < arrayComplexNumbers.Length; i++)
            {
                result = result.Add(arrayComplexNumbers[i]);
            }

            return result;
        }

        public static ComplexNumberClass operator +(ComplexNumberClass first, ComplexNumberClass second)
        {
            return first.Add(second);
        }

        public ComplexNumberClass Substract(ComplexNumberClass complexNumber)
        {
            Double resultRealPart = this.realPart - complexNumber.realPart;
            Double resultImaginaryPart = this.imaginaryPart - complexNumber.imaginaryPart;
            ComplexNumberClass result = new ComplexNumberClass(resultRealPart, resultImaginaryPart);
            return result;
        }

        public ComplexNumberClass Substract(ComplexNumberClass first, ComplexNumberClass second)
        {
            return first.Substract(second);
        }

        public static ComplexNumberClass SubstractComplexNumbers(ComplexNumberClass first, ComplexNumberClass second)
        {
            return first.Substract(second);
        }

        public static ComplexNumberClass operator -(ComplexNumberClass first, ComplexNumberClass second)
        {
            return first.Substract(second);
        }

        public ComplexNumberClass Multiply(ComplexNumberClass complexNumber)
        {
            Double resultRealPart = this.realPart * complexNumber.realPart - this.imaginaryPart * complexNumber.imaginaryPart;
            Double resultImaginaryPart = this.imaginaryPart * complexNumber.realPart + this.realPart * complexNumber.imaginaryPart;
            ComplexNumberClass result = new ComplexNumberClass(resultRealPart, resultImaginaryPart);
            return result;
        }

        public ComplexNumberClass Multiply(ComplexNumberClass first, ComplexNumberClass second)
        {
            return first.Multiply(second);
        }

        public ComplexNumberClass Multiply(params ComplexNumberClass[] arrayComplexNumbers)
        {
            ComplexNumberClass result = new ComplexNumberClass(this.realPart, this.imaginaryPart);
            for (int i = 0; i < arrayComplexNumbers.Length; i++)
            {
                result = result.Multiply(arrayComplexNumbers[i]);
            }

            return result;
        }

        public static ComplexNumberClass MultiplyComplexNumbers(ComplexNumberClass first, ComplexNumberClass second)
        {
            return first.Multiply(second);
        }

        public static ComplexNumberClass MultiplyComplexNumbers(params ComplexNumberClass[] arrayComplexNumbers)
        {

            ComplexNumberClass result = new ComplexNumberClass(0, 0);
            for (int i = 0; i < arrayComplexNumbers.Length; i++)
            {
                result = result.Multiply(arrayComplexNumbers[i]);
            }

            return result;
        }

        public static ComplexNumberClass operator *(ComplexNumberClass first, ComplexNumberClass second)
        {
            return first.Multiply(second);
        }

        public ComplexNumberClass Divide(ComplexNumberClass complexNumber)
        {
            Double resultRealPart = (this.realPart * complexNumber.realPart + this.imaginaryPart * complexNumber.imaginaryPart)/
                (complexNumber.realPart*complexNumber.realPart + complexNumber.imaginaryPart * complexNumber.imaginaryPart);

            Double resultImaginaryPart = (this.imaginaryPart * complexNumber.realPart - this.realPart * complexNumber.imaginaryPart) /
                (complexNumber.realPart * complexNumber.realPart + complexNumber.imaginaryPart * complexNumber.imaginaryPart);
            ComplexNumberClass result = new ComplexNumberClass(resultRealPart, resultImaginaryPart);
            return result;
        }

        public ComplexNumberClass Divide(ComplexNumberClass first, ComplexNumberClass second)
        {
            return first.Divide(second);
        }

        public static ComplexNumberClass DivideComplexNumbers(ComplexNumberClass first, ComplexNumberClass second)
        {
            return first.Divide(second);
        }

        public static ComplexNumberClass operator /(ComplexNumberClass first, ComplexNumberClass second)
        {
            return first.Divide(second);
        }

        public double ABS()
        {
            return Math.Sqrt(this.realPart * this.realPart + this.imaginaryPart * this.imaginaryPart);
        }

        public static double ABS(ComplexNumberClass complexNumber)
        {
            return complexNumber.ABS();
        }

        public static explicit operator double(ComplexNumberClass complexNumber)
        {
            return complexNumber.ABS();
        }

        public static ComplexNumberClass operator +(ComplexNumberClass second)
        {
            ComplexNumberClass first = new ComplexNumberClass(0, 0);
            return first.Add(second);
        }

        public static ComplexNumberClass operator -(ComplexNumberClass second)
        {
            ComplexNumberClass first = new ComplexNumberClass(0, 0);
            return first.Substract(second);
        }

        public static Boolean operator ==(ComplexNumberClass first, ComplexNumberClass second)
        {
            if ((first.realPart == second.realPart) && (first.imaginaryPart == second.imaginaryPart))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean operator !=(ComplexNumberClass first, ComplexNumberClass second)
        {
            if ((first.realPart == second.realPart) && (first.imaginaryPart == second.imaginaryPart))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        override public String ToString()
        {
            return this.realPart.ToString() + this.imaginaryPart.ToString();
        }

        public override int GetHashCode()
        {
            int realHashCode = this.realPart.GetHashCode();
            int imaginaryHashCode = this.imaginaryPart.GetHashCode();

            return realHashCode ^ imaginaryHashCode;
        }

        public override bool Equals(Object obj)
        {
            if (this.GetHashCode() == obj.GetHashCode())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
