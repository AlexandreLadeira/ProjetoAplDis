namespace ProjetoCliente
{
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
            this.gvConsultaProjetos = new System.Windows.Forms.DataGridView();
            this.btnConsultarProjetos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConsultarPorCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConsultarPorNome = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnConsultarPorCodigo = new System.Windows.Forms.Button();
            this.btnConsultarPorNome = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gvInserirProjetos = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gvExcluirProjetos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExcluirProjeto = new System.Windows.Forms.Button();
            this.txtCodigoExcluir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnInserirProjeto = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvConsultaProjetos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInserirProjetos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExcluirProjetos)).BeginInit();
            this.SuspendLayout();
            // 
            // gvConsultaProjetos
            // 
            this.gvConsultaProjetos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvConsultaProjetos.Location = new System.Drawing.Point(7, 115);
            this.gvConsultaProjetos.Margin = new System.Windows.Forms.Padding(4);
            this.gvConsultaProjetos.Name = "gvConsultaProjetos";
            this.gvConsultaProjetos.Size = new System.Drawing.Size(432, 162);
            this.gvConsultaProjetos.TabIndex = 0;
            // 
            // btnConsultarProjetos
            // 
            this.btnConsultarProjetos.Location = new System.Drawing.Point(8, 285);
            this.btnConsultarProjetos.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsultarProjetos.Name = "btnConsultarProjetos";
            this.btnConsultarProjetos.Size = new System.Drawing.Size(195, 28);
            this.btnConsultarProjetos.TabIndex = 1;
            this.btnConsultarProjetos.Text = "Consultar todos os projetos";
            this.btnConsultarProjetos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Código: ";
            // 
            // txtConsultarPorCodigo
            // 
            this.txtConsultarPorCodigo.Location = new System.Drawing.Point(72, 24);
            this.txtConsultarPorCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtConsultarPorCodigo.Name = "txtConsultarPorCodigo";
            this.txtConsultarPorCodigo.Size = new System.Drawing.Size(131, 23);
            this.txtConsultarPorCodigo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nome: ";
            // 
            // txtConsultarPorNome
            // 
            this.txtConsultarPorNome.Location = new System.Drawing.Point(304, 24);
            this.txtConsultarPorNome.Name = "txtConsultarPorNome";
            this.txtConsultarPorNome.Size = new System.Drawing.Size(131, 23);
            this.txtConsultarPorNome.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(454, 351);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnConsultarPorNome);
            this.tabPage1.Controls.Add(this.btnConsultarPorCodigo);
            this.tabPage1.Controls.Add(this.gvConsultaProjetos);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtConsultarPorCodigo);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtConsultarPorNome);
            this.tabPage1.Controls.Add(this.btnConsultarProjetos);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(446, 322);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consultar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.btnInserirProjeto);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.gvInserirProjetos);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(446, 322);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Inserir";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnConsultarPorCodigo
            // 
            this.btnConsultarPorCodigo.Location = new System.Drawing.Point(7, 77);
            this.btnConsultarPorCodigo.Name = "btnConsultarPorCodigo";
            this.btnConsultarPorCodigo.Size = new System.Drawing.Size(196, 28);
            this.btnConsultarPorCodigo.TabIndex = 6;
            this.btnConsultarPorCodigo.Text = "Consultar por código";
            this.btnConsultarPorCodigo.UseVisualStyleBackColor = true;
            // 
            // btnConsultarPorNome
            // 
            this.btnConsultarPorNome.Location = new System.Drawing.Point(247, 77);
            this.btnConsultarPorNome.Name = "btnConsultarPorNome";
            this.btnConsultarPorNome.Size = new System.Drawing.Size(192, 28);
            this.btnConsultarPorNome.TabIndex = 7;
            this.btnConsultarPorNome.Text = "Consultar por nome";
            this.btnConsultarPorNome.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(446, 322);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Alterar";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtCodigoExcluir);
            this.tabPage4.Controls.Add(this.btnExcluirProjeto);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.gvExcluirProjetos);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(446, 322);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Excluir";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // gvInserirProjetos
            // 
            this.gvInserirProjetos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvInserirProjetos.Location = new System.Drawing.Point(7, 153);
            this.gvInserirProjetos.Margin = new System.Windows.Forms.Padding(4);
            this.gvInserirProjetos.Name = "gvInserirProjetos";
            this.gvInserirProjetos.Size = new System.Drawing.Size(223, 162);
            this.gvInserirProjetos.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 153);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(432, 162);
            this.dataGridView1.TabIndex = 1;
            // 
            // gvExcluirProjetos
            // 
            this.gvExcluirProjetos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExcluirProjetos.Location = new System.Drawing.Point(7, 106);
            this.gvExcluirProjetos.Margin = new System.Windows.Forms.Padding(4);
            this.gvExcluirProjetos.Name = "gvExcluirProjetos";
            this.gvExcluirProjetos.Size = new System.Drawing.Size(432, 209);
            this.gvExcluirProjetos.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Código do Projeto:";
            // 
            // btnExcluirProjeto
            // 
            this.btnExcluirProjeto.Location = new System.Drawing.Point(9, 71);
            this.btnExcluirProjeto.Name = "btnExcluirProjeto";
            this.btnExcluirProjeto.Size = new System.Drawing.Size(244, 28);
            this.btnExcluirProjeto.TabIndex = 4;
            this.btnExcluirProjeto.Text = "Excluir Projeto";
            this.btnExcluirProjeto.UseVisualStyleBackColor = true;
            // 
            // txtCodigoExcluir
            // 
            this.txtCodigoExcluir.Location = new System.Drawing.Point(137, 14);
            this.txtCodigoExcluir.Name = "txtCodigoExcluir";
            this.txtCodigoExcluir.Size = new System.Drawing.Size(116, 23);
            this.txtCodigoExcluir.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Código: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Nome: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Descrição: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ano: ";
            // 
            // btnInserirProjeto
            // 
            this.btnInserirProjeto.Location = new System.Drawing.Point(237, 286);
            this.btnInserirProjeto.Name = "btnInserirProjeto";
            this.btnInserirProjeto.Size = new System.Drawing.Size(202, 29);
            this.btnInserirProjeto.TabIndex = 6;
            this.btnInserirProjeto.Text = "Inserir Projeto";
            this.btnInserirProjeto.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(90, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(240, 173);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(199, 107);
            this.textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(90, 41);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 23);
            this.textBox4.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 366);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Manutenção - Projetos";
            ((System.ComponentModel.ISupportInitialize)(this.gvConsultaProjetos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInserirProjetos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExcluirProjetos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvConsultaProjetos;
        private System.Windows.Forms.Button btnConsultarProjetos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConsultarPorCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConsultarPorNome;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnConsultarPorNome;
        private System.Windows.Forms.Button btnConsultarPorCodigo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView gvInserirProjetos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCodigoExcluir;
        private System.Windows.Forms.Button btnExcluirProjeto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gvExcluirProjetos;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnInserirProjeto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

