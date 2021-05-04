using System;
using Dio.Bank.Enum;

namespace Dio.Bank.Classes
{
  public class Conta
  {
    private TipoConta TipoConta { get; set; }
    private string Nome { get; set; }
    private double Saldo { get; set; }
    private double Credito { get; set; }
    public Conta(TipoConta TipoConta, string Nome, double Saldo,
     double Credito)
    {
      this.TipoConta = TipoConta;
      this.Nome = Nome;
      this.Saldo = Saldo;
      this.Credito = Credito;
    }
    public bool Sacar(double valorSaque)
    {
      if (this.Saldo - valorSaque < (this.Credito * -1))
      {
        Console.WriteLine("Saldo insuficiente!");
        return false;
      }
      this.Saldo -= valorSaque;
      Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome,
      this.Saldo);
      return true;
    }
    public void Depositar(double valorDeposito)
    {
      this.Saldo += valorDeposito;
      Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome,
            this.Saldo);
    }
    public void Transferir(double valorTransferencia, Conta contaDestino)
    {
      if (this.Sacar(valorTransferencia))
      {
        contaDestino.Depositar(valorTransferencia);
      }
    }
    public override string ToString()
    {
      string retorno = "";

      retorno += "[TipoConta: " + this.TipoConta + " | ";
      retorno += "Nome: " + this.Nome + " | ";
      retorno += "Saldo: " + this.Saldo + " | ";
      retorno += "Crédito: " + this.Credito + "]";

      return (retorno);
    }
  }
}