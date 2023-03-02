using System.Numerics;
using System.Runtime.Serialization;


internal class Program
{
    class UserInterface
    {
        public char[,] grid;
        public enum Player
        {
            Player_1,
            Player_2,
                none
        }
        public Player curruntTurn;
        public int rowIndex, colIndex;
        public string message;
        public UserInterface()
        {
            grid = new char[3, 3];
            curruntTurn = Player.Player_1;
            colIndex = 0;
            rowIndex= 0;
            message = string.Empty;
            ClearGrid();
            displayGrid();
        }
        public void playerInputRC()
        {
            while (true)
            {
                Console.WriteLine("Enter Row: ");
                rowIndex = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Column: ");
                colIndex = int.Parse(Console.ReadLine());
                if (rowIndex <= 3 && colIndex <= 3 && rowIndex >= 1 && colIndex >= 1)
                {
                    break;
                }
                else
                    Console.WriteLine("Wrong Enteries. Try again");
            }

        }
        public void displayGrid()
        {
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {   
                    Console.Write(grid[i, j] + " ");

                }
                Console.WriteLine("\n");
            }
        }
        public void ClearGrid()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j=0; j < 3; j++)
                {
                    grid[i, j] = '_';
                }
            }
        }
        public void updateUIForTurn()
        {
            Console.Clear();
            displayGrid();
            if(message != string.Empty)
            {
                Console.WriteLine(message);
            }
            
            Console.Write("Turn :: " + curruntTurn);
            if(curruntTurn == Player.Player_1)
            {
                Console.Write("(0)");
            }
            else
            {
                Console.Write("(1)");
            }
            Console.WriteLine();
            playerInputRC();
            
        }
        public void updateUIForEnd(Player pWinner)
        {
            Console.Clear();
            displayGrid();
            if (pWinner == Player.Player_1)
            {
                Console.WriteLine("Winner : Player_1" );
            }
            else if(pWinner == Player.Player_2) 
            {
                Console.WriteLine("Winner : Player_2");
            }
            //Console.Read();
        }
        public void DrawMatch()
        {
            Console.Clear();
            displayGrid();
            Console.WriteLine("Draw!");
            Console.Read();
        }
    }
  class TicTacToe
    {
        public UserInterface intrface;
        public TicTacToe()
        {
            intrface = new UserInterface();
        }
        public bool isCellEmpty(int row, int col)
        {
            if (intrface.grid[row - 1,col - 1] == '_') 
                return true;
            else
                return false;
        }
        public UserInterface.Player CheckWinner()
        {
            
            if ((intrface.grid[0, 0] == '0' && intrface.grid[1, 0] == '0' && intrface.grid[2, 0] == '0') || (intrface.grid[0, 1] == '0' && intrface.grid[1, 1] == '0' && intrface.grid[2, 1] == '0') || (intrface.grid[0, 2] == '0' && intrface.grid[1, 2] == '0' && intrface.grid[2, 2] == '0') || (intrface.grid[0, 0] == '0' && intrface.grid[0, 1] == '0' && intrface.grid[0, 2] == '0') || (intrface.grid[1, 0] == '0' && intrface.grid[1, 1] == '0' && intrface.grid[1, 2] == '0') || (intrface.grid[2, 0] == '0' && intrface.grid[2, 1] == '0' && intrface.grid[2, 2] == '0') || (intrface.grid[0, 0] == '0' && intrface.grid[1, 1] == '0' && intrface.grid[2, 2] == '0') || (intrface.grid[0, 2] == '0' && intrface.grid[1, 1] == '0' && intrface.grid[2, 0] == '0'))
                return UserInterface.Player.Player_1;
            else if ((intrface.grid[0, 0] == '1' && intrface.grid[1, 0] == '1' && intrface.grid[2, 0] == '1') || (intrface.grid[0, 1] == '1' && intrface.grid[1, 1] == '1' && intrface.grid[2, 1] == '1') || (intrface.grid[0, 2] == '1' && intrface.grid[1, 2] == '1' && intrface.grid[2, 2] == '1') || (intrface.grid[0, 0] == '1' && intrface.grid[0, 1] == '1' && intrface.grid[0, 2] == '1') || (intrface.grid[1, 0] == '1' && intrface.grid[1, 1] == '1' && intrface.grid[1, 2] == '1') || (intrface.grid[2, 0] == '1' && intrface.grid[2, 1] == '1' && intrface.grid[2, 2] == '1') || (intrface.grid[0, 0] == '1' && intrface.grid[1, 1] == '1' && intrface.grid[2, 2] == '1') || (intrface.grid[0, 2] == '1' && intrface.grid[1, 1] == '1' && intrface.grid[2, 0] == '1'))
                return UserInterface.Player.Player_2;
            else
                return UserInterface.Player.none;

        }
        void updateTurn()
        {
            if (intrface.curruntTurn == UserInterface.Player.Player_1)
                intrface.curruntTurn = UserInterface.Player.Player_2;
            else
                intrface.curruntTurn = UserInterface.Player.Player_1;
        }
        public void setGridValue(int x,int y,UserInterface.Player pCurrentTurn)
        {
            if (pCurrentTurn == UserInterface.Player.Player_1)
                intrface.grid[x-1, y-1] = '0';
            else
                intrface.grid[x - 1, y - 1] = '1';
        }
        public bool isGridFull()
        {
            uint counter = 0;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (intrface.grid[i, j] == '0' || intrface.grid[i, j] == '1')
                        counter = counter + 1 ;
                }
            }
            if(counter == 9)
                return true;
            else return false;

        }
        public void startGameLoop()
        {
            while (true)
            {
                if (isGridFull())
                {
                    intrface.DrawMatch();
                    break;
                }
                else 
                {
                    intrface.updateUIForTurn();
                    if (isCellEmpty(intrface.rowIndex, intrface.colIndex))
                        setGridValue(intrface.rowIndex, intrface.colIndex, intrface.curruntTurn);
                    else
                    {
                        intrface.message = "This Cell is already Filled";
                        continue;
                    }
                    
                    if (CheckWinner() != UserInterface.Player.none)
                    {
                        intrface.updateUIForEnd(CheckWinner());
                        break;
                    }
                    updateTurn();
                } 
            }



        }

    }

    class MainLoop
    {
        static TicTacToe game;
        private static void Main(string[] args)
        {
            int repeat = 1;
             game = new TicTacToe();
            while (repeat != 0) {
                game.startGameLoop();
                Console.WriteLine("Enter 0 to exit or any other number to continue\n");
                repeat = int.Parse(Console.ReadLine());
                game.intrface.ClearGrid();

            }   
             
             Console.ReadKey();

        }
    }
   
}
