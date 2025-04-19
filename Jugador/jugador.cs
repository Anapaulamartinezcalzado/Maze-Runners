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
<<<<<<< Maze-Runners
        PositionX += deltaX; // Actualiza la posición X
        PositionY += deltaY; // Actualiza la posición Y
=======

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

      bool isDoubleMove = (Ability is DoubleMoveAbility && Ability.IsActive);
      int moveDistance = isDoubleMove ? 2 : 1; 

       int newX = PositionX + (deltaX * moveDistance);
       int newY = PositionY + (deltaY * moveDistance); 
  
       if (!maze.Istransitable (newX, newY))
           return false;

          maze.board[PositionX, PositionY] = ' ';
          PositionX = newX;
          PositionY = newY;

          //verificar si llegó a la meta
          if (PositionX == maze.FinishPosition.x && PositionY == maze.FinishPosition.y)
          {
            maze.board[PositionX,PositionY] = this.Symbol[0];
            Console.WriteLine("Jugador 1 ha llegado a la meta!!!");
            return true;
          }

          char cell = maze.board[newX, newY];
            
            bool isInmune = (Ability is TrampImmunity && Ability.IsActive);
            bool isParalysisImmune = (Ability is ParalysisImmunity && Ability.IsActive);
            bool isReverseImmune = (Ability is ReverseTrapImmunity && Ability.IsActive);
            bool isHealtImmunity = (Ability is HealthImmunity && Ability.IsActive);


          if (cell == '♠' && !isInmune && !isHealtImmunity )
            {
               Health -= 3;
               Console.WriteLine($"Trampa activada! Salud reducida a {Health}");
            }
            else if (cell == '♠' && isHealtImmunity)
            {
               Console.WriteLine("Ahora eres inmune a las trampas que descuentan vidas");
            }
            else if (cell == '♣' )
            {
               if (!isInmune && !isReverseImmune)
               {
                  PositionX = 1;
               PositionY = 1;
               maze.board[PositionX, PositionY] = this.Symbol[0];
               Console.WriteLine("¡Jugador 1 retrocede al inicio!");
               }
               else if (isReverseImmune)
               {
                    Console.WriteLine("Inmunidad a retroceso activa! La trampa no tiene efecto");
               }
               
            }
            else if (cell == '♥' && !isInmune && !isParalysisImmune)
            {
               IsParalyzed = true;
               ParalyzeEndTime = DateTime.Now.AddSeconds(30);
              // Console.WriteLine("¡Jugador 1 paralizado por 3 minutos!");
            }
            else if ( isInmune && (cell == '♠' || cell == '♣' || cell == '♥'))
            {
               Console.WriteLine("Inmunidad a trampas activa!! No sufres efectos");
            }
            else if (cell == '♥' && isParalysisImmune)
            {
                Console.WriteLine("Inmunidad a paralización activa! La trampa no tiene efecto");
            }

            maze.board[PositionX, PositionY] = this.Symbol[0];
            if (Health <= 0)
            {
                Console.WriteLine("Jugador eliinado!");
                return false;
            }
            
        return true;

>>>>>>> local
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
    public Player2(string symbol, int w , int z, Hability ability )
>>>>>>> local
    {
       Vida = 3;
       Symbol = symbol;
<<<<<<< Maze-Runners
=======
       Ability = ability;
>>>>>>> local
       PositionW = w;
       PositionZ = z;
    }

    public void Move(int deltaW, int deltaZ)
    {
<<<<<<< Maze-Runners
       PositionW += deltaW;
       PositionZ += deltaZ;
=======
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
       
        bool isDoubleMove = (Ability is DoubleMoveAbility && Ability.IsActive);

        int moveDistance = isDoubleMove ? 2 : 1;
        
        int newW = PositionW + (deltaW * moveDistance);
        int newZ = PositionZ + (deltaZ * moveDistance) ;

        if (!maze.Istransitable(newW, newZ))
        return false;

        maze.board[PositionW, PositionZ] = ' ';
        PositionW = newW;
        PositionZ = newZ;
        
        //verificar si llegó a la meta
        if (PositionW == maze.FinishPosition.x && PositionZ == maze.FinishPosition.y)
        {
          maze.board[PositionW, PositionZ] = this.Symbol[0];
          Console.WriteLine("Jugador 2 ha llegado a la meta");
          return true;
        }

        char cell = maze.board[newW, newZ];
        bool isInmune = (Ability is TrampImmunity && Ability.IsActive);
        bool isParalysisImmune = (Ability is ParalysisImmunity && Ability.IsActive);
        bool isReverseImmune = (Ability is ReverseTrapImmunity && Ability.IsActive);
        bool isHealtImmunity = (Ability is HealthImmunity && Ability.IsActive);

        if (cell == '♠' && !isInmune && !isHealtImmunity )
        {
          Health -=3;
          Console.WriteLine($"Trampa activada! Salud reducida a {Health}");
        }
        else if (cell == '♠' && isHealtImmunity)
        {
          Console.WriteLine("Ahora eres inmune a las trampas qe descuentan vidas");
        }
        else if (cell == '♣' )
        {
          if (isInmune || isReverseImmune)
          {
             Console.WriteLine("Inmunidad activa! La trampa de retroceso no tiene efecto");
          }
           else
           {
                PositionW = 5;
              PositionZ = 5;
              maze.board[PositionW, PositionZ] = this.Symbol[0];
              Console.WriteLine("Jugador 2 retrocede al inicio!");
          }
          
        }
        else if (cell == '♥' && !isInmune && !isParalysisImmune)
        {
          IsParalyzed = true;
          ParalyzeEndTime = DateTime.Now.AddSeconds(30);
         // Console.WriteLine("Jugador 2 paralizado por 3 minutos !!");
        }
        else if (isInmune && (cell == '♠' || cell == '♣' || cell == '♥'))
        {
            Console.WriteLine("Inmunidad a trampas activa!! No sufres efectos");
        }
        else if (cell == '♥' && isParalysisImmune)
        {
          Console.WriteLine("Inmunidad a la paralzación activada! La trampa no tiene efecto");
        }
        
         maze.board[PositionW, PositionZ] = this.Symbol[0];

          if (Health <= 0)
          {
            Console.WriteLine("Jugador 2 eliminado!");
            return false;
          }
       
        return true;
      
>>>>>>> local
    }
    
}