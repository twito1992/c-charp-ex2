using System;
using System.Collections.Generic;
using System.Threading;

namespace B20_Ex02_02
{
    public class Board
    {
        private static List<char> m_MemoryLetters = null;
        private int m_Player1Count = 0;//palyer 1 can move
        private int m_Player2Count = 0;//player 2 can move
        private int m_EmptyCount = 0;///empry move
        private int m_Size = 0;
        private int m_Row = 0;
        private int m_Colow = 0;
        private char[,] m_Board = null;
        static Random m_random = new Random();
        private List<int> m_validMovesPlayer1 = null;//vaild move player 1
        private List<int> m_validMovesPlayer2 = null;//vaild move player 2

        
        public int Player1Count
        {
            get
            {
                return m_Player1Count;
            }
        }

        public int Player2Count
        {
            get
            {
                return m_Player2Count;
            }
        }

        public int EmptyCount
        {
            get
            {
                return m_EmptyCount;
            }
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

        public int Size
        {
            get
            {
                return m_Size;
            }

            set
            {
                m_Size = value;
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
            m_validMovesPlayer1 = new List<int>();
            m_validMovesPlayer2 = new List<int>();

            
        }

        private static void GetLetters(int i_row,int i_colow)
        {
            
            int size = ((i_row * i_colow)/2); 
            //returns a random letter.
            // ... Between 'A' and 'Z' inclusize.
            int num = m_random.Next(0, 23); // Zero to 25
            char let = (char)('A' + num);
            for (int j = 0; j<=size; j++)
            {
                bool is_Difreent = true;
                if (m_MemoryLetters == null)
                {
                    m_MemoryLetters = new List<char>();
                    m_MemoryLetters.Add(let);
                    
                }
                else
                {

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
                    
                }
            }
            
        }

        private void newGame()// init bord
        {
            List<char> newLetters = new List<char>();
            GetLetters(m_Row, m_Colow);

            for (int i = 0; i < m_Row; i++)
            {
                for (int j = 0; j < m_Colow; j++)
                {
                    if (m_MemoryLetters.Count > 0)
                    {
                        m_Board[i, j] = m_MemoryLetters[0];
                        newLetters.Add(m_MemoryLetters[0]);
                        m_MemoryLetters.RemoveAt(0);
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

            //for (int i = 0; i < m_Size; i++)//drew the randow letters
            //{
            //    for (int j = 0; j < m_Size; j++)
            //    {
            //        Console.Write("  {0}  ",m_Board[i,j]);
            //    }
            //    Console.WriteLine();
            //}
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
            string HLINEX6 = "   ========================";
            
            if (i_Colow==4)
            {
                Console.WriteLine(HLINEX4);
            }
            else if (i_Colow == 6)
            {
                Console.WriteLine(HLINEX6);
            }
            

        }

        private void drawBord()
        {
            
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
                Console.WriteLine();
                
            }

            getHlineOfBoardBySize(m_Colow);
        }
        

        public static void Main()
        {
            Board chack = new Board(6,6);
            chack.newGame();
            chack.getHlineOfBoardBySize(chack.Colow);
            chack.drawBord();
              
        }

        //        private bool isValidMove(int i_Color, int i_Rows, int i_Cols)//vaild move
        //        {
        //            bool validMove = false;

        //            if (m_Board[i_Rows, i_Cols] == Board.sr_Empty)
        //            {
        //                for (int discRows = -1; discRows <= 1; discRows++)
        //                {
        //                    for (int discCols = -1; discCols <= 1; discCols++)
        //                    {
        //                        if (discCols != 0 || discRows != 0)
        //                        {
        //                            if (isValidPath(i_Color, i_Rows, i_Cols, discRows, discCols))
        //                            {
        //                                validMove = true;
        //                            }
        //                        }
        //                    }
        //                }
        //            }

        //            return validMove;
        //        }

        //        //private bool isValidPath(int i_Color, int i_Rows, int i_Cols, int i_DiscRows, int i_DiscCols)
        //        //{
        //        //    int rows = i_Rows + i_DiscRows;
        //        //    int cols = i_Cols + i_DiscCols;
        //        //    bool validPath = true;

        //        //    while (rows >= 0 && rows < m_Size && cols >= 0 && cols < m_Size && m_Board[rows, cols] == -i_Color)
        //        //    {
        //        //        rows += i_DiscRows;
        //        //        cols += i_DiscCols;
        //        //    }

        //        //    if (rows < 0 || rows > m_Size - 1 || cols < 0 || cols > m_Size - 1 ||
        //        //        (rows - i_DiscRows == i_Rows && cols - i_DiscCols == i_Cols)
        //        //        || m_Board[rows, cols] != i_Color)
        //        //    {
        //        //        validPath = false;
        //        //    }

        //        //    return validPath;
        //        //}

        //        public void GetValidMoves(int i_Color)//cahck move
        //        {
        //            if (i_Color == Board.sr_Black)
        //            {
        //                m_validMovesBlack.Clear();
        //            }
        //            else if (i_Color == Board.sr_White)
        //            {
        //                m_validMovesWhite.Clear();
        //            }

        //            for (int rows = 0; rows < m_Size; rows++)
        //            {
        //                for (int cols = 0; cols < m_Size; cols++)
        //                {
        //                    if (isValidMove(i_Color, rows, cols))
        //                    {
        //                        if (i_Color == Board.sr_Black)
        //                        {
        //                            m_validMovesBlack.Add((rows * 10) + cols);
        //                        }
        //                        else if (i_Color == Board.sr_White)
        //                        {
        //                            m_validMovesWhite.Add((rows * 10) + cols);
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        public int GetNumberOfValidMoves(int i_Color)
        //        {
        //            int totalMoves = 0;

        //            if (i_Color == Board.sr_Black)
        //            {
        //                totalMoves = m_validMovesBlack.Count;
        //            }
        //            else if (i_Color == Board.sr_White)
        //            {
        //                totalMoves = m_validMovesWhite.Count;
        //            }

        //            return totalMoves;
        //        }

        //        public bool HasAnyValidMove(int i_Color)
        //        {
        //            int totalMoves = 0;

        //            if (i_Color == Board.sr_Black)
        //            {
        //                totalMoves = m_validMovesBlack.Count;
        //            }
        //            else if (i_Color == Board.sr_White)
        //            {
        //                totalMoves = m_validMovesWhite.Count;
        //            }

        //            return totalMoves > 0;
        //        }

        //        public bool IfValidMove(int i_Color, int i_Rows, int i_Cols)
        //        {
        //            bool valid = false;
        //            int checkIndex = 0;

        //            GetValidMoves(i_Color);
        //            checkIndex = (i_Rows * 10) + i_Cols;
        //            if (i_Color == Board.sr_Black)
        //            {
        //                for (int i = 0; i < m_validMovesBlack.Count; i++)
        //                {
        //                    if (m_validMovesBlack[i] == checkIndex)
        //                    {
        //                        valid = true;
        //                    }
        //                }
        //            }
        //            else if (i_Color == Board.sr_White)
        //            {
        //                for (int i = 0; i < m_validMovesWhite.Count; i++)
        //                {
        //                    if (m_validMovesWhite[i] == checkIndex)
        //                    {
        //                        valid = true;
        //                    }
        //                }
        //            }

        //            return valid;
        //        }

        //        public void MakeMove(int i_Color, int i_Rows, int i_Cols)
        //        {
        //            int discRows, discCols;
        //            int rows, cols;

        //            m_Board[i_Rows, i_Cols] = i_Color;
        //            for (discRows = -1; discRows <= 1; discRows++)
        //            {
        //                for (discCols = -1; discCols <= 1; discCols++)
        //                {
        //                    if (!(discRows == 0 && discCols == 0) && isValidPath(i_Color, i_Rows, i_Cols, discRows, discCols))
        //                    {
        //                        rows = i_Rows + discRows;
        //                        cols = i_Cols + discCols;
        //                        while (m_Board[rows, cols] == -i_Color)
        //                        {
        //                            m_Board[rows, cols] = i_Color;
        //                            rows += discRows;
        //                            cols += discCols;
        //                        }
        //                    }
        //                }
        //            }

        //            updateGameValues();
        //        }

        //        private void updateGameValues()
        //        {
        //            m_Player1Count = 0;
        //            m_Player2Count = 0;
        //            m_EmptyCount = 0;

        //            for (int rows = 0; rows < m_Size; rows++)
        //            {
        //                for (int cols = 0; cols < m_Size; cols++)
        //                {
        //                    if (m_Board[rows, cols] == Board.sr_Black)
        //                    {
        //                        m_Player1Count++;
        //                    }
        //                    else if (m_Board[rows, cols] == Board.sr_White)
        //                    {
        //                        m_Player2Count++;
        //                    }
        //                    else
        //                    {
        //                        m_EmptyCount++;
        //                    }
        //                }
        //            }
        //        }

        //        public void ComputerMakeMove(int i_Color)
        //        {
        //            int bestOption = 0;
        //            int rows = 0;
        //            int cols = 0;
        //            m_ArtificialIntelligence = new ArtificialIntelligence(this);
        //            if (i_Color == Board.sr_Black)
        //            {
        //                bestOption = m_ArtificialIntelligence.GetBestOption(m_validMovesBlack);
        //            }
        //            else if (i_Color == Board.sr_White)
        //            {
        //                bestOption = m_ArtificialIntelligence.GetBestOption(m_validMovesWhite);
        //            }

        //            rows = bestOption / 10;
        //            cols = bestOption % 10;
        //            MakeMove(i_Color, rows, cols);
        //        }
    }
}
