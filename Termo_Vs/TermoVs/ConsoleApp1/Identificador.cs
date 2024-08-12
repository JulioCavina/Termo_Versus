class Identificador
{

    Dictionary<string,string> nomesEspeciais = new Dictionary<string,string>();

    public void IdentificarNomes()  //Identifica os nomes do Player 1 e 2 e gera o placar
    {
        nomesEspeciais.Clear();
        nomesEspeciais.Add("Juliana", " Cabeçuda");
        nomesEspeciais.Add("Angela", " Peidorrera");
        nomesEspeciais.Add("Ana", " Fedorenta");
        Console.Clear();
        Console.WriteLine("Jogo Termo VERSUS\n");
        Console.WriteLine("Qual é o nome do Player 1?\n");
        string player1 = Console.ReadLine()!;
        Console.WriteLine("\nQual é o nome do Player 2?\n");
        string player2 = Console.ReadLine()!;

        foreach (string nome in nomesEspeciais.Keys)
        {
            if (player1 == nome) { player1 = player1 + nomesEspeciais[nome]; }               
            if (player2 == nome) { player2 = player2 + nomesEspeciais[nome]; }
        }

        Placar placar = new Placar(player1,player2);

        
        GeradorEstrutura geradorEstrutura = new GeradorEstrutura(placar);
        geradorEstrutura.DizerPalavra(player1,player2,1);

        Console.ReadKey();
    }


}