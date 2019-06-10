using System;
namespace ModelagemSoftware.CasosdeUso
{
    public class RegisterStorage
    {
        public RegisterStorage(Storage storage, Worker worker)
        {
            Console.WriteLine();
            Line();
            storage.PrintStoringOrders();
            Line();
            Console.WriteLine();
            Line("======== Please insert Order Id ========");

            int orderId = Convert.ToInt32(Console.ReadLine());


            Order order = storage.GetOrderById(orderId);

            if (order == null || order.Status != Status.Storing)
            {
                Line("========== Order Id invalid! ==========");
                return;
            }

            bool hadErors = false;

            for(int i = 0; i < order.intructions.Length; i++)
            {
                Line("======== Showing Order Instructions ========");
                order.WriteInstructionsToConsole();

                Instruction instr = order.intructions[i];
                Line($"==== Status for Instr. {i} for Lot {instr.Lot.Id} of Order {order.Id} ====",
                      "== 1 - Successful | 2 - Custom Error | 3 - Space Occupied | 4 - Broken Item ==");

                int status = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (status == 1)
                {
                    bool stored = instr.Position.StoreItem(instr.Lot);
                    if (stored)
                    {
                        instr.Status = Status.Successful;
                    }
                    else
                    {
                        Line("===== THIS SHOULD NOT HAPPEN ========");
                        return;
                    }
                }

                else if (status == 2)
                {
                    Line("===== Insert Explanation for Error =====");
                    string justification = Console.ReadLine();
                    instr.Status = Status.Error;
                    instr.Justification = justification;

                    hadErors = true;
                }

                else if (status == 3)
                {
                    Line("===== Which item is being stored? =====");
                    string justification = Console.ReadLine();
                    instr.Status = Status.Error;
                    instr.Justification = "SYS: Another Item Reported as Stored";
                    hadErors = true;
                }

                else if (status == 4)
                {
                    Line("===== What happened? =====");
                    string justification = Console.ReadLine();
                    instr.Status = Status.Error;
                    instr.Justification = "SYS: Broken Item";
                    hadErors = true;
                }

                else
                {
                    Line("===== Status Inválido! ======");
                    i--;
                }
            }

            if (hadErors) order.Status = Status.StoredWithErrorsUnsolved;
            else order.Status = Status.Stored;

            Line("========== Order Updated! ==========");
        }

        private void Line(string line, string line2)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine(line);
            Console.WriteLine(line2);
            Console.WriteLine("=================================================");
        }

        private void Line(string line)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine(line);
            Console.WriteLine("=================================================");
        }

        private void Line()
        {
            Console.WriteLine("=================================================");
        }
    }
}