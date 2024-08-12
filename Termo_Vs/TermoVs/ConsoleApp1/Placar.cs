class Placar { 

    public Placar(string nomeP1, string nomeP2)
    {
        NomeP1 = nomeP1;

        NomeP2 = nomeP2;
    }

    public string NomeP1 { get; set; }

    public string NomeP2 { get; set; }

    public int placarP1 = 0;

    public int placarP2 = 0;

    public void GerarPlacar(int quantidadePalpites, int jogadorDaVez)
    {

        if (jogadorDaVez == 1)
        {
            placarP1 += quantidadePalpites;
        }
        if (jogadorDaVez == 2)
        {
            placarP2 += quantidadePalpites;
        }


        int p1Caracteres = NomeP1.Length+12;   //"|Jogador: {}:|"
        int p2Caracteres = NomeP2.Length+12;   //"|Jogador: {}:|"   //"|Placar: 10|"   12  20    20-12 =  8/2 = 4 <-- " "  8%2 = 4  < -----  " "
        
        
        string placarTexto1 = $"|Placar: {placarP1}";
        string placarTexto2 = $"|Placar: {placarP2}";
        int lenghCompleta = p1Caracteres + p2Caracteres + 5;
        string placarTexto0 = "Placar Atual:";   // 13 caracteres
        Console.Clear();
        Console.WriteLine("Jogo Termo VERSUS\n");
        for (int i = 0; i < (lenghCompleta-13)/2 ; i++)   // 20  + 20 + 5
        {
            Console.Write(" ");
        }
        Console.Write(placarTexto0);
        for (int i = 0; i < (lenghCompleta - 13) % 2; i++)   // 20  + 20 + 5
        {
            Console.Write(" ");
        }


        Console.WriteLine();    

        for (int i = 0; i < p1Caracteres; i++) {       // 1° Camada

            if (i == 0 || i + 1 == p1Caracteres)
            {
                Console.Write(" ");
            }

            else { Console.Write("_"); }
        }
        Console.Write("     ");
        for (int i = 0; i < p2Caracteres; i++)   // 1° Camada
        {       

            if (i == 0 || i + 1 == p2Caracteres)
            {
                Console.Write(" ");
            }

            else { Console.Write("_"); }
        }
        Console.WriteLine();

        Console.Write($"|Jogador: {NomeP1}.|"); // 2º Camada
        Console.Write("     ");
        Console.Write($"|Jogador: {NomeP2}.|"); // 2º Camada
        Console.WriteLine();


        if (placarP1 < 10)
        {
            Console.Write(placarTexto1);
            for (int i = 1; i < p1Caracteres - placarTexto1.Length; i++)          //3º Camada
            {
                Console.Write(" ");
                if (i == p1Caracteres -1-placarTexto1.Length)
                {
                    Console.Write("|");
                }
            }
        }
        else
        {
            Console.Write(placarTexto1);
            for (int i = 1; i < p1Caracteres - placarTexto1.Length; i++)          //3º Camada
            {
                Console.Write(" ");
                if (i == p1Caracteres - 1 - placarTexto1.Length)
                {
                    Console.Write("|");
                }
            }

        }
        Console.Write("     ");
        if (placarP1 < 10)
        {
            Console.Write(placarTexto2);
            for (int i = 1; i < p2Caracteres - placarTexto2.Length; i++)          //3º Camada
            {
                Console.Write(" ");
                if (i == p2Caracteres - 1 - placarTexto2.Length)
                {
                    Console.Write("|");
                }
            }
        }
        else
        {
            Console.Write(placarTexto2);
            for (int i = 1; i < p2Caracteres - placarTexto2.Length; i++)          //3º Camada
            {
                Console.Write(" ");
                if (i == p2Caracteres - 1 - placarTexto2.Length)
                {
                    Console.Write("|");
                }
            }

        }
        Console.WriteLine();

        for (int i = 0; i < p1Caracteres; i++)
        {                                               //4º Camada
            if (i == 0 || i + 1 == p1Caracteres)
            {
                Console.Write("|");
            }

            else { Console.Write(" "); }
        }
        Console.Write("     ");

        for (int i = 0; i < p2Caracteres; i++)
        {                                               //4º Camada
            if (i == 0 || i + 1 == p2Caracteres)
            {
                Console.Write("|");
            }

            else { Console.Write(" "); }
        }
        Console.WriteLine();

        for (int i = 0; i < p1Caracteres; i++) {     // 5° Camada
           
            if (i == 0 || i + 1 == p1Caracteres)
            {
                Console.Write("|");
            }

            else { Console.Write("_"); }
        }
        Console.Write("     ");
        for (int i = 0; i < p2Caracteres; i++)   // 5° Camada
        {     

            if (i == 0 || i + 1 == p2Caracteres)
            {
                Console.Write("|");
            }

            else { Console.Write("_"); }
        }


        Console.WriteLine("\n\nCaso deseje encerrar o jogo, digite \"sair\"");
        Console.WriteLine("\nCaso deseje mais uma rodada, digite qualquer outra coisa.\n");
        string opcaoEscolhida = Console.ReadLine()!;
        if (opcaoEscolhida == "sair")
        {
            return;
        }
        GeradorEstrutura geradorEstrutura = new GeradorEstrutura(this);
        if (jogadorDaVez == 1)
        {
            jogadorDaVez = 2;
            geradorEstrutura.DizerPalavra(NomeP1,NomeP2,jogadorDaVez);

        }
        else
        {
            jogadorDaVez = 1;
            geradorEstrutura.DizerPalavra(NomeP1, NomeP2, jogadorDaVez);
        }
    }  


}
