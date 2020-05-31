using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex02_02
{
    class Player
    {
        private string m_playerName;  
        private int m_playerScore; 
       // private char m_playerChoise; //בחירת המשבצת של השחקן- לא בטוחה שזה צריך להיות במחלקה הזאת

        public Player(string i_PlayerName)
        {
            this.m_playerName = i_PlayerName;
            m_playerScore = 0;
        }
        public string GetPlayerName()
        {
            return this.m_playerName;
        }

        public void SetPlayerName(string i_PlayerName)
        {
            this.m_playerName = i_PlayerName;
        }
        public void SetScorePlayer(int i_PlayerScore)
        {
            this.m_playerScore = i_PlayerScore;
        }
        public int GetScorePlayer()
        {
            return this.m_playerScore;
        }
        /*  public void SetPlayerChoise(char i_PlayerChoice)
          {
              this.playerChoice = PlayerChoice;
          }

          public char GetPlayerChoice()
          {
              return this.playerChoice;
          }*/
    }
}