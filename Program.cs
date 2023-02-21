internal class Program
{   class output
    {
        public void makegrid(ref char[,] grid, int player)
        {
            clearscreen();
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Console.Write(" "+grid[i,j]+" ");
                }
                Console.WriteLine("\n");
            }
        }
        public void clearscreen()
        {
            Console.Clear();
        }

    }
    class gameLogic
    {
        int counter = 2;
        private output Output;
        char[,] grid;
        int row, col;
        public gameLogic()
        {
            Output = new output();
            grid = new char[3, 3];
            resetgrid();
        }//constructor who will initilize the data in array
        public void getdata()
        {
            do
            {
                Console.WriteLine("Enter Row starting from 1");
                row = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Column starting from 1");
                col = int.Parse(Console.ReadLine());
                if (row > 3 || row < 1 || col > 3 || col < 1)
                {
                    Console.WriteLine("You have entered a incorrect number. Try again");
                }
            }
            while ((row > 3 || row < 1 || col > 3 || col < 1));

        }//getdata is used in input method. This method only takes row and col from user.
        public void input()
        {
            int incorrect = 0;
            if(counter % 2 == 0)
            {
                do {
                    if (incorrect > 0)
                    {
                        Console.WriteLine("You have Entered Wrong Choice");
                        Console.WriteLine("Please Choose values in between 1,3 that have not been already filled");
                    }
                    Console.WriteLine("Player 1 Turn ");
                    getdata();
                    counter++; 
                    incorrect++;
                }
                while (grid[row-1,col-1] != '-');
                grid[(row - 1), (col - 1)] = 'O';
                Output.makegrid(ref grid, 1);
            }
            else
            {
                do
                {
                    if (incorrect > 0)
                    {
                        Console.WriteLine("You have Entered Wrong Choice");
                        Console.WriteLine("Please Choose values in between 1,3 that have not been already filled");
                    }
                    Console.WriteLine("Player 2 Turn ");
                    getdata();
                    counter++;
                    incorrect++;
                }
                while (grid[row - 1, col - 1] != '-' );
                grid[(row - 1), (col - 1)] = 'X';
                Output.makegrid(ref grid, 2);
            }
        }//all the input logic is here
        public bool checkconditions()
        {
            if((grid[0, 0] == 'X' && grid[1, 0] == 'X' && grid[2, 0] == 'X')|| (grid[0, 1] == 'X' && grid[1, 1] == 'X' && grid[2, 1] == 'X')|| (grid[0, 2] == 'X' && grid[1, 2] == 'X' && grid[2, 2] == 'X')|| (grid[0, 0] == 'X' && grid[0, 1] == 'X' && grid[0, 2] == 'X')|| (grid[1, 0] == 'X' && grid[1, 1] == 'X' && grid[1, 2] == 'X')|| (grid[2, 0] == 'X' && grid[2, 1] == 'X' && grid[2, 2] == 'X') || (grid[0,0] == 'X' && grid[1,1] == 'X' && grid[2, 2] == 'X') || (grid[0, 2] == 'X' && grid[1, 1] == 'X' && grid[2,0] == 'X'))
            {
                Console.WriteLine("Player 2 Wins");
                return false;
            }
            else if ((grid[0, 0] == 'O' && grid[1, 0] == 'O' && grid[2, 0] == 'O') || (grid[0, 1] == 'O' && grid[1, 1] == 'O' && grid[2, 1] == 'O') || (grid[0, 2] == 'O' && grid[1, 2] == 'O' && grid[2, 2] == 'O') || (grid[0, 0] == 'O' && grid[0, 1] == 'O' && grid[0, 2] == 'O') || (grid[1, 0] == 'O' && grid[1, 1] == 'O' && grid[1, 2] == 'O') || (grid[2, 0] == 'O' && grid[2, 1] == 'O' && grid[2, 2] == 'O') || (grid[0, 0] == 'O' && grid[1, 1] == 'O' && grid[2, 2] == 'O') || (grid[0, 2] == 'O' && grid[1, 1] == 'O' && grid[2, 0] == 'O'))
            {
                Console.WriteLine("Player 1 Wins");
                return false;
            }
            else { return true; }
        }//wining conditions
        public void gameloop()
        {
            bool check = true;
            while (check)
            {

                input();
                check = checkconditions();
            }
        }//game inner loop works until a player wins
        public void resetgrid()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = '-';
                }
            }
            Output.makegrid(ref grid, 0);
        }//reset all the values of grid
    }
    private static void Main(string[] args)
    {
        gameLogic obj;
        obj = new gameLogic();
        char repeat = '1';
        while(repeat == '1')
        {
            obj.gameloop();
            Console.WriteLine("Do you wanna play more? press 1 for yes or any other value for no");
            repeat = char.Parse(Console.ReadLine());
            if (repeat == '1')
            {
                obj.resetgrid();
            }
        }//outer loop of game for playing more or not
        
 


    }
}