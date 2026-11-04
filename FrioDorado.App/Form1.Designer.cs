namespace FrioDorado.App
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabHabitaciones = new System.Windows.Forms.TabPage();
            this.dgvHabitaciones = new System.Windows.Forms.DataGridView();
            this.colHabNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHabTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHabTarifaDiaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabReservas = new System.Windows.Forms.TabPage();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.colResCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAccionesReservas = new System.Windows.Forms.Panel();
            this.btnNuevaReserva = new System.Windows.Forms.Button();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lblNombreHotel = new System.Windows.Forms.Label();
            this.tabPrincipal.SuspendLayout();
            this.tabHabitaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.tabReservas.SuspendLayout();
            this.pnlAccionesReservas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.pnlCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Controls.Add(this.lblNombreHotel);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1350, 60);
            this.pnlCabecera.TabIndex = 1;
            // 
            // lblNombreHotel
            // 
            this.lblNombreHotel.AutoSize = true;
            this.lblNombreHotel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreHotel.Location = new System.Drawing.Point(16, 14);
            this.lblNombreHotel.Name = "lblNombreHotel";
            this.lblNombreHotel.Size = new System.Drawing.Size(263, 30);
            this.lblNombreHotel.TabIndex = 0;
            this.lblNombreHotel.Text = "Hotel Frío Dorado";
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabHabitaciones);
            this.tabPrincipal.Controls.Add(this.tabReservas);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 60);
            this.tabPrincipal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(1350, 709);
            this.tabPrincipal.TabIndex = 0;
            // 
            // tabHabitaciones
            // 
            this.tabHabitaciones.Controls.Add(this.dgvHabitaciones);
            this.tabHabitaciones.Location = new System.Drawing.Point(4, 29);
            this.tabHabitaciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabHabitaciones.Name = "tabHabitaciones";
            this.tabHabitaciones.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabHabitaciones.Size = new System.Drawing.Size(1342, 736);
            this.tabHabitaciones.TabIndex = 0;
            this.tabHabitaciones.Text = "Habitaciones";
            this.tabHabitaciones.UseVisualStyleBackColor = true;
            // 
            // dgvHabitaciones
            // 
            this.dgvHabitaciones.AllowUserToAddRows = false;
            this.dgvHabitaciones.AllowUserToDeleteRows = false;
            this.dgvHabitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHabNumero,
            this.colHabTipo,
            this.colHabTarifaDiaria});
            this.dgvHabitaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHabitaciones.Location = new System.Drawing.Point(4, 5);
            this.dgvHabitaciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvHabitaciones.Name = "dgvHabitaciones";
            this.dgvHabitaciones.ReadOnly = true;
            this.dgvHabitaciones.RowHeadersWidth = 62;
            this.dgvHabitaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHabitaciones.Size = new System.Drawing.Size(1334, 726);
            this.dgvHabitaciones.TabIndex = 0;
            this.dgvHabitaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHabitaciones_CellContentClick);
            //
            // colHabNumero
            //
            this.colHabNumero.DataPropertyName = "Numero";
            this.colHabNumero.HeaderText = "Número";
            this.colHabNumero.MinimumWidth = 8;
            this.colHabNumero.Name = "colHabNumero";
            //
            // colHabTipo
            //
            this.colHabTipo.DataPropertyName = "Tipo";
            this.colHabTipo.HeaderText = "Tipo";
            this.colHabTipo.MinimumWidth = 8;
            this.colHabTipo.Name = "colHabTipo";
            //
            // colHabTarifaDiaria
            //
            this.colHabTarifaDiaria.DataPropertyName = "TarifaDiaria";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.colHabTarifaDiaria.DefaultCellStyle = dataGridViewCellStyle1;
            this.colHabTarifaDiaria.HeaderText = "Tarifa";
            this.colHabTarifaDiaria.MinimumWidth = 8;
            this.colHabTarifaDiaria.Name = "colHabTarifaDiaria";
            //
            // tabReservas
            // 
            this.tabReservas.Controls.Add(this.dgvReservas);
            this.tabReservas.Controls.Add(this.pnlAccionesReservas);
            this.tabReservas.Location = new System.Drawing.Point(4, 29);
            this.tabReservas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabReservas.Name = "tabReservas";
            this.tabReservas.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabReservas.Size = new System.Drawing.Size(1342, 736);
            this.tabReservas.TabIndex = 1;
            this.tabReservas.Text = "Reservas";
            this.tabReservas.UseVisualStyleBackColor = true;
            // 
            // pnlAccionesReservas
            // 
            this.pnlAccionesReservas.Controls.Add(this.btnReportes);
            this.pnlAccionesReservas.Controls.Add(this.btnCancelarReserva);
            this.pnlAccionesReservas.Controls.Add(this.btnNuevaReserva);
            this.pnlAccionesReservas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAccionesReservas.Location = new System.Drawing.Point(4, 5);
            this.pnlAccionesReservas.Name = "pnlAccionesReservas";
            this.pnlAccionesReservas.Size = new System.Drawing.Size(1334, 50);
            this.pnlAccionesReservas.TabIndex = 1;
            // 
            // btnNuevaReserva
            // 
            this.btnNuevaReserva.Location = new System.Drawing.Point(10, 10);
            this.btnNuevaReserva.Name = "btnNuevaReserva";
            this.btnNuevaReserva.Size = new System.Drawing.Size(140, 30);
            this.btnNuevaReserva.TabIndex = 0;
            this.btnNuevaReserva.Text = "Nueva Reserva";
            this.btnNuevaReserva.UseVisualStyleBackColor = true;
            this.btnNuevaReserva.Click += new System.EventHandler(this.btnNuevaReserva_Click);
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.Location = new System.Drawing.Point(160, 10);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(140, 30);
            this.btnCancelarReserva.TabIndex = 1;
            this.btnCancelarReserva.Text = "Cancelar Reserva";
            this.btnCancelarReserva.UseVisualStyleBackColor = true;
            this.btnCancelarReserva.Click += new System.EventHandler(this.btnCancelarReserva_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(310, 10);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(140, 30);
            this.btnReportes.TabIndex = 2;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // dgvReservas
            // 
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AllowUserToDeleteRows = false;
            this.dgvReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colResCodigo,
            this.colResHabitacion,
            this.colResCliente,
            this.colResDocumento,
            this.colResEntrada,
            this.colResSalida,
            this.colResDescuento,
            this.colResEstado});
            this.dgvReservas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReservas.Location = new System.Drawing.Point(4, 5);
            this.dgvReservas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.RowHeadersWidth = 62;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.Size = new System.Drawing.Size(1334, 726);
            this.dgvReservas.TabIndex = 0;
            //
            // colResCodigo
            //
            this.colResCodigo.DataPropertyName = "Codigo";
            this.colResCodigo.HeaderText = "Código";
            this.colResCodigo.MinimumWidth = 8;
            this.colResCodigo.Name = "colResCodigo";
            //
            // colResHabitacion
            //
            this.colResHabitacion.DataPropertyName = "Habitacion";
            this.colResHabitacion.HeaderText = "Habitación";
            this.colResHabitacion.MinimumWidth = 8;
            this.colResHabitacion.Name = "colResHabitacion";
            //
            // colResCliente
            //
            this.colResCliente.DataPropertyName = "Cliente";
            this.colResCliente.HeaderText = "Cliente";
            this.colResCliente.MinimumWidth = 8;
            this.colResCliente.Name = "colResCliente";
            //
            // colResDocumento
            //
            this.colResDocumento.DataPropertyName = "Documento";
            this.colResDocumento.HeaderText = "Documento";
            this.colResDocumento.MinimumWidth = 8;
            this.colResDocumento.Name = "colResDocumento";
            //
            // colResEntrada
            //
            this.colResEntrada.DataPropertyName = "Entrada";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.colResEntrada.DefaultCellStyle = dataGridViewCellStyle2;
            this.colResEntrada.HeaderText = "Entrada";
            this.colResEntrada.MinimumWidth = 8;
            this.colResEntrada.Name = "colResEntrada";
            //
            // colResSalida
            //
            this.colResSalida.DataPropertyName = "Salida";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.colResSalida.DefaultCellStyle = dataGridViewCellStyle3;
            this.colResSalida.HeaderText = "Salida";
            this.colResSalida.MinimumWidth = 8;
            this.colResSalida.Name = "colResSalida";
            //
            // colResDescuento
            //
            this.colResDescuento.DataPropertyName = "Descuento";
            this.colResDescuento.HeaderText = "Descuento";
            this.colResDescuento.MinimumWidth = 8;
            this.colResDescuento.Name = "colResDescuento";
            //
            // colResEstado
            //
            this.colResEstado.DataPropertyName = "Estado";
            this.colResEstado.HeaderText = "Estado";
            this.colResEstado.MinimumWidth = 8;
            this.colResEstado.Name = "colResEstado";
            //
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 769);
            this.Controls.Add(this.tabPrincipal);
            this.Controls.Add(this.pnlCabecera);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Frío Dorado - Reservas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabHabitaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).EndInit();
            this.tabReservas.ResumeLayout(false);
            this.pnlAccionesReservas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblNombreHotel;
        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabHabitaciones;
        private System.Windows.Forms.DataGridView dgvHabitaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHabNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHabTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHabTarifaDiaria;
        private System.Windows.Forms.TabPage tabReservas;
        private System.Windows.Forms.Panel pnlAccionesReservas;
        private System.Windows.Forms.Button btnNuevaReserva;
        private System.Windows.Forms.Button btnCancelarReserva;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResEstado;

    }
}
