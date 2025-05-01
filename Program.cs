using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            var cuentaAhorro1 = new CajaDeAhorro("CA001", 1000m) { TasaInteres = 0.05m };
            var cuentaAhorro2 = new CajaDeAhorro("CA002", 5000m) { TasaInteres = 0.03m };
            var cuentaCorriente1 = new CuentaCorriente("CC001", 2000m) { LimiteDescubierto = 1000m, Comision = 0.02m };
            var cuentaCorriente2 = new CuentaCorriente("CC002", 3000m) { LimiteDescubierto = 2000m, Comision = 0.01m };

            RealizarOperaciones(cuentaAhorro1);
            RealizarOperaciones(cuentaAhorro2);
            RealizarOperaciones(cuentaCorriente1);
            RealizarOperaciones(cuentaCorriente2);

            var resumenes = new[]
            {
                new { cuentaAhorro1.Numero, Tipo = cuentaAhorro1.GetType().Name, cuentaAhorro1.Saldo, cuentaAhorro1.Estado },
                new { cuentaAhorro2.Numero, Tipo = cuentaAhorro2.GetType().Name, cuentaAhorro2.Saldo, cuentaAhorro2.Estado },
                new { cuentaCorriente1.Numero, Tipo = cuentaCorriente1.GetType().Name, cuentaCorriente1.Saldo, cuentaCorriente1.Estado },
                new { cuentaCorriente2.Numero, Tipo = cuentaCorriente2.GetType().Name, cuentaCorriente2.Saldo, cuentaCorriente2.Estado }
            };

            Console.WriteLine("Resumen de Cuentas:");
            foreach (var res in resumenes)
            {
                Console.WriteLine($"- {res.Numero} ({res.Tipo}): Saldo {res.Saldo:C}");
            }

            static void RealizarOperaciones(CuentaBancaria cuenta)
            {
                try
                {
                    cuenta.Depositar(500);
                    cuenta.Retirar(200);

                    if (cuenta is CajaDeAhorro caja) caja.AplicarInteres();

                    cuenta.Retirar(-100);
                }
                catch (Exception e)
                {
                    Console.WriteLine("$Error: " + e.Message);
                }
            }
        }

    }
}
