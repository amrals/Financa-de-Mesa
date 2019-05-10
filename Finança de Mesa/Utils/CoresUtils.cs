using System;
using static Finança_de_Mesa.Enums.Cores;

namespace Finança_de_Mesa.Utils
{
    public class CoresUtils
    {
        public static void MostrarMensagem (string mensagem, TipoMensagemEnum tipoMensagem)
        {
            switch (tipoMensagem)
            {
                case TipoMensagemEnum.SUCESSO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case TipoMensagemEnum.ERRO:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case TipoMensagemEnum.ALERTA:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case TipoMensagemEnum.DESTAQUE:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                break;
            }
            System.Console.WriteLine(mensagem);
            Console.ResetColor();
        }
    }
}