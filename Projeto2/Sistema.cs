using System;


class Sistema{
  private static Acao[] Acoes = new Acao[10];
  private static int nAcao;
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
    int aux = Acaoid(obj.GetId());
    if (aux != -1){
      for (int i = aux;i<nAcoes - 1; i++)
      Acoes[i] = Acoes[i + 1];
      nAcao--;
    }
  }
  pubic static void Acaoid(int id){
    for( int i =0; i < nAcao; i++ ){
    Acao obj = Acoes[i];
    if (obj.GetId == id) return i; }
    Return -1
    }
}
