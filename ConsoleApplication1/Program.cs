using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {

            Mercadorias estoque = new Mercadorias();

            int opcao = 0;

            while (opcao == 0)
            {

                iniciodoconsole:
                Console.Clear();
                Console.WriteLine("*******| Cadastro de Mercadoria |********");
                Console.WriteLine();
                Console.Write("Digite o nome da mercadoria: ");
                string mercadoria = Console.ReadLine();
                Console.Write("Digite o valor da Mercadoria: ");
                double valor = double.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("-------------------------Dados inseridos---------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Mercadoria: {0}", mercadoria);
                Console.WriteLine("Valor: {0:R}", valor);

                Console.WriteLine();
                Console.WriteLine("Confirma os dados? (s ou n)");
                string confirma = Console.ReadLine();
                if (confirma == "s")
                {
                    estoque.CadastrarMercadoria(mercadoria, valor);

                    Console.WriteLine("Mercadoria cadastrada!");
                    Console.WriteLine("Aperte 1 para cadastrar nova mercadoria ou pressione qualquer tecla para Estoque");
                    string pressione = Console.ReadLine();
                    if (pressione == "1")
                    {
                        goto iniciodoconsole;
                    }
                    else
                    {
                        Console.WriteLine("*******| Estoque |********");
                        Console.WriteLine();
                        Console.WriteLine("Quantdade de Mercadorias: {0}", estoque.quantidadeTotalMercadorias());
                        Console.WriteLine("Valor total: {0:R}", estoque.ValorTotalMercadorias());
                        Console.WriteLine("Valor médio: {0:R}", estoque.valorMedioMercadoria());
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Tente novamente!");

                    Console.ReadKey();
                    Console.Clear();
                }

                goto iniciodoconsole;

            }
        }

    }

    public class Mercadorias
    {
        public List<Mercadorias> lista = new List<Mercadorias>();
        public string nomeMercadoria { get; set; }
        public double valorMercadoria { get; set; }
        public List<Mercadorias> CadastrarMercadoria(string nome, double valor)
        {
            lista.Add(new Mercadorias() { nomeMercadoria = nome, valorMercadoria = valor });
            return lista;
        }
        public double ValorTotalMercadorias()
        {
            double totalValor = lista.Sum(item => item.valorMercadoria);
            return totalValor;
        }
        public int quantidadeTotalMercadorias()
        {
            int totalQuantidade = lista.Count();
            return totalQuantidade;
        }
        public double valorMedioMercadoria()
        {
            int totalQuantidade = lista.Count();
            double totalValor = lista.Sum(item => item.valorMercadoria);
            return totalValor / (double)totalQuantidade;
        }
    }
}

