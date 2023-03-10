using System;
using System.Collections.Generic;

class Sistema{
  private static Acao[] Acoes = new Acao[10];
  private static int nAcao;
  private static int nidAcao = 1; // Contador que define os ids das acoes
  private static int nInsc = 1;
  private static List<Voluntario> Voluntarios = new List<Voluntario>();
  private static List<Inscricao> Inscricoes = new List<Inscricao>();
  public static void CadastroAcao(Acao obj){
    
    if (nAcao == Acoes.Length)
      Array.Resize(ref Acoes,2*Acoes.Length);
    Acoes[nAcao] = obj;
    nAcao++;
    nidAcao++;
    
  }
  public static Acao[] ListarAcoes(){
    Acao[] aux  = new Acao[nAcao];
    Array.Copy(Acoes, aux, nAcao);
    return aux;
    
  }
  //metodo para retornar um obj com base no ID espicificar√° a especie a ser atualizada
  public static Acao Acaolistar(int id){
    foreach (Acao obj in Acoes)
      if (obj != null && obj.Getid() == id) return obj;
    return null;
    
  }
  
  
  public static void AcaoAtualizar(Acao obj){
    //localizara a acao com base no id especificado no metodo anterior.
    Acao aux = Acaolistar(obj.Getid());
    if (aux != null)
    aux.SetData(obj.GetData());
    aux.SetNome(obj.GetNome());
    aux.SetEnder(obj.GetLocal());
    aux.SetAjuda(obj.GetAjuda());
    aux.SetCategoria(obj.GetCategoria());
  }

  public static void AcaoExcluir(Acao obj){
    int aux = Acaoid(obj.Getid());
    if (aux != -1){
      for (int i = aux;i<nAcao - 1; i++)
      Acoes[i] = Acoes[i + 1];
      nAcao--;
      }
    }
  public static int Acaoid(int id){
    for( int i =0; i < nAcao; i++ ){
    Acao obj = Acoes[i];
    if (obj.Getid() == id) return i; }
    return -1;
    }
 
  //Metodos para a classe Voluntario.
  public static void CadastroVoluntario(Voluntario obj){
    int id = 0;
    foreach(Voluntario aux in Voluntarios)
      if (aux.Getid() > id ) id = aux.Getid();
    obj.id = id + 1;
    Voluntarios.Add(obj);
    }
  
  public static List<Voluntario> ListarVoluntario(){
    return Voluntarios;
   }
  
  //metodo para retornar um id de um voluntario espec√≠fico
  
  public static Voluntario Voluntariolistar(int id){
    foreach (Voluntario obj in Voluntarios)
      if (obj.Getid() == id) return obj;
    return null;
    
  }
  
  
  public static void VoluntarioAtualizar(Voluntario obj){
    //localizara a acao com base no id especificado no metodo anterior.
    Voluntario aux = Voluntariolistar(obj.Getid());
    if (aux != null){
    aux.SetIdade(obj.GetIdade());
    aux.SetNome(obj.GetNome());
    aux.SetEnder(obj.GetEnder());
    aux.SetInte(obj.GetInte());
      }
  }

  public static void VoluntarioExcluir(Voluntario obj){
    Voluntario aux = Voluntariolistar(obj.Getid());
    if (aux != null) Voluntarios.Remove(aux);
    }
  //metodos para classe de inscri√ß√£o
  public static void CadastroInscricao(Inscricao obj){
    int id = 0;
    foreach(Inscricao aux in Inscricoes)
      if (aux.GetidInsc() > id ) id = aux.GetidInsc();
    obj.idInsc = id + 1;
    Inscricoes.Add(obj);
    }
  //Encontra a a√ß√£o em que o voluntario ser√° escrito com base no id informado pelo usu√°rio 
  public static Acao AcaoEncontrar(int id){
    foreach (Acao obj in Acoes)
      if (obj != null && obj.Getid() == id) return obj;
    return null;
    
  }
  // Contador para id de inscri√ß√£o 
  public static int GetIdinsc(){
    return nInsc;
  }
  //Contador para id de voluntario 
  public static int GetIdAcao(){
    return nidAcao;
  }
  public static List<Inscricao> ListarInscricoes(){
    return Inscricoes;
  }
  public static string AcaoEncontrarNome(int id){
    foreach (Acao obj in Acoes)
      if (obj != null && obj.Getid() == id) return obj.GetNome();
    return null;
    
  }
   // retona um voluntario com base no seu ID
  public static Voluntario VoluntarioEncontrar(int id){
    foreach (Voluntario obj in Voluntarios)
      if (obj != null && obj.Getid() == id) return obj;
    return null;
  }
  // retona no nome do voluntario com base no seu ID
  public static string VoluntarioEncontrarNome(int id){
    foreach (Voluntario obj in Voluntarios)
      if (obj != null && obj.Getid() == id) return obj.GetNome();
    return null;
  }
  // retorna uma lista de todas as inscri√ßoes feitas por um voluntario espec√≠fico
  public static List<Inscricao> InscricoesVoluntario(Voluntario voluntario){
    List<Inscricao> r = new List<Inscricao>();
    foreach(Inscricao obj in Inscricoes) 
      if (obj.GetidVoluntario() == voluntario.Getid())
        r.Add(obj);
    return r;
  }
  public static Inscricao Inscricaolistar(int id){
    foreach (Inscricao obj in Inscricoes)
      if (obj.GetidInsc() == id) return obj;
    return null;
  }
  public static void InscricaoExcluir(Inscricao obj){
    Inscricao aux = Inscricaolistar(obj.GetidInsc());
    if (aux != null) Inscricoes.Remove(aux);
    }
   // retorna uma lista de todas as inscri√ßoes feitas em uma a√ß√£o espec√≠fica
  public static List<Inscricao> InscricoesAcao(Acao acao){
    List<Inscricao> r = new List<Inscricao>();
    foreach(Inscricao obj in Inscricoes) 
      if (obj.GetidAcao() == acao.Getid())
        r.Add(obj);
    return r;
  }
  
  }