using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente: CuentaBancaria
    {
        public decimal comision { get; set; }

        public CuentaCorriente(int numero, decimal saldo)
            : base(numero, saldo)
        { }

        protected override void RealizarDeposito(decimal monto)
        {
            var neto = monto - monto * comision;
            saldo += neto;
        }

        protected override void RealizarRetiro(decimal monto)
        {
            if (saldo - monto < -limiteDeDescubierto)
            {
                Suspender();
                throw new SaldoInsuficienteException();
            }
            saldo -= monto;
        }
    }
    
}
