
using ModelagemSoftware.Casos_de_Uso;
using ModelagemSoftware.Preenchimento;
using System;

namespace ModelagemSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();

            System.ConsoleKeyInfo answer = Console.ReadKey();
            Console.WriteLine();

            Storage storage = new Storage(2, 2);
            Worker worker = new Worker("Tiago");
            Populator populator = new Populator();

            while (answer.KeyChar != '4')
            {
                if (answer.KeyChar == '1')
                {
                    populator.InsertPendingItems(storage);
                    StorePackage process = new StorePackage(storage, worker);
                    Console.Clear();
                    WelcomeMessage();

                }

                else
                {
                    Console.WriteLine("Não Implementado");
                }

                answer = Console.ReadKey();
            }
        }

        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to SMS: Storage Management System");
            Console.WriteLine("1: Store Packages | 2: RgisterStorage | 3: EvaluateErrors | 4: Sair");
        }
    }
}
