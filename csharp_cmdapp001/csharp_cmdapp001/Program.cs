using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_EL_CommandLineApp
{
  class Program
  {
    static void Main(string[] args)
    {
      // Testing zone

      // Introduction to the program
      Console.WriteLine(Program.PrintIntro());

      // Choosing sections
      Console.WriteLine("Please type in the number of your choosing section:");
      string userInput = Console.ReadLine();
      int userSection = Program.Choose(userInput, 1, 10);

      // Calling wrapper mets with desired section
      switch (userSection)
      {
        case 1: // Int32 Section
          Int32_Section.Wrapper();
          break;
        case 2: // Double Section
          Int32_Section.Wrapper();
          break;
        case 3: // Decimal Section
          Int32_Section.Wrapper();
          break;
        case 4: // Character Section
          Int32_Section.Wrapper();
          break;
        case 5: // String Section
          Int32_Section.Wrapper();
          break;
        case 6: // Array Section
          Int32_Section.Wrapper();
          break;
        case 7: // DateTime Section
          Int32_Section.Wrapper();
          break;
        case 8: // List Section
          Int32_Section.Wrapper();
          break;
        case 9: // Dictionary Section
          Int32_Section.Wrapper();
          break;
        case 10: // Others
          Others_Section.Wrapper();
          break;
        default:
          Console.WriteLine("Unknown section!");
          break;
      }

      Console.WriteLine("Press Enter to exit...");
      Console.ReadLine();

    }

    /// <summary>
    /// Print out how to use this program.
    /// </summary>
    /// <returns>The str value of the instructions.</returns>
    public static string PrintIntro()
    {
      string newLine = new String('-', 80);
      StringBuilder intro = new StringBuilder();
      intro.Append(newLine + "\n");
      intro.Append("Welcome to the Command Line App.\n");
      intro.Append("This app was created to demonstrate my understanding of C#.\n");
      intro.Append("The app will be divided into many sections.\n");
      intro.Append("Each section shall handles their specific problems.\n");
      intro.Append("\nOptions: \n");
      intro.Append("1) Int32 Section.\n");
      intro.Append("2) Double Section.\n");
      intro.Append("3) Decimal Section.\n");
      intro.Append("4) Character Section.\n");
      intro.Append("5) String Section.\n");
      intro.Append("6) Array Section.\n");
      intro.Append("7) DateTime Section.\n");
      intro.Append("8) List Section.\n");
      intro.Append("9) Dictionary Section.\n");
      intro.Append("10) Others.\n");
      intro.Append(newLine);
      return intro.ToString();
    }

    /// <summary>
    /// Code logic handling user input with limit range.
    /// </summary>
    /// <param name="input">The input value from the user.</param>
    /// <param name="min">The min range.</param>
    /// <param name="max">The max range.</param>
    /// <returns>The satisfied input</returns>
    public static int Choose(string input, int min, int max)
    {
      Int32.TryParse(input, out int userChoice); // userChoice = 0 if wrong || cant convert
      while (userChoice == 0 || userChoice < min || userChoice > max)
      { // Force user to input correct section value
        Console.Write("Unacceptable input. Retype:");
        Int32.TryParse(Console.ReadLine(), out userChoice);
      }
      return userChoice;
    }

    /// <summary>
    /// Code logic handling user input.
    /// </summary>
    /// <param name="input">The input value from the user.</param>
    /// <returns>The satisfied input.</returns>
    /// Returns a double for parsable to other numeric types like Int32, ...
    public static double HandleNumInput(string input)
    {
      bool isParsable = Double.TryParse(input, out double userValueNum); // user can input value 0 here
      while (!isParsable)
      { // Force user to input acceptable arg value 
        Console.WriteLine("Value of input unacceptable! Retype:");
        Double.TryParse(Console.ReadLine(), out userValueNum);
      }
      return userValueNum;
    }

    /// <summary>
    /// Code logic handling multiple user inputs from a str.
    /// </summary>
    /// <param name="input">The unfiltered input.</param>
    /// <returns>The filtered input stored in a collection.</returns>
    public static List<string> HandleMulInputStr(string input)
    {
      string[] userStrSplitted = input.Split(new Char[] { ' ', ',', '.', ':', '\t' });
      List<string> userStr = new List<string>();
      foreach (string ele in userStrSplitted)
      {
        userStr.Add(ele);
      }
      return userStr;
    }
  }
}
