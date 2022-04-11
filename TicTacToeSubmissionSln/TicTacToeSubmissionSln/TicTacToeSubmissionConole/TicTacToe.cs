using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private int[] _boardPositions = new int[] {-1,-1,-1,-1,-1,-1,-1,-1,-1};
        private int _rounds;

        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10, 6);
            _boardRenderer.Render();
        }

        private void PlayMove (PlayerEnum player)
        {
                       

            Console.SetCursorPosition(2, 19);

           
            if (player == PlayerEnum.X)
                Console.Write("Player X");
            else
                Console.Write("Player O");

            Console.SetCursorPosition(2, 20);

            Console.Write("Please Enter Row: ");
            var row = Console.ReadLine();

            Console.SetCursorPosition(2, 22);


            Console.Write("Please Enter Column: ");
            var column = Console.ReadLine();

            int rowNumber = int.Parse(row);
            int columnNumber = int.Parse(column);
            int arrayPos = (rowNumber * 3) + columnNumber;

            _boardPositions[arrayPos] = (int) player;

            _boardRenderer.AddMove(rowNumber, columnNumber, player, true);

         
        }
        
        public bool CheckIfPlayerWins(PlayerEnum player)

        {
            int playerValue = (int) player;

            if ((_boardPositions[0] == playerValue) && (_boardPositions[1] == playerValue) && (_boardPositions[2] == playerValue))
                return true;
            if ((_boardPositions[3] == playerValue) && (_boardPositions[4] == playerValue) && (_boardPositions[5] == playerValue))
                return true;
            if ((_boardPositions[6] == playerValue) && (_boardPositions[7] == playerValue) && (_boardPositions[8] == playerValue))
                return true;
            if ((_boardPositions[0] == playerValue) && (_boardPositions[3] == playerValue) && (_boardPositions[6] == playerValue))
                return true;
            if ((_boardPositions[1] == playerValue) && (_boardPositions[4] == playerValue) && (_boardPositions[7] == playerValue))
                return true;
            if ((_boardPositions[2] == playerValue) && (_boardPositions[5] == playerValue) && (_boardPositions[8] == playerValue))
                return true;
            if ((_boardPositions[0] == playerValue) && (_boardPositions[4] == playerValue) && (_boardPositions[8] == playerValue))
                return true;
            if ((_boardPositions[2] == playerValue) && (_boardPositions[4] == playerValue) && (_boardPositions[6] == playerValue))
                return true;

                   
            return false;
        }

        
        public void Run()
        {
            _rounds = 0;
            bool playerXWins = false;
            bool playerOWins = false;

            while (_rounds < 4)
            {

              
                PlayMove(PlayerEnum.X);

               
                playerXWins = CheckIfPlayerWins(PlayerEnum.X);

                if (playerXWins)
                {
                    Console.WriteLine("Player X Wins!!!");

                    break;

                }
                                               
               
                PlayMove(PlayerEnum.O);
               
                playerOWins = CheckIfPlayerWins(PlayerEnum.O);

                if (playerOWins)
                {
                    Console.WriteLine("Player O Wins!!!");

                    break;
                }
             

                _rounds++;
            }

            if (!playerXWins && !playerOWins)
                Console.WriteLine("The game is draw!");
            

            Console.SetCursorPosition(2, 19);

            Console.Write("Player X");

            Console.SetCursorPosition(2, 20);

            Console.Write("Please Enter Row: ");
            var row = Console.ReadLine();

            Console.SetCursorPosition(2, 22);


            Console.Write("Please Enter Column: ");
            var column = Console.ReadLine();

                        
            _boardRenderer.AddMove(int.Parse(row), int.Parse(column), PlayerEnum.X, true);            

        }

    }
}
