using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public class FixMultiplication
    {
       public static int FindDigit (string equation) {
           // Find Indexes of special characters in String.
            var m = equation.IndexOf("*");
            var e = equation.IndexOf("=");
            var q = equation.IndexOf("?");

            // Split string in expression and result
            string[] result = equation.Split("=");

            // Split expression to extract numbers.
            string[] num = result[0].Split("*");

            // if ? is after =
            if (e < q) {
                // Convert numbers from string to integer.
                var n1 = Convert.ToInt32(num[0]);
                var n2 = Convert.ToInt32(num[1]);
                var res = n1 * n2 + "";
                // return an integer on same index as ?, 
                // - 48 to convert to actual value from ASCII
                return Convert.ToInt32(res[q-e-1]) - 48;
            } 
            // ? in expression part i.e before =
            else {
                // ? in num1
                if (m > q) {
                    // Get res and n2 as integers.
                    var res = Convert.ToInt32(result[1]);
                    var n2 = Convert.ToInt32(num[1]);
                    // If integral multiplication is possible
                    if (res % n2 == 0) {
                        // Evaluate n1 and convert to string.
                        var n1 = res / n2 + "";
                        // If ? is at ones place and it has value zero 
                        if (n1.Length < num[0].Length) {
                            return -1;
                        } 
                        // If ? is not at ones place or it has non-zero value.
                        else {
                            // - 48 to convert to actual value from ASCII
                            return Convert.ToInt32(n1[q]) - 48;
                        }
                    } 
                    // Integral multiplication impossible
                    else {
                        return -1;
                    }
                } 
                // ? in num2
                else {
                    // Get res and n1 as integer
                    var res = Convert.ToInt32(result[1]);
                    var n1 = Convert.ToInt32(num[0]);
                    // If integral multiplication possible
                    if (res % n1 == 0) {
                        // Evaluate n2 and convert to string
                        var n2 = res / n1 + "";
                        // zero at ones place
                        if (n2.Length < num[1].Length) {
                            return -1;
                        } else {
                            // - 48 to convert to actual value from ASCII
                            return Convert.ToInt32(n2[q-m-1]) - 48;
                        }
                    } else {
                        return -1;
                    }
                }
            }
       }
    }
}
