using System;

public class Player1
{
    public int Vida {get; set;}
    public string Symbol  { get; set ;}
    public int PositionX { get; set; }
    public int PositionY { get; set; }

    public Player1(string symbol, int x , int y)
    {
       Vida = 3;
       Symbol = symbol;
       PositionX = x;
       PositionY = y;
    }
    
     public void Move(int deltaX, int deltaY)
    {
        PositionX += deltaX; // Actualiza la posición X
        PositionY += deltaY; // Actualiza la posición Y
    }

}

public class Player2
{
     public int Vida {get; set;}
    public string Symbol  { get; set ;}
    public int PositionW { get; set; }
    public int PositionZ { get; set; }

<<<<<<< Maze-Runners
    public Player2(string symbol, int w , int z)
=======
    public Player2(string symbol, int w , int z, string hability )
>>>>>>> local
    {
       Vida = 3;
       Symbol = symbol;
<<<<<<< Maze-Runners
=======
       Hability = hability ;
>>>>>>> local
       PositionW = w;
       PositionZ = z;
    }

    public void Move(int deltaW, int deltaZ)
    {
       PositionW += deltaW;
       PositionZ += deltaZ;
    }
    
}