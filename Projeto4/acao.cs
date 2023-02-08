using System;
public enum Categorias: byte {
  Campanha = 1, Acao_Social = 2, Oficina = 3, Multirão = 4, Outro = 5
}

public class Acao{
  public int id;
  private int idVoluntario;
  private string nome;
  private string local;
  private DateTime data;
  public bool ajuda;
  public Categorias categoria;
  public Acao(int id){
    this.id = id;
    }
  public Acao(int id,DateTime Data ,string Nome,string Local, int IdVoluntario,bool Ajuda, Categorias Categoria){
    this.id = id;
    this.data = Data;
    this.nome = Nome;
    this.idVoluntario = IdVoluntario;
    this.local = Local;
    this.ajuda = Ajuda;
    this.categoria = Categoria;
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
  public void SetAjuda(bool umaAjuda){
    this.ajuda = umaAjuda;
  }
  public void SetCategoria(Categorias umaCategoria){
    this.categoria = umaCategoria;
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
  public bool GetAjuda(){
    return ajuda;
  }
  public Categorias GetCategoria(){
    return categoria;
  }
  
  //Metodo que transforma a ação em ajuda baseado num inteiro informado pelo usuário
  public static bool TransformarAjudaAcao(int i, bool x){
  
  if (i == 1) x = true;
    return x;
  }
  public override string ToString(){
   return $"{categoria} - ID: {id} - {nome} - Acontecera no local: {local} - Será no dia: {data:dd/MM/yyyy HH:mm}";
  }
}