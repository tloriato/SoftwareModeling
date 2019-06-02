using System;
namespace ModelagemSoftware.CasosdeUso
{
    public class EvaluateErrors
    {
        public EvaluateErrors(Storage storage, Worker worker)
        {
            Console.WriteLine();

            storage.PrintUnsolvedOrders();

            Console.WriteLine();

            Line("=======      Type ID Order to Explore    ========");
            Console.Write("== Order to Explore: ");

            int id = Convert.ToInt32(Console.ReadLine());

            Line();

            Console.WriteLine();

            storage.PrintUnsolvedInstructionsFromOrderId(id);

            Console.WriteLine();

            Line("=======      Type Resolution or null     ========");
            Console.Write("== Resoluton: ");

            string resolution = Console.ReadLine();

            if (resolution.ToLower().Equals("null"))
            {
                return;
            }

            else
            {
                Order order = storage.GetOrderById(id);
                order.resolution = resolution;
                order.Status = Status.StoredWithErrorsSolved;
            }
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
