using System;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria
    {
        public int Numero;
        public string Titular;
        public double DepositoInicial;

        public ContaBancaria(int numero, string titular)
        {
            this.Numero = numero;
            this.Titular = titular;
        }

        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            this.Numero = numero;
            this.Titular = titular;
            this.DepositoInicial = depositoInicial;
        }

        public void Deposito(double quantia)
        {
            DepositoInicial += quantia;
        }

        public void Saque(double quantia)
        {
            DepositoInicial -= quantia;
        }
    }
}
