using DoceNaoEngorda;

internal class Program
{
    private static void Main(string[] args)
    {
        int escolhaMenu;
        Sobremesa[] listaDeDoces = [];

        do
        {
            Console.WriteLine("\n>>---> Doce Não Engorda! <---<<\n\n" +
            "  [1] Novo\n" +
            "  [2] Listar Produtos\n" +
            "  [3] Remover Produtos\n" +
            "  [4] Entrada Estoque\n" +
            "  [5] Saída Estoque\n" +
            "  [0] Sair\n");

            Console.Write("\nDigite sua escolha: ");
            escolhaMenu = ValidaEscolhaDoUsuario();

            switch (escolhaMenu)
            {
                case 1:
                    Novo(ref listaDeDoces);
                    break;
                case 2:
                    ListarProdutos(ref listaDeDoces);
                    break;
                case 3:
                    RemoverProdutos();
                    break;
                case 4:
                    EntradaEstoque();
                    break;
                case 5:
                    SaidaEstoque();
                    break;
                case 0:
                    Sair();
                    break;
            }

        } while (escolhaMenu != 0);


    }

    private static int ValidaEscolhaDoUsuario()
    {
        if (!int.TryParse(Console.ReadLine(), out int escolhaMenu))
        {
            Console.WriteLine("\nERRO: Você precisa digitar uma das opções!");
            escolhaMenu = 6;
        }

        return escolhaMenu;
    }

    private static void Novo(ref Sobremesa[] listaDeDoces)
    {
        Sobremesa doce = new();

        Console.Write("  Código: ");
        doce.Codigo = int.Parse(Console.ReadLine());

        Console.Write("  Nome da Sobremesa: ");
        doce.Nome = Console.ReadLine();

        Console.Write("  Data da Fabricação: ");
        doce.DataDaFabricao = DateTime.Parse(Console.ReadLine());

        Console.Write($"  Qual o peso? ");
        doce.Peso = double.Parse(Console.ReadLine());

        Console.Write("  Quanto custa: ");
        doce.Preco = decimal.Parse(Console.ReadLine());

        listaDeDoces = AdicionaNovoDoceNaLista(listaDeDoces, doce);
    }

    private static Sobremesa[] AdicionaNovoDoceNaLista(Sobremesa[] listaDeDoces, Sobremesa doce)
    {
        if (listaDeDoces != null)
        {
            Sobremesa[] listaTemporariaDeDoces = new Sobremesa[listaDeDoces.Length + 1];
            for (int i = 0; i < listaDeDoces.Length; i++)
            {
                listaTemporariaDeDoces[i] = listaDeDoces[i];
            }
            listaTemporariaDeDoces[listaDeDoces.Length] = doce;
            listaDeDoces = listaTemporariaDeDoces;
        }

        return listaDeDoces;
    }

    private static void ListarProdutos(ref Sobremesa[] listaDeDoces)
    {
        for (int i = 0; i < listaDeDoces.Length; i++)
        {
            Console.WriteLine($"\n  Cod: {listaDeDoces[i].Codigo}.\n" +
                $"  Sobremesa: {listaDeDoces[i].Nome}.\n" +
                $"  Data de Fabricação: {listaDeDoces[i].DataDaFabricao.ToShortDateString()}.\n" +
                $"  Preço: {listaDeDoces[i].Preco}.\n" +
                $"  Peso: {listaDeDoces[i].Peso}.\n" +
                $"  Estoque: {listaDeDoces[i].QuantidadeEmEstoque}.");
        }
    }

    private static void RemoverProdutos()
    {
        Console.WriteLine("RemoverProdutos");
    }

    private static void EntradaEstoque()
    {
        Console.WriteLine("EntradaEstoque");
    }

    private static void SaidaEstoque()
    {
        Console.WriteLine("SaidaEstoque");
    }

    private static void Sair()
    {
        Console.WriteLine("Sair");
    }
}