#region imports
using static System.Console;

#endregion

/*  Usefull links

(Console.)
 ReadKey = https://docs.microsoft.com/en-us/dotnet/api/system.console.readkey?view=net-6.0
 Key = https://docs.microsoft.com/en-us/dotnet/api/system.consolekey?view=net-6.0
 
 
 */


namespace rauwers.dev
{
  class SimpleMenu
  {
    private int SelectedIndex;
    private string[] Options;
    private string Prompt;
    private Dictionary<string, bool> Settings;


    public SimpleMenu(string prompt, string[] options,
    bool widthAligned = true)
    {
      Settings = new Dictionary<string, bool>();
      Settings.Add("widthAligned", widthAligned);

      Prompt = prompt;
      Options = options;
      SelectedIndex = 0;
    }

    private void DisplayOptions()
    {
      WriteLine(Prompt);
      for (int i = 0; i < Options.Length; i++)
      {
        string currentOption = Options[i];
        string prefix = " ";

        ForegroundColor = ConsoleColor.White;
        BackgroundColor = ConsoleColor.Black;

        if (i == SelectedIndex)
        {
          prefix = "*";
          ForegroundColor = ConsoleColor.Black;
          BackgroundColor = ConsoleColor.White;
        }

        WriteLine($"{prefix} << {currentOption} >> ");

      }
      ResetColor();
    }

    public int Run()
    {
      ConsoleKey keyPressed;
      do
      {
        Clear();
        DisplayOptions();

        ConsoleKeyInfo keyInfo = ReadKey(true);
        keyPressed = keyInfo.Key;

        if (keyPressed == ConsoleKey.UpArrow) SelectedIndex--;
        else if (keyPressed == ConsoleKey.DownArrow) SelectedIndex++;

        SelectedIndex = SelectedIndex % Options.Length;
        if (SelectedIndex < 0) SelectedIndex += Options.Length;


      } while (keyPressed != ConsoleKey.Enter);

      return SelectedIndex;
    }
  }
}