using System;
using System.IO;
using System.Windows.Forms;

public class Caminho : IComparable<Caminho>, IRegistro
{
    public Cidade CidadeOrigem { get; set; }
    public Cidade CidadeDestino { get; set; }
    public int Distancia { get; set; }
    public int Tempo { get; set; }
    public int Custo { get; set; }

    public int TamanhoRegistro => 2 * CidadeDestino.TamanhoRegistro + 3 * sizeof(int);

    // Construtor
    public Caminho(Cidade cidadeOrigem, Cidade cidadeDestino, int distancia, int tempo, int custo)
    {
        CidadeOrigem = cidadeOrigem;
        CidadeDestino = cidadeDestino;
        Distancia = distancia;
        Tempo = tempo;
        Custo = custo;
    }

    public Caminho(Cidade cidadeDestino)
    {
        CidadeDestino = cidadeDestino;
    }

    // Método de comparação para ordenar ou comparar Caminhos
    public int CompareTo(Caminho outro)
    {
        if (outro == null)
            return 1;

        // Exemplo de comparação com base na distância
        return this.CidadeDestino.CompareTo(outro.CidadeDestino);
    }

    public void LerRegistro(BinaryReader arquivo, long qualRegistro)
    {
        if (arquivo != null)  // arquivo instanciado e aberto
        {
            try
            {
                long qtosBytes = qualRegistro * TamanhoRegistro;
                arquivo.BaseStream.Seek(qtosBytes, SeekOrigin.Begin);

                this.CidadeOrigem.LerRegistro(arquivo);
                this.CidadeDestino.LerRegistro(arquivo);

                this.Distancia = arquivo.ReadInt32();
                this.Tempo = arquivo.ReadInt32();
                this.Custo = arquivo.ReadInt32();
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
            char[] umNomeOrigem = new char[15];
            char[] umNomeDestino = new char[15];  // vetor de char com 30 posições 
            for (int i = 0; i < 15; i++)   // para receber os caracteres da 
            {
                umNomeOrigem[i] = CidadeOrigem.NomeCidade[i];
                umNomeDestino[i] = CidadeDestino.NomeCidade[i];  // string nome
            }
            arquivo.Write(umNomeOrigem);
            arquivo.Write(umNomeDestino);

            arquivo.Write(Distancia);                
            arquivo.Write(Tempo);
            arquivo.Write(Custo);
        }
    }
}
