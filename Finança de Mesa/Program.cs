using System;
using Finança_de_Mesa.Utils;

namespace Finança_de_Mesa {
    class Program {
        static void Main (string[] args) {
            bool querSair = false;
            do {
                MenuUtils.MenuDeslogado ();
                string codigo = Console.ReadLine ();
                switch (codigo) {
                    case "1":
                        break;
                    case "2":
                        if () {
                            do {
                                MenuUtils.MenuLogado ();
                                codigo = Console.ReadLine ();
                                switch (codigo) {
                                    case "1":
                                        break;
                                    case "2":
                                        break;
                                    case "3":
                                        break;
                                    case "0":
                                        System.Console.WriteLine ("Obrigado pela preferência");
                                        querSair = true;
                                        break;
                                    default:
                                        System.Console.WriteLine ("Digite um valor válido!");
                                        System.Console.WriteLine ("Pressione ENTER para continuar");
                                        Console.ReadLine ();
                                        break;
                                }
                            } while (!querSair);
                        } else {
                            do {
                                MenuUtils.MenuADM ();
                                codigo = Console.ReadLine ();
                                switch (codigo) {
                                    case "1":
                                        break;
                                    case "2":
                                        break;
                                    case "0":
                                        System.Console.WriteLine ("Obrigado pela preferência");
                                        querSair = true;
                                        break;
                                    default:
                                        System.Console.WriteLine ("Digite um valor válido!");
                                        System.Console.WriteLine ("Pressione ENTER para continuar");
                                        Console.ReadLine ();
                                        break;
                                }
                            } while (!querSair);
                        }
                        break;
                    case "0":
                        System.Console.WriteLine ("Obrigado pela preferência");
                        querSair = true;
                        break;
                    default:
                        System.Console.WriteLine ("Digite um valor válido!");
                        System.Console.WriteLine ("Pressione ENTER para continuar");
                        Console.ReadLine ();

                        break;
                }
            } while (!querSair);
        }
    }
}