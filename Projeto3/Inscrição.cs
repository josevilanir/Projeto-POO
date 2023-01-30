using System;
public class Inscricao{
  private int idInsc;
  private int idVoluntario;
  private int idAcao;

  public Inscricao(int idInsc, int idVoluntario, int idAcao){
    this.idInsc = idInsc;
    this.idVoluntario = idVoluntario;
    this.idAcao = idAcao; 
  }
  public void SetidInsc(Int idInsc){
        this.idInsc = idInsc;  
  }
  public void SetidVoluntario(Int idVoluntario){
        this.idVoluntario = idVoluntario;  
  }
  public void SetidAcao(Int idAcao){
        this.idAcao = idAcao;  
  }
  public int GetidInsc(){
    return idInsc;
  }
  public Get idVoluntario(){
    return idVoluntario;
  }
  public Get idAcao(){
    return idAcao;
}
  public override string ToString(){
    return $"Inscrição {idInsc} do Voluntario {idVoluntario} para a ação {idAcao} "
    
  }
