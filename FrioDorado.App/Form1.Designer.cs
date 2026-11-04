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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscarDocumento = new System.Windows.Forms.TextBox();
            this.lblBuscarDocumento = new System.Windows.Forms.Label();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnDisponibilidad = new System.Windows.Forms.Button();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.btnModificarReserva = new System.Windows.Forms.Button();
            this.btnNuevaReserva = new System.Windows.Forms.Button();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.lblNombreHotel = new System.Windows.Forms.Label();
            this.tabPrincipal.SuspendLayout();
            this.tabHabitaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones)).BeginInit();
            this.tabReservas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.pnlAccionesReservas.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            this.SuspendLayout();
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
            this.tabHabitaciones.Size = new System.Drawing.Size(1342, 676);
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
            this.dgvHabitaciones.Size = new System.Drawing.Size(1334, 666);
            this.dgvHabitaciones.TabIndex = 0;
            this.dgvHabitaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHabitaciones_CellContentClick);
            // 
            // colHabNumero
            // 
            this.colHabNumero.DataPropertyName = "Numero";
            this.colHabNumero.HeaderText = "Número";
            this.colHabNumero.MinimumWidth = 8;
            this.colHabNumero.Name = "colHabNumero";
            this.colHabNumero.ReadOnly = true;
            // 
            // colHabTipo
            // 
            this.colHabTipo.DataPropertyName = "Tipo";
            this.colHabTipo.HeaderText = "Tipo";
            this.colHabTipo.MinimumWidth = 8;
            this.colHabTipo.Name = "colHabTipo";
            this.colHabTipo.ReadOnly = true;
            // 
            // colHabTarifaDiaria
            // 
            this.colHabTarifaDiaria.DataPropertyName = "TarifaDiaria";
            dataGridViewCellStyle28.Format = "N2";
            dataGridViewCellStyle28.NullValue = null;
            this.colHabTarifaDiaria.DefaultCellStyle = dataGridViewCellStyle28;
            this.colHabTarifaDiaria.HeaderText = "Tarifa";
            this.colHabTarifaDiaria.MinimumWidth = 8;
            this.colHabTarifaDiaria.Name = "colHabTarifaDiaria";
            this.colHabTarifaDiaria.ReadOnly = true;
            // 
            // tabReservas
            // 
            this.tabReservas.Controls.Add(this.dgvReservas);
            this.tabReservas.Controls.Add(this.pnlAccionesReservas);
            this.tabReservas.Location = new System.Drawing.Point(4, 29);
            this.tabReservas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabReservas.Name = "tabReservas";
            this.tabReservas.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabReservas.Size = new System.Drawing.Size(1342, 676);
            this.tabReservas.TabIndex = 1;
            this.tabReservas.Text = "Reservas";
            this.tabReservas.UseVisualStyleBackColor = true;
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
            this.dgvReservas.Location = new System.Drawing.Point(4, 55);
            this.dgvReservas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.RowHeadersWidth = 62;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.Size = new System.Drawing.Size(1334, 616);
            this.dgvReservas.TabIndex = 0;
            // 
            // colResCodigo
            // 
            this.colResCodigo.DataPropertyName = "Codigo";
            this.colResCodigo.HeaderText = "Código";
            this.colResCodigo.MinimumWidth = 8;
            this.colResCodigo.Name = "colResCodigo";
            this.colResCodigo.ReadOnly = true;
            // 
            // colResHabitacion
            // 
            this.colResHabitacion.DataPropertyName = "Habitacion";
            this.colResHabitacion.HeaderText = "Habitación";
            this.colResHabitacion.MinimumWidth = 8;
            this.colResHabitacion.Name = "colResHabitacion";
            this.colResHabitacion.ReadOnly = true;
            // 
            // colResCliente
            // 
            this.colResCliente.DataPropertyName = "Cliente";
            this.colResCliente.HeaderText = "Cliente";
            this.colResCliente.MinimumWidth = 8;
            this.colResCliente.Name = "colResCliente";
            this.colResCliente.ReadOnly = true;
            // 
            // colResDocumento
            // 
            this.colResDocumento.DataPropertyName = "Documento";
            this.colResDocumento.HeaderText = "Documento";
            this.colResDocumento.MinimumWidth = 8;
            this.colResDocumento.Name = "colResDocumento";
            this.colResDocumento.ReadOnly = true;
            // 
            // colResEntrada
            // 
            this.colResEntrada.DataPropertyName = "Entrada";
            dataGridViewCellStyle29.Format = "dd/MM/yyyy";
            dataGridViewCellStyle29.NullValue = null;
            this.colResEntrada.DefaultCellStyle = dataGridViewCellStyle29;
            this.colResEntrada.HeaderText = "Entrada";
            this.colResEntrada.MinimumWidth = 8;
            this.colResEntrada.Name = "colResEntrada";
            this.colResEntrada.ReadOnly = true;
            // 
            // colResSalida
            // 
            this.colResSalida.DataPropertyName = "Salida";
            dataGridViewCellStyle30.Format = "dd/MM/yyyy";
            dataGridViewCellStyle30.NullValue = null;
            this.colResSalida.DefaultCellStyle = dataGridViewCellStyle30;
            this.colResSalida.HeaderText = "Salida";
            this.colResSalida.MinimumWidth = 8;
            this.colResSalida.Name = "colResSalida";
            this.colResSalida.ReadOnly = true;
            // 
            // colResDescuento
            // 
            this.colResDescuento.DataPropertyName = "Descuento";
            this.colResDescuento.HeaderText = "Descuento";
            this.colResDescuento.MinimumWidth = 8;
            this.colResDescuento.Name = "colResDescuento";
            this.colResDescuento.ReadOnly = true;
            // 
            // colResEstado
            // 
            this.colResEstado.DataPropertyName = "Estado";
            this.colResEstado.HeaderText = "Estado";
            this.colResEstado.MinimumWidth = 8;
            this.colResEstado.Name = "colResEstado";
            this.colResEstado.ReadOnly = true;
            // 
            // pnlAccionesReservas
            // 
            this.pnlAccionesReservas.Controls.Add(this.btnLimpiarBusqueda);
            this.pnlAccionesReservas.Controls.Add(this.btnBuscar);
            this.pnlAccionesReservas.Controls.Add(this.txtBuscarDocumento);
            this.pnlAccionesReservas.Controls.Add(this.lblBuscarDocumento);
            this.pnlAccionesReservas.Controls.Add(this.btnReportes);
            this.pnlAccionesReservas.Controls.Add(this.btnDisponibilidad);
            this.pnlAccionesReservas.Controls.Add(this.btnCancelarReserva);
            this.pnlAccionesReservas.Controls.Add(this.btnModificarReserva);
            this.pnlAccionesReservas.Controls.Add(this.btnNuevaReserva);
            this.pnlAccionesReservas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAccionesReservas.Location = new System.Drawing.Point(4, 5);
            this.pnlAccionesReservas.Name = "pnlAccionesReservas";
            this.pnlAccionesReservas.Size = new System.Drawing.Size(1334, 50);
            this.pnlAccionesReservas.TabIndex = 1;
            // 
            // btnLimpiarBusqueda
            // 
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(1039, 13);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(95, 30);
            this.btnLimpiarBusqueda.TabIndex = 8;
            this.btnLimpiarBusqueda.Text = "Limpiar";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(958, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 30);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscarDocumento
            // 
            this.txtBuscarDocumento.Location = new System.Drawing.Point(812, 13);
            this.txtBuscarDocumento.Name = "txtBuscarDocumento";
            this.txtBuscarDocumento.Size = new System.Drawing.Size(140, 26);
            this.txtBuscarDocumento.TabIndex = 6;
            // 
            // lblBuscarDocumento
            // 
            this.lblBuscarDocumento.AutoSize = true;
            this.lblBuscarDocumento.Location = new System.Drawing.Point(701, 15);
            this.lblBuscarDocumento.Name = "lblBuscarDocumento";
            this.lblBuscarDocumento.Size = new System.Drawing.Size(96, 20);
            this.lblBuscarDocumento.TabIndex = 5;
            this.lblBuscarDocumento.Text = "Documento:";
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(584, 8);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(111, 34);
            this.btnReportes.TabIndex = 4;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnDisponibilidad
            // 
            this.btnDisponibilidad.Location = new System.Drawing.Point(415, 10);
            this.btnDisponibilidad.Name = "btnDisponibilidad";
            this.btnDisponibilidad.Size = new System.Drawing.Size(163, 30);
            this.btnDisponibilidad.TabIndex = 3;
            this.btnDisponibilidad.Text = "Disponibilidad";
            this.btnDisponibilidad.UseVisualStyleBackColor = true;
            this.btnDisponibilidad.Click += new System.EventHandler(this.btnDisponibilidad_Click);
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.Location = new System.Drawing.Point(280, 10);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(129, 30);
            this.btnCancelarReserva.TabIndex = 2;
            this.btnCancelarReserva.Text = "Cancelar Reserva";
            this.btnCancelarReserva.UseVisualStyleBackColor = true;
            this.btnCancelarReserva.Click += new System.EventHandler(this.btnCancelarReserva_Click);
            // 
            // btnModificarReserva
            // 
            this.btnModificarReserva.Location = new System.Drawing.Point(135, 10);
            this.btnModificarReserva.Name = "btnModificarReserva";
            this.btnModificarReserva.Size = new System.Drawing.Size(140, 30);
            this.btnModificarReserva.TabIndex = 1;
            this.btnModificarReserva.Text = "Modificar Reserva";
            this.btnModificarReserva.UseVisualStyleBackColor = true;
            this.btnModificarReserva.Click += new System.EventHandler(this.btnModificarReserva_Click);
            // 
            // btnNuevaReserva
            // 
            this.btnNuevaReserva.Location = new System.Drawing.Point(10, 10);
            this.btnNuevaReserva.Name = "btnNuevaReserva";
            this.btnNuevaReserva.Size = new System.Drawing.Size(120, 30);
            this.btnNuevaReserva.TabIndex = 0;
            this.btnNuevaReserva.Text = "Nueva Reserva";
            this.btnNuevaReserva.UseVisualStyleBackColor = true;
            this.btnNuevaReserva.Click += new System.EventHandler(this.btnNuevaReserva_Click);
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
            this.lblNombreHotel.Size = new System.Drawing.Size(294, 45);
            this.lblNombreHotel.TabIndex = 0;
            this.lblNombreHotel.Text = "Hotel Frío Dorado";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.pnlAccionesReservas.ResumeLayout(false);
            this.pnlAccionesReservas.PerformLayout();
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
        private System.Windows.Forms.Button btnModificarReserva;
        private System.Windows.Forms.Button btnCancelarReserva;
        private System.Windows.Forms.Button btnDisponibilidad;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Label lblBuscarDocumento;
        private System.Windows.Forms.TextBox txtBuscarDocumento;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiarBusqueda;
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
