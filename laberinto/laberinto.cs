using System;
using System.Runtime.InteropServices;

public class Maze 
{
    private int Rows;
    private int Columns;
    private char[,] board;

    public Maze (int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        board = new char[rows, columns];
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
            if (newX >= 0 && newX < Rows && newY >= 0 && newY < Columns && board[newX, newY] == 0)
            {
                board[x + dx[i], y + dy[i]] = ' '; // Crea un camino
                GenerateMaze(newX, newY);
            }
        }
    }
    private void AllCellsAreTransitable()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (board[i, j] == 0)
                {
                    board[i, j] = ' '; // Marca todas las casillas no transitables como transitables
                }
            }
        }
    }


    public void PrintMaze()
    {
        for (int i = 0; i < Rows; i ++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Console.Write(board[i,j] == 0 ? "█" : board[i,j]);
            }
            Console.WriteLine();
        }
    }
 }