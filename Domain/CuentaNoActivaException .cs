using System;


namespace Dsw2025Ej8.Domain
{
    public class CuentaNoActivaException : Exception
    {
        public CuentaNoActivaException(Estado estado)
            : base($"La cuenta no está activa.Estado: {estado}")
        { }
    }
}
