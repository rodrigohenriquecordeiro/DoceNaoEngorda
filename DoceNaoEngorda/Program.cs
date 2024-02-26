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
                    RemoverProdutos(ref listaDeDoces);
                    break;
                case 4:
                    EntradaEstoque(ref listaDeDoces);
                    break;
                case 5:
                    SaidaEstoque(ref listaDeDoces);
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
        string resultadoLinha1 = string.Empty;

        for (int i = 0; i < listaDeDoces.Length; i++)
        {
            resultadoLinha1 = $"  Código: {listaDeDoces[i].Codigo}. Sobremesa: {listaDeDoces[i].Nome.Trim().ToUpper()}. Preço: {listaDeDoces[i].Preco.ToString("C2")}. Peso: {listaDeDoces[i].Peso.ToString("F2")} gramas.";
            string resultadoLinha2 = $"  Data de Fabricação: {listaDeDoces[i].DataDaFabricao.ToShortDateString()}. Estoque: {listaDeDoces[i].QuantidadeEmEstoque} unidades.";

            Console.WriteLine();
            Console.WriteLine(new string('*', resultadoLinha1.Length));
            Console.WriteLine(resultadoLinha1);
            Console.WriteLine(resultadoLinha2);

        }
        Console.WriteLine();
        Console.WriteLine(new string('*', resultadoLinha1.Length));
    }

    private static Sobremesa[] RemoverProdutos(ref Sobremesa[] listaDeDoces)
    {
        Console.Write("\n  Qual o código da sobremesa que você quer remover? ");
        int codigoParaRemover = int.Parse(Console.ReadLine());

        Sobremesa[] novaListaDeDoces = new Sobremesa[listaDeDoces.Length - 1];
        int indiceNovoArray = 0;

        for (int i = 0; i < listaDeDoces.Length; i++)
        {
            if (listaDeDoces[i].Codigo != codigoParaRemover)
            {
                novaListaDeDoces[indiceNovoArray] = listaDeDoces[i];
                indiceNovoArray++;
            }
        }

        Console.WriteLine($"\n  Removemos com sucesso a sobremesa {listaDeDoces[codigoParaRemover - 1].Nome.ToUpper()}");
        listaDeDoces = novaListaDeDoces;

        return listaDeDoces;
    }

    private static Sobremesa[] EntradaEstoque(ref Sobremesa[] listaDeDoces)
    {
        Console.Write("\n  Digite o Código da sobremesa que você quer alterar: ");
        int sobremesaQueSeraAlterada = int.Parse(Console.ReadLine());
        string nomeSobremesaAlterada = listaDeDoces[sobremesaQueSeraAlterada - 1].Nome.ToUpper();

        Console.Write($"  Digite a quantidade a ser adicionada a sobremesa {nomeSobremesaAlterada}: ");
        int quantidadeAdicionada = int.Parse(Console.ReadLine());

        for (int i = 0; i < listaDeDoces.Length; i++)
        {
            if (listaDeDoces[i].Codigo == sobremesaQueSeraAlterada)
                listaDeDoces[i].QuantidadeEmEstoque += quantidadeAdicionada;
        }

        Console.WriteLine($"  Foi adicionado {quantidadeAdicionada} unidades no estoque da sobremesa {nomeSobremesaAlterada}!");

        return listaDeDoces;
    }

    private static Sobremesa[] SaidaEstoque(ref Sobremesa[] listaDeDoces)
    {
        Console.Write("\n  Digite o Código da sobremesa que você quer alterar: ");
        int sobremesaQueSeraAlterada = int.Parse(Console.ReadLine());
        string nomeSobremesaAlterada = listaDeDoces[sobremesaQueSeraAlterada - 1].Nome.ToUpper();

        Console.Write($"  Digite a quantidade a ser removida a sobremesa {nomeSobremesaAlterada}: ");
        int quantidadeRemovida = int.Parse(Console.ReadLine());

        for (int i = 0; i < listaDeDoces.Length; i++)
        {
            if (listaDeDoces[i].Codigo == sobremesaQueSeraAlterada)
                listaDeDoces[i].QuantidadeEmEstoque -= quantidadeRemovida;
        }

        Console.WriteLine($"  Foi removido {quantidadeRemovida} unidades no estoque da sobremesa {nomeSobremesaAlterada}!");

        return listaDeDoces;
    }

    private static void Sair()
    {
        Console.WriteLine("Sair");
        Console.WriteLine("\nCopyright©️ Rodrigo Henrique Cordeiro");
    }
}