using System;

namespace AdventureGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int maxPtsVidaJogador = 500;
            int maxPtsMagiaJogador = 100;
            int moedasOuro = 300;
            int ataqueJogador = 100;
            int ptsVidaJogador = 100;
            int ptsMagiaJogador = 50;
            int qtdPocao = 0;
            int qtdElixir = 0;

            //Parâmetros monstro comum
            int ptsVidaMonstro = 500;
            int ataqueMonstro = 100;
            int minRecompensa = 50;
            int maxRecompensa = 100;
            int maxPtsVidaMonstro = 500;

            //Parâmetros chefão
            int ptsVidaChefe = 5000;
            int ataqueChefe = 250;
            int minRecompensaChefe = 500;
            int maxRecompensaChefe = 1000;
            int maxPtsVidaChefe = 5000;


            void RetornarMenu()
            {
                Console.WriteLine("\nOlá, aventureiro!!\nEscolha uma das 3 opções:\n1 - Visitar loja;\n2 - Dormir;\n3 - Explorar masmorra.");

                Boolean inputValido = false;
                int opcaoInicial = 0;

                while (!inputValido)
                {
                    inputValido = (int.TryParse(Console.ReadLine(), out opcaoInicial) && opcaoInicial > 0 && opcaoInicial <= 3);
                    if (inputValido)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Digite uma opção válida, aventureiro!!");
                    }
                }

                if (opcaoInicial == 1)
                {
                    VisitarLoja();
                }
                else if (opcaoInicial == 2)
                {
                    Dormir();
                }
                else if (opcaoInicial == 3)
                {
                    ExplorarMasmorra();
                }

            }
            void VisitarLoja()
            {
                Console.WriteLine($"\nVocê possui um total de {moedasOuro} moedas de ouro.");
                Console.WriteLine("Olá, estranho! O que você deseja comprar?\n1 - Poção: Recupera 500 pontos de vida. Preço: 100 moedas de ouro.\n2 - Elixir: Recupera 50 pontos de magia. Preço: 100 moedas de ouro.\n3 - Voltar ao menu de exploração.");

                Boolean inputValido = false;
                int opcaoCompra = 0;

                while (!inputValido)
                {
                    inputValido = (int.TryParse(Console.ReadLine(), out opcaoCompra) && opcaoCompra > 0 && opcaoCompra <= 3);
                    if (inputValido)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Digite uma opção válida, aventureiro!!");
                    }
                }

                if (opcaoCompra == 1)
                {
                    Console.WriteLine("\nQual a quantidade de poção você gostaria de comprar?");
                    bool inputCompra = false;
                    int qtdCompra = 0;

                    while (!inputCompra)
                    {
                        inputCompra = (int.TryParse(Console.ReadLine(), out qtdCompra) && qtdCompra > 0);
                        if (inputCompra)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Digite uma opção válida, aventureiro!!");
                        }

                    }

                    if (qtdCompra * 100 <= moedasOuro)
                    {
                        qtdPocao += qtdCompra;
                        moedasOuro -= qtdCompra * 100;
                        Console.WriteLine($"Compra realizada com sucesso! Você possui um total de {qtdPocao} poção(ões).");
                    }
                    else
                    {
                        Console.WriteLine("Você não possui moedas de ouro suficiente :(");
                    }

                    VisitarLoja();

                }
                else if (opcaoCompra == 2)
                {
                    Console.WriteLine("\nQual a quantidade de elixir você gostaria de comprar?");
                    bool inputCompra = false;
                    int qtdCompra = 0;

                    while (!inputCompra)
                    {
                        inputCompra = (int.TryParse(Console.ReadLine(), out qtdCompra) && qtdCompra > 0);
                        if (inputCompra)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Digite uma opção válida, aventureiro!!");
                        }
                    }

                    if (qtdCompra * 100 <= moedasOuro)
                    {
                        qtdElixir += qtdCompra;
                        moedasOuro -= qtdCompra * 100;
                        Console.WriteLine($"Compra realizada com sucesso! Você possui um total de {qtdElixir} elixir.");
                    }
                    else
                    {
                        Console.WriteLine("Você não possui moedas de ouro suficiente :(");
                    }

                    VisitarLoja();
                }
                else if (opcaoCompra == 3)
                {
                    RetornarMenu();
                }
            }

            void Dormir()
            {
                ptsVidaJogador = maxPtsVidaJogador;
                ptsMagiaJogador = maxPtsMagiaJogador;
                Console.WriteLine("Recepcionista: Bem-vindo a nossa taverna, aventureiro. Tenha ótimos sonhos!!\n(dormindo zzZzZ)");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("Recepcionista: Ahh, você acordou! Boas aventuras!!\n");
                RetornarMenu();
            }

            void ExplorarMasmorra()
            {
                Boolean inputValido = false;
                int opcao = 0;

                Console.WriteLine("O que gostaria de fazer, aventureiro?\n1 - Entrar na sala do monstro.\n2 - Entrar na sala do chefão.\n3 - Voltar ao menu de exploração.");

                while (!inputValido)
                {
                    inputValido = (int.TryParse(Console.ReadLine(), out opcao) && opcao > 0 && opcao <= 3);

                    if (inputValido)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Digite uma opção válida, aventureiro!!");
                    }
                }

                if (opcao == 1)
                {
                    int turnosBatalha = 0;
                    while (ptsVidaMonstro >= 0 && ptsVidaJogador >= 0)
                    {
                        BatalharMonstro();
                        ptsVidaJogador -= ataqueMonstro;
                        turnosBatalha++;
                    }

                    Console.WriteLine("\n--------------- RESOLUÇÃO DA BATALHA ----------------\n");
                    Console.WriteLine($"Jogador:\nPontos de vida: {ptsVidaJogador}/{maxPtsVidaJogador}\nPontos de magia: {ptsMagiaJogador}/{maxPtsMagiaJogador}");
                    Console.WriteLine($"Monstro:\nPontos de vida: {ptsVidaMonstro}/{maxPtsVidaMonstro}");
                    Console.WriteLine("\n-----------------------------------------------------\n");

                    if (ptsVidaJogador > ptsVidaMonstro)
                    {
                        maxPtsVidaJogador += 10;
                        ptsVidaMonstro = maxPtsVidaMonstro;
                        Random rdn = new Random();
                        int recompensa = rdn.Next(minRecompensa, maxRecompensa);
                        moedasOuro += recompensa;
                        Console.WriteLine($"Parabéns, aventureiro!! Você venceu o monstro em {turnosBatalha} turno(s).");
                        Console.WriteLine($"Vida máxima aumentada para {maxPtsVidaJogador}.\n{recompensa} moedas de ouro recebidas.\n");
                        Console.WriteLine("Retornando à sala anterior..");
                        ExplorarMasmorra();
                    }
                    else if (ptsVidaMonstro > ptsVidaJogador)
                    {
                        ptsVidaMonstro = maxPtsVidaMonstro;
                        Console.WriteLine("Monstro: HAHAHA! Fraco, muito fraco! Mande mais aventureiros para me entreter!!");
                        Console.WriteLine("\nO aventureiro será encaminhado para a taverna da cidade..\n");
                        Dormir();
                    }
                }
                else if (opcao == 2)
                {
                    int turnosBatalha = 0;
                    while (ptsVidaChefe >= 0 && ptsVidaJogador >= 0)
                    {
                        BatalharChefao();
                        ptsVidaJogador -= ataqueChefe;
                        turnosBatalha++;
                    }

                    Console.WriteLine("\n--------------- RESOLUÇÃO DA BATALHA ----------------\n");
                    Console.WriteLine($"Jogador:\nPontos de vida: {ptsVidaJogador}/{maxPtsVidaJogador}\nPontos de magia: {ptsMagiaJogador}/{maxPtsMagiaJogador}");
                    Console.WriteLine($"Chefão:\nPontos de vida: {ptsVidaChefe}/{maxPtsVidaChefe}");
                    Console.WriteLine("\n-----------------------------------------------------\n");

                    if (ptsVidaJogador > ptsVidaChefe)
                    {
                        maxPtsVidaJogador += 250;
                        ptsVidaChefe = maxPtsVidaChefe;
                        Random rdn = new Random();
                        int recompensa = rdn.Next(minRecompensaChefe, maxRecompensaChefe);
                        moedasOuro += recompensa;
                        Console.WriteLine($"Parabéns, aventureiro!! Você venceu o monstro em {turnosBatalha} turno(s).");
                        Console.WriteLine($"Vida máxima aumentada para {maxPtsVidaJogador}.\n{recompensa} moedas de ouro recebidas.\n");
                        Console.WriteLine("Retornando à sala anterior..");
                        ExplorarMasmorra();
                    }
                    else if (ptsVidaChefe > ptsVidaJogador)
                    {
                        ptsVidaChefe = maxPtsVidaChefe;
                        Console.WriteLine("Chefão: HAHAHA! Você achou mesmo que poderia me derrotar?? Precisa comer muito arroz e feijão ainda pra isso, seu fraco!!");
                        Console.WriteLine("\nO aventureiro será encaminhado para a taverna da cidade..\n");
                        Dormir();
                    }
                }
                else if (opcao == 3)
                {
                    RetornarMenu();
                }
            }

            void AtacarMonstro()
            {
                ptsVidaMonstro -= ataqueJogador;
            }

            void DispararEnergiaMonstro()
            {
                if (ptsMagiaJogador >= 50)
                {
                    ptsVidaMonstro -= (ataqueJogador * 2);
                    ptsMagiaJogador -= 50;
                }
                else
                {
                    Console.WriteLine("Você não tem pontos de magia suficiente, aventureiro :(");
                    BatalharMonstro();
                }
            }

            void AtacarChefao()
            {
                ptsVidaChefe -= ataqueJogador;
            }

            void DispararEnergiaChefao()
            {
                if (ptsMagiaJogador >= 50)
                {
                    ptsVidaChefe -= (ataqueJogador * 2);
                    ptsMagiaJogador -= 50;
                }
                else
                {
                    Console.WriteLine("Você não tem pontos de magia suficiente, aventureiro :(");
                    BatalharChefao();
                }
            }

            void UsarItem()
            {
                Console.WriteLine($"O que você gostaria de utilizar, aventureiro?\n1 - Poção (você possui {qtdPocao} poção(ões))\n2 - Elixir (você possui {qtdElixir} elixir)");

                Boolean inputValido = false;
                int opcaoUso = 0;

                while (!inputValido)
                {
                    inputValido = (int.TryParse(Console.ReadLine(), out opcaoUso) && opcaoUso > 0 && opcaoUso <= 2);

                    if (inputValido)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Digite uma opção válida, aventureiro!!");
                    }
                }

                if (opcaoUso == 1 && qtdPocao > 0)
                {
                    qtdPocao--;
                    ptsVidaJogador += 500;
                }
                else if (opcaoUso == 2 && qtdElixir > 0)
                {
                    qtdElixir--;
                    ptsMagiaJogador += 50;
                }
            }

            void BatalharMonstro()
            {
                Console.WriteLine("Realize uma ação:\n1 - Atacar;\n2 - Disparar energia;\n3 - Usar item.");

                Boolean inputValido = false;
                int opcaoBatalha = 0;

                while (!inputValido)
                {
                    inputValido = (int.TryParse(Console.ReadLine(), out opcaoBatalha) && opcaoBatalha > 0 && opcaoBatalha <= 3);

                    if (inputValido)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Digite uma opção válida, aventureiro!!");
                    }
                }

                if (opcaoBatalha == 1)
                {
                    AtacarMonstro();
                }
                else if (opcaoBatalha == 2)
                {
                    DispararEnergiaMonstro();
                }
                else if (opcaoBatalha == 3)
                {
                    UsarItem();
                }
            }

            void BatalharChefao()
            {
                Console.WriteLine("Realize uma ação:\n1 - Atacar;\n2 - Disparar energia;\n3 - Usar item.");

                Boolean inputValido = false;
                int opcaoBatalha = 0;

                while (!inputValido)
                {
                    inputValido = (int.TryParse(Console.ReadLine(), out opcaoBatalha) && opcaoBatalha > 0 && opcaoBatalha <= 3);

                    if (inputValido)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Digite uma opção válida, aventureiro!!");
                    }
                }

                if (opcaoBatalha == 1)
                {
                    AtacarChefao();
                }
                else if (opcaoBatalha == 2)
                {
                    DispararEnergiaChefao();
                }
                else if (opcaoBatalha == 3)
                {
                    UsarItem();
                }
            }



            RetornarMenu();











        }
    }
}
