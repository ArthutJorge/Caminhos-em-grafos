using System;
using System.IO;
using System.Windows.Forms;

public class Cidade : IComparable<Cidade>, IRegistro
{
  public const int tamanhoNome = 15;

  string nomeCidade;
  double coordenadaX;
  double coordenadaY;

  const int tamanhoRegistro = tamanhoNome + 2 * sizeof(double);

  public int TamanhoRegistro => tamanhoRegistro;

  public Cidade()
  {
    NomeCidade = "";
    CoordenadaX = 0.0;
    CoordenadaY = 0.0;
  }

  public Cidade(string nomeCidade, double coordenadaX, double coordenadaY)
  {
    this.NomeCidade = "";
    this.CoordenadaX = 0.0;
    this.CoordenadaY = 0.0;
  }

  public Cidade(string nomeCidade)
  {
    this.nomeCidade = nomeCidade;
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
       
        this.nomeCidade = nomeLido;      // atribui a string nomeLido para o atributo nome

        this.CoordenadaX = arquivo.ReadDouble();
        this.CoordenadaY = arquivo.ReadDouble();
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

  public string NomeCidade
  {
    get => nomeCidade;
    set => nomeCidade = value.PadRight(tamanhoNome, ' ').Substring(0, tamanhoNome);
  }
  public double CoordenadaX { get => coordenadaX; set => coordenadaX = value; }
  public double CoordenadaY { get => coordenadaY; set => coordenadaY = value; }

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

        this.nomeCidade = nomeLido;      // atribui a string nomeLido para o atributo nome

        this.CoordenadaX = arquivo.ReadDouble();
        this.CoordenadaY = arquivo.ReadDouble();
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
    }
  }
}
