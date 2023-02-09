using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;


class Sistema{
  private static Acao[] Acoes = new Acao[2];
  private static List<Voluntario> Voluntarios = new List<Voluntario>();
  private static List<Inscricao> Inscricoes = new List<Inscricao>();
  private static List<Comentario> Comentarios = new List<Comentario>();
  private static int nAcao;
  private static int nidAcao = 1; // Contador que define os ids das acoes
  private static int nInsc = 1; // Contador que define os ids das inscrições


  public static void ArquivosAbrir(){
    Arquivo<Acao[]> f1 = new Arquivo<Acao[]>();
    Acoes = f1.Abrir("./acoes.xml");
    nAcao = Acoes.Length;

    Arquivo<List<Voluntario>> f2 = new Arquivo<List<Voluntario>>();
    Voluntarios = f2.Abrir("./voluntarios.xml");
 
    Arquivo<List<Inscricao>> f3 = new Arquivo<List<Inscricao>>();
    Inscricoes = f3.Abrir("./inscricao.xml");
    nInsc = Inscricoes.Count;

    Arquivo<List<Comentario>> f4 = new Arquivo<List<Comentario>>();
    Comentarios = f4.Abrir("./comentario.xml");
  }
  
  public static void ArquivosSalvar(){
    Arquivo<Acao[]> f1 = new Arquivo<Acao[]>();
    f1.Salvar("./acoes.xml", Acaolistar());

    Arquivo<List<Voluntario>> f2 = new Arquivo<List<Voluntario>>();
    f2.Salvar("./voluntarios.xml", Voluntarios) ;
 
    Arquivo<List<Inscricao>> f3 = new Arquivo<List<Inscricao>>();
    f3.Salvar("./inscricao.xml", Inscricoes );

    Arquivo<List<Comentario>> f4 = new Arquivo<List<Comentario>>();
    f4.Salvar("./comentario.xml", Comentarios);    
  }
public static void CadastroAcao(Acao obj){
    
    if (nAcao == Acoes.Length)
      Array.Resize(ref Acoes,2*Acoes.Length);
    Acoes[nAcao] = obj;
    nAcao++;
    nidAcao++;
    
  }
  //metodo para retornar um obj com base no ID espicificará a especi a ser atualizada
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
    aux.SetAjuda(obj.GetAjuda());
    aux.SetCategoria(obj.GetCategoria());
  }

  public static void AcaoExcluir(Acao obj){
    int aux = Acaoid(obj.Getid());
    if (aux != -1){
      for (int i = aux;i<nAcao - 1; i++)
      Acoes[i] = Acoes[i + 1];
      nAcao--;
      }
    }
  public static int Acaoid(int id){
    for( int i =0; i < nAcao; i++ ){
    Acao obj = Acoes[i];
    if (obj.Getid() == id) return i; }
    return -1;
    }
 
  //Metodos para a classe Voluntario.
  public static void CadastroVoluntario(Voluntario obj){
    int id = 0;
    foreach(Voluntario aux in Voluntarios)
      if (aux.Getid() > id ) id = aux.Getid();
    obj.id = id + 1;
    Voluntarios.Add(obj);
    }
  
  public static List<Voluntario> ListarVoluntario(){
    return Voluntarios;
   }
  
  //metodo para retornar um voluntario baseado num id 
  
  public static Voluntario Voluntariolistar(int id){
    foreach (Voluntario obj in Voluntarios)
      if (obj.Getid() == id) return obj;
    return null;
    
  }
  
  
  public static void VoluntarioAtualizar(Voluntario obj){
    //localizara a acao com base no id especificado no metodo anterior.
    Voluntario aux = Voluntariolistar(obj.Getid());
    if (aux != null){
    aux.SetIdade(obj.GetIdade());
    aux.SetNome(obj.GetNome());
    aux.SetEnder(obj.GetEnder());
    aux.SetInte(obj.GetInte());
      }
  }

  public static void VoluntarioExcluir(Voluntario obj){
    Voluntario aux = Voluntariolistar(obj.Getid());
    if (aux != null) Voluntarios.Remove(aux);
    }
  //metodos para classe de inscrição
  public static void CadastroInscricao(Inscricao obj){
    int id = 0;
    foreach(Inscricao aux in Inscricoes)
      if (aux.GetidInsc() > id ) id = aux.GetidInsc();
    obj.idInsc = id + 1;
    Inscricoes.Add(obj);
    }
  //Encontra a ação em que o voluntario será escrito com base no id informado pelo usuário 
  public static Acao AcaoEncontrar(int id){
    foreach (Acao obj in Acoes)
      if (obj != null && obj.Getid() == id) return obj;
    return null;
    
  }
  // Contador para id de inscrição 
  public static int GetIdinsc(){
    return nInsc;
  }
  //Contador para id de voluntario 
  public static int GetIdAcao(){
    return nidAcao;
  }
  public static List<Inscricao> ListarInscricoes(){
    return Inscricoes;
  }
  public static string AcaoEncontrarNome(int id){
    foreach (Acao obj in Acoes)
      if (obj != null && obj.Getid() == id) return obj.GetNome();
    return null;
    
  }
   // retona um voluntario com base no seu ID
  public static Voluntario VoluntarioEncontrar(int id){
    foreach (Voluntario obj in Voluntarios)
      if (obj != null && obj.Getid() == id) return obj;
    return null;
  }
  // retona no nome do voluntario com base no seu ID
  public static string VoluntarioEncontrarNome(int id){
    foreach (Voluntario obj in Voluntarios)
      if (obj != null && obj.Getid() == id) return obj.GetNome();
    return null;
  }
  // retorna uma lista de todas as inscriçoes feitas por um voluntario específico
  public static List<Inscricao> InscricoesVoluntario(Voluntario voluntario){
    List<Inscricao> r = new List<Inscricao>();
    foreach(Inscricao obj in Inscricoes) 
      if (obj.GetidVoluntario() == voluntario.Getid())
        r.Add(obj);
    return r;
  }
  // retorna uma inscricao baseado no id informado pelo usuário
  public static Inscricao Inscricaolistar(int id){
    foreach (Inscricao obj in Inscricoes)
      if (obj.GetidInsc() == id) return obj;
    return null;
  }
  public static void InscricaoExcluir(Inscricao obj){
    Inscricao aux = Inscricaolistar(obj.GetidInsc());
    if (aux != null) Inscricoes.Remove(aux);
    }
   // retorna uma lista de todas as inscriçoes feitas em uma ação específica
  public static List<Inscricao> InscricoesAcao(Acao acao){
    List<Inscricao> r = new List<Inscricao>();
    foreach(Inscricao obj in Inscricoes) 
      if (obj.GetidAcao() == acao.Getid())
        r.Add(obj);
    return r;
    }
  //metodos para a classe comentarios
  public static void CadastroComentario(Comentario obj){
    int id = 0;
    foreach(Comentario aux in Comentarios)
      if (aux.Getid() > id ) id = aux.Getid();
    obj.id = id + 1;
    Comentarios.Add(obj);
    }
  public static List<Comentario> ListarComentarios(){
    return Comentarios;
    }
  public static Comentario Comentariolistar(int id){
    foreach (Comentario obj in Comentarios)
      if (obj.Getid() == id) return obj;
    return null;
    }
  public static void ComentarioAtualizar(Comentario obj){
    
    Comentario aux = Comentariolistar(obj.Getid());
    if (aux != null){
    aux.SetDescricao(obj.GetDescricao());
      }
    }
  public static void ComentarioExcluir(Comentario obj){
    Comentario aux = Comentariolistar(obj.Getid());
    if (aux != null) Comentarios.Remove(aux);
    }
  // retorna uma lista de todas os Comentarios feitos por um voluntario específico
  public static List<Comentario> CometariosVoluntario(Voluntario voluntario){
    List<Comentario> r = new List<Comentario>();
    foreach(Comentario obj in Comentarios) 
      if (obj.GetidVoluntario() == voluntario.Getid())
        r.Add(obj);
    return r;
    }
  }