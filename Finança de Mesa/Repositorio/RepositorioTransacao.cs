using System;
using System.Collections.Generic;
using System.IO;
using Finança_de_Mesa.ViewModel;

namespace Finança_de_Mesa.Repositorio
{
    public class RepositorioTransacao
    {
        public static void Inserir (TransacaoViewModel transacaoTeste) {
            StreamWriter sw = new StreamWriter ("transacaos.csv", true);

            transacaoTeste.DataTransacao = DateTime.Now;

            sw.WriteLine ($"\n{transacaoTeste.NomeUsuario};{transacaoTeste.Valor};{transacaoTeste.Tipo};{transacaoTeste.Descricao};{transacaoTeste.DataTransacao}");
            sw.Close ();
        }
        public static List<TransacaoViewModel> Listar () {
            List<TransacaoViewModel> transacaos = new List<TransacaoViewModel> ();
            TransacaoViewModel modeloTransacaos;
            if (!File.Exists ("transacaos.csv")) {
                return null;
            }
            string[] transacaosArray = File.ReadAllLines ("transacaos.csv");
            foreach (var item in transacaosArray) {
                if(item != null){
                string[] dadosDeCadaTransacao = item.Split (";");
                modeloTransacaos = new TransacaoViewModel ();
                modeloTransacaos.NomeUsuario = dadosDeCadaTransacao[0];
                modeloTransacaos.Valor = float.Parse(dadosDeCadaTransacao[1]);
                modeloTransacaos.Tipo = dadosDeCadaTransacao[2];
                modeloTransacaos.Descricao = dadosDeCadaTransacao[3];
                modeloTransacaos.DataTransacao = DateTime.Parse (dadosDeCadaTransacao[4]);
                transacaos.Add (modeloTransacaos);
                }
            }

            return transacaos;
        }

        public static List<TransacaoViewModel> BuscarTransacao () {
                List<TransacaoViewModel> transacoes = Listar ();
                if (transacoes != null) {
                    return transacoes;
                }
                else{
                    return null;
                }
                }
    }
}