using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_EL_CommandLineApp
{
  static class Others_Section
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
      intro.Append("This section presents some basic but cool programming questions.\n");
      intro.Append("You will be asked to choose the option you want to perform.\n");
      intro.Append("Then you will input the values you want to be operated on.\n");
      intro.Append("\nOptions:\n");
      intro.Append("1) Basic Fizz Buzz puzzle.\n");
      intro.Append("2) Calculate diameter and area of common 2D shapes.\n");
      intro.Append("3) Calculate diameter, area and volume of common 3D shapes.\n");
      intro.Append(newLine);
      return intro.ToString();
    }

    /// <summary>
    /// The popular Fizz Buzz question.
    /// </summary>
    /// <param name="num">n in the number squence.</param>
    /// <returns>A List<string> containing the sequence with the keywords.</string></returns>
    /// Ref: https://www.codewars.com/kata/5300901726d12b80e8000498
    public static List<string> M01_FizzBuzz(int num, int divisor_st, int divisor_nd)
    {
      List<string> res = new List<string>();
      for (int i = 1; i <= num; i++)
      {
        if (i % divisor_st == 0 && i % divisor_nd == 0)
        {
          res.Add("FizzBuzz");
        }
        else if (i % divisor_st == 0)
        {
          res.Add("Fizz");
        }
        else if (i % divisor_nd == 0)
        {
          res.Add("Buzz");
        }
        else
        {
          res.Add(i.ToString());
        }
      }

      return res;
    }

    /// <summary>
    /// Calculate circle, triangle and rectangle.
    /// </summary>
    /// <param name="input">A collection holding values to be operated on.</param>
    /// <returns>A collection holding values to be required.</returns>
    public static Dictionary<string, double> M02_Cal2d(List<string> input)
    {
      const double pi = 3.141;
      Dictionary<string, double> res = new Dictionary<string, double>();
      if (input[0].ToLower() == "circle")
      {
        res.Add("Radius", Convert.ToDouble(input[1]));
        res.Add("Circumference", Math.Round(2 * res["Radius"] * pi, 3));
        res.Add("Area", Math.Round(Math.Pow(res["Radius"], 2) * pi, 3));
        return res;
      }
      else if (input[0].ToLower() == "triangle")
      {
        res.Add("1st edge", Convert.ToDouble(input[1]));
        res.Add("2nd edge", Convert.ToDouble(input[2]));
        res.Add("3rd edge", Convert.ToDouble(input[3]));
        res.Add("Perimeter", res["1st edge"] + res["2nd edge"] + res["3rd edge"]);
        res.Add("Area", Math.Round(Math.Sqrt(res["Perimeter"] / 2 * (res["Perimeter"] / 2 - res["1st edge"]) * (res["Perimeter"] / 2 - res["2nd edge"]) * (res["Perimeter"] / 2 - res["3rd edge"])), 3)); // Heron Formula
        return res;
      }
      else if (input[0].ToLower() == "rectangle")
      {
        res.Add("Width", Convert.ToDouble(input[1]));
        res.Add("Height", Convert.ToDouble(input[2]));
        res.Add("Perimeter", (res["Width"] + res["Height"]) * 2);
        res.Add("Perimeter", Math.Round(res["Width"] * res["Height"], 3));
        return res;
      }
      else
      {
        res.Add("Empty", 0);
        return res;
      }
    }

    // CORE MET

    /// <summary>
    /// A code wrapper for Others section.
    /// </summary>
    public static void Wrapper()
    {
      // Printing instructions
      Console.Clear();
      Console.WriteLine(Others_Section.PrintInstruction());

      // Choosing mets
      Console.WriteLine("METHOD:\n");
      Console.WriteLine("Please type in the number of your choosing methods:");
      int userMet = Program.Choose(Console.ReadLine(), 1, 3);

      // Receive user inputs
      Console.WriteLine(new String('-', 40) + "\nINPUT\n");

      // Calling mets based on options including args and print output
      switch (userMet)
      {
        case 1:
          Console.WriteLine("Type in n (from 1 to n), then the first divisor then the second divisor:");
          List<string> userInputCase1 = Program.HandleMulInputStr(Console.ReadLine());
          List<string> res_case1 = Others_Section.M01_FizzBuzz(Convert.ToInt32(userInputCase1[0]), Convert.ToInt32(userInputCase1[1]), Convert.ToInt32(userInputCase1[2]));
          Console.WriteLine(new String('-', 40) + "\nOUTPUT\n");
          Console.WriteLine($"The result:\n {String.Join(" ", res_case1)}");
          break;
        case 2:
          Console.WriteLine("Type in order the shape and all necessary values (like edge lengths, ...):");
          List<string> userInputCase2 = Program.HandleMulInputStr(Console.ReadLine());
          Dictionary<string, double> res_case2 = Others_Section.M02_Cal2d(userInputCase2);
          Console.WriteLine(new String('-', 40) + "\nOUTPUT\n");
          foreach (KeyValuePair<string, double> kvp in res_case2)
          {
            Console.WriteLine("{0}: {1}",
                kvp.Key, kvp.Value);
          }
          break;
        default:
          Console.WriteLine("Unknown methods!");
          break;
      }
    }

  }
}
