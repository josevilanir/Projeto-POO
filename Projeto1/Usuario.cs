using System;
public class Usuario{
  private int id;
  private int idade;
  private string nome;
  private string ender;
  public Usuario(int id,int Idade,string Nome,string Ender){
    this.id = id;
    this.idade = Idade;
    this.nome = Nome;
    this.ender = Ender;
    }  
  public void Setid(int id){
    this.id = id;
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
  public int Getid(){
    return id;
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
  public override string ToString(){
   return $"Nome:{nome} - Idade:{idade} - Endereço:{ender}";
  }
}