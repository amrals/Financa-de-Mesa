using System;
using Finança_de_Mesa.Repositorio;
using Finança_de_Mesa.Utils;
using Finança_de_Mesa.ViewController;
using Finança_de_Mesa.ViewModel;
using static Finança_de_Mesa.Enums.Cores;

namespace Finança_de_Mesa {
    class Program {
        static void Main (string[] args) {
            bool querSair = false;
            TransacaoViewController transacaoViewController = new TransacaoViewController ();
            var repositorioUsuario = new RepositorioUsuario ();
            do {
                Console.Clear ();
                MenuUtils.MenuDeslogado ();
                string codigo = Console.ReadLine ();
                switch (codigo) {
                    case "1":
                        UsuarioViewController.CadastrarUsuario ();
                        break;
                    case "2":
                        UsuarioViewModel usuarioRecuperado = UsuarioViewController.LoginUsuario ();
                        if (usuarioRecuperado != null) {
                            if (usuarioRecuperado.Tipo.Equals ("Comum")) {
                                Console.Clear ();
                                CoresUtils.MostrarMensagem ($"   Bem-Vindo {usuarioRecuperado.Nome}", TipoMensagemEnum.SUCESSO);
                                System.Console.WriteLine ("Pressione ENTER para continuar");
                                Console.ReadLine ();
                                do {
                                    MenuUtils.MenuLogado ();
                                    codigo = Console.ReadLine ();
                                    switch (codigo) {
                                        case "1":
                                            transacaoViewController.CadastrarTransacao (usuarioRecuperado);
                                            repositorioUsuario.Editar (usuarioRecuperado);
                                            break;
                                        case "2":
                                            TransacaoViewController.TransacoesWord (usuarioRecuperado.Nome, usuarioRecuperado.Id, usuarioRecuperado.Saldo);
                                            break;
                                        case "3":
                                            TransacaoViewController.ExibirTransacao (usuarioRecuperado.Id);
                                            break;
                                        case "0":
                                            CoresUtils.MostrarMensagem ("Obrigado pela preferência", TipoMensagemEnum.SUCESSO);
                                            querSair = true;
                                            break;
                                        default:
                                            CoresUtils.MostrarMensagem ("Digite um valor válido!", TipoMensagemEnum.ALERTA);
                                            System.Console.WriteLine ("Pressione ENTER para continuar");
                                            Console.ReadLine ();
                                            break;
                                    }
                                } while (!querSair);
                            } else {
                                Console.Clear ();
                                CoresUtils.MostrarMensagem ($"   Bem-Vindo {usuarioRecuperado.Nome}", TipoMensagemEnum.SUCESSO);
                                System.Console.WriteLine ("   Pressione ENTER para continuar");
                                Console.ReadLine ();
                                Console.Clear ();
                                do {
                                    MenuUtils.MenuADM ();
                                    codigo = Console.ReadLine ();
                                    switch (codigo) {
                                        case "1":
                                            UsuarioViewController.ExibirUsuarios ();
                                            break;
                                        case "2":
                                            UsuarioViewController.UsuariosWord ();
                                            CoresUtils.MostrarMensagem ("\nArquivo criado com sucesso!", TipoMensagemEnum.SUCESSO);
                                            System.Console.WriteLine ("Pressione ENTER para continuar");
                                            Console.ReadLine ();
                                            break;
                                        case "3":
                                            RepositorioUsuario.Zipar();
                                            CoresUtils.MostrarMensagem ("\nArquivo criado com sucesso!", TipoMensagemEnum.SUCESSO);
                                            System.Console.WriteLine ("Pressione ENTER para continuar");
                                            Console.ReadLine ();
                                            break;
                                        case "0":
                                            CoresUtils.MostrarMensagem ("Obrigado pela preferência", TipoMensagemEnum.SUCESSO);
                                            querSair = true;
                                            break;
                                        default:
                                            CoresUtils.MostrarMensagem ("Digite um valor válido!", TipoMensagemEnum.ALERTA);
                                            System.Console.WriteLine ("Pressione ENTER para continuar");
                                            Console.ReadLine ();
                                            break;
                                    }
                                } while (!querSair);
                            }
                        } else {
                            CoresUtils.MostrarMensagem ("Usuário ou senha inválidos", TipoMensagemEnum.ALERTA);
                            System.Console.WriteLine ("Pressione ENTER para continuar");
                            Console.ReadLine ();
                        }
                        break;
                    case "0":
                        CoresUtils.MostrarMensagem ("Obrigado pela preferência", TipoMensagemEnum.SUCESSO);
                        querSair = true;
                        break;
                    default:
                        CoresUtils.MostrarMensagem ("Digite um valor válido!", TipoMensagemEnum.ALERTA);
                        System.Console.WriteLine ("Pressione ENTER para continuar");
                        Console.ReadLine ();

                        break;
                }
            } while (!querSair);
        }
    }
}