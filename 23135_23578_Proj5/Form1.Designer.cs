
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCadastro = new System.Windows.Forms.TabPage();
            this.dtCaminhos = new System.Windows.Forms.DataGridView();
            this.numCusto = new System.Windows.Forms.NumericUpDown();
            this.numYCidade = new System.Windows.Forms.NumericUpDown();
            this.numTempo = new System.Windows.Forms.NumericUpDown();
            this.pbCaminhos = new System.Windows.Forms.PictureBox();
            this.btnExibirCaminho = new System.Windows.Forms.Button();
            this.btnExcluirCaminho = new System.Windows.Forms.Button();
            this.btnAlterarCaminho = new System.Windows.Forms.Button();
            this.btnIncluirCaminho = new System.Windows.Forms.Button();
            this.btnExibirCidade = new System.Windows.Forms.Button();
            this.btnExcluirCidade = new System.Windows.Forms.Button();
            this.btnAlterarCidade = new System.Windows.Forms.Button();
            this.btnIncluirCidade = new System.Windows.Forms.Button();
            this.numDistancia = new System.Windows.Forms.NumericUpDown();
            this.tbCidadeDestino = new System.Windows.Forms.TextBox();
            this.numXCidade = new System.Windows.Forms.NumericUpDown();
            this.tbNomeCidade = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabArvore = new System.Windows.Forms.TabPage();
            this.pbArvore = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.tabCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCaminhos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYCidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaminhos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numXCidade)).BeginInit();
            this.tabArvore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArvore)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabCadastro);
            this.tabControl.Controls.Add(this.tabArvore);
            this.tabControl.Location = new System.Drawing.Point(-3, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(998, 589);
            this.tabControl.TabIndex = 0;
            // 
            // tabCadastro
            // 
            this.tabCadastro.Controls.Add(this.dtCaminhos);
            this.tabCadastro.Controls.Add(this.numCusto);
            this.tabCadastro.Controls.Add(this.numYCidade);
            this.tabCadastro.Controls.Add(this.numTempo);
            this.tabCadastro.Controls.Add(this.pbCaminhos);
            this.tabCadastro.Controls.Add(this.btnExibirCaminho);
            this.tabCadastro.Controls.Add(this.btnExcluirCaminho);
            this.tabCadastro.Controls.Add(this.btnAlterarCaminho);
            this.tabCadastro.Controls.Add(this.btnIncluirCaminho);
            this.tabCadastro.Controls.Add(this.btnExibirCidade);
            this.tabCadastro.Controls.Add(this.btnExcluirCidade);
            this.tabCadastro.Controls.Add(this.btnAlterarCidade);
            this.tabCadastro.Controls.Add(this.btnIncluirCidade);
            this.tabCadastro.Controls.Add(this.numDistancia);
            this.tabCadastro.Controls.Add(this.tbCidadeDestino);
            this.tabCadastro.Controls.Add(this.numXCidade);
            this.tabCadastro.Controls.Add(this.tbNomeCidade);
            this.tabCadastro.Controls.Add(this.label10);
            this.tabCadastro.Controls.Add(this.label9);
            this.tabCadastro.Controls.Add(this.label8);
            this.tabCadastro.Controls.Add(this.label7);
            this.tabCadastro.Controls.Add(this.label6);
            this.tabCadastro.Controls.Add(this.label5);
            this.tabCadastro.Controls.Add(this.label4);
            this.tabCadastro.Controls.Add(this.label3);
            this.tabCadastro.Controls.Add(this.label2);
            this.tabCadastro.Location = new System.Drawing.Point(4, 22);
            this.tabCadastro.Name = "tabCadastro";
            this.tabCadastro.Padding = new System.Windows.Forms.Padding(3);
            this.tabCadastro.Size = new System.Drawing.Size(990, 563);
            this.tabCadastro.TabIndex = 0;
            this.tabCadastro.Text = "Cadastro";
            this.tabCadastro.UseVisualStyleBackColor = true;
            // 
            // dtCaminhos
            // 
            this.dtCaminhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCaminhos.Location = new System.Drawing.Point(15, 307);
            this.dtCaminhos.Name = "dtCaminhos";
            this.dtCaminhos.Size = new System.Drawing.Size(472, 241);
            this.dtCaminhos.TabIndex = 28;
            // 
            // numCusto
            // 
            this.numCusto.Location = new System.Drawing.Point(299, 235);
            this.numCusto.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCusto.Name = "numCusto";
            this.numCusto.Size = new System.Drawing.Size(136, 20);
            this.numCusto.TabIndex = 27;
            // 
            // numYCidade
            // 
            this.numYCidade.DecimalPlaces = 5;
            this.numYCidade.Location = new System.Drawing.Point(367, 62);
            this.numYCidade.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYCidade.Name = "numYCidade";
            this.numYCidade.Size = new System.Drawing.Size(120, 20);
            this.numYCidade.TabIndex = 26;
            // 
            // numTempo
            // 
            this.numTempo.Location = new System.Drawing.Point(157, 235);
            this.numTempo.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTempo.Name = "numTempo";
            this.numTempo.Size = new System.Drawing.Size(136, 20);
            this.numTempo.TabIndex = 25;
            // 
            // pbCaminhos
            // 
            this.pbCaminhos.Image = ((System.Drawing.Image)(resources.GetObject("pbCaminhos.Image")));
            this.pbCaminhos.Location = new System.Drawing.Point(492, 14);
            this.pbCaminhos.Name = "pbCaminhos";
            this.pbCaminhos.Size = new System.Drawing.Size(491, 317);
            this.pbCaminhos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCaminhos.TabIndex = 24;
            this.pbCaminhos.TabStop = false;
            this.pbCaminhos.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCaminhos_Paint);
            // 
            // btnExibirCaminho
            // 
            this.btnExibirCaminho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExibirCaminho.Location = new System.Drawing.Point(258, 261);
            this.btnExibirCaminho.Name = "btnExibirCaminho";
            this.btnExibirCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnExibirCaminho.TabIndex = 23;
            this.btnExibirCaminho.Text = "Exibir";
            this.btnExibirCaminho.UseVisualStyleBackColor = false;
            // 
            // btnExcluirCaminho
            // 
            this.btnExcluirCaminho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExcluirCaminho.Location = new System.Drawing.Point(96, 261);
            this.btnExcluirCaminho.Name = "btnExcluirCaminho";
            this.btnExcluirCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnExcluirCaminho.TabIndex = 22;
            this.btnExcluirCaminho.Text = "Excluir";
            this.btnExcluirCaminho.UseVisualStyleBackColor = false;
            // 
            // btnAlterarCaminho
            // 
            this.btnAlterarCaminho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAlterarCaminho.Location = new System.Drawing.Point(177, 261);
            this.btnAlterarCaminho.Name = "btnAlterarCaminho";
            this.btnAlterarCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnAlterarCaminho.TabIndex = 21;
            this.btnAlterarCaminho.Text = "Alterar";
            this.btnAlterarCaminho.UseVisualStyleBackColor = false;
            // 
            // btnIncluirCaminho
            // 
            this.btnIncluirCaminho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnIncluirCaminho.Location = new System.Drawing.Point(15, 261);
            this.btnIncluirCaminho.Name = "btnIncluirCaminho";
            this.btnIncluirCaminho.Size = new System.Drawing.Size(75, 23);
            this.btnIncluirCaminho.TabIndex = 20;
            this.btnIncluirCaminho.Text = "Incluir";
            this.btnIncluirCaminho.UseVisualStyleBackColor = false;
            // 
            // btnExibirCidade
            // 
            this.btnExibirCidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExibirCidade.Location = new System.Drawing.Point(258, 89);
            this.btnExibirCidade.Name = "btnExibirCidade";
            this.btnExibirCidade.Size = new System.Drawing.Size(75, 23);
            this.btnExibirCidade.TabIndex = 18;
            this.btnExibirCidade.Text = "Exibir";
            this.btnExibirCidade.UseVisualStyleBackColor = false;
            this.btnExibirCidade.Click += new System.EventHandler(this.btnExibirCidade_Click);
            // 
            // btnExcluirCidade
            // 
            this.btnExcluirCidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExcluirCidade.Location = new System.Drawing.Point(96, 89);
            this.btnExcluirCidade.Name = "btnExcluirCidade";
            this.btnExcluirCidade.Size = new System.Drawing.Size(75, 23);
            this.btnExcluirCidade.TabIndex = 17;
            this.btnExcluirCidade.Text = "Excluir";
            this.btnExcluirCidade.UseVisualStyleBackColor = false;
            this.btnExcluirCidade.Click += new System.EventHandler(this.btnExcluirCidade_Click);
            // 
            // btnAlterarCidade
            // 
            this.btnAlterarCidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAlterarCidade.Location = new System.Drawing.Point(177, 89);
            this.btnAlterarCidade.Name = "btnAlterarCidade";
            this.btnAlterarCidade.Size = new System.Drawing.Size(75, 23);
            this.btnAlterarCidade.TabIndex = 16;
            this.btnAlterarCidade.Text = "Alterar";
            this.btnAlterarCidade.UseVisualStyleBackColor = false;
            this.btnAlterarCidade.Click += new System.EventHandler(this.btnAlterarCidade_Click);
            // 
            // btnIncluirCidade
            // 
            this.btnIncluirCidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnIncluirCidade.Location = new System.Drawing.Point(15, 89);
            this.btnIncluirCidade.Name = "btnIncluirCidade";
            this.btnIncluirCidade.Size = new System.Drawing.Size(75, 23);
            this.btnIncluirCidade.TabIndex = 15;
            this.btnIncluirCidade.Text = "Incluir";
            this.btnIncluirCidade.UseVisualStyleBackColor = false;
            this.btnIncluirCidade.Click += new System.EventHandler(this.btnIncluirCidade_Click);
            // 
            // numDistancia
            // 
            this.numDistancia.Location = new System.Drawing.Point(15, 235);
            this.numDistancia.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numDistancia.Name = "numDistancia";
            this.numDistancia.Size = new System.Drawing.Size(136, 20);
            this.numDistancia.TabIndex = 13;
            // 
            // tbCidadeDestino
            // 
            this.tbCidadeDestino.Location = new System.Drawing.Point(15, 187);
            this.tbCidadeDestino.Name = "tbCidadeDestino";
            this.tbCidadeDestino.Size = new System.Drawing.Size(220, 20);
            this.tbCidadeDestino.TabIndex = 12;
            // 
            // numXCidade
            // 
            this.numXCidade.DecimalPlaces = 5;
            this.numXCidade.Location = new System.Drawing.Point(241, 63);
            this.numXCidade.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numXCidade.Name = "numXCidade";
            this.numXCidade.Size = new System.Drawing.Size(120, 20);
            this.numXCidade.TabIndex = 10;
            // 
            // tbNomeCidade
            // 
            this.tbNomeCidade.Location = new System.Drawing.Point(15, 62);
            this.tbNomeCidade.Name = "tbNomeCidade";
            this.tbNomeCidade.Size = new System.Drawing.Size(220, 20);
            this.tbNomeCidade.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(296, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Custo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(154, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Tempo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Distância";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Cidade de destino";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Caminhos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(365, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cidade";
            // 
            // tabArvore
            // 
            this.tabArvore.Controls.Add(this.pbArvore);
            this.tabArvore.Location = new System.Drawing.Point(4, 22);
            this.tabArvore.Name = "tabArvore";
            this.tabArvore.Padding = new System.Windows.Forms.Padding(3);
            this.tabArvore.Size = new System.Drawing.Size(990, 563);
            this.tabArvore.TabIndex = 1;
            this.tabArvore.Text = "Árvore";
            this.tabArvore.UseVisualStyleBackColor = true;
            // 
            // pbArvore
            // 
            this.pbArvore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbArvore.Location = new System.Drawing.Point(6, 6);
            this.pbArvore.Name = "pbArvore";
            this.pbArvore.Size = new System.Drawing.Size(978, 551);
            this.pbArvore.TabIndex = 1;
            this.pbArvore.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 593);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Marte Árvores Binárias";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabCadastro.ResumeLayout(false);
            this.tabCadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCaminhos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYCidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaminhos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numXCidade)).EndInit();
            this.tabArvore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbArvore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCadastro;
        private System.Windows.Forms.TabPage tabArvore;
        private System.Windows.Forms.NumericUpDown numDistancia;
        private System.Windows.Forms.TextBox tbCidadeDestino;
        private System.Windows.Forms.NumericUpDown numXCidade;
        private System.Windows.Forms.TextBox tbNomeCidade;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExibirCaminho;
        private System.Windows.Forms.Button btnExcluirCaminho;
        private System.Windows.Forms.Button btnAlterarCaminho;
        private System.Windows.Forms.Button btnIncluirCaminho;
        private System.Windows.Forms.Button btnExibirCidade;
        private System.Windows.Forms.Button btnExcluirCidade;
        private System.Windows.Forms.Button btnAlterarCidade;
        private System.Windows.Forms.Button btnIncluirCidade;
        private System.Windows.Forms.PictureBox pbCaminhos;
        private System.Windows.Forms.DataGridView dtCaminhos;
        private System.Windows.Forms.NumericUpDown numCusto;
        private System.Windows.Forms.NumericUpDown numYCidade;
        private System.Windows.Forms.NumericUpDown numTempo;
        private System.Windows.Forms.PictureBox pbArvore;
    }

