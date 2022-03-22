using System;

namespace ClubeLeitura.ConsoleApp
{
    public class TelaCadastroAmigos
    {
            public Amigos[] amigos;
            public int numeroAmigos;
            public Notificador notificador;

            public string MostrarOpcoes()
            {
                Console.Clear();

                Console.WriteLine("Cadastro de Amigos");

                Console.WriteLine();

                Console.WriteLine("Digite 1 para Inserir");
                Console.WriteLine("Digite 2 para Editar");
                Console.WriteLine("Digite 3 para Excluir");
                Console.WriteLine("Digite 4 para Visualizar");

                Console.WriteLine("Digite s para sair");

                string opcao = Console.ReadLine();

                return opcao;
            }

            public void InserirNovoAmigo()
            {
                MostrarTitulo("Inserindo nova Amigos");

                Amigos amigo = ObterAmigos();

                amigo.numero = ++numeroAmigos;

                int posicaoVazia = ObterPosicaoVazia();
                amigos[posicaoVazia] = amigo;

                notificador.ApresentarMensagem("Amigo inserido com sucesso!", "Sucesso");
            }

            private Amigos ObterAmigos()
            {
                Console.Write("Digite o nome do Amigo: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o nome do responsavel do Amigo: ");
                string nomeresponsavel = Console.ReadLine();

                Console.Write("Digite o telefone do Amigo: ");
                string telefone = Console.ReadLine();

                Console.Write("Digite o endereço do Amigo: ");
                string endereco = Console.ReadLine();

            Amigos amigo = new Amigos();

                amigo.nome = nome;
                amigo.nomeresponsavel = nomeresponsavel;
                amigo.telefone = telefone;
                amigo.endereco = endereco;

                return amigo;
            }

            public void EditarAmigos()
            {
                MostrarTitulo("Editando Amigos");

                VisualizarAmigos("Pesquisando");

                Console.Write("Digite o número da amigos que deseja editar: ");
                int numeroAmigos = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i].numero == numeroAmigos)
                    {
                        Amigos amigo = ObterAmigos();

                        amigo.numero = numeroAmigos;
                        amigos[i] = amigo;

                        break;
                    }
                }

                notificador.ApresentarMensagem("Amigos editada com sucesso", "Sucesso");
            }

            public void MostrarTitulo(string titulo)
            {
                Console.Clear();

                Console.WriteLine(titulo);

                Console.WriteLine();
            }

            public void ExcluirAmigos()
            {
                MostrarTitulo("Excluindo Amigos");

                VisualizarAmigos("Pesquisando");

                Console.Write("Digite o número do amigo que deseja excluir: ");
                int numeroAmigos = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i].numero == numeroAmigos)
                    {
                        amigos[i] = null;
                        break;
                    }
                }

                notificador.ApresentarMensagem("Amigo excluído com sucesso", "Sucesso");
            }

            public void VisualizarAmigos(string tipo)
            {
                if (tipo == "Tela")
                    MostrarTitulo("Visualização de Amigos");

                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i] == null)
                        continue;

                    Amigos a = amigos[i];

                    Console.WriteLine("Número: " + a.numero);
                    Console.WriteLine("Nome: " + a.nome);
                    Console.WriteLine("Nome Responsavel: " + a.nomeresponsavel);
                    Console.WriteLine("Telefone: " + a.telefone);
                    Console.WriteLine("Endereço: " + a.endereco);

                Console.WriteLine();
                }
            }

            public int ObterPosicaoVazia()
            {
                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i] == null)
                        return i;
                }

                return -1;
            }
    }
}
