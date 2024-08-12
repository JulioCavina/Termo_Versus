using System.Globalization;
using System.Text;

class GeradorEstrutura
{

    private int bronca = 0;

    private string palavraEscolhida;

    private Placar placar;

    public GeradorEstrutura(Placar placar)
    {
        this.placar = placar;
    }

    public void DizerPalavra(string player1,string player2,int jogadorDaVez)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Jogo Termo VERSUS\n");
            bronca = 0;
            if (jogadorDaVez == 1)
            {
                Console.WriteLine($"ESTA TELA É APENAS PARA {player1} VER!!!\n");
                Console.WriteLine($"{player1}, qual palavra de CINCO letras deseja escolher?\n");
            }
            if (jogadorDaVez == 2)
            {
                Console.WriteLine($"ESTA TELA É APENAS PARA {player2} VER!!!\n");
                Console.WriteLine($"{player2}, qual palavra de CINCO letras deseja escolher?\n");
            }
            palavraEscolhida = Console.ReadLine()!;
            if (palavraEscolhida.Length != 5)
            {
                Bronca("5 letras");
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    char letra = palavraEscolhida[i];
                    if (!char.IsLetter(letra))
                    {
                        Bronca("numeros");
                        break;
                    }
                    if (char.IsWhiteSpace(letra))
                    {
                        Bronca("espaco vazio");
                    }
                }
                if (palavraEscolhida.ToLower().Contains("ç"))
                {
                    Bronca("ç");
                }

            }
            if (bronca == 0)
            {
                break;
            }
            Console.WriteLine("Pressione qualquer tecla para tentar novamente.");
            Console.ReadKey();
        }

        palavraEscolhida = RemoverAcentuacao(palavraEscolhida);
        
        Verificador verificador = new Verificador(player1,player2,palavraEscolhida,jogadorDaVez, placar);


        //verificador.VerificadorPalpites(jogadorDaVez);
        //Função para seguir pro jogo()

    }

    static string RemoverAcentuacao(string palavra)
    {
        if (string.IsNullOrEmpty(palavra))
            return palavra;

        var palavraNormalizada = palavra.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var letra in palavraNormalizada)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(letra);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(letra);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }



    public void Bronca(string motivo)
    {
        if (motivo == "5 letras"||motivo == "numeros")
        {
            Console.WriteLine("\nPor favor, digite uma PALAVRA que contenha EXATAMENTE 5 LETRAS!");
        }
        if (motivo == "espaco vazio")
        {
            Console.WriteLine("Por favor, digite uma PALAVRA COMPLETA E SEM ESPAÇOS com exatamente 5 letras!");
        }
        if (motivo == "ç")
        {
            Console.WriteLine("Tsc Tsc Tsc, pare de malandragem, \"Ç\" é muito roubado");
        }

        bronca++;
    }
}