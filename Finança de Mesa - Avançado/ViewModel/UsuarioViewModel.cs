using System;

namespace Finança_de_Mesa.ViewModel
{
    public class UsuarioViewModel
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Email {get;set;}
        public string Senha {get; set;}
        public DateTime DataDeNascimento {get;set;}
        public float Saldo {get;set;}
        public string Tipo {get;set;}
    }
}