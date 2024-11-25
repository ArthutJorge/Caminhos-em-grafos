using System;
using System.IO;
using System.Windows.Forms;

public partial class Form1 : Form
{
    Arvore<Cidade> aArvore;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        aArvore = new Arvore<Cidade>();
        string caminhoBase = AppDomain.CurrentDomain.BaseDirectory;

        // Caminhos relativos
        string caminhoCidades = Path.Combine(caminhoBase, "CidadesMarte.dat");
        string caminhoCaminhos = Path.Combine(caminhoBase, "CaminhosEntreCidadesMarte.dat");

        // Carregar o arquivo de cidades
        if (File.Exists(caminhoCidades))
        {
            using (var leitor = new BinaryReader(File.OpenRead(caminhoCidades)))
            {
                while (leitor.BaseStream.Position < leitor.BaseStream.Length)
                {
                    var cidade = new Cidade();
                    cidade.LerDados(leitor);
                    aArvore.Inserir(cidade);
                }
            }
        }
    }
}
