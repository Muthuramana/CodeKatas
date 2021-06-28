using CodeKatas;
using System;
using System.Linq;

ReadOption(args.FirstOrDefault());

static void ReadOption(string option)
{
    var outputSeperator = $"{Environment.NewLine}{new string('-', 20)}{Environment.NewLine}";

    try
    {
        switch (option)
        {
            case "e":
                break;

            case "d":
                Console.WriteLine(outputSeperator + DiamondKata.CreateDiamond(Console.ReadKey().KeyChar));
                TryAgain();
                break;

            default:
                TryAgain();
                break;
        }
    }
    catch(Exception ex)
    {
        Console.Error.WriteLine(outputSeperator + ex.ToString());
        TryAgain();
    }

    void TryAgain()
    {
        Console.WriteLine(outputSeperator);
        Console.WriteLine("Following code katas are available.");
        Console.WriteLine("-'e' to exit.");
        Console.WriteLine("-'d' for diamond kata.");
        ReadOption(Console.ReadLine());
    }
}