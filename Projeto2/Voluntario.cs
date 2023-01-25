using System;
public class Voluntario{
  private int id;
  private int idusuario;
  private int idade;
  private string nome;
  private string ender;
  private string interesses;
  public Voluntario(int id,int Idusuario,int Idade,string Nome,string Ender, string Interesses){
    this.id = id;
    this.idusuario = Idusuario;
    this.idade = Idade;
    this.nome = Nome;
    this.ender = Ender;
    this.interesses = Interesses;
    }  
  public void Setid(int id){
    this.id = id;
  }
  public void Setidusuario(int umidusuario){
    this.id = umidusuario;
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
  public int Getid(){
    return id;
  }
  public int Getidusuario(){
    return idusuario;
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