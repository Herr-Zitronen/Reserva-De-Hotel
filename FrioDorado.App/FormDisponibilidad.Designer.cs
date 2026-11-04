namespace FrioDorado.App
{
    partial class FormDisponibilidad
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.lblEntrada = new System.Windows.Forms.Label();
            this.dtpEntrada = new System.Windows.Forms.DateTimePicker();
            this.lblSalida = new System.Windows.Forms.Label();
            this.dtpSalida = new System.Windows.Forms.DateTimePicker();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvLibres = new System.Windows.Forms.DataGridView();
            this.pnlFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibres)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Controls.Add(this.btnConsultar);
            this.pnlFiltro.Controls.Add(this.dtpSalida);
            this.pnlFiltro.Controls.Add(this.lblSalida);
            this.pnlFiltro.Controls.Add(this.dtpEntrada);
            this.pnlFiltro.Controls.Add(this.lblEntrada);
            this.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltro.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(650, 50);
            this.pnlFiltro.TabIndex = 0;
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Location = new System.Drawing.Point(15, 18);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(47, 13);
            this.lblEntrada.TabIndex = 0;
            this.lblEntrada.Text = "Entrada:";
            // 
            // dtpEntrada
            // 
            this.dtpEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntrada.Location = new System.Drawing.Point(68, 15);
            this.dtpEntrada.Name = "dtpEntrada";
            this.dtpEntrada.Size = new System.Drawing.Size(120, 20);
            this.dtpEntrada.TabIndex = 1;
            // 
            // lblSalida
            // 
            this.lblSalida.AutoSize = true;
            this.lblSalida.Location = new System.Drawing.Point(205, 18);
            this.lblSalida.Name = "lblSalida";
            this.lblSalida.Size = new System.Drawing.Size(39, 13);
            this.lblSalida.TabIndex = 2;
            this.lblSalida.Text = "Salida:";
            // 
            // dtpSalida
            // 
            this.dtpSalida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSalida.Location = new System.Drawing.Point(250, 15);
            this.dtpSalida.Name = "dtpSalida";
            this.dtpSalida.Size = new System.Drawing.Size(120, 20);
            this.dtpSalida.TabIndex = 3;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(390, 11);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 28);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dgvLibres
            // 
            this.dgvLibres.AllowUserToAddRows = false;
            this.dgvLibres.AllowUserToDeleteRows = false;
            this.dgvLibres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLibres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLibres.Location = new System.Drawing.Point(0, 50);
            this.dgvLibres.Name = "dgvLibres";
            this.dgvLibres.ReadOnly = true;
            this.dgvLibres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLibres.Size = new System.Drawing.Size(650, 370);
            this.dgvLibres.TabIndex = 1;
            // 
            // FormDisponibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 420);
            this.Controls.Add(this.dgvLibres);
            this.Controls.Add(this.pnlFiltro);
            this.Name = "FormDisponibilidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consultar Disponibilidad";
            this.Load += new System.EventHandler(this.FormDisponibilidad_Load);
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibres)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.DateTimePicker dtpEntrada;
        private System.Windows.Forms.Label lblSalida;
        private System.Windows.Forms.DateTimePicker dtpSalida;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvLibres;
    }
}