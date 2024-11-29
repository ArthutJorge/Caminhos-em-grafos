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

      public NoArvore(Tipo informacao, NoArvore<Tipo> e, NoArvore<Tipo> d)
      {
        info = informacao;
        esq = e;
        dir = d;
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
    //... outros métodos e campos membros da classe

    public void VisitarPreOrdem()
    {
      VisitarPreOrdem(Raiz);
    }

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

    public void VisitarInOrdem()
    {
      VisitarInOrdem(Raiz);
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

    public void VisitarPosOrdem()
    {
      VisitarPosOrdem(Raiz);
    }

    private void VisitarPosOrdem(NoArvore<Dado> atual)
    {
      if (atual != null)
      {
        VisitarPosOrdem(atual.Esq);
        VisitarPosOrdem(atual.Dir);
        Console.WriteLine(atual.Info);
      }
    }

    // exercício 1
    public bool Equivalente(Arvore<Dado> outraArvore)
    {
      if (outraArvore == null)
        return false;
      // Árvore é a this
      return Equivalente(this.raiz, outraArvore.raiz);

      // na aplicação, temos duas árvores instanciadas
      // if (arvX.Equivalente(arvY))
      //    chkEquivalentes.checked = true;
      // else
      //    chkEquivalentes.checked = false;

      // ou
      //    chkEquivalentes.checked = arvX.Equivalente(arvY);
    }

    private bool Equivalente(NoArvore<Dado> atualA, NoArvore<Dado> atualB)
    {
      if (atualA == null && atualB == null)
        return true;

      if ((atualA == null) != (atualB == null))
        return false;  // uma é nula e outra não é

      // ambas são não nulas

      if (atualA.Info.CompareTo(atualB.Info) != 0)  // dados diferentes em nós correspondente
        return false;

      return Equivalente(atualA.Esq, atualB.Esq) && Equivalente(atualA.Dir, atualB.Dir);
    }

    // exercício 2

    public int QuantosNos()   // para a aplicação chamar
    {
      return QuantosNos(this.raiz);

      // na aplicação :
      // txtQuantosNos.Text = minhaArvore.QuantosNos()+"";
    }

    private int QuantosNos(NoArvore<Dado> noAtual)
    {
      if (noAtual == null)
        return 0;

      return 1 +                  // conta o nó atual
        QuantosNos(noAtual.Esq) + // conta nós da subárvore esquerda
        QuantosNos(noAtual.Dir);  // conta nós da subárvore direita
    }

    public int QuantasFolhas()    // chamado pela aplicação
    {
      return QuantasFolhas(this.raiz);  // chamada 0

      // na aplicação:
      //
      // txtQuantasFolhas.Text = minhaArvore.QuantasFolhas()+"";
    }


    private int QuantasFolhas(NoArvore<Dado> noAtual)
    {
      if (noAtual == null)
        return 0;

      if (noAtual.Esq == null && noAtual.Dir == null) // noAtual é folha
        return 1;

      // noAtual não é folha, portanto procuramos as folhas de cada ramo e as contamos
      return QuantasFolhas(noAtual.Esq) + // conta folhas da subárvore esquerda - chamada 1
             QuantasFolhas(noAtual.Dir);  // conta folhas da subárvore direita  - chamada 2
    }

    public bool EstritamenteBinaria()
    {
      return EstritamenteBinaria(this.raiz);
    }

    private bool EstritamenteBinaria(NoArvore<Dado> noAtual)
    {
      if (noAtual == null)
        return true;

      // noAtual não é nulo
      if (noAtual.Esq == null && noAtual.Dir == null)
        return true;

      // um dos descendentes é nulo e o outro não é
      if ((noAtual.Esq != null) != (noAtual.Dir != null))
        return false;

      // se chegamos aqui, nenhum dos descendentes é nulo, dai testamos a
      // "estrita binariedade" das duas subárvores descendentes do nó atual
      return EstritamenteBinaria(noAtual.Esq) && EstritamenteBinaria(noAtual.Dir);
    }

    private int Altura(NoArvore<Dado> noAtual)
    {
      if (noAtual == null)
        return 0;

      return 1 +
        Math.Max(Altura(noAtual.Esq), Altura(noAtual.Dir));
    }

    // Exercício 6 – Escrever a estrutura da árvore no formato ( Chave : AE, AD )
    public string EntreParenteses(NoArvore<Dado> noAtual)
    {
      string saida = "(";
      if (noAtual != null)
        saida += noAtual.Info + ":" +
        EntreParenteses(noAtual.Esq) +
        "," +
        EntreParenteses(noAtual.Dir);
      saida += ")";
      return saida;
    }

    // Exercício 7 – Trocar ramos esquerdo e direito entre si
    public void Trocar(NoArvore<Dado> noAtual)
    {
      if (noAtual != null)
      {
        NoArvore<Dado> auxiliar = noAtual.Esq;
        noAtual.Esq = noAtual.Dir;
        noAtual.Dir = auxiliar;
        Trocar(noAtual.Esq);
        Trocar(noAtual.Dir);
      }
    }


    // Exercício 8 – Percurso por níveis
    public string PercursoPorNiveis()   // chamado pela aplicação
    {
      return PercursoPorNiveis(this.raiz);
    }
    private string PercursoPorNiveis(NoArvore<Dado> noAtual)
    {
      string saida = "";
      var umaFila = new FilaLista<NoArvore<Dado>>();
      while (noAtual != null)
      {
        saida += " " + noAtual.Info;

        if (noAtual.Esq != null)
          umaFila.Enfileirar(noAtual.Esq);

        if (noAtual.Dir != null)
          umaFila.Enfileirar(noAtual.Dir);

        if (umaFila.EstaVazia)
           noAtual = null;      // para terminar o while
        else
          noAtual = umaFila.Retirar();
      }
      return saida;
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

    public bool ExisteRecursivo(Dado procurado)
    {
      atual = antecessor = null;
      return ExisteInterno(raiz);

      bool ExisteInterno(NoArvore<Dado> local)  // para não termos de passar procurado como parâmetro na recursão
      {
        if (local == null)
          return false;

        if (local.Info.CompareTo(procurado) == 0)
        {
          atual = local;
          return true;
        }

        antecessor = local;
        if (procurado.CompareTo(local.Info) < 0)
           return ExisteInterno(local.Esq);    // 1     Desloca apontador na 
        else                               //       próxima instância do 
           return ExisteInterno(local.Dir);    // 2     método
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

    public void InserirProcurandoODado(Dado novosDados)
    {
      bool achou = false, fim = false;
      NoArvore<Dado> novoNo = new NoArvore<Dado>(novosDados);
      if (raiz == null)         // árvore vazia
        raiz = novoNo;
      else                      // árvore não-vazia
      {
        antecessor = null;
        atual = raiz;
        while (!achou && !fim)
        {
          antecessor = atual;
          if (novosDados.CompareTo(atual.Info) < 0)
          {
            atual = atual.Esq;
            if (atual == null)
            {
              antecessor.Esq = novoNo;
              fim = true;
            }
          }
          else
              if (novosDados.CompareTo(atual.Info) == 0)
            achou = true;  // pode-se disparar uma exceção neste caso
          else
          {
            atual = atual.Dir;
            if (atual == null)
            {
              antecessor.Dir = novoNo;
              fim = true;
            }
          }
        }
      }
    }

    // inclusão não-recursiva aproveitando o método Existe já codificado
    public void IncluirNovoRegistro(Dado novoRegistro)
    {
      if (Existe(novoRegistro))
         throw new Exception("Registro com chave repetida!");

      // Chegarmos aqui indica que Existe retornou false e antecessor aponta
      // o nó que ficará como "pai" do novo nó a ser incluido na árvore
      // o novoRegistro tem uma chave inexistente, então criamos um
      // novo nó para armazená-lo e depois ligamos esse nó na árvore
      var novoNo = new NoArvore<Dado>(novoRegistro);

      // se a árvore está vazia, a raiz passará a apontar esse novo nó
      if (raiz == null)
        raiz = novoNo;
      else
        // nesse caso, antecessor aponta o pai do novo registro e
        // verificamos em qual ramo o novo nó será ligado
        if (novoRegistro.CompareTo(antecessor.Info) < 0)  // novo é menor que antecessor 
           antecessor.Esq = novoNo;		// vamos para a esquerda
        else
          antecessor.Dir = novoNo;    // ou vamos para a direita
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

    public NoArvore<Dado> ProcuraMenorDosMaioresDescendentes(NoArvore<Dado> noParaExcluir)
    {
      NoArvore<Dado> paiDoSucessor = noParaExcluir;
      NoArvore<Dado> sucessor = noParaExcluir;
      NoArvore<Dado> atualExc = noParaExcluir.Dir;
      while (atualExc != null)
      {
        if (atualExc.Esq != null)
           paiDoSucessor = sucessor;
        sucessor = atualExc;
        atualExc = atualExc.Esq;
      }
      if (sucessor != noParaExcluir.Dir)
         paiDoSucessor.Esq = sucessor.Dir;
      return sucessor;
    }

    public bool RemoverRegistro(Dado registroARemover)
    {
      atual = raiz;
      antecessor = null;
      bool ehFilhoEsquerdo = true;
      while (atual!=null && atual.Info.CompareTo(registroARemover) != 0) // enqto não acha a chave a remover
      {
        antecessor = atual;
        if (atual.Info.CompareTo(registroARemover) > 0)
        {
          ehFilhoEsquerdo = true;
          atual = atual.Esq;
        }
        else
        {
          ehFilhoEsquerdo = false;
          atual = atual.Dir;
        }

        if (atual == null)  // neste caso, a chave a remover não existe e não pode
          return false;    // ser excluída, dai retornamos falso indicando isso
      }  // fim do while

      // se fluxo de execução vem para este ponto, a chave a remover foi encontrada
      // e o ponteiro atual indica o nó que contém essa chave
      if ((atual.Esq == null) && (atual.Dir == null))  // é folha, nó com 0 filhos
      {
        if (atual == raiz)
           raiz = null;   // exclui a raiz e a árvore fica vazia
        else
          if (ehFilhoEsquerdo)        // se for filho esquerdo, o antecessor deixará 
             antecessor.Esq = null;   // de ter um descendente esquerdo
          else                     // se for filho direito, o antecessor deixará de 
             antecessor.Dir = null; // apontar para esse filho

        atual = antecessor;  // feito para atual apontar um nó válido ao sairmos do método
      }
      else   // verificará as duas outras possibilidades, exclusão de nó com 1 ou 2 filhos
        if (atual.Dir == null)   // neste caso, só tem o filho esquerdo
        {
          if (atual == raiz)
            raiz = atual.Esq;
          else
            if (ehFilhoEsquerdo)
               antecessor.Esq = atual.Esq;
            else
              antecessor.Dir = atual.Esq;
          atual = antecessor;
        }
        else
          if (atual.Esq == null)  // neste caso, só tem o filho direito
          {
            if (atual == raiz)
              raiz = atual.Dir;
            else
              if (ehFilhoEsquerdo)
              antecessor.Esq = atual.Dir;
            else
              antecessor.Dir = atual.Dir;
            atual = antecessor;
          }
          else // tem os dois descendentes
          {
            NoArvore<Dado> menorDosMaiores = ProcuraMenorDosMaioresDescendentes(atual);
            atual.Info = menorDosMaiores.Info;
            atual.Dir = menorDosMaiores.Dir;
            //menorDosMaiores = null; // para liberar o nó trocado da memória
          }
      return true;
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

        public Arvore<Dado> ClonarArvore()
        {
            Arvore<Dado> arvore = new Arvore<Dado>();
            arvore.qtosNos = this.qtosNos;
            arvore.Raiz = ClonarNo(this.Raiz);
            return arvore;
        }

        private NoArvore<Dado> ClonarNo(NoArvore<Dado> noArvoreOg)
        {
            if (noArvoreOg == null)
                return null;

            NoArvore<Dado> novoNo = new NoArvore<Dado>();
            novoNo.Info = noArvoreOg.Info;

            novoNo.esq = ClonarNo(noArvoreOg.esq);
            novoNo.dir = ClonarNo(noArvoreOg.dir);

            return novoNo;
        }

        public Arvore<Dado> EspelharArvore()
        {
            Arvore<Dado> copia = new Arvore<Dado>
            {
                qtosNos = this.qtosNos,
                raiz = EspelharArvore(this.Raiz)
            };

            return copia;
        }

        public NoArvore<Dado> EspelharArvore(NoArvore<Dado> noArvore)
        {
            if (noArvore == null)
                return null;

            NoArvore<Dado> copiaInfo = new NoArvore<Dado>();
            copiaInfo.Info = noArvore.Info;

            copiaInfo.dir = EspelharArvore(noArvore.esq);
            copiaInfo.esq = EspelharArvore(noArvore.dir);

            return copiaInfo;
        }



    }
