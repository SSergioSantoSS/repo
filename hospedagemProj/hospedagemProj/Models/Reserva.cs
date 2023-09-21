
using System;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class CapacidadeExcedidaException : Exception
    {
        public CapacidadeExcedidaException(string message) : base(message)
        {
        }
    }

    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            try
            {
                // Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
                // *IMPLEMENTE AQUI*
                if (hospedes.Count <= Suite.Capacidade)
                {
                    Hospedes = hospedes;
                }
                else
                {
                    // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                    // *IMPLEMENTE AQUI*
                    throw new CapacidadeExcedidaException("A capacidade da suíte não é suficiente para a quantidade de hóspedes.");
                }
            }
            catch (CapacidadeExcedidaException ex)
            {
                // Captura a exceção personalizada e mostra uma mensagem ao usuário.
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // Aplica o desconto de 10%
            }

            return valor;
        }
    }
}