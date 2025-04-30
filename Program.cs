using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            var cuentas = new List<CuentaBancaria>
            {
                new CajaDeAhorro(1290123, 1000m) { tasaDeInteres = 0.01m },
                new CajaDeAhorro(1179876,  500m) { tasaDeInteres = 0.015m },
                new CuentaCorriente(4155768, 200m) { limiteDeDescubierto = 300m, comision = 0.02m },
                new CuentaCorriente(6117247,   0m) { limiteDeDescubierto = 500m, comision = 0.015m }
            };

            // Pruebas de operaciones
            Ejecutar(cuentas[0], c => c.Depositar(200m));
            Ejecutar(cuentas[1], c => c.Retirar(600m));
            Ejecutar(cuentas[2], c => c.Retirar(400m));
            Ejecutar(cuentas[3], c => c.Depositar(-50m));


            // Aplicar interés en cuentas de ahorro
            foreach (var c in cuentas)
            {
                c.AplicarInteres();
            }

            // Mostrar resumen
            Console.WriteLine("\n--- Resumen de Cuentas ---");
            foreach (var c in cuentas)
            {
                Console.WriteLine($"Número: {c.numero}, Tipo: {c.GetType().Name}, Saldo: {c.saldo:C}");
            }
            Console.ReadKey();
        }

        static void Ejecutar(CuentaBancaria cuenta, Action<CuentaBancaria> accion)
        {
            try
            {
                accion(cuenta);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cuenta {cuenta.numero}: {ex.Message}");
            }
        }
    }
    
}
