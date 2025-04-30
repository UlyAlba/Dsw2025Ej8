using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaNoActivaException : Exception
    {
        public CuentaNoActivaException(Estado estado)
            : base($"La cuenta no está activa.Estado: {estado}")
        { }
    }
}
