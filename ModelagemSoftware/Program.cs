
using ModelagemSoftware.Casos_de_Uso;
using System;

namespace ModelagemSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SMS: Storage Management System");
            Console.WriteLine("1: Store Packages | 2: RgisterStorage | 3: EvaluateErrors | 4: Sair");

            System.ConsoleKeyInfo answer = Console.ReadKey();

            Storage storage; 
            Worker worker;

            if (answer.KeyChar != '4')
            {
                storage = new Storage(2, 2);
                worker = new Worker();
                // Populate Instances Here?
            }

            while (answer.KeyChar != '4')
            {
                if (answer.KeyChar == '1')
                {
                    StorePackage process = new StorePackage(storage, worker);
                }

                else
                {
                    Console.WriteLine("Não Implementado");
                }

            }
        }
    }
}
