using System.Globalization;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> Veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            
            if(Veiculos.Contains(placa))
            {
                Console.WriteLine("Placa já cadastrada!");
            }
            else
            {
                Veiculos.Add(placa);
                Console.WriteLine("Placa cadastrada com sucesso!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (Veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;
                string valorTotalHoras = (precoPorHora * horas).ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"));
                string precoPorHoraFormatado = precoPorHora.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"));

                Veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} ficou estacionado por um total de {horas}h e foi removido do estacionamento.");
                Console.WriteLine("A soma dos valores:");
                Console.WriteLine($"Preço inicial - {precoInicial.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))};");
                Console.WriteLine($"Preço por hora - {valorTotalHoras} ({precoPorHoraFormatado} * {horas});");
                Console.WriteLine($"Gerou um total de: {valorTotal.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}.");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (Veiculos.Any())
            {
                Console.WriteLine($"No momento há {Veiculos.Count} veículos estacionados.");
                Console.WriteLine("A placa dos veículos estacionados são:");
                for (int i = 0; i < Veiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {Veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
