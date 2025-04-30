using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro: CuentaBancaria
    {
        public CajaDeAhorro(int numero, decimal saldo)
            : base(numero, saldo)
        { }

        protected override void RealizarDeposito(decimal monto)
        {
            saldo += monto;
        }

        protected override void RealizarRetiro(decimal monto)
        {
            if (saldo < monto)
            {
                Suspender();
                throw new SaldoInsuficienteException();
            }
            saldo -= monto;
        }
    }
    
}
