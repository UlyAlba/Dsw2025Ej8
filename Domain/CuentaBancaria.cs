namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; }
    

    protected CuentaBancaria(string numero, decimal saldo)
    {
        Numero = numero;            
        Saldo = saldo;
        Estado = Estado.Activa;
    }

    public void Depositar(decimal monto)
    {
        ValidarOperacion(monto);
        RealizarDeposito(monto);
    }

    public void Retirar(decimal monto)
    {
        ValidarOperacion(monto);
        RealizarRetiro(monto);
    }

    private void ValidarOperacion(decimal monto)
    {
        if (monto <= 0) throw new MontoNoValidoException();
        if (Estado != Estado.Activa) throw new CuentaNoActivaException(Estado);
    }

    protected abstract void RealizarDeposito(decimal monto);
    protected abstract void RealizarRetiro(decimal monto);

    protected void Suspender() => Estado = Estado.Suspendida;

    public override string ToString()
        => $"{{ Numero = {Numero}, Tipo = {GetType().Name}, Saldo = {Saldo:C} }}";
}

