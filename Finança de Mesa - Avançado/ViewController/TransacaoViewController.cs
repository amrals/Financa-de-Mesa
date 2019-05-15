using System;
using System.Collections.Generic;
using Finança_de_Mesa.Repositorio;
using Finança_de_Mesa.Utils;
using Finança_de_Mesa.ViewModel;
using Spire.Doc;
using Spire.Doc.Documents;
using static Finança_de_Mesa.Enums.Cores;

namespace Finança_de_Mesa.ViewController {
    public class TransacaoViewController {
        public UsuarioViewModel CadastrarTransacao (UsuarioViewModel recuperado) {
            string tipo, descricao;
            float valor;
            int i = 0;
            string teste = "";

            Console.Clear ();
            do {
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Digite um tipo válido", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine ();
                    Console.Clear ();
                }
                System.Console.WriteLine ("Digite o tipo da transação (Despesa / Receita): ");
                tipo = Console.ReadLine ();
                i++;
            } while (!tipo.Contains ("D") && !tipo.Contains ("d") && !tipo.Contains ("R") && !tipo.Contains ("r"));

            i = 0;

            Console.Clear ();
            do {
                if (i > 0) {
                    CoresUtils.MostrarMensagem ("Digite um valor válido", TipoMensagemEnum.ERRO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine ();
                    Console.Clear ();
                }
                System.Console.WriteLine ("Digite o valor da transação:");
                teste = Console.ReadLine ();
                i++;
            } while (!float.TryParse (teste, out valor) && valor <= 0);

            if (tipo.Contains ("R") || tipo.Contains ("r")) {
                valor = valor * -1;
            }

            if (valor <= recuperado.Saldo) {

                if (tipo.Contains ("D") || tipo.Contains ("d")) {
                    recuperado.Saldo = recuperado.Saldo - valor;
                    tipo = "DESPESA";
                } else if (tipo.Contains ("R") || tipo.Contains ("r")) {
                    valor = valor * -1;
                    recuperado.Saldo = recuperado.Saldo + valor;
                    tipo = "RECEITA";
                }

                i = 0;

                Console.Clear ();

                System.Console.WriteLine ("Descreva a transação:");
                descricao = Console.ReadLine ();

                Console.Clear ();

                TransacaoViewModel transacaoTeste = new TransacaoViewModel ();
                transacaoTeste.Tipo = tipo;
                transacaoTeste.Valor = valor;
                transacaoTeste.Descricao = descricao;
                transacaoTeste.NomeUsuario = recuperado.Nome;
                transacaoTeste.IdUsuario = recuperado.Id;

                RepositorioTransacao.Inserir (transacaoTeste);

                CoresUtils.MostrarMensagem ("Transação concluída com sucesso!", TipoMensagemEnum.SUCESSO);
                System.Console.WriteLine ("Clique ENTER para continuar");
                Console.ReadLine ();

                return recuperado;
            } else {
                CoresUtils.MostrarMensagem ("\nNão há saldo suficiente para esta transação!!!", TipoMensagemEnum.ERRO);
                System.Console.WriteLine ("Pressione ENTER para continuar");
                Console.ReadLine ();
                Console.Clear ();
                return recuperado;
            }
        }

        public static void ExibirTransacao (int id) {
            List<TransacaoViewModel> transacoes = RepositorioTransacao.BuscarTransacao ();

            foreach (var item in transacoes) {
                if (item != null) {
                    if (item.IdUsuario.Equals (id)) {
                        System.Console.WriteLine ($"------------------------------");
                        System.Console.WriteLine ($"Valor: {item.Valor}");
                        System.Console.WriteLine ($"Tipo: {item.Tipo}");
                        System.Console.WriteLine ($"Descrição: {item.Descricao}");
                        System.Console.WriteLine ($"Data da Transação: {item.Tipo}");
                        System.Console.WriteLine ($"------------------------------");
                    }
                }
            }
            System.Console.WriteLine ("Fim das transações");
            System.Console.WriteLine ("Clique ENTER para continuar");
            Console.ReadLine ();

        }
        public static void TransacoesWord (string nome, int id, float saldo) {
            List<TransacaoViewModel> transacoes = RepositorioTransacao.Listar ();

            foreach (var iniciar in transacoes) {
                if (iniciar != null && iniciar.IdUsuario.Equals (id)) {

                    Document doc = new Document ();
                    Section section = doc.AddSection ();
                    Paragraph Para = section.AddParagraph ();
                    float inicio = saldo;
                    string nomeMaisculo = nome.ToUpper ();
                    Para.AppendText ($"                    LISTAGEM DAS TRANSAÇÕES DO USUÁRIO: {nomeMaisculo}\n\n\n");
                    Para.AppendText ($"TRANSAÇÕES:\n\n");

                    foreach (var item in transacoes) {
                        if (item != null && item.IdUsuario.Equals (id)) {
                            inicio += item.Valor;
                        }
                    }
                    foreach (var item in transacoes) {
                        if (item != null && item.IdUsuario.Equals (id)) {
                            Para.AppendText ($"---------------------------------------------------------------------------------------------------------------------------\n");
                            Para.AppendText ($"Valor:                                                                 R$ {item.Valor}\n");
                            Para.AppendText ($"Tipo:                                                                  {item.Tipo}\n");
                            Para.AppendText ($"Descrição:                                                          {item.Descricao}\n");
                            Para.AppendText ($"Data da Transação:                                            {item.DataTransacao}\n");
                            Para.AppendText ($"---------------------------------------------------------------------------------------------------------------------------\n");
                            Para.AppendText ($"\n                                                                                                             SALDO ATUAL: R$ {inicio -= item.Valor}\n\n");
                        }
                    }
                    Para.AppendText ($"                                                                                                             SALDO FINAL: R$ {saldo}");
                    doc.SaveToFile ("Transações.docx", FileFormat.Docx);
                    CoresUtils.MostrarMensagem ("\nArquivo criado com sucesso!", TipoMensagemEnum.SUCESSO);
                    System.Console.WriteLine ("Pressione ENTER para continuar");
                    Console.ReadLine();
                    
                } else {
                    CoresUtils.MostrarMensagem ("O arquivo não foi feito, já que não há transações em seu nome", TipoMensagemEnum.ALERTA);
                    System.Console.WriteLine ("Clique ENTER para continuar");
                    Console.ReadLine ();
                    break;
                }
            }
        }
    }
}