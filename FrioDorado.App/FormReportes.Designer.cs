namespace FrioDorado.App
{
    partial class FormReportes
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
            this.tabReportes = new System.Windows.Forms.TabControl();
            this.tabReservasPeriodo = new System.Windows.Forms.TabPage();
            this.dgvReporteReservas = new System.Windows.Forms.DataGridView();
            this.pnlFiltroPeriodo = new System.Windows.Forms.Panel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.tabIngresosTipo = new System.Windows.Forms.TabPage();
            this.dgvIngresos = new System.Windows.Forms.DataGridView();
            this.pnlTotalIngresos = new System.Windows.Forms.Panel();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.lblTituloTotalGeneral = new System.Windows.Forms.Label();
            this.tabReportes.SuspendLayout();
            this.tabReservasPeriodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteReservas)).BeginInit();
            this.pnlFiltroPeriodo.SuspendLayout();
            this.tabIngresosTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            this.pnlTotalIngresos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabReportes
            // 
            this.tabReportes.Controls.Add(this.tabReservasPeriodo);
            this.tabReportes.Controls.Add(this.tabIngresosTipo);
            this.tabReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReportes.Location = new System.Drawing.Point(0, 0);
            this.tabReportes.Name = "tabReportes";
            this.tabReportes.SelectedIndex = 0;
            this.tabReportes.Size = new System.Drawing.Size(850, 480);
            this.tabReportes.TabIndex = 0;
            // 
            // tabReservasPeriodo
            // 
            this.tabReservasPeriodo.Controls.Add(this.dgvReporteReservas);
            this.tabReservasPeriodo.Controls.Add(this.pnlFiltroPeriodo);
            this.tabReservasPeriodo.Location = new System.Drawing.Point(4, 22);
            this.tabReservasPeriodo.Name = "tabReservasPeriodo";
            this.tabReservasPeriodo.Padding = new System.Windows.Forms.Padding(3);
            this.tabReservasPeriodo.Size = new System.Drawing.Size(842, 454);
            this.tabReservasPeriodo.TabIndex = 0;
            this.tabReservasPeriodo.Text = "Reservas por período";
            this.tabReservasPeriodo.UseVisualStyleBackColor = true;
            // 
            // dgvReporteReservas
            // 
            this.dgvReporteReservas.AllowUserToAddRows = false;
            this.dgvReporteReservas.AllowUserToDeleteRows = false;
            this.dgvReporteReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporteReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteReservas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReporteReservas.Location = new System.Drawing.Point(3, 53);
            this.dgvReporteReservas.Name = "dgvReporteReservas";
            this.dgvReporteReservas.ReadOnly = true;
            this.dgvReporteReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporteReservas.Size = new System.Drawing.Size(836, 398);
            this.dgvReporteReservas.TabIndex = 1;
            // 
            // pnlFiltroPeriodo
            // 
            this.pnlFiltroPeriodo.Controls.Add(this.btnConsultar);
            this.pnlFiltroPeriodo.Controls.Add(this.dtpHasta);
            this.pnlFiltroPeriodo.Controls.Add(this.lblHasta);
            this.pnlFiltroPeriodo.Controls.Add(this.dtpDesde);
            this.pnlFiltroPeriodo.Controls.Add(this.lblDesde);
            this.pnlFiltroPeriodo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltroPeriodo.Location = new System.Drawing.Point(3, 3);
            this.pnlFiltroPeriodo.Name = "pnlFiltroPeriodo";
            this.pnlFiltroPeriodo.Size = new System.Drawing.Size(836, 50);
            this.pnlFiltroPeriodo.TabIndex = 0;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(400, 12);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(90, 26);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(260, 15);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(120, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(215, 18);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(75, 15);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(120, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(25, 18);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // tabIngresosTipo
            // 
            this.tabIngresosTipo.Controls.Add(this.dgvIngresos);
            this.tabIngresosTipo.Controls.Add(this.pnlTotalIngresos);
            this.tabIngresosTipo.Location = new System.Drawing.Point(4, 22);
            this.tabIngresosTipo.Name = "tabIngresosTipo";
            this.tabIngresosTipo.Padding = new System.Windows.Forms.Padding(3);
            this.tabIngresosTipo.Size = new System.Drawing.Size(842, 454);
            this.tabIngresosTipo.TabIndex = 1;
            this.tabIngresosTipo.Text = "Ingresos por tipo";
            this.tabIngresosTipo.UseVisualStyleBackColor = true;
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.AllowUserToAddRows = false;
            this.dgvIngresos.AllowUserToDeleteRows = false;
            this.dgvIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngresos.Location = new System.Drawing.Point(3, 3);
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.ReadOnly = true;
            this.dgvIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngresos.Size = new System.Drawing.Size(836, 401);
            this.dgvIngresos.TabIndex = 0;
            // 
            // pnlTotalIngresos
            // 
            this.pnlTotalIngresos.Controls.Add(this.lblTotalGeneral);
            this.pnlTotalIngresos.Controls.Add(this.lblTituloTotalGeneral);
            this.pnlTotalIngresos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotalIngresos.Location = new System.Drawing.Point(3, 404);
            this.pnlTotalIngresos.Name = "pnlTotalIngresos";
            this.pnlTotalIngresos.Size = new System.Drawing.Size(836, 47);
            this.pnlTotalIngresos.TabIndex = 1;
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGeneral.Location = new System.Drawing.Point(125, 15);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(35, 15);
            this.lblTotalGeneral.TabIndex = 1;
            this.lblTotalGeneral.Text = "0.00";
            // 
            // lblTituloTotalGeneral
            // 
            this.lblTituloTotalGeneral.AutoSize = true;
            this.lblTituloTotalGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTotalGeneral.Location = new System.Drawing.Point(20, 15);
            this.lblTituloTotalGeneral.Name = "lblTituloTotalGeneral";
            this.lblTituloTotalGeneral.Size = new System.Drawing.Size(97, 15);
            this.lblTituloTotalGeneral.TabIndex = 0;
            this.lblTituloTotalGeneral.Text = "Total General:";
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 480);
            this.Controls.Add(this.tabReportes);
            this.Name = "FormReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.FormReportes_Load);
            this.tabReportes.ResumeLayout(false);
            this.tabReservasPeriodo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteReservas)).EndInit();
            this.pnlFiltroPeriodo.ResumeLayout(false);
            this.pnlFiltroPeriodo.PerformLayout();
            this.tabIngresosTipo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            this.pnlTotalIngresos.ResumeLayout(false);
            this.pnlTotalIngresos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabReportes;
        private System.Windows.Forms.TabPage tabReservasPeriodo;
        private System.Windows.Forms.Panel pnlFiltroPeriodo;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvReporteReservas;
        private System.Windows.Forms.TabPage tabIngresosTipo;
        private System.Windows.Forms.DataGridView dgvIngresos;
        private System.Windows.Forms.Panel pnlTotalIngresos;
        private System.Windows.Forms.Label lblTituloTotalGeneral;
        private System.Windows.Forms.Label lblTotalGeneral;
    }
}