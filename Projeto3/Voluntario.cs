using System;
public enum Interesses: byte {
  Escola = 1, Hospital = 2, Asilo = 3, Serviço_comunitario = 4
}
public class Voluntario{
  private int id;
  private int idUsuario;
  private int idade;
  private string nome;
  private string ender;
  public Interesses interesses;
  public Voluntario(int id,int Idusuario,int Idade,string Nome,string Ender, Interesses Interesses){
    this.id = id;
    this.idUsuario = Idusuario;
    this.idade = Idade;
    this.nome = Nome;
    this.ender = Ender;
    this.interesses = Interesses;
    }  
  public void Setid(int id){
    this.idvoluntario = id;
  }
  public void Setidusuario(int umidusuario){
    this.idUsuario = umidusuario;
  }
  public void SetIdade(int umaIdade){
    this.idade = umaIdade;
  }
  public void SetNome(string umNome){
    this.nome = umNome;
  }
  public void SetEnder(string umEnder){
    this.ender = umEnder;
  }
  public void SetInte(string uminteresse){
    this.interesses = uminteresse;
  }
  public int Getidvoluntario(){
    return idvoluntario;
  }
  public int Getidusuario(){
    return idUsuario;
  }
  public int GetIdade(){
    return idade;
  }
  public string GetNome(){
    return nome;
  }
  public string GetEnder(){
    return ender;
  }
  public string GetInte(){
    return interesses;
  }
  public override string ToString(){
   return $"Nome:{nome} - Idade:{idade} - Endereço:{ender} - Interesses: {interesses}" ;
  }
}