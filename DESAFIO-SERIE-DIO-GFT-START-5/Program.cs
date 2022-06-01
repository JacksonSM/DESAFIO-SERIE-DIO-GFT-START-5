using Programa.Entidades;
using System;
using System.Collections.Generic;

namespace Programa
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {

            var opcaoEscolhida = MenuPrincipal();


            switch (opcaoEscolhida)
            {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSerie();
                    break;
                case "3":
                    //AtualizarSerie();
                    break;
                case "4":
                    //ExcluirSerie();
                    break;
                case "5":
                    //VisualizarSerie();

                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Write("Opção inexistente !! Aperte qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    opcaoEscolhida = MenuPrincipal();
                    break;
            }



            Main(null);
        }

        private static void InserirSerie()
        {


            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

        }

        private static void ListarSeries()
        {
            Console.Clear();
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Estamos sem nenhuma série :| Aperte qualquer tecla para voltar ao Menu.");
                Console.ReadKey();
                Main(null);
            }
            else
            {
                Console.WriteLine("Séries Cadastradas");
                Console.WriteLine("=========================================");
                foreach (Serie serie in lista)
                {
                    Console.WriteLine(serie.retornaTitulo());

                }
                Console.WriteLine("=========================================");
                Console.Write("Aperte qualquer tecla para voltar ao Menu.");
                Console.ReadKey();
            }
        }

        private static string MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*** InfoSéries ***");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine(" ");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Cadastar uma nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("6- Sair");
            Console.WriteLine();

            var escolha = (Console.ReadLine());



            return escolha;
        }
    }
}
