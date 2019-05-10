using System;
using Finança_de_Mesa.Utils;
using Finança_de_Mesa.ViewController;
using Finança_de_Mesa.ViewModel;
using static Finança_de_Mesa.Enums.Cores;

namespace Finança_de_Mesa {
    class Program {
        static void Main (string[] args) {
            bool querSair = false;
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
                        if (usuarioRecuperado.Tipo.Equals ("Comum")) {
                            do {
                                MenuUtils.MenuLogado ();
                                codigo = Console.ReadLine ();
                                switch (codigo) {
                                    case "1":
                                        TransacaoViewController.CadastrarTransacao (usuarioRecuperado.Nome);
                                        break;
                                    case "2":
                                        break;
                                    case "3":
                                        TransacaoViewController.ExibirTransacao (usuarioRecuperado.Nome);
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
                            do {
                                Console.Clear ();
                                CoresUtils.MostrarMensagem ($"   Bem-Vindo {usuarioRecuperado.Nome}", TipoMensagemEnum.SUCESSO);
                                Console.ReadLine ();

                                MenuUtils.MenuADM ();
                                codigo = Console.ReadLine ();
                                switch (codigo) {
                                    case "1":
                                        break;
                                    case "2":
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