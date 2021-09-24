using System;
namespace DIOCertificacoes
{
    class Program
    {
        static CertificacaoRepositorio repositorio = new CertificacaoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarCertificacoes();
                        break;

                    case "2":
                        InserirCertificao();
                        break;
                    case "3":
                        AtualizarCertificacao();
                        break;
                    case "4":
                        ExcluirCertificacao();
                        break;
                    case "5":
                        VisualizarCertificacao();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços, você está um passo na frente de conquistar seus objetivos!");
            Console.WriteLine();
        }

        private static void ListarCertificacoes()
        {
            Console.WriteLine("Listar Certificações");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma certificação cadastrada.");
                return;
            }
            foreach (var certificacao in lista)
            {
                var excluido = certificacao.retornaExcluido();
                if (!excluido)
                {
                    Console.WriteLine("#ID {0}: - {1}", certificacao.retornaId(), certificacao.retornaTitulo(), (excluido ? "Excluído" : "Ativo"));
                }
            }
        }

        private static void InserirCertificao()
        {
            Console.WriteLine("Inserir nova certificação");

            foreach (int i in Enum.GetValues(typeof(AreaTecnologia)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(AreaTecnologia), i));
            }
            Console.Write("Digite a área da tecnologia entre as opções acima: ");
            int entradaAreaTecnologia = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Técnologia: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a carga Horaria do curso: ");
            int entradaCargaHoraria = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da certificação: ");
            string entradaDescricao = Console.ReadLine();

            Certificacao novaCertificacao = new Certificacao(id: repositorio.ProximoID(),
                                        areaTecnologia: (AreaTecnologia)entradaAreaTecnologia,
                                        titulo: entradaTitulo,
                                        cargaHoraria: entradaCargaHoraria,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaCertificacao);
        }

        private static void AtualizarCertificacao()
        {
            Console.Write("Digite o id da Certificação: ");
            int indiceCertificacao = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(AreaTecnologia)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(AreaTecnologia), i));
            }
            Console.Write("Digite a área da certificação entre as opções acima: ");
            int entradaAreaTecnologia = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Certificação: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite a carga horária: ");
            int entradaCargaHoraria = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Certificacao atualizaCertificacao = new Certificacao(id: indiceCertificacao,
                                        areaTecnologia: (AreaTecnologia)entradaAreaTecnologia,
                                        titulo: entradaTitulo,
                                        cargaHoraria: entradaCargaHoraria,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceCertificacao, atualizaCertificacao);
        }

        private static void ExcluirCertificacao()
        {
            Console.Write("Digite o id da certificação: ");
            int indiceCertificacao = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceCertificacao);
        }

        private static void VisualizarCertificacao()
        {
            Console.Write("Digite o id da certificação: ");
            int indiceCertificacao = int.Parse(Console.ReadLine());

            var certificacao = repositorio.RetornaPorId(indiceCertificacao);

            Console.WriteLine(certificacao);
        }
        private static string ObterOpcaoUsuario()
        {

            Console.WriteLine();
            Console.WriteLine("DIO Certificações a seu dispor!");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1- Listar certificações: ");
            Console.WriteLine("2- Inserir nova certificação: ");
            Console.WriteLine("3- Atualizar certificação: ");
            Console.WriteLine("4- Excluir certificação: ");
            Console.WriteLine("5- Visualizar certificação: ");
            Console.WriteLine("C- Limpar tela: ");
            Console.WriteLine("X- Sair: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
