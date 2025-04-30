using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException()
            : base("El saldo de la cuenta es insuficiente para realizar la operación solicitada. Fue SUSPENDIDA")
        { }
    }
}
