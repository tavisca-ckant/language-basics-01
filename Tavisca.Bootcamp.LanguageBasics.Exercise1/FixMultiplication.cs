using System;

namespace GradeBook
{
    public class FixMultiplication
    {
       public static int FindDigit (string equation) 
       {
           // Find Indexes of special characters in String.
            var asteriskIndex = equation.IndexOf("*");
            var equalsIndex = equation.IndexOf("=");
            var questionsIndex = equation.IndexOf("?");

            // Split string in expression and result
            string[] expressionAndResult = equation.Split("=");

            // Split expression to extract numbers.
            string[] numbers = expressionAndResult[0].Split("*");
            var result = expressionAndResult[1];

            // if ? is after =
            if (questionsIndex > equalsIndex) 
            {
                return FindIntegerInResult (numbers, result);
            } 
            // ? in expression part i.e before =
            else 
            {
                // ? in num1
                if (asteriskIndex > questionsIndex) 
                {
                    return FindIntegerInFirstNumber (numbers, result);
                } 
                // ? in num2
                else 
                {
                    return FindIntegerInSecondNumber (numbers, result);
                }
            }
       }

       private static int FindIntegerInFirstNumber (string[] numbers, string result)
       { 
            var givenResult = int.Parse(result);
            var secondNumber = int.Parse(numbers[1]);

            // If integral division is possible
            if (IsIntegralDivisionPossible (givenResult, secondNumber)) 
            {
                return GetIntAtQuestionPlace (secondNumber, givenResult, numbers[0]);
            } 
            // Integral division impossible
            else 
            {
                return -1;
            }
       }

       private static int FindIntegerInSecondNumber (string[] numbers, string result) 
       {
            var givenResult = int.Parse(result);
            var firstNumber = int.Parse(numbers[0]);

            // If integral division is possible
            if (IsIntegralDivisionPossible(givenResult, firstNumber)) 
            {
                return GetIntAtQuestionPlace (firstNumber, givenResult, numbers[1]);
            } 
            // Integral division impossible
            else 
            {
                return -1;
            }
       }

       private static int FindIntegerInResult (string[] numbers, string result)
       {
           var questionsIndex = result.IndexOf ("?");
           var num1 = int.Parse (numbers[0]);
           var num2 = int.Parse (numbers[1]);
           var expectedResult = num1 * num2 + "";
           return int.Parse(expectedResult[questionsIndex].ToString());
       }

       private static bool IsIntegralDivisionPossible (int num1, int num2)
       {
            return (num1 % num2 == 0);
       }

       private static int GetIntAtQuestionPlace (int number, int result, string toComputeInNumber)
        {
            var expectedNumber = result / number + "";

            if (expectedNumber.Length < toComputeInNumber.Length)
            {
                return -1;
            }
            else 
            {
                var questionsIndex = toComputeInNumber.IndexOf ("?");
                return int.Parse (expectedNumber[questionsIndex].ToString());
            }
        }
    }
}
