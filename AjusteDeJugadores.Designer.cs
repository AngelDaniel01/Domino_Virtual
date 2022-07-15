namespace Domino_Virtual
{
    partial class AjusteDeJugadores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NombreDeJugador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDeJugador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Eliminar = new System.Windows.Forms.Button();
            this.editar = new System.Windows.Forms.Button();
            this.Arriba = new System.Windows.Forms.Button();
            this.Abajo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3_Editarr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreDeJugador,
            this.TipoDeJugador});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView1.Location = new System.Drawing.Point(29, 34);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 41;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(576, 266);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // NombreDeJugador
            // 
            this.NombreDeJugador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreDeJugador.HeaderText = "Nombre de jugador";
            this.NombreDeJugador.MinimumWidth = 10;
            this.NombreDeJugador.Name = "NombreDeJugador";
            this.NombreDeJugador.Visible = false;
            // 
            // TipoDeJugador
            // 
            this.TipoDeJugador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TipoDeJugador.HeaderText = "Tipo de jugador";
            this.TipoDeJugador.MinimumWidth = 10;
            this.TipoDeJugador.Name = "TipoDeJugador";
            this.TipoDeJugador.Visible = false;
            this.TipoDeJugador.Width = 200;
            // 
            // button_Eliminar
            // 
            this.button_Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Eliminar.Location = new System.Drawing.Point(465, 342);
            this.button_Eliminar.Name = "button_Eliminar";
            this.button_Eliminar.Size = new System.Drawing.Size(139, 78);
            this.button_Eliminar.TabIndex = 1;
            this.button_Eliminar.Text = "Eliminar";
            this.button_Eliminar.UseVisualStyleBackColor = true;
            this.button_Eliminar.Click += new System.EventHandler(this.button_Eliminar_Click);
            // 
            // editar
            // 
            this.editar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editar.Location = new System.Drawing.Point(29, 342);
            this.editar.Name = "editar";
            this.editar.Size = new System.Drawing.Size(139, 78);
            this.editar.TabIndex = 2;
            this.editar.Text = "Agregar";
            this.editar.UseVisualStyleBackColor = true;
            this.editar.Click += new System.EventHandler(this.editar_Click);
            // 
            // Arriba
            // 
            this.Arriba.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Arriba.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Arriba.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Arriba.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Arriba.Location = new System.Drawing.Point(634, 34);
            this.Arriba.Name = "Arriba";
            this.Arriba.Size = new System.Drawing.Size(40, 52);
            this.Arriba.TabIndex = 3;
            this.Arriba.Text = "⬆️";
            this.Arriba.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Arriba.UseVisualStyleBackColor = true;
            this.Arriba.Click += new System.EventHandler(this.Arriba_Click);
            // 
            // Abajo
            // 
            this.Abajo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Abajo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Abajo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Abajo.Location = new System.Drawing.Point(634, 111);
            this.Abajo.Name = "Abajo";
            this.Abajo.Size = new System.Drawing.Size(40, 52);
            this.Abajo.TabIndex = 4;
            this.Abajo.Text = "⬇️";
            this.Abajo.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Abajo.UseVisualStyleBackColor = true;
            this.Abajo.Click += new System.EventHandler(this.Abajo_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(193, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 78);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3_Editarr
            // 
            this.button3_Editarr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3_Editarr.Location = new System.Drawing.Point(239, 342);
            this.button3_Editarr.Name = "button3_Editarr";
            this.button3_Editarr.Size = new System.Drawing.Size(139, 78);
            this.button3_Editarr.TabIndex = 7;
            this.button3_Editarr.Text = "Editar";
            this.button3_Editarr.UseVisualStyleBackColor = true;
            this.button3_Editarr.Click += new System.EventHandler(this.button3_Editarr_Click);
            // 
            // AjusteDeJugadores
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 583);
            this.Controls.Add(this.button3_Editarr);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Abajo);
            this.Controls.Add(this.Arriba);
            this.Controls.Add(this.editar);
            this.Controls.Add(this.button_Eliminar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AjusteDeJugadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AjusteDeJugadores";
            this.Load += new System.EventHandler(this.AjusteDeJugadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button button_Eliminar;
        private DataGridViewTextBoxColumn NombreDeJugador;
        private DataGridViewTextBoxColumn TipoDeJugador;
        private Button editar;
        private Button Arriba;
        private Button Abajo;
        private Button button1;
        private Button button3_Editarr;
    }
}