using System;
using System.Diagnostics.Contracts;
using System.Formats.Asn1;
using System.Runtime.InteropServices;

public class Maze 
{
    public  int Rows;
    public int Columns;
    public char[,] board;
    public (int x, int y) FinishPosition { get; set; }

    public Maze (int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        board = new char[rows, columns];

        GenerateValidMaze();
       
        FinishPosition =(rows-2, columns -2 );
        board[FinishPosition.x, FinishPosition.y] = '☻';
    }
     
    public void GenerateValidMaze()
    {
        int attemps = 0;
        const int maxAttempts = 20;
        do
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    board[i, j] = '█';
                }
            }

             GenerateMaze(1,1);

             board[4,5] = '▓';
             board[8,12] = '▓';
             board[9,18] ='▓';
             board[10,5] = '░';
             board[7,7]  = '░';

             attemps++;

             if (IsMazeFullyConnected() || attemps >= maxAttempts)
                 break;
        } while (true);

        if (attemps >= maxAttempts)
        {
             Console.WriteLine("Advertencia: El laberinto puede tener áreas inaccesibles");
        }
    } 
    private void GenerateMaze(int x, int y)
    {
       board[x, y] = ' '; // Marca el camino como espacio vacío
        // Direcciones: Arriba, Abajo, Izquierda, Derecha
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        Random rand = new Random();

        // Mezclar direcciones aleatoriamente
        for (int i = 0; i < 4; i++)
        {
            int r = rand.Next(i,4);
            (dx[i], dx[r]) = (dx[r], dx[i]);
            (dy[i], dy[r]) = (dy[r], dy[i]);
        }

        // explorar caminos en las 4 direcciones
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dx[i] * 2;
            int newY = y + dy[i] * 2;
            if (newX >= 0 && newX < Rows-1 && newY >= 0 && newY < Columns-1 && board[newX, newY] == '█' )
            {
                board[x + dx[i], y + dy[i]] = ' '; // Crea un camino
                GenerateMaze(newX, newY);
            }
        } 
    }

    public bool IsMazeFullyConnected()
    {
        //contar celdas transitables (excluyendo la meta)
        int totalAccesibles = 0;
        for (int i = 0; i < Rows; i++)
        {
            for(int j = 0; j < Columns; j++)
            {
                if (Istransitable(i,j) && (i !=FinishPosition.x || j != FinishPosition.y))
                {
                    totalAccesibles++;
                }
            }
        }

        bool[,] visited = new bool[Rows, Columns];
        int reachedCells = CountReachableCells(1,1,visited);

        return reachedCells == totalAccesibles;
    }

    private int CountReachableCells(int x, int y, bool[,] visited)
    {
       if (x < 0 || x >= Rows || y < 0 || y >= Columns || !Istransitable(x,y) || visited[x,y])
       {
        return 0;
       }

       visited[x,y] = true;
       int count = 1;

       //no contar la meta como parte de la conectividad general
       if (!(x == FinishPosition.x && y == FinishPosition.y))
       {
          count += CountReachableCells(x + 1, y, visited);
          count += CountReachableCells(x - 1, y, visited); // Arriba
          count += CountReachableCells(x, y + 1, visited); // Derecha
          count += CountReachableCells(x, y - 1, visited); 
       }
        return count;
    }

    

    public void GenerateTramps(int numbertramps)
    {   
        Random rand = new Random();
        for (int i = 0; i < numbertramps; i++)
        {
            int trampX = rand.Next(1, Rows - 1); //evitar los bordes 
            int trampY = rand.Next(1, Columns - 1); 

            if (board[trampX, trampY] == ' ' && (trampX != FinishPosition.x || trampY != FinishPosition.y))
            {
                switch (i % 3)
                {
                    case 0 : 
                    board[trampX, trampY] = '♠'; //trampa de daño
                     break; 
                    case 1:
                     board[trampX, trampY] = '♣'; // Trampa de retroceso
                     break; 
                    case 2:
                     board[trampX, trampY] = '♥'; //trampa de paralización
                     break; 
                }
            }
            else
            {
               i--;
            }
        }
    }

    
    public bool Istransitable(int x, int y)
    {
       if (x < 0 || x >= Rows || y < 0 || y >= Columns)
       return false;
      
       char cell = board[x,y];
       
       return cell == ' ' || cell == '♠' || cell == '♣' || cell == '♥' || cell == '☻';
    }
    

    
   public void PlacePlayer(Player1 player1)
    {
        if (Istransitable(player1.PositionX, player1.PositionY))
        {
            board[player1.PositionX, player1.PositionY] = player1.Symbol[0];
        }
    }

    public void PlacePlayer(Player2 player2)
    {
        if (Istransitable (player2.PositionW, player2.PositionZ))
        {
            board[player2.PositionW, player2.PositionZ] = player2.Symbol[0];
        }
    }

    public void PrintMaze()
{
    for (int i = 0; i < Rows; i++)
    {
        for (int j = 0; j < Columns; j++)
        {
            if (i == FinishPosition.x && j == FinishPosition.y)
            {
               Console.ForegroundColor = ConsoleColor.DarkYellow;
               Console.Write("☻");
            } 
            else if (board[i,j] == '♠' )
             {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.Write("♠");
             }
           else if (board[i,j] == '♣')
           {
             Console.ForegroundColor = ConsoleColor.Green;
              Console.Write("♣");
           }
           else if (board[i,j] == '♥' )
           {
             Console.ForegroundColor = ConsoleColor.Blue;
              Console.Write("♥");
           }
           else
           {
             Console.Write(board[i,j] == '\0' ? "█" : board[i,j].ToString());
           }
           Console.ResetColor();
        }
        Console.WriteLine();
    }

   
 }
}