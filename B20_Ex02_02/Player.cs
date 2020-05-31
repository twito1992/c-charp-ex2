using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex02_02
{
    class Player
    {
        private string m_playerName; //שם השחקן 
        private int playerScore; //ניקוד השחקן
        private char playerChoise; //בחירת המשבצת של השחקן- לא בטוחה שזה צריך להיות במחלקה הזאת

        public Player(string i_PlayerName)
        {
            this.playerName = i_PlayerName;
            playerScore = 0;
        }
        public string GetPlayerName()
        {
            return this.playerName;
        }

        public void SetPlayerName(string i_PlayerName)
        {
            this.playerName = i_PlayerName;
        }
        public void SetScorePlayer(int i_PlayerScore)
        {
            this.playerScore = i_PlayerScore;
        }
        public int GetScorePlayer()
        {
            return this.playerScore;
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