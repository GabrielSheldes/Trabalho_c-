namespace Trabalho_Jef
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
            this.Codigo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textCodigoProduto = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.V = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFinalizarVenda = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Codigo
            // 
            this.Codigo.AutoSize = true;
            this.Codigo.Location = new System.Drawing.Point(1, 51);
            this.Codigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(141, 20);
            this.Codigo.TabIndex = 0;
            this.Codigo.Text = "Codigo do Produto";
            this.Codigo.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantidade";
            // 
            // textCodigoProduto
            // 
            this.textCodigoProduto.Location = new System.Drawing.Point(165, 51);
            this.textCodigoProduto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textCodigoProduto.Name = "textCodigoProduto";
            this.textCodigoProduto.Size = new System.Drawing.Size(148, 26);
            this.textCodigoProduto.TabIndex = 2;
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(165, 87);
            this.txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(148, 26);
            this.txt.TabIndex = 3;
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(137, 123);
            this.btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(213, 35);
            this.btn.TabIndex = 4;
            this.btn.Text = "Adicionar ao Carrinho";
            this.btn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Produto,
            this.Quantidade,
            this.V,
            this.Subtotal});
            this.dataGridView1.Location = new System.Drawing.Point(370, 41);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(644, 254);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Produto
            // 
            this.Produto.HeaderText = "Produto ";
            this.Produto.MinimumWidth = 8;
            this.Produto.Name = "Produto";
            this.Produto.Width = 150;
            // 
            // Quantidade
            // 
            this.Quantidade.HeaderText = "Quantidade ";
            this.Quantidade.MinimumWidth = 8;
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.Width = 150;
            // 
            // V
            // 
            this.V.HeaderText = "Valor Unitario";
            this.V.MinimumWidth = 8;
            this.V.Name = "V";
            this.V.Width = 150;
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.MinimumWidth = 8;
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Valor Pago:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Location = new System.Drawing.Point(13, 211);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(48, 20);
            this.Total.TabIndex = 7;
            this.Total.Text = "Total:";
            // 
            // txtValorPago
            // 
            this.txtValorPago.Location = new System.Drawing.Point(126, 255);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(92, 26);
            this.txtValorPago.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.Location = new System.Drawing.Point(17, 341);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(155, 45);
            this.btnFinalizarVenda.TabIndex = 10;
            this.btnFinalizarVenda.Text = "Finalizar Venda ";
            this.btnFinalizarVenda.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(216, 341);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(155, 45);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar Venda ";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 562);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFinalizarVenda);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtValorPago);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.textCodigoProduto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Codigo);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Codigo;
        private System.Windows.Forms.TextBox textCodigoProduto;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn V;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFinalizarVenda;
        private System.Windows.Forms.Button btnCancelar;
    }
}

