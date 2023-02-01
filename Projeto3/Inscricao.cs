using System;
public class Inscricao{
  public int idInsc;
  private int idVoluntario;
  private int idAcao;
  private string AcaoNome;
  private string VoluntarioNome;

  public Inscricao(int idInsc, int idVoluntario, int idAcao, string AcaoNome,string VoluntarioNome){
    this.idInsc = idInsc;
    this.idVoluntario = idVoluntario;
    this.idAcao = idAcao;
    this.AcaoNome = AcaoNome;
    this.VoluntarioNome = VoluntarioNome;
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
  public void SetAcaoNome(string AcaoNome){
    this.AcaoNome = AcaoNome;
  }
  public void SetVoluntarioNome(string VoluntarioNome){
    this.VoluntarioNome = VoluntarioNome;
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
  public string GetAcaoNome(){
    return AcaoNome;
  }
  public string GetVoluntarioNome(){
    return VoluntarioNome;
  }
  public override string ToString(){
    return $"Inscrição de numero: {idInsc} \n O voluntario {VoluntarioNome} foi inscrito na ação {AcaoNome} ";
    }
  }
