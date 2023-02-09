using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;


public class Arquivo<T>{

  public List<T> Abrir(string arquivo){
    List<T> obj;
    XmlSerializer xml = new XmlSerializer (typeof(List<T>));
    StreamReader f = null;
    try {
      f = new StreamReader(arquivo);
      obj = (List<T>) xml.Deserialize(f);
    } catch(Exception) {
      obj = new List<T>();
    }
    f.Close();
    return obj;
  }

  public void Salvar(string arquivo, List<T> obj){
    XmlSerializer xml = new XmlSerializer (typeof(List<T>));
    StreamWriter f = new StreamWriter(arquivo, false);
    xml.Serialize(f, obj);
    f.Close();
  }
}