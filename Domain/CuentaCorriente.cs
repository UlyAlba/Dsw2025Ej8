using System;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente: CuentaBancaria
    {
        public decimal LimiteDescubierto { get; set; }
        public decimal Comision { get; set; }

        public CuentaCorriente(string numero, decimal saldo)
            : base(numero, saldo)
        { }

        protected override void RealizarDeposito(decimal monto)
        {
            var neto = monto - (monto * Comision);
            Saldo += neto;
        }

        protected override void RealizarRetiro(decimal monto)
        {
            if (Saldo - monto < -LimiteDescubierto)
            {
                Suspender();
                throw new SaldoInsuficienteException();
            }
            else
            {
                Saldo -= monto;
                if (Saldo < 0) Suspender();
            }
        }
    }
    
}
