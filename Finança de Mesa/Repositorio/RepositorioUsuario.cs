using System;
using System.Collections.Generic;
using System.IO;
using Finança_de_Mesa.ViewModel;

namespace Finança_de_Mesa.Repositorio {
    public class RepositorioUsuario {
        List<UsuarioViewModel> usuarios = new List<UsuarioViewModel> ();
        public static void Inserir (UsuarioViewModel usuarioTeste) {
            StreamWriter sw = new StreamWriter ("usuarios.csv", true);

            usuarioTeste.Tipo = "Comum";

            sw.WriteLine ($"\n{usuarioTeste.Nome};{usuarioTeste.Email};{usuarioTeste.Senha};{usuarioTeste.DataDeNascimento};{usuarioTeste.Saldo};{usuarioTeste.Tipo}");
            sw.Close ();
        }
        public List<UsuarioViewModel> Listar () {
            List<UsuarioViewModel> usuarios = new List<UsuarioViewModel> ();
            UsuarioViewModel modeloUsuarios;
            if (!File.Exists ("usuarios.csv")) {
                return null;
            }
            string[] usuariosArray = File.ReadAllLines ("usuarios.csv");
            foreach (var item in usuariosArray) {
                if(item != null){
                string[] dadosDeCadaUsuario = item.Split (";");
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

            return usuarios;
        }

        public UsuarioViewModel BuscarUsuario (string email, string senha) {
            List<UsuarioViewModel> usuarios = Listar ();
            foreach (var item in usuarios){
                if (item.Email.Equals(email) && item.Senha.Equals(senha)){
                    return item;
                }
            }
            return null;
        }
    }
}