using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    const string menuHint = "Type 'menu' to go back to menu";
    string[] passwordEasy = { "password", "batman", "secure", "access", "welcome" };
    string[] passwordNormal = { "ledger", "debit", "authorization", "disclosure", "mortgage" };
    string[] passwordHard = { "nevada", "amphibious", "ammunition", "camouflage", "parachute" };
    string[] passwordVeryHard = { "ch1m1ch4ng4", "b00bs", "b00g4l00", "3l3ctr1c", "4n0nym0u5" };

    //Game state
    int level;
    enum Screen { MainMenu, Password, Win }
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("To hack list:");
        Terminal.WriteLine("");
        Terminal.WriteLine("(1) School (n00bs)");
        Terminal.WriteLine("(2) Bank (just another day at work)");
        Terminal.WriteLine("(3) Area 51 (risky, but aliens?!?)");
        Terminal.WriteLine("");
        Terminal.WriteLine("TIME 2 HACK:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("Console terminated. Closing device is safe.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3" || input == "69420");

        if (isValidLevel)
        {
            level = int.Parse(input);
            AccessDenied();
        }
        else if (input == "ipconfig")
        {
            Terminal.WriteLine("Nice Try");
        }
        else
        {
            Terminal.WriteLine("Invalid network");
        }
    }

    void AccessDenied()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetPassword();
        Terminal.WriteLine("Access denied, password hacking toolkit /" + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetPassword()
    {
        switch (level)
        {
            case 1:
                password = passwordEasy[Random.Range(0, passwordEasy.Length)];
                break;
            case 2:
                password = passwordNormal[Random.Range(0, passwordNormal.Length)];
                break;
            case 3:
                password = passwordHard[Random.Range(0, passwordHard.Length)];
                break;
            case 69420:
                password = passwordVeryHard[Random.Range(0, passwordVeryHard.Length)];
                Terminal.WriteLine("We live in a society");
                break;
            default:
                Debug.LogError("invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWin();
        }
        else
        {
            AccessDenied();
        }
    }

    void DisplayWin()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hack successful");
        WinReward();
        Terminal.WriteLine(menuHint);
    }

    void WinReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
  _______________________
 /\______________________/`-.
<()>____________________<    ##
 \/______________________\,-'
"
                );
                break;
            case 2:
                Terminal.WriteLine(@"
  .     '     ,
    _________
 _ /_|_____|_\ _
   '. \   / .'
     '.\ /.'
       '.'
"
                );
                break;
            case 3:
                Terminal.WriteLine(@"
 _ ________,
 >`(==(----'
(__/~~`
"
                );
                break;
            case 69420:
                Terminal.WriteLine(@"
  _____
 /     \
| () () |
 \  ^  /
  |||||
  |||||
"
                );
                break;
            default:
                Debug.LogError("invalid level number");
                break;
        }
    }
}
