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
                aArvore.Atual.Info.Caminhos.InserirAposFim(umCaminho);
                aArvore.Existe(umCaminho.CidadeDestino);
                var dado = aArvore.Atual.Info;
                umCaminho.CidadeDestino.CoordenadaX = dado.CoordenadaX;
                umCaminho.CidadeDestino.CoordenadaY = dado.CoordenadaY;
            }
        }

        origem.Close();
    }

    private void pbCaminhos_Paint(object sender, PaintEventArgs e)
    {
        var ondeDesenhar = e.Graphics;
        int radio = 4;
        SolidBrush brush;
        Font fonte = new Font("Tahoma", 10); // fonte e tamanho do nome da cidade

        if (aArvore.QuantosNos() > 0)
        {
            ListaSimples<Cidade> listaCidades = aArvore.RetornarLista();

            // Verifica se a cidadeSelecionada existe
            if (cidadeSelecionada != null)
                aArvore.Existe(cidadeSelecionada);

            var ArvoreSelecionadaInfo = aArvore.Atual.Info;

            if (listaCidades != null && listaCidades.Contar() > 0)
            {
                NoLista<Cidade> no = listaCidades.Primeiro;

                // Desenha as cidades
                while (no != null)
                {
                    Cidade cidadeAtual = no.Info;

                    // Define a cor para a cidade selecionada ou não
                    brush = cidadeSelecionada != null && cidadeAtual.NomeCidade == cidadeSelecionada.NomeCidade
                            ? new SolidBrush(Color.Red) // Cidade selecionada
                            : new SolidBrush(Color.Black); // Cidades não selecionadas

                    // Desenha a cidade como um ponto
                    float xCidade = (float)(cidadeAtual.CoordenadaX * pbCaminhos.Width);
                    float yCidade = (float)(cidadeAtual.CoordenadaY * pbCaminhos.Height);
                    ondeDesenhar.FillEllipse(brush, xCidade - radio, yCidade - radio, radio * 2, radio * 2);
                    ondeDesenhar.DrawString(cidadeAtual.NomeCidade, fonte, brush, xCidade, yCidade - 15);

                    no = no.Prox;
                }

                // Desenha os caminhos da cidade selecionada
                if (cidadeSelecionada != null)
                {
                    var caminhoAtual = ArvoreSelecionadaInfo.Caminhos.Primeiro;
                    while (caminhoAtual != null)
                    {
                        Cidade cidadeDestino = caminhoAtual.Info.CidadeDestino;

                        // Calcula as posições para desenhar a linha entre as cidades
                        float xOrigem = (float)(ArvoreSelecionadaInfo.CoordenadaX * pbCaminhos.Width);
                        float yOrigem = (float)(ArvoreSelecionadaInfo.CoordenadaY * pbCaminhos.Height);
                        float xDestino = (float)(cidadeDestino.CoordenadaX * pbCaminhos.Width);
                        float yDestino = (float)(cidadeDestino.CoordenadaY * pbCaminhos.Height);

                        // Desenha a linha entre as cidades
                        using (Pen caneta = new Pen(Color.Blue))
                            ondeDesenhar.DrawLine(caneta, xOrigem, yOrigem, xDestino, yDestino);

                        caminhoAtual = caminhoAtual.Prox;
                    }
                }
            }
        }
    }



    private void btnIncluirCidade_Click(object sender, EventArgs e)
    {
        string nome = tbNomeCidade.Text;
        double x = (double)numXCidade.Value;
        double y = (double)numYCidade.Value;

        if (nome != "")
        {
            Cidade novaCidade = new Cidade(nome, x, y);
            if (!aArvore.Existe(novaCidade))
            {
                cidadeSelecionada = novaCidade;
                aArvore.Incluir(novaCidade);
            }
            else { MessageBox.Show("Cidade já existe!"); }
        }
        else { MessageBox.Show("Coloque um nome para a cidade!"); }
        pbCaminhos.Invalidate();
    }

    private void btnExcluirCidade_Click(object sender, EventArgs e)
    {
        string nome = tbNomeCidade.Text;

        if (nome != "")
        {
            Cidade cidadeAExcluir = new Cidade(nome);

            if (aArvore.Existe(cidadeAExcluir))
            {
                cidadeSelecionada = null;
                aArvore.ExcluirRecursivo(cidadeAExcluir);
            }
        }
        else { MessageBox.Show("Coloque um nome para a cidade a ser excluida!"); }
        pbCaminhos.Invalidate();
    }

        private void btnAlterarCidade_Click(object sender, EventArgs e)
        {
            string nome = tbNomeCidade.Text;
            double novoX = (double)numXCidade.Value;
            double novoY = (double)numYCidade.Value;

            Cidade cidade = new Cidade(nome);

            if (aArvore.Existe(cidade))
            {
                aArvore.Atual.Info.CoordenadaX = novoX;
                aArvore.Atual.Info.CoordenadaY = novoY;
            }
            else { 
                MessageBox.Show("Não existe essa cidade!");
            }
            pbCaminhos.Invalidate();
        }

    private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControl.SelectedTab == tabArvore) // Verifica se a aba ativa é tabArvore
        {
            pbArvore.Invalidate(); // Força a chamada do evento Paint do PictureBox
        }
    }

    private void btnExibirCidade_Click(object sender, EventArgs e)
    {
        string nome = tbNomeCidade.Text;
        Cidade cidade = new Cidade(nome);

        if (aArvore.Existe(cidade))
        {
            cidadeSelecionada = aArvore.Atual.Info;
            numXCidade.Value = (decimal)aArvore.Atual.Info.CoordenadaX;
            numYCidade.Value = (decimal)aArvore.Atual.Info.CoordenadaY;

            if (dtCaminhos.Columns.Count == 0)
            {
                dtCaminhos.Columns.Add("Destino", "Destino");
                dtCaminhos.Columns.Add("Distancia", "Distância");
                dtCaminhos.Columns.Add("Tempo", "Tempo");
                dtCaminhos.Columns.Add("Custo", "Custo");
            }
            dtCaminhos.Rows.Clear();

            cidadeSelecionada.Caminhos.iniciarPercursoSequencial();
            if(cidadeSelecionada.Caminhos.Primeiro != null)
            {
                string nomeCidade = cidadeSelecionada.Caminhos.Atual.Info.CidadeDestino.NomeCidade;   // primeiro acesso
                int distancia = cidadeSelecionada.Caminhos.Atual.Info.Distancia;
                int tempo = cidadeSelecionada.Caminhos.Atual.Info.Tempo;
                int custo = cidadeSelecionada.Caminhos.Atual.Info.Custo;
                dtCaminhos.Rows.Add(nomeCidade, distancia, tempo, custo);
                while (cidadeSelecionada.Caminhos.podePercorrer())
                {
                    nomeCidade = cidadeSelecionada.Caminhos.Atual.Info.CidadeDestino.NomeCidade;   //demais acessos
                    distancia = cidadeSelecionada.Caminhos.Atual.Info.Distancia;
                    tempo = cidadeSelecionada.Caminhos.Atual.Info.Tempo;
                    custo = cidadeSelecionada.Caminhos.Atual.Info.Custo;
                    dtCaminhos.Rows.Add(nomeCidade, distancia, tempo, custo);
                }
            }

        }
        else { MessageBox.Show("Não existe essa cidade!"); }

        pbCaminhos.Invalidate();
    }

    private void pbArvore_Paint(object sender, PaintEventArgs e)
    {
        if (aArvore?.Raiz != null) // Verifica se a árvore não está vazia
        {
            Graphics g = e.Graphics;
            aArvore.DesenharArvore(true, pbArvore.Width/2, 0, g);
        }
    }

    private void btnIncluirCaminho_Click(object sender, EventArgs e)
    {
        string nomeCidadeDestino = tbCidadeDestino.Text;
        int distancia = (int)numDistancia.Value;
        int custo = (int)numCusto.Value;
        int tempo = (int)numTempo.Value;

        if (aArvore.Existe(cidadeSelecionada))   // se existe a cidade de origem
        {
            cidadeSelecionada = aArvore.Atual.Info;
            Cidade cidadeDestino = new Cidade(nomeCidadeDestino);
            if (aArvore.Existe(cidadeDestino))   // se existe a cidade de destino
            {
                cidadeDestino = aArvore.Atual.Info;

                Caminho caminhoASerAdicionado = new Caminho(cidadeSelecionada, cidadeDestino, distancia, tempo, custo);  //cria o caminho

                if (!cidadeSelecionada.Caminhos.existeDado(caminhoASerAdicionado))   // se nao existe esse caminho nessa cidade
                {
                    cidadeSelecionada.Caminhos.InserirAposFim(caminhoASerAdicionado);   // adiciona caminho nessa cidade
                }
                else { MessageBox.Show("Já existe um caminho para essa cidade de destino!"); }
            }
            else { MessageBox.Show("Não existe essa cidade de origem!"); }
        }
        else { MessageBox.Show("Não existe essa cidade de origem!"); }
        pbCaminhos.Invalidate();
    }

    private void btnExcluirCaminho_Click(object sender, EventArgs e)
    {
        string nomeCidadeDestino = tbCidadeDestino.Text;

        if (aArvore.Existe(cidadeSelecionada))   // se existe a cidade de origem
        {
            cidadeSelecionada = aArvore.Atual.Info;
            Cidade cidadeDestino = new Cidade(nomeCidadeDestino);
            if (aArvore.Existe(cidadeDestino))   // se existe a cidade de destino
            {
                cidadeDestino = aArvore.Atual.Info;

                Caminho caminhoAExcluir = new Caminho(cidadeDestino);  //cria o caminho que sera excluido para CompareTo

                if (cidadeSelecionada.Caminhos.existeDado(caminhoAExcluir))   // se nao existe esse caminho nessa cidade
                {
                    cidadeSelecionada.Caminhos.removerDado(caminhoAExcluir);   // remove caminho dessa cidade
                }
                else { MessageBox.Show("Não existe um caminho para essa cidade de destino!"); }
            }
            else { MessageBox.Show("Não existe essa cidade de origem!"); }
        }
        else { MessageBox.Show("Não existe essa cidade de origem!"); }
        pbCaminhos.Invalidate();
    }

    private void btnAlterarCaminho_Click(object sender, EventArgs e)
    {
        string nomeCidadeDestino = tbCidadeDestino.Text;
        int novaDistancia = (int)numDistancia.Value;
        int novoCusto = (int)numCusto.Value;
        int novoTempo = (int)numTempo.Value;

        if (aArvore.Existe(cidadeSelecionada))   // se existe a cidade de origem
        {
            cidadeSelecionada = aArvore.Atual.Info;
            Cidade cidadeDestino = new Cidade(nomeCidadeDestino);
            if (aArvore.Existe(cidadeDestino))   // se existe a cidade de destino
            {
                cidadeDestino = aArvore.Atual.Info;

                Caminho caminho = new Caminho(cidadeDestino);  //cria o caminho para achar na lista de caminhos

                if (cidadeSelecionada.Caminhos.existeDado(caminho))   // se nao existe esse caminho nessa cidade
                {
                    cidadeSelecionada.Caminhos.Atual.Info.Distancia = novaDistancia;  //atualiza os valores dos atributos
                    cidadeSelecionada.Caminhos.Atual.Info.Custo = novoCusto;
                    cidadeSelecionada.Caminhos.Atual.Info.Tempo = novoTempo;
                }
                else { MessageBox.Show("Não existe um caminho para essa cidade de destino!"); }
            }
            else { MessageBox.Show("Não existe essa cidade de origem!"); }
        }
        else { MessageBox.Show("Não existe essa cidade de origem!"); }
        pbCaminhos.Invalidate();
    }

}
