using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

public class Maze 
{
    public  int Rows;
    public int Columns;
    public char[,] board;

    public Maze (int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        board = new char[rows, columns];

         for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            board[i, j] = '█';
        }
    }

        GenerateMaze(1,1);
    }

    private void GenerateMaze(int x, int y)
    {
       board[x, y] = ' '; // Marca el camino como espacio vacío
        // Direcciones: Arriba, Abajo, Izquierda, Derecha
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        Random rand = new Random();

        // Mezclar direcciones
        for (int i = 0; i < 4; i++)
        {
            int dir = rand.Next(4);
            int tempX = dx[i];
            int tempY = dy[i];
            dx[i] = dx[dir];
            dy[i] = dy[dir];
            dx[dir] = tempX;
            dy[dir] = tempY;
        }

        // Recursión para crear caminos
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dx[i] * 2;
            int newY = y + dy[i] * 2;
            if (newX >= 0 && newX < Rows && newY >= 0 && newY < Columns && board[newX, newY] == '█' )
            {
                board[x + dx[i], y + dy[i]] = ' '; // Crea un camino
                GenerateMaze(newX, newY);
            }
        }

        board[4,5] = '▓';
        board[8,12] = '▓';
        board[9,18] ='▓';
        board[10,5] = '░';
        board[7,7]  = '░';
    }

    public void GenerateTramps(int numbertramps)
    {   
        Random rand = new Random();
        for (int i = 0; i < numbertramps; i++)
        {
            int trampX = rand.Next(1, Rows - 1); //evitar los bordes 
            int trampY = rand.Next(1, Columns - 1); 

            if (board[trampX, trampY] == ' ')
            {
                board[trampX, trampY] = '♠';
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
       
       return cell == ' ' || cell == '♠';
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


   /* public void PrintMaze()
    {
        for (int i = 0; i < Rows; i ++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Console.Write(board[i,j] == 0 ? "█" : board[i,j]);
            }
            Console.WriteLine();
        }
    }*/

    public void PrintMaze()
{
    for (int i = 0; i < Rows; i++)
    {
        for (int j = 0; j < Columns; j++)
        {
            // Mostrar '█' para cualquier celda no definida o con valor 0
            Console.Write(board[i,j] == '\0' ? "█" : board[i,j].ToString());
        }
        Console.WriteLine();
    }

   
 }
}