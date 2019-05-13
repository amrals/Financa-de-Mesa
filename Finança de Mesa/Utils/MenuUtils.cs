using System;
using static Finança_de_Mesa.Enums.Cores;

namespace Finança_de_Mesa.Utils
{
    public class MenuUtils
    {
        public static void MenuDeslogado()
        {
            System.Console.WriteLine("||=================================||");
            System.Console.Write("||");
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("         Finança de Mesa         ");
            Console.ResetColor();
            System.Console.WriteLine("||");
            System.Console.WriteLine("||---------------------------------||");
            System.Console.WriteLine("|| 1 - Cadastrar Usuário           ||");
            System.Console.WriteLine("|| 2 - Efetuar Login               ||");
            System.Console.WriteLine("|| 0 - Sair                        ||");
            System.Console.WriteLine("||=================================||");
        }
        public static void MenuLogado()
        {
            System.Console.WriteLine("||=================================||");
            System.Console.Write("||");
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("    Finança de Mesa - Usuário    ");
            Console.ResetColor();
            System.Console.WriteLine("||");
            System.Console.WriteLine("||---------------------------------||");
            System.Console.WriteLine("|| 1 - Transações                  ||");
            System.Console.WriteLine("|| 2 - Visualizar Extrato no WORD  ||");
            System.Console.WriteLine("|| 3 - Visualizar Extrato no APP   ||");
            System.Console.WriteLine("|| 0 - Sair                        ||");
            System.Console.WriteLine("||=================================||");
        }
        public static void MenuADM()
        {
            System.Console.WriteLine("||=================================||");
            System.Console.Write("||");
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("      Finança de Mesa - ADM      ");
            Console.ResetColor();
            System.Console.WriteLine("||");
            System.Console.WriteLine("||---------------------------------||");
            System.Console.WriteLine("|| 1 - Listar Usuários no APP      ||");
            System.Console.WriteLine("|| 2 - Listar Usuários NO WORD     ||");
            System.Console.WriteLine("|| 3 - Exportar dados para ZIP     ||");
            System.Console.WriteLine("|| 0 - Sair                        ||");
            System.Console.WriteLine("||=================================||");
        }
    }
}