using System;

public class Program
{
    public static void Main()
    {
       Maze maze = new Maze(25, 27);
<<<<<<< Maze-Runners
       maze.PrintMaze();
    }
=======
       maze.GenerateTramps(20);

       string[] token = { "Maria", "Joseph", "Atenea", "Julio", "Mario" };
       string[] symbol  = { "@", "#", "$", "&", "*" };
       Hability[] abilities = { new TrampImmunity(),  //trampa para @
                                new ReverseTrapImmunity (),//trampa para #
                                new ParalysisImmunity(), //trampa para $
                                new HealthImmunity(), //treampa para &
                                 new DoubleMoveAbility() // Para *
                                };

        Dictionary<string , Hability> symbolAbilities = new Dictionary<string, Hability>
        {
            { "@", abilities[0] },
            { "#", abilities[1] },
            { "$", abilities[2] },
            { "&", abilities[3] },
            { "*", abilities[4] }
        };

       Player1 player1 = null!;
       Player2 player2 = null!;
     
     List<string> availableSymbols = new List<string>(symbol);

     Console.WriteLine("=== BIENVENIDOS A MAZE RUNNERS!!!! ===");
     Console.WriteLine("=== SELECCIÓN DE JUGADORES ===");
     while (player1 == null || player2 == null)
     {
        if (player1 == null)
        {
            Console.WriteLine("\nJugador 1 - elija un símbolo:");
            for (int i = 0; i < availableSymbols.Count; i++)
            {
                int originalIndex = Array.IndexOf(symbol, availableSymbols[i]);
                Console.WriteLine($"{availableSymbols[i]} : {token[originalIndex]} (Habilidad: {abilities[originalIndex].Name})");
            }

            string election = Console.ReadLine()!;
            if (availableSymbols.Contains(election))
            {
                int originalIndex = Array.IndexOf(symbol, election);
                player1 = new Player1(election, 1,1 , abilities[originalIndex]);
                availableSymbols.Remove(election); //remuevo la ficha elegida
                Console.WriteLine($"Jugador 1 seleccionado: {abilities[originalIndex].Name}");
            }
            else 
            {
                 Console.WriteLine("Símbolo inválido o ya seleccionado. Intente de nuevo.");
            }
        }
        else if (player2 == null)
        {
            Console.WriteLine("\nJugador 2 - Elija un símbolo:");
            for (int j = 0; j < availableSymbols.Count; j++ )
            {  
               int originalIndex = Array.IndexOf(symbol, availableSymbols[j]);
               Console.WriteLine($"{availableSymbols[j]} : {token[originalIndex]} (Habilidad: {abilities[originalIndex].Name})");
            }

            string election2 = Console.ReadLine()!;
            if (availableSymbols.Contains(election2))
            {
                int originalIndex =Array.IndexOf(symbol, election2);
               player2 = new Player2(election2, 5,5, abilities[originalIndex]);
               Console.WriteLine ($"Jugador 2 seleccionado: {abilities[originalIndex].Name}");
            }
            else 
            {
                Console.WriteLine("Símbolo inválido o ya seleccionado. Por favor intente de nuevo");
            } 
        }
     }
      
        maze.PlacePlayer(player1);
        maze.PlacePlayer(player2);

        Console.WriteLine("\n=== CONTROLES ===");
        Console.WriteLine("Jugador 1 (WASD) | Jugador 2 (Flechas)");
        Console.WriteLine("Para activar la habilidad de su primer jugador debe presionar: ");
        Console.WriteLine("('E': inmunidad a todas las trampas)");
        Console.WriteLine("('P': contra la paralización)");
        Console.WriteLine("('J': contra la trampa de reversa)");
        Console.WriteLine("('Q': inmunidad a la trampa de las vidas)");
        Console.WriteLine("('O': doble movimiento)");
        Console.WriteLine("\nPara activar la habilidad de su segundo jugador debe presionar: ");
        Console.WriteLine("('M': inmunidad a todas las trampas)");
        Console.WriteLine("('L': contra la paralización)");
        Console.WriteLine("('K': contra la trampa de reversa)");
        Console.WriteLine("('U': inmunidad a la trampa de las vidas)");
        Console.WriteLine("('H': doble movimiento)");
        Console.WriteLine("\nOBJETIVO: LLEGAR A LA META (☻) ANTES DE QUE TU OPONENTE O REDUCIR SU SALUD A 0");
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
            if (isPlayer1Turn)
            {
               if (keyInfo.Key == ConsoleKey.E)
                {
                    player1.TryActiveAbility();
                    continue;
                    
                }
                else if (keyInfo.Key == ConsoleKey.J && player1.Ability is ReverseTrapImmunity)
                {
                    player1.TryActiveAbility();
                    continue;
                }
                else if (keyInfo.Key == ConsoleKey.P && player1.Ability is ParalysisImmunity)
                {
                    player1.TryActiveAbility();
                    continue;
                }
                else if (keyInfo.Key == ConsoleKey.Q && player1.Ability is HealthImmunity)
                {
                    player1.TryActiveAbility();
                    continue;
                }
                else if (keyInfo.Key == ConsoleKey.O && player1.Ability is DoubleMoveAbility)
                {
                     player1.TryActiveAbility();
                     continue;
                }
            }
            else
            {
                if ( keyInfo.Key == ConsoleKey.M)
                 {
                   player2.TryActiveAbility();
                   continue;
                 } 
                 else if (keyInfo.Key == ConsoleKey.K && player2.Ability is ReverseTrapImmunity)
                 {
                    player2.TryActiveAbility();
                    continue;
                 }
                 else if (keyInfo.Key == ConsoleKey.L && player2.Ability is ParalysisImmunity)
                 {
                    player2.TryActiveAbility();
                    continue;
                 }
                 else if (keyInfo.Key == ConsoleKey.U && player2.Ability is HealthImmunity)
                 {
                    player2.TryActiveAbility();
                    continue;
                 }
                 else if (keyInfo.Key == ConsoleKey.H && player2.Ability is DoubleMoveAbility)
                 {
                    player2.TryActiveAbility();
                    continue;
                 }
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
                            if (player1.PositionX == maze.FinishPosition.x && player1.PositionY == maze.FinishPosition.y)
                            {
                                Console.WriteLine("Jugador 1 ha llegado a la meta!!!!");
                                return ;
                            }
                            isPlayer1Turn = false;
                        }
                        break;
                    case ConsoleKey.S:
                       if (player1.Move(1, 0, maze)) 
                       {
                          maze.board[prevX1, prevY1] = ' ';
                          if (player1.PositionX == maze.FinishPosition.x && player1.PositionY == maze.FinishPosition.y)
                          {
                            Console.WriteLine("¡Jugador 1 ha ganado al llegar a la meta!");
                                return;
                          }
                          isPlayer1Turn = false;
                       }
                        break;
                    case ConsoleKey.A:
                       if (player1.Move(0, -1, maze)) 
                       {
                            maze.board[prevX1, prevY1] = ' ';
                             if (player1.PositionX == maze.FinishPosition.x && player1.PositionY == maze.FinishPosition.y)
                            {
                                Console.WriteLine("¡Jugador 1 ha ganado al llegar a la meta!");
                                return;
                            }
                            isPlayer1Turn = false;
                       }
                        break;
                    case ConsoleKey.D:
                         if (player1.Move(0, 1, maze))
                         {
                            maze.board[prevX1, prevY1] = ' ';
                            if (player1.PositionX == maze.FinishPosition.x && player1.PositionY == maze.FinishPosition.y)
                            {
                                Console.WriteLine("¡Jugador 1 ha ganado al llegar a la meta!");
                                return;
                            }
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
                            if (player2.PositionW == maze.FinishPosition.x && player2.PositionZ == maze.FinishPosition.y)
                            {
                                Console.WriteLine("¡Jugador 2 ha ganado al llegar a la meta!");
                                return;
                            }
                            isPlayer1Turn = true;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                         if (player2.Move(0, -1, maze))
                         {
                            maze.board[prevX2, prevY2] = ' ';
                            if (player2.PositionW == maze.FinishPosition.x && player2.PositionZ == maze.FinishPosition.y)
                            {
                                Console.WriteLine("¡Jugador 2 ha ganado al llegar a la meta!");
                                return;
                            }
                            isPlayer1Turn = true;
                         }
                        
                        break;
                    case ConsoleKey.RightArrow:
                        if (player2.Move(0, 1, maze))
                        {
                           maze.board[prevX2, prevY2] = ' ';
                           if (player2.PositionW == maze.FinishPosition.x && player2.PositionZ == maze.FinishPosition.y)
                            {
                                Console.WriteLine("¡Jugador 2 ha ganado al llegar a la meta!");
                                return;
                            }
                           isPlayer1Turn = true;
                        }
                        break;
                }
            }

         }
     }
>>>>>>> local
}
