using System;

class Program
{
    static void Main(string[] args)
    {
        // Execução do programa
        Console.WriteLine("MENU");
        Console.WriteLine("1 - Questão 1");
        Console.WriteLine("2 - Questão 2");

        Console.Write("Selecione uma opção: ");
        int opcao = int.Parse(Console.ReadLine());

        Console.Clear();

        switch (opcao)
        {
            case 1:
                Questao1();
                break;
            case 2:
                Questao2();
                break;
            default:
                Console.WriteLine("Você selecionou uma opção inválida, tente novamente.");
                break;
        }

        Console.WriteLine();
    }

    // Questão 1
    public static void Questao1()
    {
        int[,] matriz = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        Console.WriteLine("Matriz original:");
        ImprimirMatriz(matriz);

        InverterDiagonais(matriz);

        Console.WriteLine("Matriz com diagonais invertidas:");
        ImprimirMatriz(matriz);

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
        Console.Clear();
    }

    public static void InverterDiagonais(int[,] matriz)
    {
        int tamanho = matriz.GetLength(0);

        for (int i = 0; i < tamanho; i++)
        {
            int temp = matriz[i, i];
            matriz[i, i] = matriz[i, tamanho - 1 - i];
            matriz[i, tamanho - 1 - i] = temp;
        }
    }

    public static void ImprimirMatriz(int[,] matriz)
    {
        int tamanho = matriz.GetLength(0);

        for (int i = 0; i < tamanho; i++)
        {
            for (int j = 0; j < tamanho; j++)
                Console.Write(matriz[i, j] + " ");

            Console.WriteLine();
        }
    }

    // Questão 2
    public static void Questao2()
    {
        int[,] matriz = {
            {1, 2, 3},
            {4, 2, 5},
            {6, 7, 2}
        };

        int[,] submatriz = {
            {2, 5},
            {7, 2}
        };

        int quantidade = CountSubmatriz(matriz, submatriz);
        Console.WriteLine("A submatriz B pode ser encontrada na matriz A. " + quantidade + " vezes.");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
        Console.Clear();
    }

    public static int CountSubmatriz(int[,] matriz, int[,] submatriz)
    {
        int count = 0;
        int linA = matriz.GetLength(0);
        int colA = matriz.GetLength(1);
        int linB = submatriz.GetLength(0);
        int colB = submatriz.GetLength(1);

        for (int i = 0; i <= linA - linB; i++)
            for (int j = 0; j <= colA - colB; j++)
                if (VerificarSubmatriz(matriz, submatriz, i, j))
                    count++;

        return count;
    }

    private static bool VerificarSubmatriz(int[,] matriz, int[,] submatriz, int lin1, int col1)
    {
        int linB = submatriz.GetLength(0);
        int colB = submatriz.GetLength(1);

        for (int i = 0; i < linB; i++)
            for (int j = 0; j < colB; j++)
                if (matriz[i + lin1, j + col1] != submatriz[i, j])
                    return false;

        return true;
    }
}
