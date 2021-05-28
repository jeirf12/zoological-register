namespace AppZoologico
{
    partial class appZoologico
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(appZoologico));
            this.tbpBorrarAnimal = new System.Windows.Forms.TabPage();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtCodElimAnim = new System.Windows.Forms.TextBox();
            this.txtNitZooElimAnim = new System.Windows.Forms.TextBox();
            this.lblCodElimAnim = new System.Windows.Forms.Label();
            this.lblNitZooElimAnim = new System.Windows.Forms.Label();
            this.tbpBuscarAnimal = new System.Windows.Forms.TabPage();
            this.btnBuscarAnimal = new System.Windows.Forms.Button();
            this.rtxtInfoAnim = new System.Windows.Forms.RichTextBox();
            this.txtCodBusAnim = new System.Windows.Forms.TextBox();
            this.txtZooBusAnim = new System.Windows.Forms.TextBox();
            this.lblCodAnimBusc = new System.Windows.Forms.Label();
            this.lblNiTzooBusAnim = new System.Windows.Forms.Label();
            this.tbpBuscarZoologico = new System.Windows.Forms.TabPage();
            this.btnBuscarZoologico = new System.Windows.Forms.Button();
            this.txtNitBuscar = new System.Windows.Forms.TextBox();
            this.lblNitZooBus = new System.Windows.Forms.Label();
            this.rtxtInfoZool = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpRegistroZoologico = new System.Windows.Forms.TabPage();
            this.pnlRegistroZoologico = new System.Windows.Forms.Panel();
            this.btnGuardarInformacion = new System.Windows.Forms.Button();
            this.rbCerrado = new System.Windows.Forms.RadioButton();
            this.rbAbierto = new System.Windows.Forms.RadioButton();
            this.txtNomZool = new System.Windows.Forms.TextBox();
            this.txtNitZool = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblNomZoologico = new System.Windows.Forms.Label();
            this.lblNit = new System.Windows.Forms.Label();
            this.lblMsj2 = new System.Windows.Forms.Label();
            this.lblMsj1 = new System.Windows.Forms.Label();
            this.tbpRegistroAnimal = new System.Windows.Forms.TabPage();
            this.pnlRegistroAnimal = new System.Windows.Forms.Panel();
            this.btnGuardarInformacionAnimal = new System.Windows.Forms.Button();
            this.txtPesoAnim = new System.Windows.Forms.TextBox();
            this.cbxContOrig = new System.Windows.Forms.ComboBox();
            this.txtNomAnim = new System.Windows.Forms.TextBox();
            this.txtCodAnim = new System.Windows.Forms.TextBox();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblCont = new System.Windows.Forms.Label();
            this.lblNomAnim = new System.Windows.Forms.Label();
            this.lblCodigoAnim = new System.Windows.Forms.Label();
            this.lblMsj3 = new System.Windows.Forms.Label();
            this.lblMensajeAnimal = new System.Windows.Forms.Label();
            this.tbpBorrarAnimal.SuspendLayout();
            this.tbpBuscarAnimal.SuspendLayout();
            this.tbpBuscarZoologico.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbpRegistroZoologico.SuspendLayout();
            this.pnlRegistroZoologico.SuspendLayout();
            this.tbpRegistroAnimal.SuspendLayout();
            this.pnlRegistroAnimal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbpBorrarAnimal
            // 
            this.tbpBorrarAnimal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbpBorrarAnimal.BackgroundImage")));
            this.tbpBorrarAnimal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbpBorrarAnimal.Controls.Add(this.btnEliminar);
            this.tbpBorrarAnimal.Controls.Add(this.txtCodElimAnim);
            this.tbpBorrarAnimal.Controls.Add(this.txtNitZooElimAnim);
            this.tbpBorrarAnimal.Controls.Add(this.lblCodElimAnim);
            this.tbpBorrarAnimal.Controls.Add(this.lblNitZooElimAnim);
            this.tbpBorrarAnimal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpBorrarAnimal.Location = new System.Drawing.Point(4, 22);
            this.tbpBorrarAnimal.Name = "tbpBorrarAnimal";
            this.tbpBorrarAnimal.Size = new System.Drawing.Size(573, 324);
            this.tbpBorrarAnimal.TabIndex = 4;
            this.tbpBorrarAnimal.Text = "BorrarAnimal";
            this.tbpBorrarAnimal.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(434, 224);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 38);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtCodElimAnim
            // 
            this.txtCodElimAnim.Location = new System.Drawing.Point(434, 150);
            this.txtCodElimAnim.Name = "txtCodElimAnim";
            this.txtCodElimAnim.Size = new System.Drawing.Size(100, 29);
            this.txtCodElimAnim.TabIndex = 3;
            // 
            // txtNitZooElimAnim
            // 
            this.txtNitZooElimAnim.Location = new System.Drawing.Point(434, 82);
            this.txtNitZooElimAnim.Name = "txtNitZooElimAnim";
            this.txtNitZooElimAnim.Size = new System.Drawing.Size(100, 29);
            this.txtNitZooElimAnim.TabIndex = 2;
            // 
            // lblCodElimAnim
            // 
            this.lblCodElimAnim.AutoSize = true;
            this.lblCodElimAnim.Location = new System.Drawing.Point(60, 153);
            this.lblCodElimAnim.Name = "lblCodElimAnim";
            this.lblCodElimAnim.Size = new System.Drawing.Size(287, 21);
            this.lblCodElimAnim.TabIndex = 1;
            this.lblCodElimAnim.Text = "Dígite el codigo del animal a eliminar:";
            // 
            // lblNitZooElimAnim
            // 
            this.lblNitZooElimAnim.AutoSize = true;
            this.lblNitZooElimAnim.Location = new System.Drawing.Point(14, 85);
            this.lblNitZooElimAnim.Name = "lblNitZooElimAnim";
            this.lblNitZooElimAnim.Size = new System.Drawing.Size(414, 21);
            this.lblNitZooElimAnim.TabIndex = 0;
            this.lblNitZooElimAnim.Text = "Dígite el nit del zoologico donde se encuentra el animal:";
            // 
            // tbpBuscarAnimal
            // 
            this.tbpBuscarAnimal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbpBuscarAnimal.BackgroundImage")));
            this.tbpBuscarAnimal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbpBuscarAnimal.Controls.Add(this.btnBuscarAnimal);
            this.tbpBuscarAnimal.Controls.Add(this.rtxtInfoAnim);
            this.tbpBuscarAnimal.Controls.Add(this.txtCodBusAnim);
            this.tbpBuscarAnimal.Controls.Add(this.txtZooBusAnim);
            this.tbpBuscarAnimal.Controls.Add(this.lblCodAnimBusc);
            this.tbpBuscarAnimal.Controls.Add(this.lblNiTzooBusAnim);
            this.tbpBuscarAnimal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpBuscarAnimal.Location = new System.Drawing.Point(4, 22);
            this.tbpBuscarAnimal.Name = "tbpBuscarAnimal";
            this.tbpBuscarAnimal.Size = new System.Drawing.Size(573, 324);
            this.tbpBuscarAnimal.TabIndex = 3;
            this.tbpBuscarAnimal.Text = "BuscarAnimal";
            this.tbpBuscarAnimal.UseVisualStyleBackColor = true;
            // 
            // btnBuscarAnimal
            // 
            this.btnBuscarAnimal.Location = new System.Drawing.Point(435, 84);
            this.btnBuscarAnimal.Name = "btnBuscarAnimal";
            this.btnBuscarAnimal.Size = new System.Drawing.Size(100, 32);
            this.btnBuscarAnimal.TabIndex = 5;
            this.btnBuscarAnimal.Text = "Buscar";
            this.btnBuscarAnimal.UseVisualStyleBackColor = true;
            this.btnBuscarAnimal.Click += new System.EventHandler(this.btnBuscarAnimal_Click);
            // 
            // rtxtInfoAnim
            // 
            this.rtxtInfoAnim.Location = new System.Drawing.Point(22, 122);
            this.rtxtInfoAnim.Name = "rtxtInfoAnim";
            this.rtxtInfoAnim.Size = new System.Drawing.Size(533, 190);
            this.rtxtInfoAnim.TabIndex = 4;
            this.rtxtInfoAnim.Text = "";
            // 
            // txtCodBusAnim
            // 
            this.txtCodBusAnim.Location = new System.Drawing.Point(435, 49);
            this.txtCodBusAnim.Name = "txtCodBusAnim";
            this.txtCodBusAnim.Size = new System.Drawing.Size(100, 29);
            this.txtCodBusAnim.TabIndex = 3;
            // 
            // txtZooBusAnim
            // 
            this.txtZooBusAnim.Location = new System.Drawing.Point(435, 13);
            this.txtZooBusAnim.Name = "txtZooBusAnim";
            this.txtZooBusAnim.Size = new System.Drawing.Size(100, 29);
            this.txtZooBusAnim.TabIndex = 2;
            // 
            // lblCodAnimBusc
            // 
            this.lblCodAnimBusc.AutoSize = true;
            this.lblCodAnimBusc.Location = new System.Drawing.Point(18, 38);
            this.lblCodAnimBusc.Name = "lblCodAnimBusc";
            this.lblCodAnimBusc.Size = new System.Drawing.Size(273, 21);
            this.lblCodAnimBusc.TabIndex = 1;
            this.lblCodAnimBusc.Text = "Dígite el codigo del animal a buscar:";
            // 
            // lblNiTzooBusAnim
            // 
            this.lblNiTzooBusAnim.AutoSize = true;
            this.lblNiTzooBusAnim.Location = new System.Drawing.Point(14, 13);
            this.lblNiTzooBusAnim.Name = "lblNiTzooBusAnim";
            this.lblNiTzooBusAnim.Size = new System.Drawing.Size(414, 21);
            this.lblNiTzooBusAnim.TabIndex = 0;
            this.lblNiTzooBusAnim.Text = "Dígite el nit del zoologico donde se encuentra el animal:";
            // 
            // tbpBuscarZoologico
            // 
            this.tbpBuscarZoologico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbpBuscarZoologico.BackgroundImage")));
            this.tbpBuscarZoologico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbpBuscarZoologico.Controls.Add(this.btnBuscarZoologico);
            this.tbpBuscarZoologico.Controls.Add(this.txtNitBuscar);
            this.tbpBuscarZoologico.Controls.Add(this.lblNitZooBus);
            this.tbpBuscarZoologico.Controls.Add(this.rtxtInfoZool);
            this.tbpBuscarZoologico.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpBuscarZoologico.Location = new System.Drawing.Point(4, 22);
            this.tbpBuscarZoologico.Name = "tbpBuscarZoologico";
            this.tbpBuscarZoologico.Size = new System.Drawing.Size(573, 324);
            this.tbpBuscarZoologico.TabIndex = 2;
            this.tbpBuscarZoologico.Text = "BuscarZoologico";
            this.tbpBuscarZoologico.UseVisualStyleBackColor = true;
            // 
            // btnBuscarZoologico
            // 
            this.btnBuscarZoologico.Location = new System.Drawing.Point(393, 10);
            this.btnBuscarZoologico.Name = "btnBuscarZoologico";
            this.btnBuscarZoologico.Size = new System.Drawing.Size(95, 32);
            this.btnBuscarZoologico.TabIndex = 3;
            this.btnBuscarZoologico.Text = "Buscar";
            this.btnBuscarZoologico.UseVisualStyleBackColor = true;
            this.btnBuscarZoologico.Click += new System.EventHandler(this.btnBuscarZoologico_Click);
            // 
            // txtNitBuscar
            // 
            this.txtNitBuscar.Location = new System.Drawing.Point(235, 13);
            this.txtNitBuscar.Name = "txtNitBuscar";
            this.txtNitBuscar.Size = new System.Drawing.Size(130, 29);
            this.txtNitBuscar.TabIndex = 2;
            // 
            // lblNitZooBus
            // 
            this.lblNitZooBus.AutoSize = true;
            this.lblNitZooBus.Location = new System.Drawing.Point(24, 13);
            this.lblNitZooBus.Name = "lblNitZooBus";
            this.lblNitZooBus.Size = new System.Drawing.Size(204, 21);
            this.lblNitZooBus.TabIndex = 1;
            this.lblNitZooBus.Text = "Digite el Nit del Zoologico:";
            // 
            // rtxtInfoZool
            // 
            this.rtxtInfoZool.Location = new System.Drawing.Point(14, 48);
            this.rtxtInfoZool.Name = "rtxtInfoZool";
            this.rtxtInfoZool.Size = new System.Drawing.Size(539, 262);
            this.rtxtInfoZool.TabIndex = 0;
            this.rtxtInfoZool.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpRegistroZoologico);
            this.tabControl1.Controls.Add(this.tbpRegistroAnimal);
            this.tabControl1.Controls.Add(this.tbpBuscarZoologico);
            this.tabControl1.Controls.Add(this.tbpBuscarAnimal);
            this.tabControl1.Controls.Add(this.tbpBorrarAnimal);
            this.tabControl1.Location = new System.Drawing.Point(13, 90);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(581, 350);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpRegistroZoologico
            // 
            this.tbpRegistroZoologico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbpRegistroZoologico.Controls.Add(this.pnlRegistroZoologico);
            this.tbpRegistroZoologico.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpRegistroZoologico.Location = new System.Drawing.Point(4, 22);
            this.tbpRegistroZoologico.Name = "tbpRegistroZoologico";
            this.tbpRegistroZoologico.Size = new System.Drawing.Size(573, 324);
            this.tbpRegistroZoologico.TabIndex = 5;
            this.tbpRegistroZoologico.Text = "RegistroZoologico";
            this.tbpRegistroZoologico.UseVisualStyleBackColor = true;
            // 
            // pnlRegistroZoologico
            // 
            this.pnlRegistroZoologico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlRegistroZoologico.BackgroundImage")));
            this.pnlRegistroZoologico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlRegistroZoologico.Controls.Add(this.btnGuardarInformacion);
            this.pnlRegistroZoologico.Controls.Add(this.rbCerrado);
            this.pnlRegistroZoologico.Controls.Add(this.rbAbierto);
            this.pnlRegistroZoologico.Controls.Add(this.txtNomZool);
            this.pnlRegistroZoologico.Controls.Add(this.txtNitZool);
            this.pnlRegistroZoologico.Controls.Add(this.lblEstado);
            this.pnlRegistroZoologico.Controls.Add(this.lblNomZoologico);
            this.pnlRegistroZoologico.Controls.Add(this.lblNit);
            this.pnlRegistroZoologico.Controls.Add(this.lblMsj2);
            this.pnlRegistroZoologico.Controls.Add(this.lblMsj1);
            this.pnlRegistroZoologico.Location = new System.Drawing.Point(15, 13);
            this.pnlRegistroZoologico.Name = "pnlRegistroZoologico";
            this.pnlRegistroZoologico.Size = new System.Drawing.Size(541, 295);
            this.pnlRegistroZoologico.TabIndex = 0;
            // 
            // btnGuardarInformacion
            // 
            this.btnGuardarInformacion.Location = new System.Drawing.Point(131, 250);
            this.btnGuardarInformacion.Name = "btnGuardarInformacion";
            this.btnGuardarInformacion.Size = new System.Drawing.Size(286, 30);
            this.btnGuardarInformacion.TabIndex = 26;
            this.btnGuardarInformacion.Text = "Guardar Informacion Zoologico";
            this.btnGuardarInformacion.UseVisualStyleBackColor = true;
            this.btnGuardarInformacion.Click += new System.EventHandler(this.btnGuardarInformacion_Click);
            // 
            // rbCerrado
            // 
            this.rbCerrado.AutoSize = true;
            this.rbCerrado.Location = new System.Drawing.Point(164, 204);
            this.rbCerrado.Name = "rbCerrado";
            this.rbCerrado.Size = new System.Drawing.Size(85, 25);
            this.rbCerrado.TabIndex = 16;
            this.rbCerrado.TabStop = true;
            this.rbCerrado.Text = "Cerrado";
            this.rbCerrado.UseVisualStyleBackColor = true;
            // 
            // rbAbierto
            // 
            this.rbAbierto.AutoSize = true;
            this.rbAbierto.Location = new System.Drawing.Point(164, 173);
            this.rbAbierto.Name = "rbAbierto";
            this.rbAbierto.Size = new System.Drawing.Size(82, 25);
            this.rbAbierto.TabIndex = 15;
            this.rbAbierto.TabStop = true;
            this.rbAbierto.Text = "Abierto";
            this.rbAbierto.UseVisualStyleBackColor = true;
            // 
            // txtNomZool
            // 
            this.txtNomZool.Location = new System.Drawing.Point(167, 126);
            this.txtNomZool.Name = "txtNomZool";
            this.txtNomZool.Size = new System.Drawing.Size(131, 29);
            this.txtNomZool.TabIndex = 14;
            // 
            // txtNitZool
            // 
            this.txtNitZool.Location = new System.Drawing.Point(167, 85);
            this.txtNitZool.Name = "txtNitZool";
            this.txtNitZool.Size = new System.Drawing.Size(131, 29);
            this.txtNitZool.TabIndex = 13;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(4, 173);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(62, 21);
            this.lblEstado.TabIndex = 12;
            this.lblEstado.Text = "Estado:";
            // 
            // lblNomZoologico
            // 
            this.lblNomZoologico.AutoSize = true;
            this.lblNomZoologico.Location = new System.Drawing.Point(4, 129);
            this.lblNomZoologico.Name = "lblNomZoologico";
            this.lblNomZoologico.Size = new System.Drawing.Size(147, 21);
            this.lblNomZoologico.TabIndex = 11;
            this.lblNomZoologico.Text = "Nombre Zoologico:";
            // 
            // lblNit
            // 
            this.lblNit.AutoSize = true;
            this.lblNit.Location = new System.Drawing.Point(4, 88);
            this.lblNit.Name = "lblNit";
            this.lblNit.Size = new System.Drawing.Size(112, 21);
            this.lblNit.TabIndex = 10;
            this.lblNit.Text = "Nit Zoologico:";
            // 
            // lblMsj2
            // 
            this.lblMsj2.AutoSize = true;
            this.lblMsj2.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsj2.Location = new System.Drawing.Point(4, 52);
            this.lblMsj2.Name = "lblMsj2";
            this.lblMsj2.Size = new System.Drawing.Size(195, 21);
            this.lblMsj2.TabIndex = 9;
            this.lblMsj2.Text = "Informacion Zoologico:";
            // 
            // lblMsj1
            // 
            this.lblMsj1.AutoSize = true;
            this.lblMsj1.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsj1.Location = new System.Drawing.Point(80, 11);
            this.lblMsj1.Name = "lblMsj1";
            this.lblMsj1.Size = new System.Drawing.Size(364, 50);
            this.lblMsj1.TabIndex = 1;
            this.lblMsj1.Text = "Registra la Informacion del Zoologico\r\n\r\n";
            // 
            // tbpRegistroAnimal
            // 
            this.tbpRegistroAnimal.Controls.Add(this.pnlRegistroAnimal);
            this.tbpRegistroAnimal.Location = new System.Drawing.Point(4, 22);
            this.tbpRegistroAnimal.Name = "tbpRegistroAnimal";
            this.tbpRegistroAnimal.Size = new System.Drawing.Size(573, 324);
            this.tbpRegistroAnimal.TabIndex = 6;
            this.tbpRegistroAnimal.Text = "RegistroAnimal";
            this.tbpRegistroAnimal.UseVisualStyleBackColor = true;
            // 
            // pnlRegistroAnimal
            // 
            this.pnlRegistroAnimal.Controls.Add(this.btnGuardarInformacionAnimal);
            this.pnlRegistroAnimal.Controls.Add(this.txtPesoAnim);
            this.pnlRegistroAnimal.Controls.Add(this.cbxContOrig);
            this.pnlRegistroAnimal.Controls.Add(this.txtNomAnim);
            this.pnlRegistroAnimal.Controls.Add(this.txtCodAnim);
            this.pnlRegistroAnimal.Controls.Add(this.lblPeso);
            this.pnlRegistroAnimal.Controls.Add(this.lblCont);
            this.pnlRegistroAnimal.Controls.Add(this.lblNomAnim);
            this.pnlRegistroAnimal.Controls.Add(this.lblCodigoAnim);
            this.pnlRegistroAnimal.Controls.Add(this.lblMsj3);
            this.pnlRegistroAnimal.Controls.Add(this.lblMensajeAnimal);
            this.pnlRegistroAnimal.Location = new System.Drawing.Point(3, 3);
            this.pnlRegistroAnimal.Name = "pnlRegistroAnimal";
            this.pnlRegistroAnimal.Size = new System.Drawing.Size(723, 310);
            this.pnlRegistroAnimal.TabIndex = 0;
            // 
            // btnGuardarInformacionAnimal
            // 
            this.btnGuardarInformacionAnimal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnGuardarInformacionAnimal.Location = new System.Drawing.Point(117, 210);
            this.btnGuardarInformacionAnimal.Name = "btnGuardarInformacionAnimal";
            this.btnGuardarInformacionAnimal.Size = new System.Drawing.Size(238, 37);
            this.btnGuardarInformacionAnimal.TabIndex = 27;
            this.btnGuardarInformacionAnimal.Text = "Guardar Informacion Animal";
            this.btnGuardarInformacionAnimal.UseVisualStyleBackColor = true;
            this.btnGuardarInformacionAnimal.Click += new System.EventHandler(this.btnGuardarInformacionAnimal_Click);
            // 
            // txtPesoAnim
            // 
            this.txtPesoAnim.Location = new System.Drawing.Point(170, 163);
            this.txtPesoAnim.Name = "txtPesoAnim";
            this.txtPesoAnim.Size = new System.Drawing.Size(121, 20);
            this.txtPesoAnim.TabIndex = 26;
            // 
            // cbxContOrig
            // 
            this.cbxContOrig.FormattingEnabled = true;
            this.cbxContOrig.Items.AddRange(new object[] {
            "América",
            "Asia",
            "África",
            "Europa",
            "Oceanía"});
            this.cbxContOrig.Location = new System.Drawing.Point(170, 136);
            this.cbxContOrig.Name = "cbxContOrig";
            this.cbxContOrig.Size = new System.Drawing.Size(121, 21);
            this.cbxContOrig.TabIndex = 25;
            // 
            // txtNomAnim
            // 
            this.txtNomAnim.Location = new System.Drawing.Point(170, 110);
            this.txtNomAnim.Name = "txtNomAnim";
            this.txtNomAnim.Size = new System.Drawing.Size(121, 20);
            this.txtNomAnim.TabIndex = 24;
            // 
            // txtCodAnim
            // 
            this.txtCodAnim.Location = new System.Drawing.Point(170, 78);
            this.txtCodAnim.Name = "txtCodAnim";
            this.txtCodAnim.Size = new System.Drawing.Size(121, 20);
            this.txtCodAnim.TabIndex = 23;
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblPeso.Location = new System.Drawing.Point(21, 161);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(48, 21);
            this.lblPeso.TabIndex = 22;
            this.lblPeso.Text = "Peso:";
            // 
            // lblCont
            // 
            this.lblCont.AutoSize = true;
            this.lblCont.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblCont.Location = new System.Drawing.Point(21, 133);
            this.lblCont.Name = "lblCont";
            this.lblCont.Size = new System.Drawing.Size(146, 21);
            this.lblCont.TabIndex = 21;
            this.lblCont.Text = "Continente Origen:";
            // 
            // lblNomAnim
            // 
            this.lblNomAnim.AutoSize = true;
            this.lblNomAnim.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblNomAnim.Location = new System.Drawing.Point(21, 107);
            this.lblNomAnim.Name = "lblNomAnim";
            this.lblNomAnim.Size = new System.Drawing.Size(128, 21);
            this.lblNomAnim.TabIndex = 20;
            this.lblNomAnim.Text = "Nombre Especie:";
            // 
            // lblCodigoAnim
            // 
            this.lblCodigoAnim.AutoSize = true;
            this.lblCodigoAnim.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblCodigoAnim.Location = new System.Drawing.Point(21, 81);
            this.lblCodigoAnim.Name = "lblCodigoAnim";
            this.lblCodigoAnim.Size = new System.Drawing.Size(65, 21);
            this.lblCodigoAnim.TabIndex = 19;
            this.lblCodigoAnim.Text = "Código:";
            // 
            // lblMsj3
            // 
            this.lblMsj3.AutoSize = true;
            this.lblMsj3.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsj3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMsj3.Location = new System.Drawing.Point(20, 49);
            this.lblMsj3.Name = "lblMsj3";
            this.lblMsj3.Size = new System.Drawing.Size(174, 21);
            this.lblMsj3.TabIndex = 18;
            this.lblMsj3.Text = "Informacion Animal:";
            // 
            // lblMensajeAnimal
            // 
            this.lblMensajeAnimal.AutoSize = true;
            this.lblMensajeAnimal.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeAnimal.Location = new System.Drawing.Point(92, 12);
            this.lblMensajeAnimal.Name = "lblMensajeAnimal";
            this.lblMensajeAnimal.Size = new System.Drawing.Size(290, 25);
            this.lblMensajeAnimal.TabIndex = 0;
            this.lblMensajeAnimal.Text = "Registrar Informacion Animal";
            // 
            // appZoologico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(606, 446);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "appZoologico";
            this.Text = "Zoologico";
            this.tbpBorrarAnimal.ResumeLayout(false);
            this.tbpBorrarAnimal.PerformLayout();
            this.tbpBuscarAnimal.ResumeLayout(false);
            this.tbpBuscarAnimal.PerformLayout();
            this.tbpBuscarZoologico.ResumeLayout(false);
            this.tbpBuscarZoologico.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tbpRegistroZoologico.ResumeLayout(false);
            this.pnlRegistroZoologico.ResumeLayout(false);
            this.pnlRegistroZoologico.PerformLayout();
            this.tbpRegistroAnimal.ResumeLayout(false);
            this.pnlRegistroAnimal.ResumeLayout(false);
            this.pnlRegistroAnimal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tbpBorrarAnimal;
        private System.Windows.Forms.TabPage tbpBuscarAnimal;
        private System.Windows.Forms.TabPage tbpBuscarZoologico;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpRegistroZoologico;
        private System.Windows.Forms.Panel pnlRegistroZoologico;
        private System.Windows.Forms.Button btnGuardarInformacion;
        private System.Windows.Forms.RadioButton rbCerrado;
        private System.Windows.Forms.RadioButton rbAbierto;
        private System.Windows.Forms.TextBox txtNomZool;
        private System.Windows.Forms.TextBox txtNitZool;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblNomZoologico;
        private System.Windows.Forms.Label lblNit;
        private System.Windows.Forms.Label lblMsj2;
        private System.Windows.Forms.Label lblMsj1;
        private System.Windows.Forms.TextBox txtNitBuscar;
        private System.Windows.Forms.Label lblNitZooBus;
        private System.Windows.Forms.RichTextBox rtxtInfoZool;
        private System.Windows.Forms.Button btnBuscarZoologico;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtCodElimAnim;
        private System.Windows.Forms.TextBox txtNitZooElimAnim;
        private System.Windows.Forms.Label lblCodElimAnim;
        private System.Windows.Forms.Label lblNitZooElimAnim;
        private System.Windows.Forms.Button btnBuscarAnimal;
        private System.Windows.Forms.RichTextBox rtxtInfoAnim;
        private System.Windows.Forms.TextBox txtCodBusAnim;
        private System.Windows.Forms.TextBox txtZooBusAnim;
        private System.Windows.Forms.Label lblCodAnimBusc;
        private System.Windows.Forms.Label lblNiTzooBusAnim;
        private System.Windows.Forms.TabPage tbpRegistroAnimal;
        private System.Windows.Forms.Panel pnlRegistroAnimal;
        private System.Windows.Forms.TextBox txtPesoAnim;
        private System.Windows.Forms.ComboBox cbxContOrig;
        private System.Windows.Forms.TextBox txtNomAnim;
        private System.Windows.Forms.TextBox txtCodAnim;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblCont;
        private System.Windows.Forms.Label lblNomAnim;
        private System.Windows.Forms.Label lblCodigoAnim;
        private System.Windows.Forms.Label lblMsj3;
        private System.Windows.Forms.Label lblMensajeAnimal;
        private System.Windows.Forms.Button btnGuardarInformacionAnimal;
    }
}

