using System;
using System.Collections.Generic;
using System.Threading;


namespace B20_Ex02_02
{
    public class Board
    {
        private static List<char> m_MemoryLetters = null;
        private int m_Row = 0;
        private int m_Colow = 0;
        private char[,] m_Board = null;
        private char[,] m_NewBoard = null;
        static Random m_random = new Random();
        private Player m_player1= null;
        private Player m_player2=null;
        private int m_playerNumber = 1;
        private int m_countmoves = 0;



        public Board()
        {
            m_Row = 0;
            m_Colow = 0;
        }

        public char[,] BoardGame
        {
            get
            {
                return m_Board;
            }

            set
            {
                m_Board = value;
            }
        }

        public int Row
        {
            get
            {
                return m_Row;
            }

            set
            {
                m_Row = value;
            }
        }
        public int Colow
        {
            get
            {
                return m_Colow;
            }

            set
            {
                m_Colow = value;
            }
        }

        public Board(int row,int colow)
        {
            m_Row = row;
            m_Colow = colow;
            m_Board = new char[row, colow];
            m_NewBoard = new char[row, colow];

            
        }

        private static void GetLetters(int i_row,int i_colow)
        {
            
            int size = ((i_row * i_colow)/2); 
            //returns a random letter.
            // ... Between 'A' and 'Z' inclusize.
            int num = m_random.Next(0, 23); // Zero to 25
            char let = (char)('A' + num);
            for (int j = 0; j<size; j++)
            {
               
                if (m_MemoryLetters == null)
                {
                    m_MemoryLetters = new List<char>();
                    m_MemoryLetters.Add(let);   
                }
                else
                {
                    bool is_Difreent= true;
                    do
                    {
                        is_Difreent = true;
                        for (int i = 0; i < m_MemoryLetters.Count; i++)
                            {
                                if (m_MemoryLetters[i] == let)
                                {
                                    is_Difreent = false;
                                }
                            }
                            if (is_Difreent == true)
                            {
                                m_MemoryLetters.Add(let);
                            }
                            num = m_random.Next(0, 24);
                            let = (char)('A' + num);

                        
                    } while (is_Difreent == false);
                }
            }
            
        }

        private void newGame()// init bord
        {
            List<char> newLetters = new List<char>();
            GetLetters(m_Row, m_Colow);

            List<char> temp = new List<char> (m_MemoryLetters);
            for (int i = 0; i < m_Row; i++)
            {
                for (int j = 0; j < m_Colow; j++)
                {
                    if (temp.Count > 0)
                    {
                        m_Board[i, j] = temp[0];
                        newLetters.Add(temp[0]);
                        temp.RemoveAt(0);
                    }
                    else
                    {
                        if (newLetters.Count > 0)
                        {
                            m_Board[i, j] = newLetters[0];
                            newLetters.RemoveAt(0);
                        }
                    }

                }
            }
        }
        private void getTitleOfBoardBySize(int i_Colow)
        {
            string titleX4 = "     A   B   C   D  ";
            string titleX6 = "     A   B   C   D   E   F  ";
            

            if (i_Colow ==4)
            {
                Console.WriteLine(titleX4);
            }
            else if (i_Colow == 6)
            {
                Console.WriteLine(titleX6);
            }
            
        }

        private void getHlineOfBoardBySize(int i_Colow)
        {
            string HLINEX4 = "   =================";
            string HLINEX6 = "   =========================";
            
            if (i_Colow==4)
            {
                Console.WriteLine(HLINEX4);
            }
            else if (i_Colow == 6)
            {
                Console.WriteLine(HLINEX6);
            }
            

        }

        private void drawBord()//TO CHACK BUILD BOARD WITH LETTERS
        {
            Thread.Sleep(2000);
            Ex02.ConsoleUtils.Screen.Clear();
            getTitleOfBoardBySize(m_Colow);
            for (int i = 0; i < m_Row; i++)
            {
                getHlineOfBoardBySize(m_Colow);
                Console.Write(" " + (i + 1));


                for (int j = 0; j < m_Colow; j++)
                {
                    Console.Write(" |");
                    
                        Console.Write(" {0}", m_Board[i, j]);
                }
                Console.Write(" |");
                Console.WriteLine();
                
            }

            getHlineOfBoardBySize(m_Colow);
        }


        private bool userChose()
        {
            string correntplayername;
            if (m_playerNumber == 1)
            {
                correntplayername = m_player1.GetPlayerName();
            }
            else
            {
                correntplayername = m_player2.GetPlayerName();
            }
            Console.WriteLine("");
            bool ifCorrect = true;
            int userChoiceRows = 0;
            int userChoiceColows = 0;
            int firstUserChoiceRows = 0;
            int firstUserChoiceColow = 0;
            string userChoice;
            for(int i =0; i < 2; i++)
            {
                drawChoseBord();
                
                Console.WriteLine("{0} Select a Place to put your chose (e.x F4):",correntplayername);
                userChoice = Console.ReadLine();
                if (userChoice[0] != 'Q')
                {
                    userChoiceRows = (userChoice[1] - '0') - 1;
                    userChoiceColows = userChoice[0] - 'A';
                    m_NewBoard[userChoiceRows, userChoiceColows] = m_Board[userChoiceRows, userChoiceColows];
                    drawChoseBord();
                }
                if (i==0)
                {
                    firstUserChoiceColow = userChoiceColows;
                    firstUserChoiceRows = userChoiceRows;
                }
            }
            if (m_NewBoard[firstUserChoiceRows, firstUserChoiceColow] != m_NewBoard[userChoiceRows, userChoiceColows])
            {
                m_NewBoard[firstUserChoiceRows, firstUserChoiceColow] = '\0';
                m_NewBoard[userChoiceRows, userChoiceColows] = '\0';
                ifCorrect = false;
            }
            else
            {
                m_countmoves++;
                if (m_playerNumber == 1)
                {
                    m_player1.Score++;
                }
                else
                {
                    m_player2.Score++;
                }
            }
            Ex02.ConsoleUtils.Screen.Clear();
            Thread.Sleep(2000);

            return ifCorrect;
            
            
        }
        private void drawChoseBord()
        {
            Thread.Sleep(2000);
            Ex02.ConsoleUtils.Screen.Clear();
            getTitleOfBoardBySize(m_Colow);
            for (int i = 0; i < m_Row; i++)
            {
                getHlineOfBoardBySize(m_Colow);
                Console.Write(" " + (i + 1));


                for (int j = 0; j < m_Colow; j++)
                {
                    Console.Write(" |");
                    Console.Write(" {0}", m_NewBoard[i, j]);
                }
                Console.Write(" |");
                Console.WriteLine();

            }

            getHlineOfBoardBySize(m_Colow);
        }

        public void PlayGameBoard(string i_player1, string i_player2)
        {
            int row;
            int colow;
            bool iscorrect = true;


            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Enter row and colow: (row=4/6,colow=4/6)");
            row = Convert.ToInt32(Console.ReadLine());
            colow = Convert.ToInt32(Console.ReadLine());

            while (((row != 4) && (row != 6)) || ((colow != 4) && (colow != 6)))
            {
                Console.WriteLine("Wrong input enter again: ");
                row = Convert.ToInt32(Console.ReadLine());
                colow = Convert.ToInt32(Console.ReadLine());
            }
            Board chack = new Board(row, colow);


            chack.newGame();


            chack.m_player1 = new Player(i_player1);

            chack.m_player2 = new Player(i_player2);

            do
            {
                iscorrect = chack.userChose();
                if (iscorrect == false)// החלפת שחקנים
                {
                    if (chack.m_playerNumber == 1)
                    {
                        chack.m_playerNumber = 2;
                    }
                    else
                    {
                        chack.m_playerNumber = 1;
                    }
                }
            } while (chack.m_countmoves < (chack.m_Row * chack.m_Colow / 2));

            Console.WriteLine("{0} Your score is: {1}", chack.m_player1.GetPlayerName(), chack.m_player1.Score);
            Console.WriteLine("{0} Your score is: {1}", chack.m_player2.GetPlayerName(), chack.m_player2.Score);

            if (chack.m_player1.Score > chack.m_player2.Score)
            {
                Console.WriteLine("The winner is {0}", chack.m_player1.GetPlayerName());
            }
            else
            {
                if (chack.m_player1.Score < chack.m_player2.Score)
                {
                    Console.WriteLine("The winner is {0}", chack.m_player2.GetPlayerName());
                }
                else
                {
                    Console.WriteLine("Its a tie!!");
                }
            }
            
            
        
        }

        

    }
}
