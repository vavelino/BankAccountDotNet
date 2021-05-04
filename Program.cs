using System;
using System.Collections.Generic;
using Dio.Bank.Classes;
using Dio.Bank.Enum;

namespace DiO.Bank
{
  class Program
  {
    static List<Conta> listaContas = new List<Conta>();
    static void Main(string[] args)
    {
      string opcaoUsuario;
      Console.WriteLine("Inicio Tesla's Bank ");

      opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListaContas();
            break;
          case "2":
            InserirConta();
            break;
          case "3":
            Trasnferir();
            break;
          case "4":
            Sacar();
            break;
          case "5":
            Depositar();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            //throw new ArgumentOutOfRangeException();
            Console.WriteLine("Comando Inválido");
            break;
        }
        opcaoUsuario = ObterOpcaoUsuario();
      }

      Console.WriteLine("Obrigado por utilizar nossos Serviços.");
      //Conta contaVitor = new Conta(TipoConta.PessoaFisica, "Vitor", 0, 0);
      Console.WriteLine("Fim Programa");
      Console.ReadLine();

    }

    private static void Depositar()
    {
      try
      {
        Console.WriteLine("Digite o número da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        if ((indiceConta < 0) || (indiceConta > (listaContas.Count - 1)))
        {
          Console.WriteLine("Erro Durante Deposito");
          return;

        }
        Console.WriteLine("Digite o Valor a ser Depositado: ");
        double valorDeposito = double.Parse(Console.ReadLine());
        listaContas[indiceConta].Depositar(valorDeposito);
      }
      catch
      {
        Console.WriteLine("Erro Durante Deposito");
      }
    }

    private static void Trasnferir()
    {
      try
      {
        Console.WriteLine("Digite o Número da Conta de Origem: ");
        int indiceContaOrigem = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o Número da Conta de Destino: ");
        int indiceContaDestino = int.Parse(Console.ReadLine());

        if ((indiceContaOrigem < 0) || (indiceContaOrigem > (listaContas.Count - 1)))
        {
          Console.WriteLine("Erro Durante Transferencia");
          return;
        }
        if ((indiceContaDestino < 0) || (indiceContaDestino > (listaContas.Count - 1)))
        {
          Console.WriteLine("Erro Durante Transferencia");
          return;
        }
        Console.WriteLine("Digite o Valor a ser Trasferido");
        double valorTrasferencia = double.Parse(Console.ReadLine());
        listaContas[indiceContaOrigem].Transferir(valorTrasferencia,
        listaContas[indiceContaDestino]);
      }
      catch
      {
        Console.WriteLine("Erro Durante Transferencia");
      }
    }

    private static void Sacar()
    {
      try
      {
        Console.WriteLine("Digite o número da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        if ((indiceConta < 0) || (indiceConta > (listaContas.Count - 1)))
        {
          Console.WriteLine("Erro Durante Saque");
          return;

        }
        Console.WriteLine("Digite o Valor a ser Sacado: ");
        double valorSaque = double.Parse(Console.ReadLine());
        listaContas[indiceConta].Sacar(valorSaque);
      }
      catch
      {
        Console.WriteLine("Erro Durante Saque");
      }
    }

    private static void ListaContas()
    {

      Console.WriteLine("Contas cadastradas: ");
      if (listaContas.Count == 0)
      {
        Console.WriteLine("Nenhuma Conta Cadastrada");
        return;
      }
      for (int i = 0; i < listaContas.Count; i++)
      {
        Conta conta = listaContas[i];
        Console.Write("#{0} - ", i);
        Console.WriteLine(conta);
      }
    }

    private static void InserirConta()
    {
      try
      {
        Console.WriteLine("Inserir nova conta");
        Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Juridica: ");
        int entradaTipoConta = int.Parse(Console.ReadLine());
        if ((entradaTipoConta > 2) || (entradaTipoConta < 1))
        {
          Console.WriteLine("Erro nos Valores");
          return;
        }
        Console.WriteLine("Digite o Nome do Cliente: ");
        string entradaNome = Console.ReadLine();
        Console.WriteLine("Digite o Saldo Inicial: ");
        double entradaSaldo = double.Parse(Console.ReadLine());
        Console.WriteLine("Digite o Crédito: ");
        double entradaCredito = double.Parse(Console.ReadLine());

        Conta novaconta = new Conta((TipoConta)entradaTipoConta, entradaNome,
        entradaSaldo, entradaCredito);
        Console.WriteLine(novaconta);
        listaContas.Add(novaconta);
      }
      catch
      {
        Console.WriteLine("Erro Durante a Criacao de usuário");
      }
    }

    private static string ObterOpcaoUsuario()
    {
      string opcaoUsuario;

      Console.WriteLine("\nInforme a opção Desejada:");
      Console.WriteLine("1 - Listar Contas");
      Console.WriteLine("2 - Inserir nova Conta");
      Console.WriteLine("3 - Trasferir");
      Console.WriteLine("4 - Sacar");
      Console.WriteLine("5 - Depositar");
      Console.WriteLine("C - Limpar Tela");
      Console.WriteLine("X - Sair\n");

      opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine("opção Escolhida: {0}", opcaoUsuario);
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
