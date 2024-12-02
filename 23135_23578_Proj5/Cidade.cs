using System;
using System.IO;
using System.Windows.Forms;

public class Cidade : IComparable<Cidade>, IRegistro
{
    public const int tamanhoNome = 15;

    string nomeCidade;
    double coordenadaX;
    double coordenadaY;
    ListaSimples<Caminho> caminhos;

    const int tamanhoRegistro = tamanhoNome + 2 * sizeof(double);

    public int TamanhoRegistro => tamanhoRegistro;
    public string NomeCidade
    {
        get => nomeCidade;
        set
        {
            string nomeAjustado = value.Replace('\0', ' ')
                                       .PadRight(tamanhoNome, ' ')
                                       .Substring(0, tamanhoNome);
            nomeCidade = nomeAjustado;
        }
    }

    public int QuantosCaminhos => caminhos.QuantosNos;

    public Cidade()
    {
        NomeCidade = "";
        CoordenadaX = 0.0;
        CoordenadaY = 0.0;
        Caminhos = new ListaSimples<Caminho>();
    }


    public Cidade(string nomeCidade, double coordenadaX, double coordenadaY)
    {
        NomeCidade = nomeCidade;
        CoordenadaX = coordenadaX;
        CoordenadaY = coordenadaY;
        Caminhos = new ListaSimples<Caminho>();
    }

    public Cidade(string nomeCidade)
    {
        NomeCidade = nomeCidade;
        CoordenadaX = 0.0;
        CoordenadaY = 0.0;
    }

    public int CompareTo(Cidade outraCidade)
    {
        return NomeCidade.CompareTo(outraCidade.NomeCidade);
    }

    public override string ToString()
    {
        return NomeCidade;
    }

  public void LerRegistro(BinaryReader arquivo, long qualRegistro)
  {
    if (arquivo != null)  // arquivo instanciado e aberto
    {
      try
      {
        long qtosBytes = qualRegistro * TamanhoRegistro;
        arquivo.BaseStream.Seek(qtosBytes, SeekOrigin.Begin);

        char[] umNome = new char[tamanhoNome];  // vetor de char para guardar o nome lido
        umNome = arquivo.ReadChars(tamanhoNome);
        string nomeLido = "";

        for (int i = 0; i < tamanhoNome; i++) // percorre o vetor de char 
          nomeLido += umNome[i];              // e concatena cada caracter na string nomeLido
       
        NomeCidade = nomeLido;      // atribui a string nomeLido para o atributo nome

        CoordenadaX = arquivo.ReadDouble();
        CoordenadaY = arquivo.ReadDouble();
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
    }
  }

  public void GravarRegistro(BinaryWriter arquivo)
  {
    if (arquivo != null)
    {
      char[] umNome = new char[tamanhoNome];  // vetor de char com 30 posições 
      for (int i = 0; i < tamanhoNome; i++)   // para receber os caracteres da 
        umNome[i] = nomeCidade[i];                  // string nome
      arquivo.Write(umNome);                  // grava vetor de char com 30 posições
      arquivo.Write(CoordenadaX);                 // grava 8 bytes (double)
      arquivo.Write(CoordenadaY);                 // grava 8 bytes (double)
    }
  }

  public double CoordenadaX { get => coordenadaX; set => coordenadaX = value; }
  public double CoordenadaY { get => coordenadaY; set => coordenadaY = value; }
  public ListaSimples<Caminho> Caminhos { get => caminhos; set => caminhos = value; }

    public void LerRegistro(BinaryReader arquivo)   // sobrecarga para leitura sequencial
    {
        if (arquivo != null)  // arquivo instanciado e aberto
        {
            try
            {
                char[] umNome = new char[tamanhoNome];  // vetor de char para guardar o nome lido
                umNome = arquivo.ReadChars(tamanhoNome);
                string nomeLido = "";

                for (int i = 0; i < tamanhoNome; i++) // percorre o vetor de char 
                    nomeLido += umNome[i];              // e concatena cada caracter na string nomeLido

                NomeCidade = nomeLido;      // atribui a string nomeLido para o atributo nome

                CoordenadaX = arquivo.ReadDouble();
                CoordenadaY = arquivo.ReadDouble();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
