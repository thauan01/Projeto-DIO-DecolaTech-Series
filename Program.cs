using System;
using System.Collections.Generic;

namespace PROJETO2
{

    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = GetObterOpcaoUsuario();

            while(OpcaoUsuario != "X")
            {
                switch(OpcaoUsuario)
                {
                    case "1":
                    ListarSeries();
                    break;

                    case "2":
                    InserirSerie();
                    break;

                    case "3":
                    AtualizarSerie();
                    break;

                    case "4":
                    ExcluirSerie();
                    break;

                    case "5":
                    VisualizarSerie();
                    break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                        
                }
                OpcaoUsuario = GetObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nossos serviços!");
            System.Console.WriteLine("");


        }
        public static void ListarSeries()
        {
            System.Console.WriteLine("Listar Series:");

            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma Série Cadastrada!");
                return;
            }
            else
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                System.Console.WriteLine("ID: {0} - Série: {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "- Excluido" : ""));
            }
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir Nova Série: ");

            System.Console.WriteLine("Qual o Gênero principal da Série que vamos inserir? ");
            System.Console.WriteLine("Selecione uma das opções abaixo:");
            System.Console.WriteLine("");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("");
            int entradagenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("");
            System.Console.WriteLine("Digite o Título da Série:");           
            string entradatitulo = Console.ReadLine();
            
            System.Console.WriteLine("");
            System.Console.WriteLine("Digite uma breve Descrição da Série:");
            string entradadescricao = Console.ReadLine();
            
            System.Console.WriteLine("");
            System.Console.WriteLine("Digite o Ano em que a Série foi iniciada:");
            int entradaano = int.Parse(Console.ReadLine());

            Serie novaserie = new Serie(Id: repositorio.ProximoId(),
                                        genero: (Genero) entradagenero,
                                        titulo: entradatitulo,
                                        ano: entradaano,
                                        descricao: entradadescricao);                   
            repositorio.Insere(novaserie);
        }
    private static void AtualizarSerie()
    {
        System.Console.WriteLine("Atualizar Série:");
        System.Console.WriteLine("");
        System.Console.WriteLine("Digite o ID da Série a ser atualizada: ");
        int indiceserie = int.Parse(Console.ReadLine());
        
        System.Console.WriteLine("Qual o Gênero principal da Série que estamos atualizando? ");
        System.Console.WriteLine("Selecione uma das opções abaixo:");
        System.Console.WriteLine("");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
        System.Console.WriteLine("");
        int entradagenero = int.Parse(Console.ReadLine());

        System.Console.WriteLine("");
        System.Console.WriteLine("Digite o Título da Série:");           
        string entradatitulo = Console.ReadLine();
            
        System.Console.WriteLine("");
        System.Console.WriteLine("Digite uma breve Descrição da Série:");
        string entradadescricao = Console.ReadLine();
            
        System.Console.WriteLine("");
        System.Console.WriteLine("Digite o Ano em que a Série foi iniciada:");
        int entradaano = int.Parse(Console.ReadLine());

        Serie novaserie = new Serie(Id: indiceserie,
                                        genero: (Genero) entradagenero,
                                        titulo: entradatitulo,
                                        ano: entradaano,
                                        descricao: entradadescricao);                   
        repositorio.Insere(novaserie);
    }

    private static void ExcluirSerie()
    {
        System.Console.WriteLine("Excluir Série:");
        System.Console.WriteLine("");
        System.Console.WriteLine("Digite o ID da Série a ser excluída: ");
        int indiceserie = int.Parse(Console.ReadLine());
        
        System.Console.WriteLine("Tem certeza que deseja exlcuir {0}? ", repositorio.RetornaTituloPorId(indiceserie));
        System.Console.WriteLine("S para Sim, N para Não");
        string OpcaoExcluir = System.Console.ReadLine().ToUpper();
        if(OpcaoExcluir == "S")
        {
            repositorio.Exclui(indiceserie);
        }
        else
        {
            return;
        }          
    }

    private static void VisualizarSerie()
    {
        System.Console.WriteLine("Visualizar Série:");
        System.Console.WriteLine("");
        System.Console.WriteLine("Indique o ID da Série a ser visualizada:");

        int indiceserie = int.Parse(Console.ReadLine());
        var serie = repositorio.RetornaPorId(indiceserie);
        System.Console.WriteLine(serie);

    }
    private static string GetObterOpcaoUsuario()
     {
         
        System.Console.WriteLine();
        System.Console.WriteLine("DIO Series a Seu Dispor!!");
        System.Console.WriteLine("Informe a opção desejada:");
        System.Console.WriteLine("");

        System.Console.WriteLine("1 - Listar Séries");
        System.Console.WriteLine("2 - Inserir nova Série");
        System.Console.WriteLine("3 - Atualizar Série");
        System.Console.WriteLine("4 - Excluir Série");
        System.Console.WriteLine("5 - Visualizar Série");
        System.Console.WriteLine("C - Limpar Tela");
        System.Console.WriteLine("X - Sair");
        System.Console.WriteLine("");

        string OpcaoUsuario = Console.ReadLine().ToUpper();
        System.Console.WriteLine("");
        return OpcaoUsuario;
    }}}  
    



