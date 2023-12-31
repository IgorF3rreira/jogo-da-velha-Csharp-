// PROCEDIMENTO
//JOGO DA VELHA
    static char[,] tabuleiro = new char[3,3];
    static void InicializarTabuleiro()
    {
        for (int l = 0; l < 3; l++)
        {
            for (int c = 0; c < 3; c++)
            {
                tabuleiro[l, c] = ' ';
            }
        }
    }

    //Monta tabuleiro
    static void ImprimirTabuleiro()
    {
        Console.Clear();
        Console.WriteLine("***************");
        Console.WriteLine(" JOGO DA VELHA ");
        Console.WriteLine("***************");
        Console.WriteLine();
        Console.WriteLine($"{tabuleiro[0,0]} | {tabuleiro[0,1]} | {tabuleiro[0,2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($"{tabuleiro[1, 0]} | {tabuleiro[1, 1]} | {tabuleiro[1, 2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($"{tabuleiro[2, 0]} | {tabuleiro[2, 1]} | {tabuleiro[2, 2]} ");
        Console.WriteLine("---+---+---");

    }

    //Verificar vitoria
    static bool verificarVitoria(char jogador) 
    {
        //verificar linhaws
        for (int l = 0; l < 3; l++)
        {
            if (tabuleiro[l,0] == jogador && tabuleiro[l,1] == jogador && tabuleiro[l,2] == jogador)
            {
                return true;
            }
        }
        // verificar colunas
        for (int c = 0; c < 3; c++)

        {
            if ((tabuleiro[0, c] == jogador && tabuleiro[1, c] == jogador && tabuleiro[2, c] == jogador))
            {
                return true;
            }
        }

        //verifica diagonais
        if (tabuleiro[0,0] == jogador && tabuleiro[1,1] == jogador && tabuleiro[2,2] == jogador)
        {
            return true;
        }
        if (tabuleiro[0, 2] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 0] == jogador)
        {
            return true;
        }

        return false;

    }       





// ================================================================================




// CONSOLE

// JOGO DA VELHA


InicializarTabuleiro();
    int jogadas = 0 ; // controla o total de jogadas
        
    while (true)
    {
        ImprimirTabuleiro();
        // SOLICITA A JOGADA DO JOGADOR ATUAL
        Console.Write($"jogador {(jogadas % 2 == 0 ? "X" : "O")}, digite a linha e a coluna da sua jogada (exemplo: 1 1): ");
        string entrada = Console.ReadLine();
           string[] posicoes = entrada.Split(' ');

        int linha = int.Parse(posicoes[0]) ;
        int coluna = int.Parse(posicoes[1]) ;

        //verificar se a posição escolhida é valida

           if (linha < 0 || linha > 2 || coluna < 0 || coluna > 2)
        {
               Console.WriteLine("\nPosição invalida! Tenta novamente.");
               Thread.Sleep(2000);
               continue;

           }

           //verifica se a posicao
           if (tabuleiro[linha, coluna] != ' ')
           {
               Console.WriteLine("\nPosição já ocupada! Tente novamente");
               Thread.Sleep(2000);
               continue;
           }

           //faz a jogada do jogador atual
        tabuleiro[linha, coluna] = jogadas % 2 == 0 ? 'X' : 'O'; 
           jogadas++;


        //verificar se o jogo acabou
        if (verificarVitoria('X'))
        {
           ImprimirTabuleiro();
               Console.WriteLine("*******************");
               Console.WriteLine("  JOGADOR X VENCEU!");
               Console.WriteLine("*******************");
               break;

        }
        if (verificarVitoria('O'))
        {
               ImprimirTabuleiro();
               Console.WriteLine("*******************");
               Console.WriteLine("  JOGADOR O VENCEU!");
               Console.WriteLine("*******************");
               break;

        }

           if (jogadas == 9)
           {
               ImprimirTabuleiro();
               Console.WriteLine("*****************");
               Console.WriteLine("  JOGO EMPATADO  ");
               Console.WriteLine("*****************");
               break;
           }



    }