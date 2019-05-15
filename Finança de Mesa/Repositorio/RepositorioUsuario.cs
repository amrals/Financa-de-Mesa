using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Finança_de_Mesa.ViewModel;
using Spire.Doc;
using Spire.Doc.Documents;

namespace Finança_de_Mesa.Repositorio {
    public class RepositorioUsuario {
        List<UsuarioViewModel> usuarios = new List<UsuarioViewModel> ();
        public static void Inserir (UsuarioViewModel usuarioTeste) {
            StreamWriter sw = new StreamWriter ("Iniciar/usuarios.csv", true);

            usuarioTeste.Tipo = "Comum";

            sw.WriteLine ($"{usuarioTeste.Nome};{usuarioTeste.Email};{usuarioTeste.Senha};{usuarioTeste.DataDeNascimento};{usuarioTeste.Saldo};{usuarioTeste.Tipo}");
            sw.Close ();
        }
        public List<UsuarioViewModel> Listar () {
            List<UsuarioViewModel> usuarios = new List<UsuarioViewModel> ();
            UsuarioViewModel modeloUsuarios;
            if (!File.Exists ("Iniciar/usuarios.csv")) {
                return null;
            }
            string[] usuariosArray = File.ReadAllLines ("Iniciar/usuarios.csv");
            foreach (var item in usuariosArray) {
                if (item != null) {
                    string[] dadosDeCadaUsuario = item.Split (";");
                    if (dadosDeCadaUsuario[0].Length > 1) {
                        modeloUsuarios = new UsuarioViewModel ();
                        modeloUsuarios.Nome = dadosDeCadaUsuario[0];
                        modeloUsuarios.Email = dadosDeCadaUsuario[1];
                        modeloUsuarios.Senha = dadosDeCadaUsuario[2];
                        modeloUsuarios.DataDeNascimento = DateTime.Parse (dadosDeCadaUsuario[3]);
                        modeloUsuarios.Saldo = float.Parse (dadosDeCadaUsuario[4]);
                        modeloUsuarios.Tipo = dadosDeCadaUsuario[5];
                        usuarios.Add (modeloUsuarios);
                    }
                }
            }

            return usuarios;
        }

        public UsuarioViewModel BuscarUsuario (string email, string senha) {
            List<UsuarioViewModel> usuarios = Listar ();
            foreach (var item in usuarios) {
                if (item.Email.Equals (email) && item.Senha.Equals (senha)) {
                    return item;
                }
            }
            return null;
        }
        public UsuarioViewModel Editar (UsuarioViewModel usuario) {
            string[] linhas = System.IO.File.ReadAllLines ("Iniciar/usuarios.csv");

            for (int i = 0; i < linhas.Length; i++) {
                if (string.IsNullOrEmpty (linhas[i])) {
                    continue;
                }

                string[] dados = linhas[i].Split (';');

                //Verifica se o id do formulário é igual ao da linha
                if (usuario.Nome.ToString () == dados[0]) {
                    //Altera os dados da linha
                    linhas[i] = $"{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.DataDeNascimento};{usuario.Saldo};{usuario.Tipo};";
                    break;
                }
            }

            //Altera o arquivo usuarios.csv
            System.IO.File.WriteAllLines ("Iniciar/usuarios.csv", linhas);

            return usuario;
        }
        public static void Zipar()
        {
            string startPath = @".\Iniciar";
            string zipPath = @".\Dados.zip";

            ZipFile.CreateFromDirectory (startPath, zipPath);
        }
    }
}