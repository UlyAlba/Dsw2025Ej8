namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public int numero { get; }
    public decimal saldo { get; protected set; }
    public Estado estado { get; private set; }
    public decimal tasaDeInteres { get; set; }
    public decimal limiteDeDescubierto { get; set; }

    protected CuentaBancaria(int numero, decimal saldo)
    {
        this.numero = numero;
        this.saldo = saldo;
        this.estado = Estado.Activa;
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

    public void AplicarInteres()
    {
        if (this is CajaDeAhorro)
            saldo += saldo * tasaDeInteres;
    }

    private void ValidarOperacion(decimal monto)
    {
        if (monto <= 0) throw new MontoNoValidoException();
        if (estado != Estado.Activa) throw new CuentaNoActivaException(estado);
    }

    protected abstract void RealizarDeposito(decimal monto);
    protected abstract void RealizarRetiro(decimal monto);

    protected void Suspender() => estado = Estado.Suspendida;

    public override string ToString()
        => $"{{ Numero = {numero}, Tipo = {GetType().Name}, Saldo = {saldo:C} }}";
}

