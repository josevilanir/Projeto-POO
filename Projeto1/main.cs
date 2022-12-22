using System;
class Program{
  public static void Main(){
    Usuario a = new Usuario(1, 23,"Claudio", "Av alameda Zé da Dutra, 1050");
    Acao z = new Acao(1, DateTime.Parse("04/09/2022"),"Restauração de escola abandonada","Av nascimento de castro, 1050");
    Console.WriteLine(a);
    Console.WriteLine(z);
  }
}