namespace FrioDorado.App
{
    partial class FormNuevaReserva
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
            this.lblTituloHabitacion = new System.Windows.Forms.Label();
            this.cmbHabitacion = new System.Windows.Forms.ComboBox();
            this.lblTituloCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblTituloDocumento = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblTituloEntrada = new System.Windows.Forms.Label();
            this.dtpEntrada = new System.Windows.Forms.DateTimePicker();
            this.lblTituloSalida = new System.Windows.Forms.Label();
            this.dtpSalida = new System.Windows.Forms.DateTimePicker();
            this.lblTituloDescuento = new System.Windows.Forms.Label();
            this.numDescuento = new System.Windows.Forms.NumericUpDown();
            this.lblTituloNoches = new System.Windows.Forms.Label();
            this.lblNoches = new System.Windows.Forms.Label();
            this.lblTituloTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDescuento)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloHabitacion
            // 
            this.lblTituloHabitacion.AutoSize = true;
            this.lblTituloHabitacion.Location = new System.Drawing.Point(30, 25);
            this.lblTituloHabitacion.Name = "lblTituloHabitacion";
            this.lblTituloHabitacion.Size = new System.Drawing.Size(61, 13);
            this.lblTituloHabitacion.TabIndex = 0;
            this.lblTituloHabitacion.Text = "Habitación:";
            // 
            // cmbHabitacion
            // 
            this.cmbHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHabitacion.FormattingEnabled = true;
            this.cmbHabitacion.Location = new System.Drawing.Point(120, 22);
            this.cmbHabitacion.Name = "cmbHabitacion";
            this.cmbHabitacion.Size = new System.Drawing.Size(260, 21);
            this.cmbHabitacion.TabIndex = 1;
            // 
            // lblTituloCliente
            // 
            this.lblTituloCliente.AutoSize = true;
            this.lblTituloCliente.Location = new System.Drawing.Point(30, 60);
            this.lblTituloCliente.Name = "lblTituloCliente";
            this.lblTituloCliente.Size = new System.Drawing.Size(42, 13);
            this.lblTituloCliente.TabIndex = 2;
            this.lblTituloCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(120, 57);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(260, 20);
            this.txtCliente.TabIndex = 3;
            // 
            // lblTituloDocumento
            // 
            this.lblTituloDocumento.AutoSize = true;
            this.lblTituloDocumento.Location = new System.Drawing.Point(30, 95);
            this.lblTituloDocumento.Name = "lblTituloDocumento";
            this.lblTituloDocumento.Size = new System.Drawing.Size(65, 13);
            this.lblTituloDocumento.TabIndex = 4;
            this.lblTituloDocumento.Text = "Documento:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(120, 92);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(260, 20);
            this.txtDocumento.TabIndex = 5;
            // 
            // lblTituloEntrada
            // 
            this.lblTituloEntrada.AutoSize = true;
            this.lblTituloEntrada.Location = new System.Drawing.Point(30, 130);
            this.lblTituloEntrada.Name = "lblTituloEntrada";
            this.lblTituloEntrada.Size = new System.Drawing.Size(47, 13);
            this.lblTituloEntrada.TabIndex = 6;
            this.lblTituloEntrada.Text = "Entrada:";
            // 
            // dtpEntrada
            // 
            this.dtpEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntrada.Location = new System.Drawing.Point(120, 127);
            this.dtpEntrada.Name = "dtpEntrada";
            this.dtpEntrada.Size = new System.Drawing.Size(120, 20);
            this.dtpEntrada.TabIndex = 7;
            // 
            // lblTituloSalida
            // 
            this.lblTituloSalida.AutoSize = true;
            this.lblTituloSalida.Location = new System.Drawing.Point(30, 165);
            this.lblTituloSalida.Name = "lblTituloSalida";
            this.lblTituloSalida.Size = new System.Drawing.Size(39, 13);
            this.lblTituloSalida.TabIndex = 8;
            this.lblTituloSalida.Text = "Salida:";
            // 
            // dtpSalida
            // 
            this.dtpSalida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSalida.Location = new System.Drawing.Point(120, 162);
            this.dtpSalida.Name = "dtpSalida";
            this.dtpSalida.Size = new System.Drawing.Size(120, 20);
            this.dtpSalida.TabIndex = 9;
            // 
            // lblTituloDescuento
            // 
            this.lblTituloDescuento.AutoSize = true;
            this.lblTituloDescuento.Location = new System.Drawing.Point(30, 200);
            this.lblTituloDescuento.Name = "lblTituloDescuento";
            this.lblTituloDescuento.Size = new System.Drawing.Size(78, 13);
            this.lblTituloDescuento.TabIndex = 10;
            this.lblTituloDescuento.Text = "Descuento (%):";
            // 
            // numDescuento
            // 
            this.numDescuento.DecimalPlaces = 2;
            this.numDescuento.Location = new System.Drawing.Point(120, 198);
            this.numDescuento.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDescuento.Name = "numDescuento";
            this.numDescuento.Size = new System.Drawing.Size(120, 20);
            this.numDescuento.TabIndex = 11;
            // 
            // lblTituloNoches
            // 
            this.lblTituloNoches.AutoSize = true;
            this.lblTituloNoches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloNoches.Location = new System.Drawing.Point(30, 235);
            this.lblTituloNoches.Name = "lblTituloNoches";
            this.lblTituloNoches.Size = new System.Drawing.Size(54, 13);
            this.lblTituloNoches.TabIndex = 12;
            this.lblTituloNoches.Text = "Noches:";
            // 
            // lblNoches
            // 
            this.lblNoches.AutoSize = true;
            this.lblNoches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoches.Location = new System.Drawing.Point(120, 235);
            this.lblNoches.Name = "lblNoches";
            this.lblNoches.Size = new System.Drawing.Size(10, 13);
            this.lblNoches.TabIndex = 13;
            this.lblNoches.Text = "-";
            // 
            // lblTituloTotal
            // 
            this.lblTituloTotal.AutoSize = true;
            this.lblTituloTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTotal.Location = new System.Drawing.Point(30, 265);
            this.lblTituloTotal.Name = "lblTituloTotal";
            this.lblTituloTotal.Size = new System.Drawing.Size(40, 13);
            this.lblTituloTotal.TabIndex = 14;
            this.lblTituloTotal.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(120, 265);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(10, 13);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "-";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(215, 305);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(80, 28);
            this.btnCrear.TabIndex = 16;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(300, 305);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(80, 28);
            this.btnCerrar.TabIndex = 17;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormNuevaReserva
            // 
            this.AcceptButton = this.btnCrear;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(414, 351);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTituloTotal);
            this.Controls.Add(this.lblNoches);
            this.Controls.Add(this.lblTituloNoches);
            this.Controls.Add(this.numDescuento);
            this.Controls.Add(this.lblTituloDescuento);
            this.Controls.Add(this.dtpSalida);
            this.Controls.Add(this.lblTituloSalida);
            this.Controls.Add(this.dtpEntrada);
            this.Controls.Add(this.lblTituloEntrada);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.lblTituloDocumento);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblTituloCliente);
            this.Controls.Add(this.cmbHabitacion);
            this.Controls.Add(this.lblTituloHabitacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNuevaReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Reserva";
            ((System.ComponentModel.ISupportInitialize)(this.numDescuento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloHabitacion;
        private System.Windows.Forms.ComboBox cmbHabitacion;
        private System.Windows.Forms.Label lblTituloCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblTituloDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblTituloEntrada;
        private System.Windows.Forms.DateTimePicker dtpEntrada;
        private System.Windows.Forms.Label lblTituloSalida;
        private System.Windows.Forms.DateTimePicker dtpSalida;
        private System.Windows.Forms.Label lblTituloDescuento;
        private System.Windows.Forms.NumericUpDown numDescuento;
        private System.Windows.Forms.Label lblTituloNoches;
        private System.Windows.Forms.Label lblNoches;
        private System.Windows.Forms.Label lblTituloTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnCerrar;
    }
}