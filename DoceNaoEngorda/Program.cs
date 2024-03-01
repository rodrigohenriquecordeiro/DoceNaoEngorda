using DoceNaoEngorda;

internal class Program
{
    private static void Main(string[] args)
    {
        int escolhaMenu;
        Sobremesa[] listaDeDoces = [];

        do
        {
            escolhaMenu = Menu(ref listaDeDoces);

        } while (escolhaMenu != 0);
    }

    private static int Menu(ref Sobremesa[] listaDeDoces)
    {
        int escolhaMenu;
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

        return escolhaMenu;
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
        ValidaNovoCodigo(doce);

        Console.Write("  Nome da Sobremesa: ");
        ValidaNovoNome(doce);

        Console.Write("  Data da Fabricação: ");
        ValidaNovaDataFabricacao(doce);

        Console.Write($"  Qual o peso? ");
        ValidaNovoPeso(doce);

        Console.Write("  Quanto custa: ");
        ValidaNovoPreco(doce);

        listaDeDoces = AdicionaNovoDoceNaLista(listaDeDoces, doce);
    }

    private static void ValidaNovoCodigo(Sobremesa doce)
    {
        int codigo;

        while (!int.TryParse(Console.ReadLine(), out codigo))
        {
            Console.WriteLine("  Digite um Código válido para a sobremesa");
            Console.Write("  NOVA TENTATIVA: ");
        }

        doce.Codigo = codigo;
    }

    private static void ValidaNovoNome(Sobremesa doce)
    {
        string? nome = Console.ReadLine();

        while (nome is null || nome == "")
        {
            Console.WriteLine("  Digite um nome válido para a sobremesa");
            Console.Write("  NOVA TENTATIVA: ");
            nome = Console.ReadLine();
        }

        doce.Nome = nome;
    }

    private static void ValidaNovaDataFabricacao(Sobremesa doce)
    {
        DateTime data;

        while (!DateTime.TryParse(Console.ReadLine(), out data))
        {
            Console.WriteLine("  Digite uma data valida para a sobremesa");
            Console.Write("  NOVA TENTATIVA: ");
        }

        doce.DataDaFabricao = data;
    }

    private static void ValidaNovoPeso(Sobremesa doce)
    {
        double peso;

        while (!double.TryParse(Console.ReadLine(), out peso))
        {
            Console.WriteLine("  Digite um peso valido para a sobremesa");
            Console.Write("  NOVA TENTATIVA: ");
        }

        doce.Peso = peso;
    }

    private static void ValidaNovoPreco(Sobremesa doce)
    {
        decimal preco;

        while (!decimal.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("  Digite um preço valido para a sobremesa");
            Console.Write("  NOVA TENTATIVA: ");
        }

        doce.Preco = preco;
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
            resultadoLinha1 = $"  Código: {listaDeDoces[i].Codigo}. Sobremesa: {listaDeDoces[i].Nome.Trim().ToUpper()}. Preço: {listaDeDoces[i].Preco:C2}. Peso: {listaDeDoces[i].Peso:F2} gramas.";
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

        if (quantidadeAdicionada == 0)
            Console.WriteLine($"  Foi adicionado {quantidadeAdicionada} unidade no estoque da sobremesa {nomeSobremesaAlterada}!");
        else
            Console.WriteLine($"  Foram adicionadas {quantidadeAdicionada} unidades no estoque da sobremesa {nomeSobremesaAlterada}!");

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

        if (quantidadeRemovida == 0)
            Console.WriteLine($"  Foi removido {quantidadeRemovida} unidade no estoque da sobremesa {nomeSobremesaAlterada}!");
        else
            Console.WriteLine($"  Foram removidos {quantidadeRemovida} unidades no estoque da sobremesa {nomeSobremesaAlterada}!");

        return listaDeDoces;
    }

    private static void Sair()
    {
        Console.WriteLine("Sair");
        Console.WriteLine("\nCopyright©️ Rodrigo Henrique Cordeiro");
    }
}