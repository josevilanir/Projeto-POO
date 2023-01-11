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
  
}
