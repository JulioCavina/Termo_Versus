using System.Data;
using System.Globalization;
using System.Text;

class Verificador
{
    private Placar placar;

    public Verificador(string player1, string player2, string palavraSecreta, int jogadorDaVez, Placar placar)
    {
        Player1 = player1;
        Player2 = player2;
        dicPalavras.Add(0, new List<string> { palavraSecreta });
        JogadorDaVez = jogadorDaVez;
        this.placar = placar;

        for (int i = 1; i < 7; i++)
        {
            dicPalavras.Add(i, new List<string> { "?????" });                                    // 1 - 6 --> sera as palavras q o jogador ja chutou
            dicPalavras.Add(i + 6, new List<string> { "                                     " });  //7 - 12 --> sera a verificação salva
        }

        // Crie o placar apenas uma vez na criação do Verificador
        placar = new Placar(Player1, Player2);

        VerificadorPalpites(JogadorDaVez);
    }

    private int bronca = 0;

    Dictionary<int, List<string>> dicPalavras = new Dictionary<int, List<string>>();

    public string Player1 { get; }

    public string Player2 { get; }
    public int JogadorDaVez { get; }

    
    public void VerificadorPalpites(int jogadorDaVez)
    {
        int quantidadeCerto = 0;
        int quantidadePalpites = 0;
        while (quantidadePalpites < 7)
        {

            Console.Clear();
            bronca = 0;

            if (jogadorDaVez == 1 && quantidadePalpites != 6 && quantidadeCerto != 5)
            {
                Console.WriteLine($"\n\n\n\n\n{Player2}, sua vez de jogar!\nTente adivinhar quais são as 5 letras escondidas!\n");
            }
            if (jogadorDaVez == 2 && quantidadePalpites != 6 && quantidadeCerto != 5)
            {
                Console.WriteLine($"\n\n\n\n\n{Player1}, sua vez de jogar!\nTente adivinhar quais são as 5 letras escondidas!\n");
            }

            for (int i = 1; i < 7; i++)
            {
                Console.WriteLine(dicPalavras[i + 6][0]);
                Console.WriteLine($" ___  |  ___  |  ___  |  ___  |  ___\n|   | | |   | | |   | | |   | | |   |\n| {char.ToUpper(dicPalavras[i][0][0])} | - | {char.ToUpper(dicPalavras[i][0][1])} | - | {char.ToUpper(dicPalavras[i][0][2])} | - | {char.ToUpper(dicPalavras[i][0][3])} | - | {char.ToUpper(dicPalavras[i][0][4])} |\n|___|   |___|   |___|   |___|   |___|\n");
            }
            if (quantidadeCerto == 5)
            {
                Console.WriteLine($"\nResposta Correta! Você acertou em {quantidadePalpites} tentativas! (Pressione qualquer dígito para ir ao placar)");
                Console.ReadKey();
                break;
            }
            if (quantidadePalpites != 6)
            {
                Console.WriteLine("\nQual será seu palpite?");
                string palpiteJogador = Console.ReadLine()!;

                if (palpiteJogador.Length != 5)
                {
                    Bronca("5 letras");
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        char letra = palpiteJogador[i];
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
                }

                if (bronca == 0 && quantidadePalpites < 6)
                {
                    palpiteJogador = RemoverAcentuacao(palpiteJogador);

                    quantidadePalpites++;
                    dicPalavras[quantidadePalpites][0] = palpiteJogador;
                    string palavraDicMinuscula = dicPalavras[0][0].ToLower();

                    var letraSecretaCount = new Dictionary<char, int>();

                    foreach (char c in palavraDicMinuscula)
                    {
                        if (letraSecretaCount.ContainsKey(c))
                        {
                            letraSecretaCount[c]++;
                        }
                        else
                        {
                            letraSecretaCount[c] = 1;
                        }
                    }

                    var resultado = new List<string>(new string[6]);
                    for (int i = 0; i < 6; i++)
                    {
                        if (i == 5)
                        {
                            resultado[i] = "|";
                        }
                        else
                        {
                            resultado[i] = "  NÃO  ";
                        }
                    }
                    quantidadeCerto = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        
                        char caractere = char.ToLower(palpiteJogador[i]);
                        if (palavraDicMinuscula[i] == caractere)
                        {
                            resultado[i] = " CERTO ";
                            letraSecretaCount[caractere]--;
                            quantidadeCerto++;
                        }
                    }


                    for (int i = 0; i < 5; i++)
                    {
                        char caractere = char.ToLower(palpiteJogador[i]);
                        if (resultado[i] == "  NÃO  " && palavraDicMinuscula.Contains(caractere) && letraSecretaCount.TryGetValue(caractere, out int count) && count > 0)
                        {
                            resultado[i] = " QUASE ";
                            letraSecretaCount[caractere]--;
                        }
                    }

                    resultado[0] = resultado[0].Substring(1);
                    string resultadoString = "";

                    for (int i = 0; i < 5; i++)
                    {
                        if (i == 4)
                        {
                            resultadoString = resultadoString + resultado[i];
                        }
                        else
                        {
                            resultadoString = resultadoString + resultado[i] + resultado[5];
                        }
                    }
                    dicPalavras[quantidadePalpites + 6][0] = resultadoString;
                }
                else
                {
                    Console.WriteLine("\nPressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                }
            }
            else
            {
                quantidadePalpites++;
                Console.WriteLine($"\nQue pena! Adicionado {quantidadePalpites} pontos ao seu placar!");
                Console.ReadKey();
            }
        }

        placar.GerarPlacar(quantidadePalpites, jogadorDaVez);
    }

    public void Bronca(string motivo)
    {
        if (motivo == "5 letras" || motivo == "numeros")
        {
            Console.WriteLine("\nPor favor, digite uma PALAVRA que contenha EXATAMENTE 5 LETRAS!");
        }
        if (motivo == "espaco vazio")
        {
            Console.WriteLine("Por favor, digite uma PALAVRA COMPLETA E SEM ESPAÇOS com exatamente 5 letras!");
        }

        bronca++;
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

}
