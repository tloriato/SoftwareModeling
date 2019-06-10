using ModelagemSoftware.CasosdeUso;
using ModelagemSoftware.Preenchimento;
using ModelagemSoftware.Utils;
using System;
using System.IO;
using System.Xml.Serialization;

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

                    //XmlSerializer SerializerObj = new XmlSerializer(typeof(Storage));
                    //TextWriter WriteFileStream = new StreamWriter(@"test.xml");
                    //SerializerObj.Serialize(WriteFileStream, storage);

                    //WriteFileStream.Close();

                    StorePackage process = new StorePackage(storage, worker);
                }

                else if (answer.KeyChar == '2')
                {
                    RegisterStorage process = new RegisterStorage(storage, worker);
                }

                else if (answer.KeyChar == '3')
                {
                    EvaluateErrors process = new EvaluateErrors(storage, worker);
                }

                else
                {
                    Console.WriteLine("Inválido");
                }

                Console.WriteLine();
                Console.WriteLine();
                WelcomeMessage();

                answer = Console.ReadKey();
            }
        }

        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to SMS: Storage Management System");
            Console.WriteLine("1: Store Packages | 2: RegisterStorage | 3: EvaluateErrors | 4: Sair");
        }
    }
}
