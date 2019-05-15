using System;
using System.Collections.Generic;
using Finança_de_Mesa.Repositorio;
using Finança_de_Mesa.Utils;
using Finança_de_Mesa.ViewModel;
using Spire.Doc;
using Spire.Doc.Documents;
using static Finança_de_Mesa.Enums.Cores;

namespace Finança_de_Mesa.ViewController {
    public class UsuarioViewController {
        static RepositorioUsuario repositorioUsuario = new RepositorioUsuario ();
        static UsuarioViewModel testador = new UsuarioViewModel ();
        public static void CadastrarUsuario () {

            string nome = "", email = "", senha = "", teste = "", testesenha = "";
            DateTime nascimento;
            int i = 0;
            DateTime maiorDeIdade = DateTime.Parse ("15/05/2001");
            int verificacao = 0;

            Console.Clear ();
            do {
                if (i > 0) {
                    verificacao = 0;
                    CoresUtils.MostrarMensagem ("Digite um nome diferente, já temos um usuário com este nome", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine ();
                    Console.Clear ();
                }
                System.Console.WriteLine ("Digite seu nome: ");
                nome = Console.ReadLine ();
                i++;
                UsuarioViewModel testador = repositorioUsuario.TestarNome (nome);
                if (testador != null) {
                    verificacao++;
                }
            } while (nome.Length < 4 || verificacao != 0);

            i = 0;

            Console.Clear ();
            do {
                if (i > 0) {
                    verificacao = 0;
                    CoresUtils.MostrarMensagem ("E-mail inválido ou já utilizado para cadastro", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine ();
                    Console.Clear ();
                }
                System.Console.WriteLine ("Digite seu e-mail:");
                email = Console.ReadLine ();
                i++;
                UsuarioViewModel testador = repositorioUsuario.TestarEmail (email);
                if (testador != null) {
                    verificacao++;
                }
            } while (!email.Contains ("@") && !email.Contains (".") || verificacao != 0);

            i = 0;

            Console.Clear ();
            do {
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Senha inválida ou não corresponderam", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine ();
                    Console.Clear ();
                }
                System.Console.WriteLine ("Digite sua senha: (min. 8)");
                senha = Console.ReadLine ();
                System.Console.WriteLine ("Digite sua senha novamente: (min. 8)");
                testesenha = Console.ReadLine ();
                i++;
            } while (senha.Length < 8 || senha != testesenha);

            i = 0;

            Console.Clear ();
            do {
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Digite uma data válida", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine ();
                    Console.Clear ();
                }
                System.Console.WriteLine ("Digite sua data de nascimento: (você precisa ser maior de idade)");
                teste = Console.ReadLine ();
                i++;
            } while (!DateTime.TryParse (teste, out nascimento) || nascimento > maiorDeIdade);

            UsuarioViewModel usuarioTeste = new UsuarioViewModel ();
            usuarioTeste.Nome = nome;
            usuarioTeste.Email = email;
            usuarioTeste.Senha = senha;
            usuarioTeste.DataDeNascimento = nascimento;

            RepositorioUsuario.Inserir (usuarioTeste);

            CoresUtils.MostrarMensagem ("Usuário cadastrado com sucesso!", TipoMensagemEnum.SUCESSO);
            System.Console.WriteLine ("Clique ENTER para continuar");
            Console.ReadLine ();
        }
        public static UsuarioViewModel LoginUsuario () {

            int i = 0;
            string email, senha;
            do {
                Console.Clear ();
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Digite um e-mail válido", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine ();
                    Console.Clear ();
                }
                System.Console.WriteLine ("Digite seu e-mail:");
                email = Console.ReadLine ();
                i++;
            } while (!email.Contains ("@") && !email.Contains ("."));

            i = 0;

            Console.Clear ();
            do {
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Digite uma senha válida", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine ();
                    Console.Clear ();
                }
                System.Console.WriteLine ("Digite sua senha: (min. 8)");
                senha = Console.ReadLine ();
                i++;
            } while (senha.Length < 8);

            UsuarioViewModel usuarioRecuperado = repositorioUsuario.BuscarUsuario (email, senha);

            return usuarioRecuperado;
        }
        public static void ExibirUsuarios () {
            List<UsuarioViewModel> usuarios = RepositorioUsuario.Listar ();

            foreach (var item in usuarios) {
                if (item != null) {
                    System.Console.WriteLine ($"----------------------------------------");
                    System.Console.WriteLine ($"Id do Usuário: {item.Id}");
                    System.Console.WriteLine ($"Nome: {item.Nome}");
                    System.Console.WriteLine ($"E-mail: {item.Email}");
                    System.Console.WriteLine ($"Senha: {item.Senha}");
                    System.Console.WriteLine ($"Data de nascimento: {item.DataDeNascimento}");
                    System.Console.WriteLine ($"Saldo: {item.Saldo}");
                    System.Console.WriteLine ($"Tipo de Usuário: {item.Tipo}");
                    System.Console.WriteLine ($"----------------------------------------");
                }
            }
            CoresUtils.MostrarMensagem ("Fim dos usuários", TipoMensagemEnum.ERRO);
            System.Console.WriteLine ("Clique ENTER para continuar");
            Console.ReadLine ();

        }
        public static void UsuariosWord () {
            List<UsuarioViewModel> usuarios = RepositorioUsuario.Listar ();
            Document doc = new Document ();
            Section section = doc.AddSection ();
            Paragraph Para = section.AddParagraph ();
            Para.AppendText ($"             LISTAGEM DOS USUÁRIOS CADASTRADOS NO BANCO: FINANÇA DE MESA\n\n\n");
            Para.AppendText ($"USUÁRIOS:\n\n");
            foreach (var item in usuarios) {
                if (item != null) {
                    Para.AppendText ($"---------------------------------------------------------------------------------------------------------------------------\n");
                    Para.AppendText ($"Nome:                                     {item.Nome}\n");
                    Para.AppendText ($"Id do Usuário:                         {item.Id}\n");
                    Para.AppendText ($"E-mail:                                    {item.Email}\n");
                    Para.AppendText ($"Senha:                                     {item.Senha}\n");
                    Para.AppendText ($"Data de Nascimento:              {item.DataDeNascimento}\n");
                    Para.AppendText ($"Saldo:                                      R$ {item.Saldo}\n");
                    Para.AppendText ($"Tipo de Usuário:                    {item.Tipo}\n");
                    Para.AppendText ($"---------------------------------------------------------------------------------------------------------------------------\n\n");
                }
            }
            doc.SaveToFile ("Usuários.docx", FileFormat.Docx);
        }
    }
}