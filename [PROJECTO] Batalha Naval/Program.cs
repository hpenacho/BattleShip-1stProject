using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace _PROJECTO__Batalha_Naval
{
    class Program
    {
        private static bool isCpu;
        private static bool noWinnerYet;

        //-----------------------------------
        static void titulo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("         ____        __        ____             _   __                  __");
            Console.WriteLine("        / __ )____ _/ /_____ _/ / /_  ____ _   / | / /___ __   ______ _/ /");
            Console.WriteLine("       / __  / __  / __/ __  / / __  / __  /  /  |/ / __  / | / / __  / /");
            Console.WriteLine("      / /_/ / /_/ / /_/ /_/ / / / / / /_/ /  / /|  / /_/ /| |/ / /_/ / /__");
            Console.WriteLine("     /_____/_/ /_/ __ // / /_/_/ /_/_/ /_/  / / / /_/ /_/ |___/_/ /_/____/");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        //-----------------------------------
        static void mostraOpcoesMenu()
        {
            Console.WriteLine("\n                         Bem vindo á Batalha Naval!");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("              ______________________________________________\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                       1 : Novo Jogo\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                       2 : Regras & Objectivos de Jogo\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("                       3 : Música\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("                       4 : Sair");

            rodape();
        }
        //----------------------------------- 
        static void rodape()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("              ______________________________________________");
            Console.WriteLine("              Projecto feito por Hugo Penacho. TPSI-CAS-0919\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n                            Escolha uma opção:");
            Console.SetCursorPosition(37, 21);
        }
        //-----------------------------------   
        static string barco(int check)
        {
            if (check == 1)
            {
                return " ~ ";  // esta " ~ " é diferente do mar() normal, esta tem um "espaço" diferente depois do ~, usando Alt+255 com capslock. visualmente identicas ao utilizador                              
            }                  //mas internamente diferentes, e distinguiveis pelo sistema

            else if (check == 0)
            {
                return " B ";
            }
            return null;
        }
        //-----------------------------------
        static string[,] escondeBarcos(string[,] mapaJogo)
        {
            for (int l = 0; l < mapaJogo.GetLength(0); l++)
            {
                for (int c = 0; c < mapaJogo.GetLength(1); c++)
                {                  
                    if(mapaJogo[l, c] == barco(0))
                    {
                        mapaJogo[l, c] = barco(1);
                    }
                }
            }
            return mapaJogo;
        }

        static void teclaParaContinuar()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" ___________________________________");
            Console.WriteLine(" Prima qualquer tecla para continuar");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
            Console.Clear();
        }
        //-----------------------------------
        static string tiroAfunda()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            return (" * ");
        }
        //-----------------------------------
        static string tiroFalhou()
        {
            Console.ForegroundColor = ConsoleColor.White;
            return (" O ");
        }
        //-----------------------------------
        static void regrasAndExemplo()

        {
            Console.Clear();
            Console.SetWindowSize(85, 35);

            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("\n      0   1   2   3   4   5   6    "); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("[x]\n");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("    -----------------------------");
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" 0  "); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("| ~ | ~ | ~ | ~ | ~ |"); Console.Write(tiroFalhou()); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("|"); Console.Write(tiroAfunda()); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("|\n");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("    -----------------------------");
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" 1  "); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("|"); Console.Write(tiroFalhou()); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("| ~ | ~ | ~ | ~ | ~ |"); Console.Write(tiroFalhou()); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("|\n");
            Console.ForegroundColor = ConsoleColor.Blue; Console.Write("    -----------------------------"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("                   Legenda:\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" 2  "); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("| ~ | ~ | ~ |"); Console.Write(tiroFalhou()); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("|"); Console.Write(tiroFalhou()); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("| ~ | ~ |"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("            -------------------- \n");
            Console.ForegroundColor = ConsoleColor.Blue; Console.Write("   ------------------------------"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("           |"); Console.ForegroundColor = ConsoleColor.DarkGreen; Console.Write(" Coordenada:"); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("   (x,y)"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("|\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" 3  "); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("| ~ | ~ | ~ | ~ | ~ | ~ | ~ |"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("           |"); Console.ForegroundColor = ConsoleColor.DarkGreen; Console.Write(" Tiro em cheio:"); Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("  *"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("  |\n");
            Console.ForegroundColor = ConsoleColor.Blue; Console.Write("    -----------------------------"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("           |"); Console.ForegroundColor = ConsoleColor.DarkGreen; Console.Write(" Tiro falhado:"); Console.ForegroundColor = ConsoleColor.White; Console.Write("   O"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("  |\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" 4  "); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("|"); Console.Write(tiroAfunda()); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("| ~ | ~ | ~ | ~ | ~ | ~ |") ; Console.ForegroundColor = ConsoleColor.Gray; Console.Write("           |"); Console.ForegroundColor = ConsoleColor.DarkGreen; Console.Write("      Mar : "); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("     ~"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("  |\n");
            Console.ForegroundColor = ConsoleColor.Blue; Console.Write("    -----------------------------"); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine("            -------------------- ");
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" 5  "); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("| ~ |"); Console.Write(tiroFalhou()); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("|"); Console.Write(tiroAfunda()); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("| ~ | ~ | ~ | ~ |\n");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("    -----------------------------");
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(" 6  "); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("| ~ | ~ |"); Console.Write(tiroFalhou()); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("| ~ | ~ | ~ |"); Console.Write(tiroFalhou()); Console.ForegroundColor = ConsoleColor.Blue; Console.Write("|\n");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("    -----------------------------");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("[y]\n");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\n         [Objectivo]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" O objectivo do jogo é afundar todos os submarinos do oponente \n inserindo as coordenadas onde pretende lançar um tiro.\n");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("          [Regras]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" 1 : Não são permitidos tiros onde já tenha acertado, ou falhado um tiro.");
            Console.WriteLine(" 2 : Não são permitidas jogadas em coordenadas fora dos limites do tabuleiro.");
            Console.WriteLine(" 3 : Não é permitido colocar multiplos barcos numa única coordenada");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPrima qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();
        }
        //-----------------------------------
        static string mar()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            return " ~ ";           
        }
        //-----------------------------------
        static void sairJogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n    O programa encerrou por ordem do utilizador.");
            Console.WriteLine("                 Até ao próximo jogo!");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("    _____________________________________________\n\n\n");

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("                    | \\ ");
            Console.WriteLine("                     '.| ");
            Console.WriteLine("     _ -   _-    _-  _-||    _-    _-  _-   _-    _-    _-");
            Console.WriteLine("       _ -    _-   - __||___    _-       _-    _-    _-");
            Console.WriteLine("    _ -   _-    _-  |   _   |       _-   _-    _-");
            Console.WriteLine("      _ -    _-    /_) (_) (_\\        _-    _-       _-");
            Console.WriteLine("              _.-'           `-._      ________       _-");
            Console.WriteLine("        _..--`                   `-..'       .'");
            Console.WriteLine("    _.-'  o/o                     o/o`-..__.'        ~  ~");
            Console.WriteLine(" .-'      o|o                     o|o      `.._.  // ~  ~");
            Console.WriteLine(" `-._     o|o                     o|o        |||<|||~  ~");
            Console.WriteLine("     `-.__o\\o                     o|o       .'-'  \\ ~  ~");
            Console.WriteLine("         `-.______________________\\_...-``'.       ~  ~");
            Console.WriteLine("                                    `._______`.");

            Console.ReadKey();
        }
        //-----------------------------------     
        static string[,] inicializaTabuleiro(string[,] mapaJogo)
        {
            for (int l = 0; l < mapaJogo.GetLength(0); l++)
            {
                for (int c = 0; c < mapaJogo.GetLength(1); c++)
                {
                    mapaJogo[l, c] = mar();
                }
            }
            return mapaJogo;
        }
        //-----------------------------------                    
        static string[,] tabuleiro(string[,] mapaJogo)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("     0   1   2   3   4   5   6   ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" [x]");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   -----------------------------");
            for (int l = 0; l < 7; l++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" " + l + " ");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("|");

                for (int c = 0; c < 7; c++)
                {
                    if (mapaJogo[l, c] == mar())
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;

                    }
                    else if (mapaJogo[l, c] == tiroAfunda())
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else if (mapaJogo[l, c] == barco(0))
                    {
                        Console.ForegroundColor = ConsoleColor.White;                         
                    }

                    else if (mapaJogo[l, c] == barco(1))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    else 
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.Write(mapaJogo[l, c]);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("|");
                }
                Console.Write("\n   -----------------------------\n");
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[y]\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            return mapaJogo;
        }
        //-----------------------------------    
        static void subMenuMusica()
        {
            string opcao;
            SoundPlayer musica = new SoundPlayer();
            do
            {
                Console.Clear();
                titulo();

                Console.WriteLine("\n                           Opções Música:");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("              ______________________________________________\n");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("                       1 - Música:'Drunken Sailor'\n");
                Console.WriteLine("                       2 - Música:'8bit Drunken Sailor'\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("                       3 - Mute\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                       4 - Voltar ao menu principal");
                rodape();
                Console.SetCursorPosition(37, 21);
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        musica.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "DrunkenSailor-IrishRovers.wav";
                        musica.PlayLooping(); break;

                    case "2":
                        musica.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "DrunkenSailor-8bit.wav";
                        musica.PlayLooping(); break;

                    case "3": musica.Stop(); break;
                    case "4": Console.WriteLine("Voltar ao menu principal"); break;
                    default: Console.WriteLine("Resposta invalida."); break;
                }
            } while (opcao != "4");
        }
        //-----------------------------------   
        static void escolheOponente()
        {            
            switch (Console.ReadLine())
            {
                case "1": decideP2("1"); break;
                case "2": decideP2("2"); break;
                default: Console.WriteLine("Resposta invalida, escolha 1 ou 2"); break;
            }
        }
        //-----------------------------------
        static void decideP2(string check)
        {

            if (check == "1")
            {
                isCpu = false;
            }
            else 
            {
                isCpu = true;
            }
            //isCpu = check != "1";     //alternativa com menos linhas, mas menos legivel
        }
        //-----------------------------------
        static void verificaPerdedor(int nBarcosP1, int nBarcosP2)
        {
            if ((nBarcosP1 == 0) || (nBarcosP2 == 0))
            {
                noWinnerYet = false;
            }

             else
             {
              noWinnerYet = true;
             }
            //noWinnerYet = nBarcosP1 > 0 && nBarcosP2 > 0;  //alternativa com menos linhas, mas menos legivel
        }
        //-----------------------------------              
        static string askNomePlayer1()
        {
            string player1Nome;
            Console.WriteLine("Insira o nome do Player 1");
            player1Nome = Console.ReadLine();
            return player1Nome;
        }
        //-----------------------------------
        static string askNomePlayer2()
        {
            string player2Nome;

            if (isCpu)
            {
                player2Nome = "CPU";
                return player2Nome;
            }
            else
            {
                Console.WriteLine("Insira o nome do Player2");
                player2Nome = Console.ReadLine();
                return player2Nome;
            }
        }
        //-----------------------------------
        static int pedeInteiroValido()
        {
            SoundPlayer SFX_erro = new SoundPlayer();
            SFX_erro.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "errorSFX.wav";

            int coordValida = -1;
            do
            {
                try
                {
                    coordValida = int.Parse(Console.ReadLine());
                    if (coordValida < 0 || coordValida > 6)
                    {
                        
                        SFX_erro.Play();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("ERRO: Escolheu uma coordenada fora dos limites do tabuleiro\n Volte a escolher:"); Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                catch (System.FormatException)
                { SFX_erro.Play(); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("Inseriu algo que não um número inteiro, volte a jogar"); Console.ForegroundColor = ConsoleColor.Gray; }
            } while (coordValida < 0 || coordValida > 6);
            return coordValida;
        }
        //-----------------------------------
        static void Main(string[] args)
        {

            string[,] mapaJogoP1;
            string[,] mapaJogoP2;
            string player1Nome;
            string player2Nome;
            int qtdBarcosInseridos = 1;

            string opcoesMenuPrincipal;

            SoundPlayer musica = new SoundPlayer();
            musica.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "DrunkenSailor-8bit.wav";
            musica.PlayLooping();

            SoundPlayer SFX_kaboom = new SoundPlayer();
            SFX_kaboom.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "subm_afundaSFX.wav";

            SoundPlayer SFX_agua = new SoundPlayer();
            SFX_agua.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "subm_aguaSFX.wav";
           
            SoundPlayer SFX_erro = new SoundPlayer();
            SFX_erro.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "errorSFX.wav";

            SoundPlayer SFX_barco = new SoundPlayer();
            SFX_barco.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "subm_colocaSFX.wav";

            SoundPlayer SFX_victoria = new SoundPlayer();
            SFX_victoria.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "victoria.wav";

            do
            {

                mapaJogoP1 = new string[7, 7];
                mapaJogoP2 = new string[7, 7];

                Console.Clear();
                Console.SetWindowSize(79, 25);
                titulo();
                mostraOpcoesMenu();
                
                opcoesMenuPrincipal = Console.ReadLine();
                switch (opcoesMenuPrincipal)
                {
                    case "1":     //aqui efectivamente corre o jogo
                        Console.Clear();
                        titulo();
                        Console.WriteLine("\n                              Modo de jogo:");

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("              ______________________________________________");                   
                        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\n\n\n                           1: Versus Player2\n");                       
                        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("                             2: Versus CPU\n\n");
                        rodape();
                        escolheOponente();

                        Console.Clear();
                        if (isCpu)
                        {
                            Console.WriteLine("Escolheu versus CPU");
                        }
                        else
                        {
                            Console.WriteLine("Escolheu versus humano");
                        }

                        player1Nome = askNomePlayer1();
                        Console.Clear();
                        player2Nome = askNomePlayer2();
                        Console.Clear();
                        
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(" Nome de jogador 1 = " + player1Nome);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("         VERSUS");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(" Nome de jogador 2 = " + player2Nome);
                        teclaParaContinuar();

                        //---------------------------------------------------------------------------------------------------------------------

                        Console.Clear();
                        inicializaTabuleiro(mapaJogoP1);
                        inicializaTabuleiro(mapaJogoP2);

                        int x;
                        int y;
                        //---------------------------------------------------------------------------------------------------------------------
                        //   p1 place boats
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("         Player 1 = " + player1Nome + "\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(" No próximo ecrã colocará os seus barcos.");
                        teclaParaContinuar();

                        do
                        {
                            Console.Clear();
                            tabuleiro(mapaJogoP1);

                            Console.WriteLine("Por favor insira o {0}º barco na coordenada correspondente:", qtdBarcosInseridos);
                            Console.WriteLine("Insira o digito correspondente a coordenada X");
                            x = pedeInteiroValido();
                            Console.WriteLine("Insira o digito correspondente a coordenada Y");
                            y = pedeInteiroValido();

                            if (mapaJogoP1[y, x] == barco(0))
                            {
                                SFX_erro.Play();
                            }

                            else
                            {
                                SFX_barco.Play();
                                mapaJogoP1[y, x] = barco(0);
                                qtdBarcosInseridos++;
                            }

                        } while (qtdBarcosInseridos != 5);
                        qtdBarcosInseridos = 1;

                        Console.Clear();
                        tabuleiro(mapaJogoP1);

                        Console.WriteLine(player1Nome + " acabou de colocar todos os seus barcos!");
                        //-----------------------------------------------------------------------------------------------------------------------
                        int l;
                        int c;
                        Random numRandom = new Random();
                        //     p2 place boats
                        teclaParaContinuar();

                        if (isCpu)
                        {
                            Console.WriteLine("De seguida o CPU colocará os próprios barcos :");
                            teclaParaContinuar();

                            while (qtdBarcosInseridos != 5)
                            {
                                //tabuleiro(mapaJogoP2);
                                x = numRandom.Next(0, 7);
                                y = numRandom.Next(0, 7);
                             
                                        if (mapaJogoP2[y, x] != barco(0))
                                        {
                                            mapaJogoP2[y, x] = barco(0);
                                            qtdBarcosInseridos++;                                 
                                        }
                            }
                            qtdBarcosInseridos = 1;                            
                            tabuleiro(mapaJogoP2);
                            Console.WriteLine(player2Nome + " acabou de colocar todos os seus barcos!");
                            teclaParaContinuar();
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("          Player 2 = " + player2Nome + "\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("  No próximo ecrã colocará os seus barcos.");
                            teclaParaContinuar();

                            do
                            {
                                Console.Clear();
                                tabuleiro(mapaJogoP2);

                                Console.WriteLine("Por favor insira o {0}º barco na coordenada correspondente:", qtdBarcosInseridos);
                                Console.WriteLine("Insira o digito correspondente a coordenada X");
                                x = pedeInteiroValido();
                                Console.WriteLine("Insira o digito correspondente a coordenada Y");
                                y = pedeInteiroValido();

                                if (mapaJogoP2[y, x] == barco(0))
                                {
                                    SFX_erro.Play();
                                }

                                else
                                {
                                    SFX_barco.Play();
                                    mapaJogoP2[y, x] = barco(0);
                                    qtdBarcosInseridos++;
                                }
                            } while (qtdBarcosInseridos != 5);
                            qtdBarcosInseridos = 1;

                            Console.Clear();
                            tabuleiro(mapaJogoP2);
                            Console.WriteLine(player2Nome + " acabou de colocar todos os seus barcos!");
                            teclaParaContinuar();
                        }

                        escondeBarcos(mapaJogoP1);
                        escondeBarcos(mapaJogoP2);
                        //-----------------------------------------------------------------------------------------------------------------------
                        Console.WriteLine("De seguida começará o jogo:");
                        Console.ReadKey();
                        int nBarcosP1 = 4;
                        int nBarcosP2 = 4;
                        int ronda = 1;
                        verificaPerdedor(nBarcosP1, nBarcosP2);

                        do    //jogo nao sai daqui até haver vencedor
                        {
                            
                            Console.Write("Ronda: {0} //", ronda);                           

                            if (ronda % 2 != 0)   // jogadas impares para P1
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("  Player 1 = " + player1Nome + " // Lance o seu tiro!");

                                tabuleiro(mapaJogoP2);

                                Console.WriteLine("Insira o digito correspondente a coordenada X");
                                x = pedeInteiroValido();
                                Console.WriteLine("Insira o digito correspondente a coordenada Y");
                                y = pedeInteiroValido();

                                if (mapaJogoP2[y, x] == mar())
                                {

                                    mapaJogoP2[y, x] = tiroFalhou();
                                    ronda++;

                                    SFX_agua.Play();
                                    Console.Clear();
                                    Console.WriteLine("");
                                    tabuleiro(mapaJogoP2);
                                    Console.WriteLine("  Tiro em água. ({0},{1})", x, y);
                                    verificaPerdedor(nBarcosP1, nBarcosP2);
                                    teclaParaContinuar();
                                }

                                else if (mapaJogoP2[y, x] == tiroFalhou() || mapaJogoP2[y, x] == tiroAfunda())
                                {
                                    SFX_erro.Play();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Já lançou um tiro nessas coordenadas! Volte a jogar");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    teclaParaContinuar();
                                }

                                else
                                {
                                    mapaJogoP2[y, x] = tiroAfunda();
                                    ronda++;
                                    nBarcosP2--;

                                    SFX_kaboom.Play();
                                    Console.Clear();
                                    Console.WriteLine("");
                                    tabuleiro(mapaJogoP2);
                                    Console.WriteLine("  Tiro em cheio! ({0},{1})", x, y);
                                    verificaPerdedor(nBarcosP1, nBarcosP2);
                                    teclaParaContinuar(); //---pause to check
                                }
                                Console.Clear();                                
                            }

                            else         // jogadas pares para P2
                            {
                                if (isCpu)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("  CPU jogará de seguida");
                                    teclaParaContinuar();

                                    int checkCpu = 0;

                                    while (checkCpu == 0)
                                    {
                                        x = numRandom.Next(0, 7);
                                        y = numRandom.Next(0, 7);

                                        if (mapaJogoP1[y, x] == mar())
                                        {
                                            checkCpu = 1;
                                            mapaJogoP1[y, x] = tiroFalhou();
                                            ronda++;

                                            SFX_agua.Play();
                                            tabuleiro(mapaJogoP1);
                                            Console.WriteLine("Tiro em água. ({0},{1})", x, y);
                                            teclaParaContinuar();
                                        }

                                        else if (mapaJogoP1[y, x] == barco(1))
                                        {
                                            checkCpu = 1;
                                            mapaJogoP1[y, x] = tiroAfunda();
                                            ronda++;
                                            nBarcosP1--;

                                            SFX_kaboom.Play();
                                            tabuleiro(mapaJogoP1);
                                            Console.WriteLine("Tiro em cheio! ({0},{1})", x, y);
                                            verificaPerdedor(nBarcosP1, nBarcosP2);
                                            teclaParaContinuar();
                                        }
                                    }
                                }

                                else        // joga P2 HUMANO
                                {
                                    Console.WriteLine("  // Player 2 = " + player2Nome + " // Lance o seu tiro!");                                    

                                    tabuleiro(mapaJogoP1);

                                    Console.WriteLine("Insira o digito correspondente a coordenada X");
                                    x = pedeInteiroValido();
                                    Console.WriteLine("Insira o digito correspondente a coordenada Y");
                                    y = pedeInteiroValido();

                                    if (mapaJogoP1[y, x] == mar())
                                    {

                                        mapaJogoP1[y, x] = tiroFalhou();
                                        ronda++;

                                        SFX_agua.Play();
                                        Console.Clear();
                                        Console.WriteLine("");
                                        tabuleiro(mapaJogoP1);
                                        Console.WriteLine("Tiro em água. ({0},{1})", x, y);
                                        teclaParaContinuar();
                                    }

                                    else if (mapaJogoP1[y, x] == tiroFalhou() || mapaJogoP1[y, x] == tiroAfunda())
                                    {
                                        SFX_erro.Play();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Já lançou um tiro nessas coordenadas! Volte a jogar");
                                        Console.ForegroundColor = ConsoleColor.Gray;                                        
                                    }

                                    else
                                    {
                                        mapaJogoP1[y, x] = tiroAfunda();
                                        ronda++;
                                        nBarcosP1--;

                                        SFX_kaboom.Play();
                                        Console.Clear();
                                        Console.WriteLine("");
                                        tabuleiro(mapaJogoP1);
                                        Console.WriteLine("Tiro em cheio! ({0},{1})", x, y);
                                        verificaPerdedor(nBarcosP1, nBarcosP2);
                                        teclaParaContinuar();
                                    }
                                }
                                Console.Clear();
                            }
                        } while (noWinnerYet);
                        //-----------------------------------------------------------                        
                        if (nBarcosP1 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("       {0} VENCEU O JOGO!", player2Nome);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("       {0} VENCEU O JOGO!", player1Nome);
                        }
                        SFX_victoria.Play();                       
                        Console.ForegroundColor = ConsoleColor.DarkGray;                    
                        teclaParaContinuar();                        
                        //----------------------------------------------------------
                        musica.PlayLooping();
                        //--------------------------------------
                        break;
                    case "2": regrasAndExemplo(); break;
                    case "3": subMenuMusica(); break;
                    case "4": sairJogo(); break;
                }
            } while (opcoesMenuPrincipal != "4");

        }
    }
}

