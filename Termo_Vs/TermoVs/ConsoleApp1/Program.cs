// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Identificador identificador = new Identificador();


Console.WriteLine("QUASE | CERTO |  NÃO  | CERTO | QUASE");



void MenuPrincipal()
{
    Console.Clear();
    Console.WriteLine("Bem vindo ao:\n");
    Console.WriteLine(" ___  |  ___  |  ___  |  ___  |  ___\n|   | | |   | | |   | | |   | | |   |\n| T | - | E | - | R | - | M | - | O |  VERSUS!\n|___|   |___|   |___|   |___|   |___|\n");

    Console.WriteLine("1. Iniciar jogo Versus");
    Console.WriteLine("2. Sair\n");
    string opcaoEscolhida = Console.ReadLine()!;

    switch (opcaoEscolhida)
    {
        case "1":
            
            identificador.IdentificarNomes();
            Console.WriteLine("\nObrigado por usar o programa!");
            break;
        case "2":
            Console.WriteLine("\nObrigado por usar o programa!");
            break;
        default:
            Console.WriteLine($"\nOpção escolhida \"{opcaoEscolhida}\" não é válida...\nPressione qualquer tecla para tentar novamente.");
            Console.ReadKey();
            MenuPrincipal();
            break;
    }




}




MenuPrincipal();
