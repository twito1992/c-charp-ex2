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

        
        public Player()
        {
            m_playerScore = 0;
            m_playerName = null;
        }


        public Player(string i_PlayerName)
        {
            m_playerName = i_PlayerName;
            m_playerScore = 0;
        }
        public string GetPlayerName()
        {
            return m_playerName;
        }

        public void SetPlayerName(string i_PlayerName)
        {
            m_playerName = i_PlayerName;
        }
        public void SetScorePlayer(int i_PlayerScore)
        {
            m_playerScore = i_PlayerScore;
        }
        public int GetScorePlayer()
        {
            return m_playerScore;
        }

        public int Score
        {
            set
            {
                m_playerScore = value;
            }
            get
            {
                return m_playerScore;
            }

        }
    }
}