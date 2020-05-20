using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex02_02
{
    class Board
    {
        public static void Main()
        {
            printBord(4,6);
        }
        private static void getSizeFromUser()
        {
            string colow; 
            string row;

            Console.WriteLine("Enter row:");
            row = Console.ReadLine();
            Console.WriteLine("Enter colow");
            colow = Console.ReadLine();

            int colw_int = int.Parse(colow);
            int row_int = int.Parse(row);

            //Console.WriteLine("{0}, {1}",colw_int,row_int); בדיקה

        }

        private static void printBord(int colw,int row)
        {
            char c = 'A';
            
            for (int k = 0; k < row; k++)
            {
                Console.Write("    {0}   ",c);
                c++;
            }
            Console.WriteLine();

            Random rnd = new Random();
            

            for (int i = 0; i <colw; i++)
            {
                Console.Write("{0}", i + 1);
                for (int j = 0; j < row; j++)
                {
                    char randomChar = (char)rnd.Next('a', 'z');
                    Console.Write("  [{0}]   ",randomChar);
                    
                }
                Console.WriteLine();
                
               
            }
        }
    }
}
