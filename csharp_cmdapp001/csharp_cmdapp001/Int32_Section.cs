using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_EL_CommandLineApp
{
  /// <summary>
  /// A class implementing manipulation mets with Int32 type.
  /// </summary>
  static class Int32_Section
  {
    /// <summary>
    /// Returns a str describing mets of this class.
    /// </summary>
    /// <returns>A str representation of the description.</returns>
    public static string PrintInstruction()
    {
      string newLine = new String('-', 80);
      StringBuilder intro = new StringBuilder();
      intro.Append(newLine + "\n");
      intro.Append("This section specifies about Int32 type manipulation.\n");
      intro.Append("You will be asked to choose the option you want to perform.\n");
      intro.Append("Then you will input the values you want to be operated on.\n");
      intro.Append("\nOptions:\n");
      intro.Append("1) Returns the inputed number with negative value.\n");
      intro.Append("2) Determine if the inputed number is even or not.\n");
      intro.Append("3) Determine all postive odd integers below the inputed number (not included).\n");
      intro.Append("4) Determine if the inputed number is divisible to 2 other numbers.\n");
      intro.Append("5) Calculate the sum of the number sequence from 0 to the inputed number.\n");
      intro.Append("6) Calculate the factorial of the inputed number.\n");
      intro.Append(newLine);
      return intro.ToString();
    }

    // Int32 type manipulation mets

    /// <summary>
    /// Transform the value of the param into negative.
    /// </summary>
    /// <param name="num">An integer.</param>
    /// <returns>The negative value of the param.</returns>
    /// Ref: https://www.codewars.com/kata/55685cd7ad70877c23000102
    public static int M01_TurnNegative(int num)
    {
      return Math.Abs(num) * -1;
    }

    /// <summary>
    /// Determine if the param is even or not.
    /// </summary>
    /// <param name="num">An integer.</param>
    /// <returns>A bool representation of the result.</returns>
    /// Ref: https://www.codewars.com/kata/even-or-odd/csharp
    public static bool M02_EvenOrOdd(int num)
    {
      return (num % 2 == 0) ? true : false;
    }

    /// <summary>
    /// Returns the amount of odd number that is smaller than the param.
    /// </summary>
    /// <param name="num">An integer in question.</param>
    /// <param name="res">The array containing all the odd numbers.</param>
    /// <returns>The count of all the odd number smaller than the param.</returns>
    /// Ref: https://www.codewars.com/kata/59342039eb450e39970000a6
    public static double M03_OddCount(int num, out int[] res)
    {
      double count = Math.Floor((double)num / 2);
      res = new int[(int)count];
      int ele = 1;
      for (int i = 0; i < res.Length; i++)
      {
        res[i] = ele;
        ele += 2;
      }
      return count;
    }

    /// <summary>
    /// Checks if the param is divisible to 2 other numbers or not.
    /// </summary>
    /// <param name="num">An integer in question.</param>
    /// <param name="divisorOne">The first divisor.</param>
    /// <param name="divisorTwo">The second divisor.</param>
    /// <returns>A bool representation of the result.</returns>
    /// Ref: https://www.codewars.com/kata/5545f109004975ea66000086
    public static bool M04_IsDivisible(int num, int divisorOne, int divisorTwo)
    {
      return Int32.Equals(num % divisorOne, 0) && Int32.Equals(num % divisorTwo, 0);
    }

    /// <summary>
    /// Calculate the sum from 0 to the param.
    /// </summary>
    /// <param name="num">An integer in question.</param>
    /// <param name="arr">The array containing the number sequence from 0 to param.</param>
    /// <returns>The sum of the number sequence from zero to param.</returns>
    /// Ref: https://www.codewars.com/kata/55d24f55d7dd296eb9000030
    public static int M05_ZeroToNumSum(int num, out int[] arr)
    {
      int res = num * (num + 1) / 2;
      arr = new int[num + 1];
      for (int i = 0; i < arr.Length; i++)
      {
        arr[i] = i;
      }
      return res;
    }

    /// <summary>
    /// Calculate the factorial of the param.
    /// </summary>
    /// <param name="num">The positive integer.</param>
    /// <returns>The result of the factorial.</returns>
    public static int M06_Factorial(int num)
    {
      int res = 1;
      if (Int32.Equals(num, 0) || Int32.Equals(num, 1))
      {
        return res;
      }
      res = M06_Factorial(num - 1) * num;
      return res;
    }


    // CORE MET

    /// <summary>
    /// A code wrapper for Int32 type.
    /// </summary>
    public static void Wrapper()
    {
      // Printing instructions
      Console.Clear();
      Console.WriteLine(Int32_Section.PrintInstruction());

      // Choosing mets
      Console.WriteLine("METHOD:\n");
      Console.WriteLine("Please type in the number of your choosing methods:");
      int userMet = Program.Choose(Console.ReadLine(), 1, 6);

      // Receive user inputs
      Console.WriteLine(new String('-', 40) + "\nINPUT\n");
      int userInputInt32 = (int)Program.HandleNumInput(Console.ReadLine());

      Console.WriteLine(new String('-', 40) + "\nOUTPUT\n");

      // Calling mets based on options including args 
      switch (userMet)
      {
        case 1:
          int res_case1 = Int32_Section.M01_TurnNegative(userInputInt32);
          Console.WriteLine($"The result: {res_case1}");
          break;
        case 2:
          bool res_case2 = Int32_Section.M02_EvenOrOdd(userInputInt32);
          Console.WriteLine($"The number is even: {res_case2}");
          break;
        case 3:
          double res_case3 = Int32_Section.M03_OddCount(userInputInt32, out int[] arr_case3);
          Console.WriteLine($"The number of odd integer: {res_case3}");
          Console.WriteLine($"The number sequence: {String.Join(",", arr_case3)}");
          break;
        case 4:
          Console.WriteLine("Type in the first divisor:");
          Int32.TryParse(Console.ReadLine(), out int divisor1);
          Console.WriteLine("Type in the second divisor:");
          Int32.TryParse(Console.ReadLine(), out int divisor2);
          bool res_case4 = Int32_Section.M04_IsDivisible(userInputInt32, divisor1, divisor2);
          Console.WriteLine($"The number is divisible to {divisor1} AND {divisor2}: {res_case4}");
          break;
        case 5:
          if (userInputInt32 < 0)
          {
            Console.WriteLine("Inputed number must be a positive integer!");
            break;
          }
          int res_case5 = Int32_Section.M05_ZeroToNumSum(userInputInt32, out int[] arr_case5);
          Console.WriteLine($"The sum: {res_case5}");
          Console.WriteLine($"The number sequence: {String.Join(",", arr_case5)}");
          break;
        case 6:
          if (userInputInt32 >= 13 || userInputInt32 < 0)
          {
            Console.WriteLine($"Value unacceptable!");
            break;
          }
          else
          {
            int res_case6 = Int32_Section.M06_Factorial(userInputInt32);
            Console.WriteLine($"{userInputInt32}! = {res_case6}");
            break;
          }
        default:
          Console.WriteLine("Unknown methods!");
          break;
      }
    }

  }

}
