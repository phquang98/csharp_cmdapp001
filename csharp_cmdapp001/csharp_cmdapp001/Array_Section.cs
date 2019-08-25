using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_EL_CommandLineApp
{
  class Array_Section
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
      intro.Append("This section presents specifies about Int32 type manipulation.\n");
      intro.Append("You will be asked to choose the method you want to perform.\n");
      intro.Append("Then you will input the values you want to be operated on.\n");
      intro.Append("\nOptions:\n");
      intro.Append("1) Basic Fizz Buzz puzzle.\n");
      intro.Append("2) Calculate diameter and area of common 2D shapes.\n");
      intro.Append("3) Calculate diameter, area and volume of common 3D shapes.\n");
      intro.Append(newLine);
      return intro.ToString();
    }


    // CORE MET

    /// <summary>
    /// A code wrapper for Array section.
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
          break;
        default:
          Console.WriteLine("Unknown methods!");
          break;
      }
    }

  }
}
