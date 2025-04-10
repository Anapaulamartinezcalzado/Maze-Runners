using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

public class Player1
{
    public int Health {get; set;}
    public string Symbol  { get; set ;}
    public int PositionX { get; set; }
    public int PositionY { get; set; }

    public Player1(string symbol, int x , int y)
    {
       Health = 100;
       Symbol = symbol;
       PositionX = x;
       PositionY = y;
    }

    
     public bool Move(int deltaX, int deltaY, Maze maze)
    {
       int newX = PositionX + deltaX;
       int newY = PositionY + deltaY; 
       
       if (!maze.Istransitable (newX, newY))
           return false;
        
        maze.board[PositionX, PositionY] = ' ';

        PositionX = newX;
        PositionY = newY;

        maze.board[PositionX, PositionY] = this.Symbol[0];



        return true;
       /*else 
       {
         Console.WriteLine("Movimiento no válido. Hay un obstáculo");
       }*/

    }
  
}

public class Player2
 {
    public int Health {get; set;}
    public string Symbol  { get; set ;}
    public int PositionW { get; set; }
    public int PositionZ { get; set; }

    public Player2(string symbol, int w , int z)
    {
       Health = 100;
       Symbol = symbol;
       PositionW = w;
       PositionZ = z;
    }

    public bool Move(int deltaW, int deltaZ, Maze maze)
    {
        int newW = PositionW + deltaW;
        int newZ = PositionZ + deltaZ;

        if (!maze.Istransitable(newW, newZ))
        return false;

        maze.board[PositionW, PositionZ] = ' ';

        PositionW = newW;
        PositionZ = newZ;

        maze.board[PositionW, PositionZ] = this.Symbol[0];

        
        return true;
      
    }
    
}