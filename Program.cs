using System;
using System.Threading;

public class Program
{
    private static bool isPlayer1Turn;
    public static void Main()
    {
       Maze maze = new Maze(25, 27);
<<<<<<< Maze-Runners
       maze.PrintMaze();
    }
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

       Player1 player1 = null!;
       Player2 player2 = null!;
     
     Console.WriteLine("=== SELECCIÓN DE JUGADORES ===");
     while (player1 == null || player2 == null)
     {
        if (player1 == null)
        {
            Console.WriteLine("\nJugador 1 - elija un símbolo:");
            for (int i = 0; i < symbol.Length; i++)
            {
                Console.WriteLine($"{symbol[i]} : {token[i]} (Habilidad : {symbolAbilities[symbol[i]].Name})");
            }
            
            string election = Console.ReadLine()!;
            if (symbolAbilities.TryGetValue(election, out Hability ability))
            {
                player1 = new Player1(election, 1,1, ability);
                Console.WriteLine($"Jugador 1 seleccionado: {ability.Name}");
            }
            else
            {
                Console.WriteLine("Símbolo inválido.Por favor intente dr nuevo");
            }
        }
        else if (player2 == null)
        {
            Console.WriteLine("\nJugador 2 - Elija un símbolo:");
            for (int j = 0; j < symbol.Length; j++ )
            {
                Console.WriteLine($"{symbol[j]}: {token[j]} (Habilidad : {symbolAbilities[symbol[j]].Name})");
            }

            string election2 = Console.ReadLine()!;
            if (symbolAbilities.TryGetValue(election2, out Hability ability2))
            {
                player2 = new Player2(election2, 5,5, ability2);
                Console.WriteLine($"Jugador 2 seleccionado: {ability2.Name}");
            }
            else 
            {
                Console.WriteLine("Símbolo inválido. Por favor intente de nuevo");
            } 
        }
     }
      
        maze.PlacePlayer(player1);
        maze.PlacePlayer(player2);

        Console.WriteLine("\n=== CONTROLES ===");
        Console.WriteLine("Jugador 1 (WASD) | Jugador 2 (Flechas)");
        Console.WriteLine("Para activar la habilidad de su primer jugador debe presionar 'E' ");
        Console.WriteLine("Para activar la habilida de su segundo jugador debe presionar 'M'");
        Console.WriteLine("Presione cualquier tecla para comenzar...");
        Console.ReadKey();

        while(true)
        {
            Console.Clear();
            maze.PrintMaze();
        
            Console.WriteLine($"Jugador 1 ({player1.Symbol}) - Salud: {player1.Health} | Habilidad: {player1.Ability.Name} (Usos de la habilidad : {player1.Ability.RemainingUses}/{player1.Ability.MaxUses}) ");
            Console.WriteLine($"Jugador 2 ({player2.Symbol}) - Salud ({player2.Health})| Habilidad: {player2.Ability.Name} (Usos: {player2.Ability.RemainingUses}/{player2.Ability.MaxUses}) {(player2.IsParalyzed ? "[PARALIZADO POR 1 MINUTO]" : "")}");
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
            //verificar la activación de las habilidades 
            if (isPlayer1Turn && keyInfo.Key == ConsoleKey.E)
            {
               player1.TryActiveAbility();
               continue;
            }
            else if (!isPlayer1Turn && keyInfo.Key == ConsoleKey.M)
            {
                player2.TryActiveAbility();
                continue;
            }


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

         }
     }
>>>>>>> local
}
    
    

