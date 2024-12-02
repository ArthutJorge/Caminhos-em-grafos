using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;


  public class Arvore<Dado> where Dado : IComparable<Dado>,IRegistro, new() // entidade terá construtor sem parâmetros
  {
    public class NoArvore<Tipo> : IComparable<NoArvore<Tipo>>
        where Tipo : IComparable<Tipo>, IRegistro, new()
    {
      Tipo info;
      public NoArvore<Tipo> esq, dir;

      public NoArvore()
      {
        info = default(Tipo);
        esq = dir = null;
      }

      public NoArvore(Tipo informacao)
      {
        info = informacao;
        esq = dir = null;
      }

      public Tipo Info { get => info; set => info = value; }
      public NoArvore<Tipo> Esq { get => esq; set => esq = value; }
      public NoArvore<Tipo> Dir { get => dir; set => dir = value; }

      public int CompareTo(NoArvore<Tipo> outro)
      {
        if (outro != null)
          return this.info.CompareTo(outro.info);

        return -1;
      }

      public bool Equals(NoArvore<Tipo> outro)
      {
        return this.info.Equals(outro.info);
      }

    }

    // Classe árvore

    NoArvore<Dado> raiz, atual, antecessor;
    int qtosNos;

    public Arvore()
    {
      raiz = null;
      atual = null;
      antecessor = null;
      qtosNos = 0;
    }

    public NoArvore<Dado> Raiz
    {
      get => raiz;
      set => raiz = value;
    }
    public NoArvore<Dado> Atual { get => atual; set => atual = value; }
    public NoArvore<Dado> Anterior { get => antecessor; set => antecessor = value; }

    public ListaSimples<Dado> RetornarLista()
    {
        ListaSimples<Dado> lista = new ListaSimples<Dado>();
        CriarLista(ref lista, raiz);
        return lista;
    }

    private void CriarLista(ref ListaSimples<Dado> lista, NoArvore<Dado> dadoAtual)
    {
        if(dadoAtual != null)
        {
            lista.InserirAposFim(dadoAtual.Info);
            CriarLista(ref lista, dadoAtual.Esq);
            CriarLista(ref lista, dadoAtual.Dir);
        }
    }

    private void VisitarPreOrdem(NoArvore<Dado> atual)
    {
      if (atual != null)
      {
        Console.WriteLine(atual.Info);
        VisitarPreOrdem(atual.Esq);
        VisitarPreOrdem(atual.Dir);
      }
    }

    private void VisitarInOrdem(NoArvore<Dado> atual)
    {
      if (atual != null)
      {
        VisitarInOrdem(atual.Esq);
        Console.WriteLine(atual.Info);
        VisitarInOrdem(atual.Dir);
      }
    }

    public int QuantosNos()   
    {
      return QuantosNos(this.raiz);
    }

    private int QuantosNos(NoArvore<Dado> noAtual)
    {
      if (noAtual == null)
        return 0;

      return 1 +                  // conta o nó atual
        QuantosNos(noAtual.Esq) + // conta nós da subárvore esquerda
        QuantosNos(noAtual.Dir);  // conta nós da subárvore direita
    }

    public void DesenharArvore(bool v, int x, int y, Graphics g)
    {
        DesenharArvore(true, this.raiz, x, y, Math.PI / 2, 1, 300, g);
    }

    private void DesenharArvore(bool primeiraVez, NoArvore<Dado> noAtual,
                                int x, int y, double angulo, double incremento,
                                double comprimento, Graphics g)
    {
        int xf, yf;
        if (noAtual != null)
        {
            Pen caneta = new Pen(Color.Red);
            xf = (int)Math.Round(x + Math.Cos(angulo) * comprimento);
            yf = (int)Math.Round(y + Math.Sin(angulo) * comprimento);

            if (primeiraVez)
                yf = 25;

            g.DrawLine(caneta, x, y, xf, yf);

            DesenharArvore(false, noAtual.Esq, xf, yf, Math.PI / 2 + incremento,
                           incremento * 0.60, comprimento * 0.75, g);

            DesenharArvore(false, noAtual.Dir, xf, yf, Math.PI / 2 - incremento,
                           incremento * 0.60, comprimento * 0.75, g);

            SolidBrush preenchimento = new SolidBrush(Color.Blue);
            // Desenhando o quadrado com as dimensões ajustadas
            g.FillRectangle(preenchimento, xf - 45, yf - 7, 90, 45); // Ajuste de largura e altura

            // Centralização do texto (nome do nó)
            string texto = noAtual.Info.ToString();
            Font fonte = new Font("Comic Sans", 10);
            SizeF tamanhoTexto = g.MeasureString(texto, fonte);

            float textoX = xf + 2 - (tamanhoTexto.Width / 2); // Centraliza horizontalmente
            float textoY = yf + 9 - (tamanhoTexto.Height / 2); // Centraliza verticalmente

            g.DrawString(texto, fonte, new SolidBrush(Color.White), textoX, textoY);

            // Adicionando a quantidade de caminhos abaixo do nome
            string quantidadeCaminhos = noAtual.Info.QuantosCaminhos.ToString();
            Font fonteCaminho = new Font("Comic Sans", 8);
            g.DrawString(quantidadeCaminhos + " Caminho(s)", fonteCaminho, new SolidBrush(Color.White), xf - 35, textoY+15);
        }
    }

    public void LerArquivoDeRegistros(string nomeArquivo)
    {
      raiz = null;            // limpa a árvore
      Dado dado = new Dado(); // classe genérica chama o construtor sem parâmetros
      var origem = new FileStream(nomeArquivo, FileMode.OpenOrCreate);
      var arquivo = new BinaryReader(origem);
      int posicaoFinal = (int)origem.Length / dado.TamanhoRegistro - 1;
      this.qtosNos = posicaoFinal + 1;
      Particionar(0, posicaoFinal, ref raiz);
      origem.Close();
      
      void Particionar(long inicio, long fim, ref NoArvore<Dado> atual)
      {
        if (inicio <= fim)
        {
          long meio = (inicio + fim) / 2;
          dado = new Dado();       // cria um objeto para armazenar os dados
          dado.LerRegistro(arquivo, meio); // 
          atual = new NoArvore<Dado>(dado);
          Particionar(inicio, meio - 1, ref atual.esq);   // Particiona à esquerda 
          var novoDir = atual.Dir;
          Particionar(meio + 1, fim, ref atual.dir);      // Particiona à direita  
        }
      }
    }

    public bool Existe(Dado procurado)
    {
      antecessor = null;
      atual = raiz;
      while (atual != null)
      {
        if (atual.Info.CompareTo(procurado) == 0)
           return true;

        antecessor = atual;
        if (procurado.CompareTo(atual.Info) < 0)
           atual = atual.esq;     // Desloca apontador para o ramo à esquerda
        else
          atual = atual.dir;      // Desloca apontador para o ramo à direita
      }
      return false;       // Se local == null, a chave não existe
    }

    public void Incluir(Dado dadoLido)
    {
      IncluirRecursivo(ref raiz, dadoLido);
    }

    private void IncluirRecursivo(ref NoArvore<Dado> atual, Dado dadoLido)
    {
      if (atual == null)
        atual = new NoArvore<Dado>(dadoLido);
      else
        if (dadoLido.CompareTo(atual.Info) == 0)
        throw new Exception("Já existe esse registro!");
      else
          if (dadoLido.CompareTo(atual.Info) < 0)
          {
            IncluirRecursivo(ref atual.esq, dadoLido);
          }
          else
          {
            IncluirRecursivo(ref atual.dir, dadoLido);
          }
    }

    public bool ExcluirRecursivo(Dado procurado)
    {
      return ExcluirInterno(ref raiz);

      bool ExcluirInterno(ref NoArvore<Dado> atual)
      {
        NoArvore<Dado> atualAnt;
        if (atual == null)
          return false; // não achou procurado
        else
          if (atual.Info.CompareTo(procurado) > 0)
        {
          var temp = atual.Esq;
          bool result = ExcluirInterno(ref temp);
          atual.Esq = temp;
          return result;
        }
        else
            if (atual.Info.CompareTo(procurado) < 0)
        {
          var temp = atual.Dir;
          bool result = ExcluirInterno(ref temp);
          atual.Dir = temp;
          return result;
        }
        else    // achou procurado
        {
          atualAnt = atual;   // nó a retirar 
          if (atual.Dir == null)
            atual = atual.Esq;
          else
            if (atual.Esq == null)
            atual = atual.Dir;
          else
          {   // pai de 2 filhos 
            var temp = atual.Esq;
            Rearranjar(ref temp, ref atualAnt);
          }
          return true;
        }
      }

      void Rearranjar(ref NoArvore<Dado> aux, ref NoArvore<Dado> atualAnt)
      {
        if (aux.Dir != null)
        {
          NoArvore<Dado> temp = aux.Dir;
          Rearranjar(ref temp, ref atualAnt);  // Procura Maior
          aux.Dir = temp;
        }
        else
        {                           // Guarda os dados do nó a excluir
          atualAnt.Info = aux.Info;   // troca conteúdo!
          aux = aux.Esq;
        }
      }
    }

    public void GravarArquivoDeRegistros(string nomeArquivo)
    {
      var destino = new FileStream(nomeArquivo, FileMode.Create);
      var arquivo = new BinaryWriter(destino);
      GravarInOrdem(raiz);
      arquivo.Close();

      void GravarInOrdem(NoArvore<Dado> r)
      {
        if (r != null)
        {
          GravarInOrdem(r.Esq);
          r.Info.GravarRegistro(arquivo);
          GravarInOrdem(r.Dir);
        }
      }
    }


  }
