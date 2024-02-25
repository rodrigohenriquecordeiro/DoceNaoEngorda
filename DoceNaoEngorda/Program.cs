internal class Program
{
    private static void Main(string[] args)
    {
        int escolhaUsurario = Menu();

        _ = escolhaUsurario switch
        {
            1 => "Novo",
            2 => "Listar Produtos",
            3 => "Remover Produtos",
            4 => "Entrada Estoque",
            5 => "Saída Estoque",
            _ => "Sair"
        };
    }

    private static int Menu()
    {
        int escolhaMenu;
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
            escolhaMenu = ValidaEscolhaDoUsario();

        } while (escolhaMenu != 0);

        return escolhaMenu;
    }

    private static int ValidaEscolhaDoUsario()
    {
        if (!int.TryParse(Console.ReadLine(), out int escolhaMenu))
        {
            Console.WriteLine("\nERRO: Você precisa digitar uma das opções!");
            escolhaMenu = 6;
        }

        return escolhaMenu;
    }
}