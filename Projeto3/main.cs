using System;
using System.Globalization;
using System.Collections.Generic;
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
        case 9 : CadastroInscricao(); break;
        case 10 : ListarIncricoes (); break;
        case 11 : ListarIncricoesVoluntario(); break;
        case 12 : ListarIncricoesAcao(); break;
        case 13 : ListarApenasInscAcoes(); break;
        case 14 : ListarApenasInscAjudas(); break;
        case 15 : ExcluirInscricao(); break;
        
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
  Console.WriteLine("01 - Cadastrar um movimento");
  Console.WriteLine("02 - Listar movimentos");
  Console.WriteLine("03 - Atualizar um movimento");
  Console.WriteLine("04 - Excluir um movimento");
  Console.WriteLine("05 - Cadastrar um voluntário");
  Console.WriteLine("06 - Listar voluntários");
  Console.WriteLine("07 - Atualizar um voluntario");
  Console.WriteLine("08 - Excluir um voluntário"); 
  Console.WriteLine("09 - Inscrever-se em um movimento");
  Console.WriteLine("10 - Ver incrições realizadas");
  Console.WriteLine("11 - Ver inscrições de um usuário específico");
  Console.WriteLine("12 - Ver inscrições de um movimento específico");
  Console.WriteLine("13 - Listar apenas Ações"); 
  Console.WriteLine("14 - Listar apenas Ajudas");
  Console.WriteLine("15 - Excluir uma inscrição"); 
  Console.WriteLine("00 - Finalizar Programa");
  Console.WriteLine("----------------------------------------");
  Console.Write("Opção: ");
  int op = int.Parse(Console.ReadLine());
  Console.WriteLine();
  return op;
  }
  public static void CadastroAcao(){
    Console.WriteLine("---------- Inserir um movimento ----------");
    int id = Sistema.GetIdAcao();
    Console.Write("Dê um nome para o movimento: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o local onde o movimento acontecerá:");
    string local = Console.ReadLine();
    Console.Write("Informe a data em que o movimento acontecerá:");
    DateTime data = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
    Console.Write("Informe o seu id de Voluntario: ");
    int idVoluntario = int.Parse(Console.ReadLine());
    Console.Write("Escolha uma categoria para esse movimento:\n Campanha - 1\n Ação Social - 2\n Oficina - 3\n Multirão - 4\n Outro - 5\n");
    int aux2  = int.Parse(Console.ReadLine());
    Categorias categoria = (Categorias) aux2;
    bool ajuda = false;
    Console.Write("Você deseja tornar isso uma:\n Ação - 0\n Ajuda - 1\n");
    int aux  = int.Parse(Console.ReadLine());
    ajuda = Acao.TransformarAjudaAcao(aux,ajuda);
    Acao obj = new Acao(id,data,nome,local,idVoluntario,ajuda,categoria);
    Sistema.CadastroAcao(obj);
    if (ajuda == false)
      Console.WriteLine("--------Ação inserida com sucesso---------");
    if (ajuda == true)
      Console.WriteLine("-------Ajuda inserida com sucesso---------");
  }
  public static void ListarAcoes(){
    Console.WriteLine("--------Listar os movimentos cadastrados---------");
    foreach (Acao obj in Sistema.ListarAcoes()){
      if (obj.ajuda == false ) {Console.WriteLine($" Ação - {obj}" );}
      else { Console.WriteLine($" Ajuda - {obj}" );}}
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------");
  }

   public static void AtualizarAcao(){
    Console.WriteLine("---------- Atualizar um movimento ----------");
    ListarAcoes();
    Console.Write("Informe o Id do movimento a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe um novo nome para o movimento: ");
    string nome = Console.ReadLine();
    Console.Write("Informe um novo local onde o movimento acontecerá:");
    string local = Console.ReadLine();
    Console.Write("Informe a nova data em que o movimento acontecerá:");
    DateTime data = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
    Console.Write("Informe o novo id de voluntario do dono do movimento:");
    int idVoluntario = int.Parse(Console.ReadLine());
    Console.Write("Escolha uma nova caregoria para esse movimento:\n Campanha - 1\n Ação Social -2\n Oficina - 3\n Multirão - 4\n Outro - 5\n");
    int aux2  = int.Parse(Console.ReadLine());
    Categorias categoria = (Categorias) aux2;
    bool ajuda = false;
    Console.Write("Você deseja atualizar isso para uma:\n Ação - 0\n Ajuda - 1\n");
    int aux  = int.Parse(Console.ReadLine());
    ajuda = Acao.TransformarAjudaAcao(aux,ajuda);
    Acao obj = new Acao(id,data,nome,local,idVoluntario,ajuda,categoria);
    Sistema.AcaoAtualizar(obj);
    Console.WriteLine("");
    if (ajuda == false)
      Console.WriteLine("--------Ação atualizada com sucesso---------");
    if (ajuda == true)
      Console.WriteLine("-------Ajuda atualizada com sucesso---------");
   }
  public static void ExcluirAcao(){
    Console.WriteLine("---------- Excluir um movimento ----------");
    Console.Write("Informe o Id da ação a ser Excluida: ");
    int id = int.Parse(Console.ReadLine());
    
    DateTime data = DateTime.Now;
    Acao obj = new Acao(id);
    Sistema.AcaoExcluir(obj);
    Console.WriteLine("");
    Console.WriteLine("------Movimento excluido com sucesso--------");
   }
  // Menu do voluntário
  public static void CadastroVoluntario(){
    Console.WriteLine("---------- Cadastrar um Voluntário ----------");
    int id = 0;
    int idUsuario = 1;
    Console.Write("Informe um nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe seu endereço:");
    string ender = Console.ReadLine();
    Console.Write("Informe sua idade:");
    int idade = int.Parse(Console.ReadLine());
    Console.Write("Informe seus interesses: \n- Escola : 1 \n- Hospital : 2 \n- Asilo : 3 \n- Serviço_comunitario : 4\n");
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
    Console.Write("Informe o Id do voluntário a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    int idUsuario = 1;
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
  //menu de inscrições
  public static void CadastroInscricao(){
    Console.WriteLine("---------- Inscrever-se em um movimento ----------");
    ListarAcoes();
    Console.Write("Informe o Id do movimento que deseja participar: ");
    int idAcao = int.Parse(Console.ReadLine());
    ListarVoluntario();
    Console.Write("Informe seu Id de voluntário: ");
    int idVoluntario = int.Parse(Console.ReadLine());
    int idInsc = Sistema.GetIdinsc();
    
    
    Inscricao obj = new Inscricao(idInsc,idVoluntario,idAcao);
    Sistema.CadastroInscricao(obj);
    Console.WriteLine("--------Inscrição realizada com sucesso---------");
  }
  public static void ListarIncricoes(){
    Console.WriteLine("--------Listar incrições realizadas---------");
    
    foreach (Inscricao obj in Sistema.ListarInscricoes()){
      Acao aux = Sistema.AcaoEncontrar(obj.GetidAcao());
      //Desclaração da variavel nome fora do método para que ocorra atualização automatica do mesmo quando um usuario tiver seu nome atualizado
      string nome = Sistema.VoluntarioEncontrarNome(obj.GetidVoluntario());
      if (aux.ajuda == false) {Console.WriteLine($"{obj}{nome} foi inscrito na Ação: {aux.GetNome()}");}
      else {Console.WriteLine($"{obj}{nome} foi inscrito na Ajuda: {aux.GetNome()}");}}
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------");
  }
  
  public static void ListarIncricoesVoluntario(){
    ListarVoluntario();
    Console.WriteLine("Informe o ID do voluntario que deseja verificar suas inscrições: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("--- Incrições realizadas por esse usuário ---");
    
    
    
    //retorna um voluntario selecionado pelo id 
    Voluntario obj = Sistema.Voluntariolistar(id);
    // retorna uma lista com todas as inscrições feitas pelo voluntário
    foreach (var i in Sistema.InscricoesVoluntario(obj))
    {  Acao aux = Sistema.AcaoEncontrar(i.GetidAcao());
      string nome = Sistema.VoluntarioEncontrarNome(i.GetidVoluntario());
      if (aux.ajuda == false) {Console.WriteLine($"{i}{nome} Foi inscrito na Ação: {aux.GetNome()}");}
      else {Console.WriteLine($"{i}{nome} Foi inscrito na Ajuda: {aux.GetNome()}");}}
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------");
  }
  public static void ExcluirInscricao(){
    Console.WriteLine("---------- Excluir uma Inscrição ----------");
    ListarIncricoes();
    Console.Write("Informe o Id da inscrição que deseja excluir: ");
    int idInsc = int.Parse(Console.ReadLine());
   
    DateTime data = DateTime.Now;
    Inscricao obj = new Inscricao(idInsc);
    Sistema.InscricaoExcluir(obj);
    Console.WriteLine("");
    Console.WriteLine("------Inscriçao excluida com sucesso--------");
   }
  public static void ListarIncricoesAcao(){
    ListarAcoes();
    Console.WriteLine("Informe o ID do movimento que deseja verificar as inscrições: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("--- Incrições realizadas nesse movimento ---");
    //retorna uma acao selecionada pelo id 
    Acao obj = Sistema.Acaolistar(id);
    // retorna uma lista com todas as inscrições feitas pelo voluntário
    foreach (var i in Sistema.InscricoesAcao(obj))
    {  Acao aux = Sistema.AcaoEncontrar(i.GetidAcao());
      string nome = Sistema.VoluntarioEncontrarNome(i.GetidVoluntario());
      if (aux.ajuda == false) {Console.WriteLine($"{i}{nome} Foi inscrito na Ação: {aux.GetNome()}");}
      else {Console.WriteLine($"{i}{nome} Foi inscrito na Ajuda: {aux.GetNome()}");}}
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------");
  }
  public static void ListarApenasInscAcoes(){
    Console.WriteLine("-------- Listar Ações ---------");

    foreach (Acao obj in Sistema.ListarAcoes()){
      if (obj.ajuda == false ) {Console.WriteLine($" Ação - {obj}" );}}
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------");
    }
    public static void ListarApenasInscAjudas(){
    Console.WriteLine("-------- Listar Ajudas ---------");
    

    foreach (Acao obj in Sistema.ListarAcoes()){
      if (obj.ajuda == true ) {Console.WriteLine($" Ajuda - {obj}" );}}
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------");
  }
  }