using System;
public class Acao{
  public int id;
  private int idVoluntario;
  private string nome;
  private string local;
  private DateTime data;
  public Acao(int id){
    this.id = id;
    }
  public Acao(int id,DateTime Data ,string Nome,string Local, int IdVoluntario){
    this.id = id;
    this.data = Data;
    this.nome = Nome;
    this.idVoluntario = IdVoluntario;
    this.local = Local;
    }  
  public void Setid(int id){
    this.id = id;
  }
  public void SetidVoluntario(int umIdVoluntario){
    this.idVoluntario = umIdVoluntario;
  }
  public void SetData(DateTime umaData){
    this.data = umaData;
  }
  public void SetNome(string umNome){
    this.nome = umNome;
  }
  public void SetEnder(string umLocal){
    this.local = umLocal;
  }
  public int Getid(){
    return id;
  }
  public int GetidVoluntario(){
    return idVoluntario;
  }
  public string GetNome(){
    return nome;
  }
  public string GetLocal(){
    return local;
  }
  public DateTime GetData(){
    return data;
  }
  public override string ToString(){
   return $" {id} - {nome} - Acontecera no local: {local} - Será no dia: {data:dd/MM/yyyy} ";
  }
}