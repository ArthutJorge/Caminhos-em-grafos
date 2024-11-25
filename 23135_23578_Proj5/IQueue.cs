using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IQueue<Tipo>
{
  void Enfileirar(Tipo elemento);
  Tipo Retirar();
  Tipo OInicio();
  Tipo OFim();
  List<Tipo> Listar();
  int Tamanho { get; }
  bool EstaVazia { get; }
}