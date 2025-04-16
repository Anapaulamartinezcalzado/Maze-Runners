using System;

public class Program
{
    public static void Main()
    {
       Maze maze = new Maze(25, 27);
<<<<<<< Maze-Runners
       maze.PrintMaze();
=======
       maze.GenerateTramps(15);

       string[] token = { "Maria", "Joseph", "Atenea", "Julio", "Mario" };
       string[] symbol  = { "@", "#", "$", "&", "*" };
       Hability[] abilities = { new TrampImmunity(),  //trampa para @
                                new Hability("Teletransportación", "Te permite moverte a cualquier lugar del mapa"),//trampa para #
                                new Hability("Inmune a la paralización", "No puedes quedar paralizado"), //trampa para $
                                new Hability ("Inmune a la muerte" , "No te resta vidas"), //trampa para &
                                 new Hability("Doble movimiento", "Puedes moverte dos casillas por turno") // Para *
                                };

        Dictionary<string, Hability> symbolAbilities = new Dictionary<string, Hability>
        {
          {"@", abilities[0] } ,
          {"#", abilities[1] } ,
          {"$", abilities[2] } ,
          {"&", abilities[3] } ,
          {"*", abilities[4] } ,
        } ;                       

       Player1 player1 = null;
       Player2 player2 = null;
     
      Console.WriteLine("Elija un símbolo para su jugador");
      for (int i = 0; i < token.Length; i++)
      {
          Console.WriteLine($" {token[i]}: {symbol[i]} (Habilidad: {abilities[i].Name})");
      }

      Console.WriteLine("Elija un símbolo para su segundo jugador");
      for (int j = 0; j < token.Length; j++)
      {
          Console.WriteLine($"{token[j]}: {symbol[j]}");
      }


      
      string election2;
      bool CorrectSelection = false;

      while (!CorrectSelection)
      {  
          string election = Console.ReadLine()!;
        if (symbolAbilities.TryGetValue(election, out Hability selectedAbility))
        {
            player1 = new Player1(election, 1,1, selectedAbility);
            CorrectSelection = true;
            Console.WriteLine($"Has elegido {player1.Symbol} con la habilidad {selectedAbility.Name}");
        }
        else
        {
          Console.WriteLine("Ficha inválidad. Por favor elija otra");
        }
      }  
          election2 = Console.ReadLine()!;
          int numToken2 = Array.IndexOf(symbol, election2);

          if (numToken2 >= 0 && numToken2 < token.Length)
          {
               player2.Symbol = symbol[numToken2];
               maze.PlacePlayer(player2);
               CorrectSelection = true;
               
          }
          else
          {
               Console.WriteLine("Símbolo inválido . Por favor vuelva a elegir");
          }
           
      
        maze.PlacePlayer(player1);
        maze.PlacePlayer(player2);
        Console.WriteLine("Controles:");
        Console.WriteLine("Jugador 1 (WASD) - Jugador 2 (Flechas)");
        Console.WriteLine("Presione cualquier tecla para comenzar...");
        Console.ReadKey();

        while(true)
        {
            Console.Clear();
            maze.PrintMaze();
            

            Console.WriteLine($"Jugador 1 ({player1.Symbol}) - Salud: {player1.Health} {(player1.IsParalyzed ? "[PARALIZADO POR 1 MINUTO]" : "")}");
            Console.WriteLine($"Jugador 2 ({player2.Symbol}) - Salud ({player2.Health}) {(player2.IsParalyzed ? "[PARALIZADO POR 1 MINUTO]" : "")}");
            Console.WriteLine($"Turno del {(isPlayer1Turn ? "Jugador 1" : "Jugador 2")}");  // Mostrar de quién es el turno

            if (player1.Health <= 0)
            {
                Console.WriteLine ("Jugador 2 gana!!!!!!");
                break;
            }
            if (player2.Health <= 0)
            {
               Console.WriteLine("Jugador 1 gana!!!");
               break;
            }

            if ((isPlayer1Turn && player1.IsParalyzed) || (!isPlayer1Turn && player2.IsParalyzed))
            {
                Console.WriteLine($"{(isPlayer1Turn ? "Jugador 1" : "Jugador 2" )} está paralizado por 1 minuto.Turno omitido");
                isPlayer1Turn = !isPlayer1Turn;
                Thread.Sleep(150);
                continue;
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            int prevX1 = player1.PositionX;
            int prevY1 = player1.PositionY;
            int prevX2 = player2.PositionW;
            int prevY2 = player2.PositionZ;


            if (isPlayer1Turn)
            {
               
                // Movimiento del jugador 1
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        if (player1.Move(-1, 0, maze))
                        {
                            maze.board[prevX1, prevY1] = ' ';
                           // maze.PlacePlayer(player1);
                            isPlayer1Turn = false;
                        }
                        break;
                    case ConsoleKey.S:
                       if (player1.Move(1, 0, maze)) 
                       {
                          maze.board[prevX1, prevY1] = ' ';
                          maze.PlacePlayer(player1);
                          isPlayer1Turn = false;
                       }
                        break;
                    case ConsoleKey.A:
                       if (player1.Move(0, -1, maze)) 
                       {
                            maze.board[prevX1, prevY1] = ' ';
                            maze.PlacePlayer(player1);
                            isPlayer1Turn = false;
                       }
                        break;
                    case ConsoleKey.D:
                         if (player1.Move(0, 1, maze))
                         {
                            maze.board[prevX1, prevY1] = ' ';
                            maze.PlacePlayer(player1);
                            isPlayer1Turn = false;
                         }
                        break;
                }
               }
               else
               {
                // Movimiento del jugador 2
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                         if (player2.Move(-1, 0, maze))
                         {
                            maze.board[prevX2, prevY2] = ' ';
                            maze.PlacePlayer(player2);
                            isPlayer1Turn = true;
                         }
                        break;
                    case ConsoleKey.DownArrow:
                        if (player2.Move(1, 0, maze)) 
                        {  
                            maze.board[prevX2, prevY2] = ' ';
                            maze.PlacePlayer(player2); 
                            isPlayer1Turn = true;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                         if (player2.Move(0, -1, maze))
                         {
                            maze.board[prevX2, prevY2] = ' ';
                            maze.PlacePlayer(player2);
                            isPlayer1Turn = true;
                         }
                        
                        break;
                    case ConsoleKey.RightArrow:
                        if (player2.Move(0, 1, maze))
                        {
                           maze.board[prevX2, prevY2] = ' ';
                           maze.PlacePlayer(player2); 
                           isPlayer1Turn = true;
                        }
                        break;
                }
            }
            

      /*Console.WriteLine("Para mover al primer jugador debes presionar : W(Arriba), S(Abajo) , A(Izquierda), D(Derecha)"); 
    
     while(true)
     {
 
         ConsoleKeyInfo keyInfo = Console.ReadKey(true);

         switch (keyInfo.Key)
         {
            case ConsoleKey.W:
                 player1.Move(-1, 0 , maze);
                 break;
            case ConsoleKey.S:
                 player1.Move(1, 0, maze);
                 break;
            case ConsoleKey.A:
                 player1.Move(0, -1, maze);
                 break;
            case ConsoleKey.D:
                 player1.Move(0, 1, maze);
                 break;              
         }

         Console.Clear();
         maze.PrintMaze();
         Console.SetCursorPosition(player1.PositionX, player1.PositionY);
         Console.Write(player1.Symbol);
     }*/

>>>>>>> local
    }
}
