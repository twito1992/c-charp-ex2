using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace B20_Ex02_02
{
    public class UserInterface
    {
        
        private Board m_board = null;
        private Player m_player1;
        private Player m_player2;
        private bool m_playWithComputer = true;

        

        public UserInterface()
        {
            GameMenu();
        }

        private void GameMenu()
        {
            
            WelcomePrint();
            Thread.Sleep(2000);
            Ex02.ConsoleUtils.Screen.Clear();
            startGame();
        }

        private void startGame()
        {
            Console.WriteLine("Enter player 1 name: ");
            m_player1 = new Player(Console.ReadLine());
            getDecideAgainstWhoToPlay();
            m_board = new Board();
            
            m_board.PlayGameBoard(m_player1.GetPlayerName(),m_player2.GetPlayerName());
            
   
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

            string userChoice;
            StringBuilder msgToPlayer = new StringBuilder();
          
            msgToPlayer.AppendLine("hello " + m_player1.GetPlayerName());
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
                m_player2 = new Player("Computer");
                
            }
            else
            {
                m_playWithComputer = false;
                Console.WriteLine("Enter player 2 name: ");
                m_player2 = new Player(Console.ReadLine());
            }
        }

       


    }
}

