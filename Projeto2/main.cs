using System;
class Program{
  public static void Main(){
    Console.WriteLine("Bem vindo ao Help.io");
    int op = 0;
    do {
      op = Menu();
      switch(op){
      case 1 : CadastroAcao(); break;
      case 2 : ListarAcoes(); break;
      }
    } while (op != 0);
    
  }
  public static int Menu(){
  Console.WriteLine();
  Console.WriteLine("---------- Escolha Uma opção! ----------");
  Console.WriteLine("01 - Cadastrar uma Ação");
  Console.WriteLine("02 - Listar Ações");
  Console.WriteLine("00 - Finalizar Programa");
  Console.WriteLine("----------------------------------------");
  Console.Write("Opção: ");
  int op = int.Parse(Console.ReadLine());
  Console.WriteLine();
  return op;
  }
  public static void CadastroAcao(){
    Console.WriteLine("---------- Inserir uma nova ação ----------");
    Console.Write("Informe o Id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Dê um nome para a ação: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o local onde a ação acontecerá:");
    string local = Console.ReadLine();
    Console.Write("Informe a data em que a ação acontecerá:");
    DateTime data = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
    Acao obj = new Acao(id,data,nome,local);
    Sistema.CadastroAcao(obj);
    Console.WriteLine("Ação inserida com sucesso");
  }
  public static void ListarAcoes(){
    
  }
}