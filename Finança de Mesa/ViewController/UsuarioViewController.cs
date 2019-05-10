using System;
using Finança_de_Mesa.Repositorio;
using Finança_de_Mesa.Utils;
using Finança_de_Mesa.ViewModel;
using static Finança_de_Mesa.Enums.Cores;

namespace Finança_de_Mesa.ViewController {
    public class UsuarioViewController {
        static RepositorioUsuario repositorioUsuario = new RepositorioUsuario();
        public static void CadastrarUsuario () {

            string nome = "", email = "", senha = "", teste = "";
            DateTime nascimento;            
            int i = 0;

            Console.Clear ();
            do {
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Digite um nome válido", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
                    System.Console.WriteLine ("Digite seu nome: ");
                    nome = Console.ReadLine ();
                    i++;
            } while (nome.Length < 4);

            i = 0;
            
            Console.Clear ();
            do {
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Digite um e-mail válido", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
                    System.Console.WriteLine ("Digite seu e-mail:");
                    email = Console.ReadLine ();
                    i++;
            } while (!email.Contains("@") && !email.Contains("."));
            
            i = 0;
            
            Console.Clear ();
            do {
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Digite uma senha válida", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
                    System.Console.WriteLine ("Digite sua senha: (min. 8)");
                    senha = Console.ReadLine ();
                    i++;
            } while (senha.Length < 8);
            
            i = 0;
            
            Console.Clear ();
            do {
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Digite uma data válida", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
                    System.Console.WriteLine ("Digite sua data de nascimento:");
                    teste = Console.ReadLine ();
                    i++;
            } while (!DateTime.TryParse(teste, out nascimento));

            UsuarioViewModel usuarioTeste = new UsuarioViewModel();
            usuarioTeste.Nome = nome ;
            usuarioTeste.Email = email;
            usuarioTeste.Senha = senha;
            usuarioTeste.DataDeNascimento = nascimento;
            
            RepositorioUsuario.Inserir(usuarioTeste);
        }
        public static UsuarioViewModel LoginUsuario () {
            
            int i = 0;
            string email,senha;
            do {
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Digite um e-mail válido", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
                    System.Console.WriteLine ("Digite seu e-mail:");
                    email = Console.ReadLine ();
                    i++;
            } while (!email.Contains("@") && !email.Contains("."));
            
            i = 0;
            
            Console.Clear ();
            do {
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Digite uma senha válida", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
                    System.Console.WriteLine ("Digite sua senha: (min. 8)");
                    senha = Console.ReadLine ();
                    i++;
            } while (senha.Length < 8);

            UsuarioViewModel usuarioRecuperado = repositorioUsuario.BuscarUsuario(email, senha);

            return usuarioRecuperado;
        }
    }
}