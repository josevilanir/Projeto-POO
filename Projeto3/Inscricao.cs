using System;
public class Inscricao{
  public int idInsc;
  private int idVoluntario;
  private int idAcao;
  
  
  public Inscricao(int idInsc){
    this.idInsc = idInsc;
    }
  
  public Inscricao(int idInsc, int idVoluntario, int idAcao){
    this.idInsc = idInsc;
    this.idVoluntario = idVoluntario;
    this.idAcao = idAcao;
    
    
  }
  public void SetidInsc(int idInsc){
        this.idInsc = idInsc;  
  }
  public void SetidVoluntario(int idVoluntario){
        this.idVoluntario = idVoluntario;  
  }
  public void SetidAcao(int idAcao){
        this.idAcao = idAcao;  
  }
  
  public int GetidInsc(){
    return idInsc;
  }
  public int GetidVoluntario(){
    return idVoluntario;
  }
  public int GetidAcao(){
    return idAcao;
}
  
  
  public override string ToString(){
    return $"Inscrição de numero: {idInsc} - O voluntario ";
    }
  }
