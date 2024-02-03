// Screen Sound

// List<string> bandas = new List<string>(["You2", "Beatles"]);
using System.Security.Cryptography.X509Certificates;

Dictionary<string, List<int>> bandas = new Dictionary<string, List<int>>
{
    { "Linkin Park", new List<int> { 10, 9, 8 } },
    { "Beatles", new List<int> {} }
};

void ExibirMensagemDeBoasVindas()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
}

void ExibirOpcoesDoMenu()
{
    ExibirMensagemDeBoasVindas();
    Console.WriteLine("Bem vindo(a) ao screen sound\n");

    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a media de uma banda");
    Console.WriteLine("\nDigite -1 para sair\n");
    Console.Write("Digite sua opção: ");

    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            VerMediaDeUmaBanda();
            break;
        case -1:
            Console.WriteLine("Tc#hau tc#hau!");
            break;
        default:
            Console.WriteLine("Opcao incalida!");
            break;
    }
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloSecao("Exibindo todas as bandas registradas");

    foreach (string banda in bandas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nTecle para voltar ao menu...");
    Console.ReadLine();

    Console.Clear();
    ExibirOpcoesDoMenu();
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloSecao("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandas.Add(nomeDaBanda, []);
    Thread.Sleep(500);
    Console.WriteLine($"\nA banda {nomeDaBanda} foi regitrada com sucesso!");
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloSecao("Avaliar banda");

    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece? ");
        int nota = int.Parse(Console.ReadLine()!);
        bandas[nomeDaBanda].Add(nota);
        Thread.Sleep(500);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}\n");
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não está cadastrada!");
    }

    Console.WriteLine("\nTecle para voltar ao menu...");
    Console.ReadLine();

    Console.Clear();
    ExibirOpcoesDoMenu();
}

float mediaDeNotas(List<int> notas)
{
    if (notas.Count == 0) return 0;
    return notas.Sum() / notas.Count;
}

void VerMediaDeUmaBanda()
{
    Console.Clear();
    ExibirTituloSecao("Media de uma banda");

    Console.Write("Digite o nome da banda que deseja verificar a media: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandas[nomeDaBanda];
        float media = mediaDeNotas(notasDaBanda);
        Console.WriteLine($"A banda {nomeDaBanda} tem media de notas igual a {media}");
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não está cadastrada!");
    }

    Console.WriteLine("\nTecle para voltar ao menu...");
    Console.ReadLine();

    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloSecao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = String.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos);
}

ExibirOpcoesDoMenu();