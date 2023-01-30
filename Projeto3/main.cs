using System;
using System.Globalization;
class Program{
  public static void Main(){
    Console.WriteLine("Bem vindo ao Help.io");
    int op = 0;
    do {
      try{
        op = Menu();
        switch(op){
        case 1 : CadastroAcao(); break;
        case 2 : ListarAcoes(); break;
        case 3 : AtualizarAcao(); break;
        case 4 : ExcluirAcao(); break;
        case 5 : CadastroVoluntario(); break;
        case 6 : ListarVoluntario(); break;
        case 7 : AtualizarVoluntario(); break;
        case 8 : ExcluirVoluntario(); break;
       
        }
      }
      catch (Exception erro){
        op = -1;
        Console.WriteLine("Erro: " + erro.Message);
      }
    } while (op != 0);
    
  }
  public static int Menu(){
  Console.WriteLine();
  Console.WriteLine("---------- Escolha Uma opção! ----------");
  Console.WriteLine("01 - Cadastrar uma Ação");
  Console.WriteLine("02 - Listar Ações");
  Console.WriteLine("03 - Atualizar uma Ação");
  Console.WriteLine("04 - Excluir uma Ação");
  Console.WriteLine("05 - Cadastrar um voluntário");
  Console.WriteLine("06 - Listar voluntários");
  Console.WriteLine("07 - Atualizar um voluntario");
  Console.WriteLine("08 - Excluir um voluntário"); 
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
    Console.Write("Informe o seu id de Voluntario: ");
    int idVoluntario = int.Parse(Console.ReadLine());
    Acao obj = new Acao(id,data,nome,local,idVoluntario);
    Sistema.CadastroAcao(obj);
    Console.WriteLine("--------Ação inserida com sucesso---------");
  }
  public static void ListarAcoes(){
    Console.WriteLine("--------Listar as ações cadastradas---------");
    foreach (Acao obj in Sistema.ListarAcoes())
      Console.WriteLine(obj);
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------");
  }

   public static void AtualizarAcao(){
    Console.WriteLine("---------- Atualizar uma ação ----------");
    Console.Write("Informe o Id da ação a ser atualizada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe um novo nome para a ação: ");
    string nome = Console.ReadLine();
    Console.Write("Informe um novo local onde a ação acontecerá:");
    string local = Console.ReadLine();
    Console.Write("Informe a nova data em que a ação acontecerá:");
    DateTime data = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
    Console.Write("Informe o novo id de voluntario do dono da ação:");
    int idVoluntario = int.Parse(Console.ReadLine());
    Acao obj = new Acao(id,data,nome,local,idVoluntario);
    Sistema.AcaoAtualizar(obj);
    Console.WriteLine("");
    Console.WriteLine("------Ação Atualizada com sucesso--------");
   }
  public static void ExcluirAcao(){
    Console.WriteLine("---------- Excluir uma ação ----------");
    Console.Write("Informe o Id da ação a ser Excluida: ");
    int id = int.Parse(Console.ReadLine());
    
    DateTime data = DateTime.Now;
    Acao obj = new Acao(id);
    Sistema.AcaoExcluir(obj);
    Console.WriteLine("");
    Console.WriteLine("------Ação excluida com sucesso--------");
   }
  // Menu do voluntário
  public static void CadastroVoluntario(){
    Console.WriteLine("---------- Cadastrar um Voluntário ----------");
    Console.Write("Informe o Id: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o Id do usuario: ");
    int idUsuario = int.Parse(Console.ReadLine());
    Console.Write("Informe um nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe seu endereço:");
    string ender = Console.ReadLine();
    Console.Write("Informe sua idade:");
    int idade = int.Parse(Console.ReadLine());
    Console.Write("Informe seus seus interesses: Escola : 1 - Hospital : 2 - Asilo : 3 -  Serviço_comunitario - 4");
    int aux = int.Parse(Console.ReadLine()); // Variavel auxiliar para selecionar os interesses
    Interesses interesses = (Interesses) aux;
    Voluntario obj = new Voluntario(id,idUsuario,idade,nome,ender,interesses );
    Sistema.CadastroVoluntario(obj);
    Console.WriteLine("--------Voluntario Cadastrado com sucesso---------");
  }
  public static void ListarVoluntario(){
    Console.WriteLine("--------Listar voluntarios cadastrados---------");
    foreach (Voluntario obj in Sistema.ListarVoluntario())
      Console.WriteLine(obj);
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------");
  }
  public static void AtualizarVoluntario(){
    Console.WriteLine("---------- Atualizar um perfil de Voluntário ----------");
    Console.Write("Informe o Id do voluntário: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o Id de usuário do voluntário: ");
    int idUsuario = int.Parse(Console.ReadLine());
    Console.Write("Informe um novo nome para o voluntário: ");
    string nome = Console.ReadLine();
    Console.Write("Informe um novo endereço do voluntário:");
    string ender = Console.ReadLine();
    Console.Write("Informe a nova idade do voluntário:");
    int idade = int.Parse(Console.ReadLine());
    Console.Write("Defina um novo interesse para o Voluntario:");
    int aux = int.Parse(Console.ReadLine()); // Variavel auxiliar para selecionar os interesses
    Interesses interesses = (Interesses) aux;
    Voluntario obj = new Voluntario(id,idUsuario,idade,nome,ender,interesses );
    Sistema.VoluntarioAtualizar(obj);
    Console.WriteLine("");
    Console.WriteLine("------Voluntario Atualizado com sucesso--------");
   }
  public static void ExcluirVoluntario(){
    Console.WriteLine("---------- Excluir um Voluntário ----------");
    Console.Write("Informe o Id do voluntario a ser Excluido: ");
    int id = int.Parse(Console.ReadLine());
   
    DateTime data = DateTime.Now;
    Voluntario obj = new Voluntario(id);
    Sistema.VoluntarioExcluir(obj);
    Console.WriteLine("");
    Console.WriteLine("------Voluntario excluido com sucesso--------");
   }
  }