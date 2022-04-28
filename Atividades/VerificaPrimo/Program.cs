using System;
using System.Collections.Generic;

namespace ListaExercicioV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listNum = new List<int>();
            Boolean inputPrimo = false;

            //Laço executado até que o usuário digite um número primo
            while (!inputPrimo)
            {
                Boolean inputValido = false;
                int numero = 0;
                int contador = 0;
                Console.WriteLine("Digite um número inteiro:");

                //Valida se o input do usuário é um número inteiro
                while (!inputValido)
                {
                    inputValido = (int.TryParse(Console.ReadLine(), out numero) && numero >= 0);

                    if (inputValido)
                    {
                        listNum.Add(numero);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Digite um número válido, parsero!");
                    }
                }

                //Contador de divisores inteiros do número digitado pelo usuário
                for (int i = 1; i <= numero; i++)
                {
                    if (numero % i == 0)
                    {
                        contador++;
                    }
                }

                //Condição para o número ser primo: se o numero tiver exatamente dois divisores (1 e ele mesmo)
                if (contador == 2)
                {
                    inputPrimo = true;
                    Console.WriteLine($"\n********** NUMERO PRIMO ENCONTRADO: {numero} **********\n");
                }
            }

            int contadorPar = 0;
            int contadorImpar = 0;
            int somaNumeros = 0;
            int maiorNumero = 0;
            int menorNumero = listNum[0];

            foreach (int numero in listNum)
            {
                //Verificando a quantidade de números pares e ímpares
                if (numero % 2 == 0)
                {
                    contadorPar++;
                }
                else
                {
                    contadorImpar++;
                }

                //Somando os números
                somaNumeros += numero;

                //Verificando o maior e o menor número digitado
                if (numero > maiorNumero)
                {
                    maiorNumero = numero;
                }
                if (numero < menorNumero)
                {
                    menorNumero = numero;
                }
            }

            //Adicionando na nova lista números aleatórios gerados entre o menor e o maior número digitados
            int numeroElementos = listNum.Count;
            int N = (int)Math.Ceiling(numeroElementos / 3.0);
            int cont = 0;
            List<int> novaLista = new List<int>();

            while (cont < N)
            {
                Random random = new Random();
                int numeroAleatório = random.Next(menorNumero, maiorNumero);
                novaLista.Add(numeroAleatório);
                cont++;
            }

            //Verificando os elementos comuns nas duas listas
            Boolean listaInicial = false;
            List<int> numsDuplicados = new List<int>();

            if (numeroElementos >= 3)
            {
                foreach (int numero in novaLista)
                {
                    if (listNum.Contains(numero))
                    {
                        numsDuplicados.Add(numero);
                        listNum.Remove(numero);
                    }
                }
            }

            //Outputs
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.WriteLine($"Total de números pares: {contadorPar}");
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.WriteLine($"Total de números ímpares: {contadorImpar}");
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.WriteLine($"Soma dos números digitados: {somaNumeros}");
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.WriteLine($"Maior número digitado: {maiorNumero}");
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.WriteLine($"Menor número digitado: {menorNumero}");
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.WriteLine($"A nova lista gerada com números randômicos é: {String.Join(", ", novaLista)}");
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.WriteLine($"O(s) número(s) {String.Join(", ", numsDuplicados)} da lista randômica está(ão) presente(s) no input do usuário.");
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.WriteLine($"Retirando número(s) randômico(s) encontrado(s), sua lista de input agora é: {String.Join(", ", listNum)}");
            Console.WriteLine("\n--------------------------------------------------------\n");
        }

    }
}
