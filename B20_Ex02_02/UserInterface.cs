using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace B20_Ex02_02
{
    public class UserInterface
    {
        private bool m_gameRunning = true;
        private Board m_board = null;
        private Player m_player = new Player();

        public UserInterface()
        {
            GameMenu();
        }

        private void GameMenu()
        {
            int m_userChoiceSizeOfBoard = 0;
            WelcomePrint();
            Ex02.ConsoleUtils.Screen.Clear();
        }

        private void WelcomePrint()
        {
            string TitleText = null;

            TitleText = @"
=============================
=============================
      ~~ MEMORY GAME ~~
=============================
=============================
           by MOR TWITO and ORTAL CHIFRUT                     
                (press any key to play)               
";
            Console.Title = "Memory Game by MOR TWITO and ORTAL CHIFRUT";
            Console.WriteLine(TitleText);
            Console.ReadKey();
        }
        

        private void getDecideAgainstWhoToPlay()
        {
            string userChoice = null;
            StringBuilder msgToPlayer = new StringBuilder();

            msgToPlayer.AppendLine("hello " + m_player.firstPlayerName);
            msgToPlayer.AppendLine("Who would you like to play with");
            msgToPlayer.AppendLine("Press 1 for Computer");
            msgToPlayer.AppendLine("Press 2 for another player");
            Console.Write(msgToPlayer);
            userChoice = Console.ReadLine();
            while (userChoice != "1" && userChoice != "2")
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.Write(msgToPlayer);
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Please press only 1 or 2");
                userChoice = Console.ReadLine();
            }

            if (userChoice == "1")
            {
                m_player.playWithComputer = true;
                m_player.secondPlayerName = "Computer";
            }
            else
            {
                m_player.secondPlayerName = GetPlayerName(2);
            }
        }
    }
}

