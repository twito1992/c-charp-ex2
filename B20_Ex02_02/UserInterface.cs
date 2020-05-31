using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace B20_Ex02_02
{
    public class UserInterface
    {
        gameMenu();
    }
    

    private void gameMenu()
    {

        int userChoiceSizeOfBoard = 0;

        welcomePrint();
        Ex02.ConsoleUtils.Screen.Clear();
        m_Player.PlayerOneName = getNameFromClient(1);
        Ex02.ConsoleUtils.Screen.Clear();
        getDecisionAgainstWhoToPlay();
        Ex02.ConsoleUtils.Screen.Clear();
        userChoiceSizeOfBoard = getDecisionAboutTheSizeOfBoard();
        startGame(userChoiceSizeOfBoard);
    }
}
        

    private void welcomePrint()
    {
    string TitleText = null;

    TitleText = @"
============================
============================
       MEMORY GAME
============================
============================
           by MOR TWITO and ORTAL CHIFRUT                     
                (press any key to play)               
";

    Console.Title = "Memory Game by MOR TWITO and ORTAL CHIFRUT";
    Console.WriteLine(TitleText);
    Console.ReadKey();
    }


private string getNameFromClient(int i_PlayerNumber)
{
    string nameFromClient;

    Console.WriteLine("Player" + i_PlayerNumber + " Please enter your name: ");
    nameFromClient = Console.ReadLine();
    while (nameFromClient.Length < 2)
    {
        Ex02.ConsoleUtils.Screen.Clear();
        Console.WriteLine("Bad Name (Name Required at least 2 lettars)");
        Console.WriteLine("Player" + i_PlayerNumber + " Please enter your name: ");
        nameFromClient = Console.ReadLine();
    }

    return nameFromClient;
}
}
