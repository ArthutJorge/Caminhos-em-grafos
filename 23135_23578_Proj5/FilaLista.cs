using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class FilaLista<Tipo> : IQueue<Tipo>
                               where Tipo : IComparable<Tipo>
{

  protected NoFila<Tipo> primeiro, ultimo, atual, anterior;
  int quantosNos;
  public void Enfileirar(Tipo elemento) // inclui objeto “elemento”
  {
      var novoNo = new NoFila<Tipo>(elemento);
      if (EstaVazia)
         primeiro = novoNo;
      else
        ultimo.Prox = novoNo;

      ultimo = novoNo;
      ultimo.Prox = null;
      quantosNos++;
  }
  public Tipo Retirar() // devolve objeto do início e o
  { // retira da fila
    if (!EstaVazia)
    {
      Tipo elemento = primeiro.Info;
      primeiro = primeiro.Prox;
      if (primeiro == null)
         ultimo = null;
      quantosNos--;
      return elemento;
    }
    throw new Exception("Fila vazia");
  }
  public Tipo OInicio() // devolve objeto do início
  { // sem retirá-lo da fila
    if (EstaVazia)
      throw new Exception("Fila vazia");
    
    Tipo o = primeiro.Info; // acessa o 1o objeto genérico
    return o;
  }
  public Tipo OFim() // devolve objeto do fim
  { // sem retirá-lo da fila
    if (EstaVazia)
      throw new Exception("Fila vazia");
    Tipo o = ultimo.Info; // acessa o 1o objeto genérico
    return o;
  }
  // devolve número de elementos da fila
  public int Tamanho { get => quantosNos; }
  public bool EstaVazia { get => primeiro == null; }
  public List<Tipo> Listar()
  {
    var lista = new List<Tipo>();
    atual = primeiro;
    while (atual != null)
    {
      lista.Add(atual.Info);
      atual = atual.Prox;
    }
    return lista;
  }
}
