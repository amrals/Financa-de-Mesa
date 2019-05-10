using System;
using System.Collections.Generic;
using Finança_de_Mesa.Repositorio;
using Finança_de_Mesa.Utils;
using Finança_de_Mesa.ViewModel;
using static Finança_de_Mesa.Enums.Cores;

namespace Finança_de_Mesa.ViewController {
    public class TransacaoViewController {
        public static void CadastrarTransacao (string nome)
        {
            string tipo, descricao;
            float valor;
            int i = 0;

            Console.Clear ();
            do {
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Digite um tipo válido", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
                    System.Console.WriteLine ("Digite o tipo da transação (Despesa / Receita): ");
                    tipo = Console.ReadLine ();
                    i++;
            } while (!tipo.Contains("D") && !tipo.Contains("R"));

            i = 0;
            
            Console.Clear ();
            do {
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Digite um valor válido", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
                    System.Console.WriteLine ("Digite o valor da transação:");
                    valor = float.Parse(Console.ReadLine ());
                    i++;
            } while (valor <= 0);
            
            i = 0;
            
            Console.Clear ();
            
                    System.Console.WriteLine ("Descreva a transação");
                    descricao = Console.ReadLine ();
            
            Console.Clear ();

            TransacaoViewModel transacaoTeste = new TransacaoViewModel();
            transacaoTeste.Tipo = tipo ;
            transacaoTeste.Valor = valor;
            transacaoTeste.Descricao = descricao;
            transacaoTeste.NomeUsuario = nome;
            
            RepositorioTransacao.Inserir(transacaoTeste);
        }

        public static void ExibirTransacao (string nome) {
            List<TransacaoViewModel> transacoes = RepositorioTransacao.BuscarTransacao();
            
            foreach (var item in transacoes){
                if (item.NomeUsuario.Equals(nome))
                {
                    System.Console.WriteLine($"------------------------------");
                    System.Console.WriteLine($"Valor: {item.Valor}");
                    System.Console.WriteLine($"Tipo: {item.Tipo}");
                    System.Console.WriteLine($"Descrição: {item.Descricao}");
                    System.Console.WriteLine($"Data da Transação: {item.Tipo}");
                    System.Console.WriteLine($"------------------------------");
                }
            }
            System.Console.WriteLine("Fim das transações");
            System.Console.WriteLine("Clique ENTER para continuar");
            Console.ReadLine();
            
        }
    }
}