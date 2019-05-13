using System;
using System.Collections.Generic;
using System.IO;
using Finança_de_Mesa.ViewModel;
using Spire.Doc;
using Spire.Doc.Documents;

namespace Finança_de_Mesa.Repositorio {
    public class RepositorioTransacao {
        public static void Inserir (TransacaoViewModel transacaoTeste) {
            StreamWriter sw = new StreamWriter ("Iniciar/transacoes.csv", true);

            transacaoTeste.DataTransacao = DateTime.Now;

            sw.Write ($"{transacaoTeste.NomeUsuario};{transacaoTeste.Valor};{transacaoTeste.Tipo};{transacaoTeste.Descricao};{transacaoTeste.DataTransacao}\n");
            sw.Close ();
        }
        public static List<TransacaoViewModel> Listar () {
            List<TransacaoViewModel> transacaos = new List<TransacaoViewModel> ();
            TransacaoViewModel modeloTransacaos;
            if (!File.Exists ("Iniciar/transacoes.csv")) {
                return null;
            }
            string[] transacaosArray = File.ReadAllLines ("Iniciar/transacoes.csv");
            foreach (var item in transacaosArray) {
                if (item != null) {
                    string[] dadosDeCadaTransacao = item.Split (";");
                    if (dadosDeCadaTransacao[0].Length > 1) {
                        modeloTransacaos = new TransacaoViewModel ();
                        modeloTransacaos.NomeUsuario = dadosDeCadaTransacao[0];
                        modeloTransacaos.Valor = float.Parse (dadosDeCadaTransacao[1]);
                        modeloTransacaos.Tipo = dadosDeCadaTransacao[2];
                        modeloTransacaos.Descricao = dadosDeCadaTransacao[3];
                        modeloTransacaos.DataTransacao = DateTime.Parse (dadosDeCadaTransacao[4]);
                        transacaos.Add (modeloTransacaos);
                    }
                }
            }

            return transacaos;
        }

        public static List<TransacaoViewModel> BuscarTransacao () {
            List<TransacaoViewModel> transacoes = Listar ();
            if (transacoes != null) {
                return transacoes;
            } else {
                return null;
            }
        }
    }
}