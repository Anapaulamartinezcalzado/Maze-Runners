using System;
using System.Reflection.Metadata;

public class Program
{
    private static bool isPlayer1Turn;

    public static void Main()
    {
       Maze maze = new Maze(25, 27);
       maze.GenerateTramps(5);
      
       Player1 player1 = new Player1 ("P1", 1,1);
       Player2 player2 = new Player2 ("P2", 5,5 );
       

       string[] token = { "Maria", "Joseph", "Atenea", "Julio", "Mario" };
       string[] symbol  = { "@", "#", "$", "&", "*" };
     
      Console.WriteLine("Elija un símbolo para su jugador");
      for (int i = 0; i < token.Length; i++)
      {
          Console.WriteLine($"{token[i]}: {symbol[i]}");
      }

      Console.WriteLine("Elija un símbolo para su segundo jugador");
      for (int j = 0; j < token.Length; j++)
      {
          Console.WriteLine($"{token[j]}: {symbol[j]}");
      }


      string election;
      string election2;
      bool CorrectSelection = false;

      while (!CorrectSelection)
      {
          election = Console.ReadLine()!;
          int numToken = Array.IndexOf(symbol, election);

          if (numToken >= 0 && numToken < token.Length)
          {
               player1.Symbol = symbol[numToken];
               maze.PlacePlayer(player1);
               CorrectSelection = true;
               
          }
          else
          {
               Console.WriteLine("Símbolo inválido . Por favor vuelva a elegir");
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
            
            // Mostrar de quién es el turno
            Console.WriteLine($"Turno del {(isPlayer1Turn ? "Jugador 1" : "Jugador 2")}");

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

    }
}}
    
    

