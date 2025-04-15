using System;
using System.Threading;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

public class Player1
{

    public int Health {get; set;}
    public Hability Ability { get; set; }
    public string Symbol  { get; set ;}
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public bool IsParalyzed { get; set; }
    public DateTime ParalyzeEndTime { get; set; }

    public Player1(string symbol, int x , int y, Hability ability)
    {
       Health = 10;
       Symbol = symbol;
       Ability = ability;
       PositionX = x;
       PositionY = y;
    }

    
     public bool Move(int deltaX, int deltaY, Maze maze)
    {

      if (IsParalyzed)
      {
         if (DateTime.Now >= ParalyzeEndTime)
         {
            IsParalyzed = false;
            Console.WriteLine("¡Jugador 1 se ha recuperado de la parálisis!");
            return true;
         }
         else
         {
             Console.WriteLine("Jugador 1 está paralizado. Turno perdido.");
             return false;
         }
      }
       int newX = PositionX + deltaX;
       int newY = PositionY + deltaY; 
       
       if (!maze.Istransitable (newX, newY))
           return false;

          maze.board[PositionX, PositionY] = ' ';
          PositionX = newX;
          PositionY = newY;

          char cell = maze.board[newX, newY];
            
            bool isInmune = (Ability is TrampImmunity && Ability.IsActive);
         
          if (maze.board[newX, newY] == '♠' && !isInmune )
            {
               Health -= 3;
               Console.WriteLine($"Trampa activada! Salud reducida a {Health}");
            }
            else if (cell == '♣' && !isInmune)
            {
               PositionX = 1;
               PositionY = 1;
               maze.board[PositionX, PositionY] = this.Symbol[0];
               Console.WriteLine("¡Jugador 1 retrocede al inicio!");
            }
            else if (cell == '♥' && !isInmune)
            {
               IsParalyzed = true;
               ParalyzeEndTime = DateTime.Now.AddSeconds(30);
              // Console.WriteLine("¡Jugador 1 paralizado por 3 minutos!");
            }
            else if ( isInmune && (cell == '♠' || cell == '♣' || cell == '♥'))
            {
               Console.WriteLine("Inmunidad a trampas activa!! No sufres efectos");
            }

            maze.board[PositionX, PositionY] = this.Symbol[0];
            if (Health <= 0)
            {
                Console.WriteLine("Jugador eliinado!");
                return false;
            }
            
        return true;

    }
  
}

public class Player2
 {
    public int Health {get; set;}
    public string Hability { get; set; }
    public string Symbol  { get; set ;}
    public int PositionW { get; set; }
    public int PositionZ { get; set; }
    public bool IsParalyzed { get; set; }
    public DateTime ParalyzeEndTime { get; set; }

    public Player2(string symbol, int w , int z, string hability)
    {
       Health = 10;
       Symbol = symbol;
       Hability = hability;
       PositionW = w;
       PositionZ = z;
    }

    public bool Move(int deltaW, int deltaZ, Maze maze)
    {
       if (IsParalyzed)
       {
         if ( DateTime.Now >= ParalyzeEndTime)
         {
            IsParalyzed = false;
            Console.WriteLine("Jugador 2 se ha recuperado de la parálisis");
         }
         else
         {
            Console.WriteLine("Jugador 2 está paralizado.Turno perdido.");
            return false;
         }
       }

        int newW = PositionW + deltaW;
        int newZ = PositionZ + deltaZ;

        if (!maze.Istransitable(newW, newZ))
        return false;

        maze.board[PositionW, PositionZ] = ' ';
        PositionW = newW;
        PositionZ = newZ;
        
        char cell = maze.board[newW, newZ];
        
        if (maze.board[newW, newZ] == '♠' )
        {
          Health -=3;
          Console.WriteLine($"Trampa activada! Salud reducida a {Health}");
        }
        else if (cell == '♣')
        {
          PositionW = 5;
          PositionZ = 5;
          maze.board[PositionW, PositionZ] = this.Symbol[0];
          Console.WriteLine("Jugador 2 retrocede al inicio!");
        }
        else if (cell == '♥')
        {
          IsParalyzed = true;
          ParalyzeEndTime = DateTime.Now.AddSeconds(30);
         // Console.WriteLine("Jugador 2 paralizado por 3 minutos !!");
        }
        
         maze.board[PositionW, PositionZ] = this.Symbol[0];

          if (Health <= 0)
          {
            Console.WriteLine("Jugador 2 eliminado!");
            return false;
          }
       
        return true;
      
    }
    
}