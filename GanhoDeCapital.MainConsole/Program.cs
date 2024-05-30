using GanhoDeCapital.Application.Services;
using GanhoDeCapital.Domain.Entities;
using GanhoDeCapital.Domain.Rules;
using Newtonsoft.Json;

namespace GanhoDeCapital.MainConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var taxCalculator = new TaxCalculator();
            var taxCalculatorService = new TaxCalculatorService(taxCalculator);

            bool running = true;
            while (running)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Iniciar operações");
                Console.WriteLine("2. Sair");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ProcessOperations(taxCalculatorService);
                        break;
                    case "2":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private static void ProcessOperations(TaxCalculatorService taxCalculatorService)
        {
            string line;
            var operations = new List<string>();

            Console.WriteLine("Digite as operações (pressione Enter para finalizar):");

            while ((line = Console.ReadLine()) != "")
                operations.Add(line);

            var taxes = new List<string>();

            foreach (string operation in operations)
                taxes.Add(taxCalculatorService.CalculateTaxes(JsonConvert.DeserializeObject<List<OperationEntity>>(operation)));

            foreach (var tax in taxes)
                Console.WriteLine(tax);

            Console.WriteLine();
        }
    }
}
