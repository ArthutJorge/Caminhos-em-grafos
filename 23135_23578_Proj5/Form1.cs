<<<<<<< HEAD
﻿using System;
using System.IO;
=======
﻿using Arvores2024;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 823239cd4f417e478d25f5f2e5839773a830d89d
using System.Windows.Forms;

public partial class Form1 : Form
{
    Arvore<Cidade> aArvore;

    public Form1()
    {
<<<<<<< HEAD
        InitializeComponent();
    }
=======

        Cidade cidadeSelecionada;

        public Form1()
        {
            InitializeComponent();
        }
>>>>>>> 823239cd4f417e478d25f5f2e5839773a830d89d

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
    }
}
