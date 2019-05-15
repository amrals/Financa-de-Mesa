using System;

namespace Finança_de_Mesa.ViewModel
{
    public class TransacaoViewModel
    {
        public int IdUsuario {get;set;}
        public string NomeUsuario {get;set;}
        public float Valor {get;set;}
        public string Tipo {get;set;}
        public string Descricao {get;set;}
        public DateTime DataTransacao {get;set;}
    }
}