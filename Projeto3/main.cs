using System;
using System.Globalization;
using System.Collections.Generic;
class Program{
private static Voluntario voluntarioLogin = null;
  
  public static void Main(){
    Console.WriteLine("Bem vindo ao Help.io");
    int op = 0;
    int perfil = 0;
    do {
      try{
          if (perfil == 0){
            op = 0;
            perfil = MenuUsuario();
          }
          if (perfil == 1 ){
        op = MenuAdmin();
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
        case 99 : perfil = 0; break;
          }
        }
      if (perfil == 2 && voluntarioLogin == null){
        op = MenuVoluntarioLogin();
        switch(op){
        case 1 : VoluntarioLogin(); break;
        case 99 : perfil = 0; break;
        }
      }
      if (perfil == 2 && voluntarioLogin != null){
        op = MenuVoluntarioLogout();
        switch(op){
        case 1 : CadastroAcaoVoluntario(); break;
        case 2 : ListarAcoes(); break;
        case 3 : ListarApenasInscAcoes(); break;
        case 4 : ListarApenasInscAjudas(); break;
        case 5 : Inscreverse(); break;
        case 6 : ListarMinhasIncricoes(); break;
        case 7 : ListarIncricoesAcao(); break;
        case 8 : Desinscreverse(); break;
        case 9 : AtualizarPerfil(); break;
        case 99 : VoluntarioLogout(); break;
        }
      }  
      }
      catch (Exception erro){
        op = -1;
        Console.WriteLine("Erro: " + erro.Message);
      }
    } while (op != 0);
  }

  public static void  VoluntarioLogin(){
  Console.WriteLine("----------------------------------------");
   ListarVoluntario();
  Console.Write("Informe seu id de cliente");
  Console.WriteLine();
  int id = int.Parse(Console.ReadLine());
  voluntarioLogin = Sistema.VoluntarioEncontrar(id);
  }
  public static void VoluntarioLogout(){
    Console.WriteLine("----- Logout do voluntario ------");
    voluntarioLogin = null;
  }
  public static void Inscreverse(){
    Console.WriteLine("---------- Inscrever-se em um movimento ----------");
    ListarAcoes();
    Console.Write("Informe o Id do movimento que deseja participar: ");
    int idAcao = int.Parse(Console.ReadLine());
    
    int idVoluntario = voluntarioLogin.id;
    int idInsc = Sistema.GetIdinsc();
    
    
    Inscricao obj = new Inscricao(idInsc,idVoluntario,idAcao);
    Sistema.CadastroInscricao(obj);
    Console.WriteLine("--------Inscri????o realizada com sucesso---------");
  }
  public static void ListarMinhasIncricoes(){
    ListarVoluntario();
    Console.WriteLine();
    int id = voluntarioLogin.id;
    Console.WriteLine("--- Suas incri????es ---");
    //retorna um voluntario selecionado pelo id 
    Voluntario obj = Sistema.Voluntariolistar(id);
    // retorna uma lista com todas as inscri????es feitas pelo volunt??rio
    foreach (var i in Sistema.InscricoesVoluntario(obj))
    {  Acao aux = Sistema.AcaoEncontrar(i.GetidAcao());
      string nome = Sistema.VoluntarioEncontrarNome(i.GetidVoluntario());
      if (aux.ajuda == false) {Console.WriteLine($"{i}{nome} Foi inscrito na A????o: {aux.GetNome()}");}
      else {Console.WriteLine($"{i}{nome} Foi inscrito na Ajuda: {aux.GetNome()}");}}
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------");
  }
  public static void  Desinscreverse(){
    Console.WriteLine("---------- Sair de um movimento ----------");
    ListarMinhasIncricoes();
    Console.Write("Informe o Id da inscri????o que deseja excluir: ");
    int idInsc = int.Parse(Console.ReadLine());
    DateTime data = DateTime.Now;
    Inscricao obj = new Inscricao(idInsc);
    Sistema.InscricaoExcluir(obj);
    Console.WriteLine("");
    Console.WriteLine("------Inscri??ao excluida com sucesso--------");
  }
  

  public static void CadastroAcaoVoluntario(){
    Console.WriteLine("---------- Inserir um movimento ----------");
    int id = Sistema.GetIdAcao();
    Console.Write("D?? um nome para o movimento: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o local onde o movimento acontecer??:");
    string local = Console.ReadLine();
    Console.Write("Informe a data em que o movimento acontecer??:");
    DateTime data = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
    int idVoluntario = voluntarioLogin.id;
    Console.Write("Escolha uma categoria para esse movimento:\n Campanha - 1\n A????o Social - 2\n Oficina - 3\n Multir??o - 4\n Outro - 5\n");
    int aux2  = int.Parse(Console.ReadLine());
    Categorias categoria = (Categorias) aux2;
    bool ajuda = false;
    Console.Write("Voc?? deseja tornar isso uma:\n A????o - 0\n Ajuda - 1\n");
    int aux  = int.Parse(Console.ReadLine());
    ajuda = Acao.TransformarAjudaAcao(aux,ajuda);
    Acao obj = new Acao(id,data,nome,local,idVoluntario,ajuda,categoria);
    int idInsc = Sistema.GetIdinsc();
    Inscricao objinsc = new Inscricao(idInsc,idVoluntario,id);
    Sistema.CadastroInscricao(objinsc);
    Sistema.CadastroAcao(obj);
    if (ajuda == false)
      Console.WriteLine("--------A????o inserida com sucesso---------");
    if (ajuda == true)
      Console.WriteLine("-------Ajuda inserida com sucesso---------");
  }
  public static void AtualizarPerfil(){
    Console.WriteLine("---------- Atualizar seu perfil de Volunt??rio ----------");
    int id = voluntarioLogin.id;
    int idUsuario = 1;
    Console.Write("Informe um novo nome para o volunt??rio: ");
    string nome = Console.ReadLine();
    Console.Write("Informe um novo endere??o do volunt??rio:");
    string ender = Console.ReadLine();
    Console.Write("Informe a nova idade do volunt??rio:");
    int idade = int.Parse(Console.ReadLine());
    Console.Write("Defina um novo interesse para o Voluntario: \n- Escola : 1 \n- Hospital : 2 \n- Asilo : 3 \n- Servi??o_comunitario : 4\n");
    int aux = int.Parse(Console.ReadLine()); // Variavel auxiliar para selecionar os interesses
    Interesses interesses = (Interesses) aux;
    Voluntario obj = new Voluntario(id,idUsuario,idade,nome,ender,interesses );
    Sistema.VoluntarioAtualizar(obj);
    Console.WriteLine("");
    Console.WriteLine("------Voluntario Atualizado com sucesso--------");
  }



  
  public static int MenuUsuario(){
    Console.WriteLine();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("1 - Entrar como Administrador");
    Console.WriteLine("2 - Entrar como Voluntario");
    Console.WriteLine("0 - Encerrar sistema");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Informe uma opc??o: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
    }

    public static int MenuVoluntarioLogin(){
    Console.WriteLine();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("1 - Login");
    Console.WriteLine("99 - Voltar ao menu anterior");
    Console.WriteLine("0 - Encerrar sistema");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Informe uma opc??o: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
    }


    public static int MenuVoluntarioLogout(){
    Console.WriteLine();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Seja bem vindo(a) " + voluntarioLogin.nome);
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("1 - Cadastrar um movimento");
    Console.WriteLine("2 - Listar movimentos");
    Console.WriteLine("3 - Listar apenas A????es");
    Console.WriteLine("4 - Listar apenas Ajudas");
    Console.WriteLine("5 - Inscrever-se em movimento");
    Console.WriteLine("6 - Ver Minhas inscri????es");
    Console.WriteLine("7 - Ver inscri????es de um movimento espec??fico");
    Console.WriteLine("8 - Desinscrever-se de um movimento");
    Console.WriteLine("9 - Atualizar meu perfil de volunt??rio");
    Console.WriteLine("99 - Logout"); 
    Console.WriteLine("0 - Encerrar sistema");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Informe uma opc??o: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
    }



  
  public static int MenuAdmin(){
  Console.WriteLine();
  Console.WriteLine("---------- Escolha Uma op????o! ----------");
  Console.WriteLine("01 - Cadastrar um movimento");
  Console.WriteLine("02 - Listar movimentos");
  Console.WriteLine("03 - Atualizar um movimento");
  Console.WriteLine("04 - Excluir um movimento");
  Console.WriteLine("05 - Cadastrar um volunt??rio");
  Console.WriteLine("06 - Listar volunt??rios");
  Console.WriteLine("07 - Atualizar um voluntario");
  Console.WriteLine("08 - Excluir um volunt??rio"); 
  Console.WriteLine("09 - Inscrever-se em um movimento");
  Console.WriteLine("10 - Ver incri????es realizadas");
  Console.WriteLine("11 - Ver inscri????es de um usu??rio espec??fico");
  Console.WriteLine("12 - Ver inscri????es de um movimento espec??fico");
  Console.WriteLine("13 - Listar apenas A????es"); 
  Console.WriteLine("14 - Listar apenas Ajudas");
  Console.WriteLine("15 - Excluir uma inscri????o"); 
  Console.WriteLine("99 - Voltar ao menu anterior");   
  Console.WriteLine("00 - Finalizar Programa");
  Console.WriteLine("----------------------------------------");
  Console.Write("Op????o: ");
  int op = int.Parse(Console.ReadLine());
  Console.WriteLine();
  return op;
  }
  public static void CadastroAcao(){
    Console.WriteLine("---------- Inserir um movimento ----------");
    int id = Sistema.GetIdAcao();
    Console.Write("D?? um nome para o movimento: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o local onde o movimento acontecer??:");
    string local = Console.ReadLine();
    Console.Write("Informe a data em que o movimento acontecer??:");
    DateTime data = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
    Console.Write("Informe o seu id de Voluntario: ");
    int idVoluntario = int.Parse(Console.ReadLine());
    Console.Write("Escolha uma categoria para esse movimento:\n Campanha - 1\n A????o Social - 2\n Oficina - 3\n Multir??o - 4\n Outro - 5\n");
    int aux2  = int.Parse(Console.ReadLine());
    Categorias categoria = (Categorias) aux2;
    bool ajuda = false;
    Console.Write("Voc?? deseja tornar isso uma:\n A????o - 0\n Ajuda - 1\n");
    int aux  = int.Parse(Console.ReadLine());
    ajuda = Acao.TransformarAjudaAcao(aux,ajuda);
    Acao obj = new Acao(id,data,nome,local,idVoluntario,ajuda,categoria);
    int idInsc = Sistema.GetIdinsc();
    Inscricao objinsc = new Inscricao(idInsc,idVoluntario,id);
    Sistema.CadastroInscricao(objinsc);
    Sistema.CadastroAcao(obj);
    if (ajuda == false)
      Console.WriteLine("--------A????o inserida com sucesso---------");
    if (ajuda == true)
      Console.WriteLine("-------Ajuda inserida com sucesso---------");
  }
  
  
  
  public static void ListarAcoes(){
    Console.WriteLine("--------Listar os movimentos cadastrados---------");
    foreach (Acao obj in Sistema.ListarAcoes()){
      if (obj.ajuda == false ) {Console.WriteLine($" A????o - {obj}" );}
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
    Console.Write("Informe um novo local onde o movimento acontecer??:");
    string local = Console.ReadLine();
    Console.Write("Informe a nova data em que o movimento acontecer??:");
    DateTime data = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
    Console.Write("Informe o novo id de voluntario do dono do movimento:");
    int idVoluntario = int.Parse(Console.ReadLine());
    Console.Write("Escolha uma nova caregoria para esse movimento:\n Campanha - 1\n A????o Social -2\n Oficina - 3\n Multir??o - 4\n Outro - 5\n");
    int aux2  = int.Parse(Console.ReadLine());
    Categorias categoria = (Categorias) aux2;
    bool ajuda = false;
    Console.Write("Voc?? deseja atualizar isso para uma:\n A????o - 0\n Ajuda - 1\n");
    int aux  = int.Parse(Console.ReadLine());
    ajuda = Acao.TransformarAjudaAcao(aux,ajuda);
    Acao obj = new Acao(id,data,nome,local,idVoluntario,ajuda,categoria);
    Sistema.AcaoAtualizar(obj);
    Console.WriteLine("");
    if (ajuda == false)
      Console.WriteLine("--------A????o atualizada com sucesso---------");
    if (ajuda == true)
      Console.WriteLine("-------Ajuda atualizada com sucesso---------");
   }
  public static void ExcluirAcao(){
    Console.WriteLine("---------- Excluir um movimento ----------");
    ListarAcoes();
    Console.Write("Informe o Id da a????o a ser Excluida: ");
    int id = int.Parse(Console.ReadLine());
    
    DateTime data = DateTime.Now;
    Acao objs = Sistema.AcaoEncontrar(id);
    foreach (Inscricao aux in Sistema.InscricoesAcao(objs))      
    {Sistema.InscricaoExcluir(aux);};
    Acao obj = new Acao(id);
    Sistema.AcaoExcluir(obj);
    Console.WriteLine("");
    Console.WriteLine("------Movimento excluido com sucesso--------");
   }
  // Menu do volunt??rio
  public static void CadastroVoluntario(){
    Console.WriteLine("---------- Cadastrar um Volunt??rio ----------");
    int id = 0;
    int idUsuario = 1;
    Console.Write("Informe um nome: ");
    string nome = Console.ReadLine();
    Console.Write("Informe seu endere??o:");
    string ender = Console.ReadLine();
    Console.Write("Informe sua idade:");
    int idade = int.Parse(Console.ReadLine());
    Console.Write("Informe seus interesses: \n- Escola : 1 \n- Hospital : 2 \n- Asilo : 3 \n- Servi??o_comunitario : 4\n");
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
    Console.WriteLine("---------- Atualizar um perfil de Volunt??rio ----------");
    Console.Write("Informe o Id do volunt??rio a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    int idUsuario = 1;
    Console.Write("Informe um novo nome para o volunt??rio: ");
    string nome = Console.ReadLine();
    Console.Write("Informe um novo endere??o do volunt??rio:");
    string ender = Console.ReadLine();
    Console.Write("Informe a nova idade do volunt??rio:");
    int idade = int.Parse(Console.ReadLine());
    Console.Write("Defina um novo interesse para o Voluntario:\n- Escola : 1 \n- Hospital : 2 \n- Asilo : 3 \n- Servi??o_comunitario : 4\n");
    int aux = int.Parse(Console.ReadLine()); // Variavel auxiliar para selecionar os interesses
    Interesses interesses = (Interesses) aux;
    Voluntario obj = new Voluntario(id,idUsuario,idade,nome,ender,interesses );
    Sistema.VoluntarioAtualizar(obj);
    Console.WriteLine("");
    Console.WriteLine("------Voluntario Atualizado com sucesso--------");
   }
  public static void ExcluirVoluntario(){
    Console.WriteLine("---------- Excluir um Volunt??rio ----------");
    ListarVoluntario();
    Console.Write("Informe o Id do voluntario a ser Excluido: ");
    int id = int.Parse(Console.ReadLine());
    DateTime data = DateTime.Now;
    Voluntario obj = new Voluntario(id);
    Voluntario objs = Sistema.VoluntarioEncontrar(id);
    foreach (Inscricao aux in Sistema.InscricoesVoluntario(objs))      
    {Sistema.InscricaoExcluir(aux);};
    Sistema.VoluntarioExcluir(obj);
    Console.WriteLine("");
    Console.WriteLine("------Voluntario excluido com sucesso--------");
   }
  //menu de inscri????es
  public static void CadastroInscricao(){
    Console.WriteLine("---------- Inscrever-se em um movimento ----------");
    ListarAcoes();
    Console.Write("Informe o Id do movimento que deseja participar: ");
    int idAcao = int.Parse(Console.ReadLine());
    ListarVoluntario();
    Console.Write("Informe seu Id de volunt??rio: ");
    int idVoluntario = int.Parse(Console.ReadLine());
    int idInsc = Sistema.GetIdinsc();
    
    
    Inscricao obj = new Inscricao(idInsc,idVoluntario,idAcao);
    Sistema.CadastroInscricao(obj);
    Console.WriteLine("--------Inscri????o realizada com sucesso---------");
  }
  public static void ListarIncricoes(){
    Console.WriteLine("--------Listar incri????es realizadas---------");
    
    foreach (Inscricao obj in Sistema.ListarInscricoes()){
      Acao aux = Sistema.AcaoEncontrar(obj.GetidAcao());
      //Desclara????o da variavel nome fora do m??todo para que ocorra atualiza????o automatica do mesmo quando um usuario tiver seu nome atualizado
      string nome = Sistema.VoluntarioEncontrarNome(obj.GetidVoluntario());
      if (aux.ajuda == false) {Console.WriteLine($"{obj}{nome} foi inscrito na A????o: {aux.GetNome()}");}
      else {Console.WriteLine($"{obj}{nome} foi inscrito na Ajuda: {aux.GetNome()}");}}
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------");
  }
  
  public static void ListarIncricoesVoluntario(){
    ListarVoluntario();
    Console.WriteLine("Informe o ID do voluntario que deseja verificar suas inscri????es: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("--- Incri????es realizadas por esse usu??rio ---");
    
    
    
    //retorna um voluntario selecionado pelo id 
    Voluntario obj = Sistema.Voluntariolistar(id);
    // retorna uma lista com todas as inscri????es feitas pelo volunt??rio
    foreach (var i in Sistema.InscricoesVoluntario(obj))
    {  Acao aux = Sistema.AcaoEncontrar(i.GetidAcao());
      string nome = Sistema.VoluntarioEncontrarNome(i.GetidVoluntario());
      if (aux.ajuda == false) {Console.WriteLine($"{i}{nome} Foi inscrito na A????o: {aux.GetNome()}");}
      else {Console.WriteLine($"{i}{nome} Foi inscrito na Ajuda: {aux.GetNome()}");}}
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------");
  }
  public static void ExcluirInscricao(){
    Console.WriteLine("---------- Excluir uma Inscri????o ----------");
    ListarIncricoes();
    Console.Write("Informe o Id da inscri????o que deseja excluir: ");
    int idInsc = int.Parse(Console.ReadLine());
   
    DateTime data = DateTime.Now;
    Inscricao obj = new Inscricao(idInsc);
    Sistema.InscricaoExcluir(obj);
    Console.WriteLine("");
    Console.WriteLine("------Inscri??ao excluida com sucesso--------");
   }
  public static void ListarIncricoesAcao(){
    ListarAcoes();
    Console.WriteLine("Informe o ID do movimento que deseja verificar as inscri????es: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("--- Incri????es realizadas nesse movimento ---");
    //retorna uma acao selecionada pelo id 
    Acao obj = Sistema.Acaolistar(id);
    // retorna uma lista com todas as inscri????es feitas pelo volunt??rio
    foreach (var i in Sistema.InscricoesAcao(obj))
    {  Acao aux = Sistema.AcaoEncontrar(i.GetidAcao());
      string nome = Sistema.VoluntarioEncontrarNome(i.GetidVoluntario());
      if (aux.ajuda == false) {Console.WriteLine($"{i}{nome} Foi inscrito na A????o: {aux.GetNome()}");}
      else {Console.WriteLine($"{i}{nome} Foi inscrito na Ajuda: {aux.GetNome()}");}}
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------");
  }
  public static void ListarApenasInscAcoes(){
    Console.WriteLine("-------- Listar A????es ---------");

    foreach (Acao obj in Sistema.ListarAcoes()){
      if (obj.ajuda == false ) {Console.WriteLine($" A????o - {obj}" );}}
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