using System;
using System.Collections.Generic;

class Sistema{
  private static Acao[] Acoes = new Acao[10];
  private static int nAcao;
  private static List<Voluntario> Voluntarios = new List<Voluntario>();
  public static void CadastroAcao(Acao obj){
    if (nAcao == Acoes.Length)
      Array.Resize(ref Acoes,2*Acoes.Length);
    Acoes[nAcao] = obj;
    nAcao++;
    
  }
  public static Acao[] ListarAcoes(){
    Acao[] aux  = new Acao[nAcao];
    Array.Copy(Acoes, aux, nAcao);
    return aux;
    
  }
  //metodo para retornar um id que espicificará a especie a ser atualizada
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
    Voluntarios.Add(obj);
    }
  
  public static List<Voluntario> ListarVoluntario(){
    return voluntarios;
   }
  
  //metodo para retornar um id de um voluntario específico
  
  public static Voluntario Voluntariolistar(int id){
    foreach (Voluntario obj in Voluntarios)
      if (obj.Getid() == idvoluntario) return obj;
    return null;
    
  }
  
  
  public static void VoluntarioAtualizar(Voluntario obj){
    //localizara a acao com base no id especificado no metodo anterior.
    Voluntario aux = Voluntariolistar(obj.Getidvoluntario());
    if (aux != null){
    aux.SetIdade(obj.GetData());
    aux.SetNome(obj.GetNome());
    aux.SetEnder(obj.GetEnder());
    aux.SetInte(obj.GetInte());
      }
  }

  public static void VoluntarioExcluir(Voluntario obj){
    Voluntario aux = Voluntariolistar(obj.Getidvoluntario());
    if (aux != null) Voluntarios.Remove(aux);
    }
  }
