using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class Form1 : Form
{
    Arvore<Cidade> aArvore;
    Cidade cidadeSelecionada;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        aArvore = new Arvore<Cidade>();

        // Caminhos relativos
        string caminhoCidades = @"..\..\CidadesMarte.dat";
        string caminhoCaminhos = @"..\..\CaminhoEntreCidadesMarte.dat";

        // Ler as cidades
        aArvore.LerArquivoDeRegistros(caminhoCidades);

        var origem = new FileStream(caminhoCaminhos, FileMode.OpenOrCreate);
        var arquivo = new BinaryReader(origem);

        Caminho umCaminho = new Caminho();
        int posicaoFinal = (int)origem.Length / umCaminho.TamanhoRegistro - 1;

        for (int qualRegistro = 0; qualRegistro <= posicaoFinal; qualRegistro++)
        {
            umCaminho = new Caminho();
            umCaminho.LerRegistro(arquivo, qualRegistro);

            // Procurar a cidade de origem na árvore
            if (aArvore.Existe(umCaminho.CidadeOrigem))
            {
                // Adicionar o caminho à lista de caminhos da cidade de origem
                aArvore.Atual.Info.Caminhos.InserirAposFim(umCaminho);
            }
        }

        origem.Close();
    }


    private void pbCaminhos_Paint(object sender, PaintEventArgs e)
        {
           /* var ondeDesenhar = e.Graphics;
            SolidBrush brush;
            Font fonte = new Font("Tahoma", 10); // fonte e tamanho do nome da cidade
            int radio = 4;

            if (listaCidades != null && listaCidades.Length > 0) // se dados não for vazio
                foreach (var lista in listaCidades) // percorre todas cidades
                    if (lista != null && lista.Count > 0)
                        foreach (Cidade cidade in lista)
                        {
                            if (cidade.nome == txtNome.Text && cidade.x == (double)udX.Value && cidade.y == (double)udY.Value)
                                brush = new SolidBrush(Color.Red); // se for a cidade pesquisada o ponto e nome ficarão vermelho
                            else
                                brush = new SolidBrush(Color.Black);
                            ondeDesenhar.FillEllipse(brush, (float)(cidade.x * pbMapa.Width), (float)(cidade.y * pbMapa.Height), radio * 2, radio * 2); // desenha o ponto
                            ondeDesenhar.DrawString(cidade.nome, fonte, brush, (float)(cidade.x * pbMapa.Width), (float)(cidade.y * pbMapa.Height - 15)); // escreve o nome em cima do ponto
                        }*/




        }

        private void btnIncluirCidade_Click(object sender, EventArgs e)
        {
            string nome = tbNomeCidade.Text;
            double x = (double)numXCidade.Value;
            double y = (double)numYCidade.Value;

            /*if (nome != "")
            {
                Cidade novaCidade = new Cidade(nome, x, y);
                if (!arvore.Existe(novaCidade))
                {
                    cidadeSelecionada = novaCidade;

                    //incluir na arvore binaria a nova cidade
                }
                else { MessageBox.Show("Cidade já existe!"); }
            }
            else { MessageBox.Show("Coloque um nome para a cidade!"); }*/
        }

        private void btnExcluirCidade_Click(object sender, EventArgs e)
        {
            string nome = tbNomeCidade.Text;

            /*if (nome != "")
            {
                Cidade cidadeAExcluir = new Cidade(nome);

                if (arvore.Existe(cidadeAExcluir))
                {
                    cidadeSelecionada = null;
                    //excluir da arvore   
                }
            }
            else { MessageBox.Show("Coloque um nome para a cidade!"); }*/
        }

        private void btnAlterarCidade_Click(object sender, EventArgs e)
        {
            string nome = tbNomeCidade.Text;
            double novoX = (double)numXCidade.Value;
            double novoY = (double)numYCidade.Value;

            Cidade cidade = new Cidade(nome);

            /*if (arvore.Existe(cidade))
            {
                //atualizar x e y do nó da arvore   
            }*/
        }

        private void btnExibirCidade_Click(object sender, EventArgs e)
        {
            string nome = tbNomeCidade.Text;

            Cidade cidade = new Cidade(nome);

            /*if (arvore.Existe(cidade))
            {
                //obter a arvore
                //preencher nome, x, y e listar todos os caminhos
            }*/
        }


    private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControl.SelectedTab == tabArvore) // Verifica se a aba ativa é tabArvore
        {
            pbArvore.Invalidate(); // Força a chamada do evento Paint do PictureBox
        }
    }

    private void pbArvore_Paint(object sender, PaintEventArgs e)
    {
        if (aArvore?.Raiz != null) // Verifica se a árvore não está vazia
        {
            Graphics g = e.Graphics;
            aArvore.DesenharArvore(true, pbArvore.Width/2, pbArvore.Height, g);
        }
    }
}
