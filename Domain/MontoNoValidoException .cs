using System;


namespace Dsw2025Ej8.Domain
{
    public class MontoNoValidoException : Exception
    {
        public MontoNoValidoException()
           : base("El monto ingresado no es válido para la operación solicitada")
        { }
    }
}
