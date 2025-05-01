using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro: CuentaBancaria
    {
        public decimal TasaInteres { get; set; }

        public CajaDeAhorro(string numero, decimal saldo)
            : base(numero, saldo)
        { }

        protected override void RealizarDeposito(decimal monto)
        {
            Saldo += monto;
        }

        protected override void RealizarRetiro(decimal monto)
        {
            if (Saldo < monto)
            {
                Suspender();
                throw new SaldoInsuficienteException();
            }
            Saldo -= monto;
        }

        public void AplicarInteres()
        {
            if (Estado == Estado.Activa) Saldo += Saldo * TasaInteres;

        }
    }
    
}
