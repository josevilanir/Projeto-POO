using System;
using System.Collections.Generic;

class Sistema{
  private static Acao[] Acoes = new Acao[10];
  private static int nAcao;
  private static int nidAcao = 1; // Contador que define os ids das acoes
  private static int nInsc = 1;
  private static List<Voluntario> Voluntarios = new List<Voluntario>();
  private static Inscricao[] Inscricoes = new Inscricao[1];
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
  //metodo para retornar um obj com base no ID espicificará a especie a ser atualizada
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
  
  //metodo para retornar um id de um voluntario específico
  
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
  //metodos para classe de inscrição
  public static void CadastroInscricao(Inscricao obj){
    if (nInsc == Inscricoes.Length)
      Array.Resize(ref Inscricoes,2*Inscricoes.Length);
    Inscricoes[nInsc] = obj;
    nInsc++;

    }
  //Encontra a ação em que o voluntario será escrito com base no id informado pelo usuário 
  public static Acao AcaoEncontrar(int id){
    foreach (Acao obj in Acoes)
      if (obj != null && obj.Getid() == id) return obj;
    return null;
    
  }
  public static int GetIdinsc(){
    return nInsc;
  }
  public static int GetIdAcao(){
    return nidAcao;
  }
  public static Inscricao[] ListarInscricoes(){
    Inscricao[] aux  = new Inscricao[nInsc];
    Array.Copy(Inscricoes, aux, nInsc);
    return aux;
  }
  public static string AcaoEncontrarNome(int id){
    foreach (Acao obj in Acoes)
      if (obj != null && obj.Getid() == id) return obj.GetNome();
    return null;
    
  }
  public static string VoluntarioEncontrarNome(int id){
    foreach (Voluntario obj in Voluntarios)
      if (obj != null && obj.Getid() == id) return obj.GetNome();
    return null;
    
  }
  }