using AppZoologico.logica;
using System;
using System.Windows.Forms;

namespace AppZoologico {
    public partial class appZoologico : Form {
        private string rutaArchivoZoologico;
        private string rutaArchivoAnimal;
        private Zoologico[] zoologicos;
        private Animal[] animales;
        private int tamanioZoologico;
        private int tamanioAnimal;
        private int i, j;

        public appZoologico() {
            this.InitializeComponent();
            this.rutaArchivoZoologico = "../../../data/Zoologico.txt";
            this.rutaArchivoAnimal = "../../../data/Anim.txt";
            this.zoologicos = new Zoologico[2];
            this.animales = new Animal[4];
            Utilidad.leerArchivo(rutaArchivoZoologico, this.zoologicos);
            Utilidad.leerArchivo(rutaArchivoAnimal, this.animales);
            this.tamanioZoologico = Utilidad.contarValoresNulos(this.zoologicos);
            this.tamanioAnimal = Utilidad.contarValoresNulos(this.animales);
            this.i = 0;
            this.j = 0;
            this.verificarInformacionGuardada();
        }

        private void verificarInformacionGuardada() {
            if (this.tamanioZoologico > 0 && this.tamanioAnimal > 0) {
                if (this.tamanioZoologico == 1 && this.tamanioAnimal <= 2) {
                    if (this.tamanioAnimal == 1) {
                        this.zoologicos[0].animales[0] = this.animales[0];
                        this.inhabilitarControlesZoologico();
                        this.tabControl1.SelectedIndex = 1;
                        j = 1;
                    } else {
                        this.zoologicos[0].animales[1] = this.animales[1];
                        this.inhabilitarControlesAnimal();
                        i = 1;
                        j = 0;
                    }
                } else if (this.tamanioZoologico == 2 && this.tamanioAnimal <= 4) {
                    if (this.tamanioAnimal == 2) {
                        this.zoologicos[0].animales[0] = this.animales[0];
                        this.zoologicos[0].animales[1] = this.animales[1];
                        this.inhabilitarControlesZoologico();
                        this.tabControl1.SelectedIndex = 1;
                        i = 2;
                        j = 0;
                    } else if (this.tamanioAnimal == 3) {
                        this.zoologicos[1].animales[0] = this.animales[2];
                        this.inhabilitarControlesZoologico();
                        this.tabControl1.SelectedIndex = 1;
                        i = 2;
                        j = 1;
                    } else if (this.tamanioAnimal == 4) {
                        this.zoologicos[1].animales[1] = this.animales[3];
                        this.inhabilitarControlesZoologico();
                        this.inhabilitarControlesAnimal();
                    }
                }
            } else if (this.tamanioZoologico > 0 && this.tamanioAnimal == 0) {
                this.inhabilitarControlesZoologico();
                this.tabControl1.SelectedIndex = 1;
            } else if (this.tamanioZoologico == 0 && this.tamanioAnimal == 0) {
                this.inhabilitarControlesAnimal();
            }
        }

        private void btnBuscarZoologico_Click(object sender, EventArgs e) {
            int nit;
            String mensajeZool = "";
            try {
                nit = int.Parse(txtNitBuscar.Text);
                Array.ForEach(this.zoologicos, zoo => {
                    if (zoo != null && Utilidad.compararIgualdad(nit, zoo.nit)) {
                        mensajeZool += zoo.ToString();
                    }
                });
                mensajeZool = mensajeZool == "" ? "El nit no pertenece a ningun zoologico registrado en la base de datos" : mensajeZool; 
                rtxtInfoZool.Text = mensajeZool;
                this.limpiarCajaTexto();
            } catch (Exception ex) { Utilidad.mensajeError(ex.Message); }
        }

        private void btnBuscarAnimal_Click(object sender, EventArgs e) {
            int nit, cod;  
            try {
                string anim = "";
                nit = int.Parse(txtZooBusAnim.Text);
                cod = int.Parse(txtCodBusAnim.Text);
                Array.ForEach(this.zoologicos, zoo => {
                    if(zoo != null && Utilidad.compararIgualdad(nit, zoo.nit)) {
                        Array.ForEach(zoo.animales, ani => {
                            if(ani != null && Utilidad.compararIgualdad(cod, ani.codigo)) anim += ani.ToString() + "\n"; 
                        });
                    }
                });
                anim = anim == "" ? "El codigo o el nit ingresado no pertenece a ningun animal registrado" : anim;
                rtxtInfoAnim.Text = anim;
                this.limpiarCajaTexto();
            } catch (Exception ex) { Utilidad.mensajeError(ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            int nit, cod, cont;
            try {
                Animal[] vecAuxAnim = new Animal[2];
                String mensaje = "El animal no se ha borrado satisfactoriamente porque no existe nit o codigo";
                nit = int.Parse(txtNitZooElimAnim.Text);
                cod = int.Parse(txtCodElimAnim.Text);
                cont = 0;
                bool isDeleted = false;
                Array.ForEach(this.zoologicos, zoo => {
                    if(zoo != null && Utilidad.compararIgualdad(nit, zoo.nit)) {
                        Array.ForEach(zoo.animales, ani => {
                            if (ani != null && cod != ani.codigo) {
                                vecAuxAnim[cont] = ani;
                                cont++;
                            } else if(ani != null && cod == ani.codigo) {
                                mensaje = "El animal se ha borrado satisfactoriamente";
                                isDeleted = true;
                            }
                        });
                        zoo.animales = vecAuxAnim;
                    }
                });
                if(isDeleted) Utilidad.mensajeExito(mensaje);
                else Utilidad.mensajeAdvertencia(mensaje);
                this.limpiarCajaTexto();
            } catch (Exception ex) { Utilidad.mensajeError(ex.Message); }
        }

        private void btnGuardarInformacionAnimal_Click(object sender, EventArgs e) {
            int cod;
            double peso;
            string nomAnim, continent, datosAnimal;
            try {
                if (j < 2) {
                    cod = int.Parse(txtCodAnim.Text);
                    nomAnim = txtNomAnim.Text;
                    continent = cbxContOrig.SelectedItem.ToString();
                    peso = double.Parse(txtPesoAnim.Text);
                    datosAnimal = cod + ", " + nomAnim + ", " + continent + ", " + peso;
                    Utilidad.insertarArchivo(rutaArchivoAnimal, datosAnimal);
                    animales[j] = new Animal(cod, nomAnim, continent, peso);
                    Utilidad.mensajeExito("Informacion del animal Registrada");
                    j++;
                    if (j == 2 && i < 2) {
                        zoologicos[i].animales = animales;
                        i++;
                        if(j == 2 && i == 2) {
                            Utilidad.mensajeAdvertencia("Llego al numero maximo de registros de animales y Zoologicos");
                            this.inhabilitarControlesZoologico();
                            this.inhabilitarControlesAnimal();
                        } else {
                            j = 0;
                            this.inhabilitarControlesAnimal();
                            this.habilitarControlesZoologico();
                            tabControl1.SelectedIndex = 0;
                        }
                    } 
                }
                this.limpiarCajaTexto();
            } catch (Exception ex) { Utilidad.mensajeError(ex.Message); }
        }

        private void btnGuardarInformacion_Click(object sender, EventArgs e) {
            int nit;
            string nomZool, estad = "", datosZoologico;
            try {                   
                if (i < 2) {
                    nit = int.Parse(txtNitZool.Text);
                    nomZool = txtNomZool.Text;
                    estad = rbAbierto.Checked && !rbCerrado.Checked ? "Abierto" : "Cerrado";
                    datosZoologico = nit + ", " + nomZool + ", " + estad;
                    Utilidad.insertarArchivo(rutaArchivoZoologico, datosZoologico);
                    zoologicos[i] = new Zoologico(nit, nomZool, estad);
                    Utilidad.mensajeExito("Informacion del zoologico Registrada correctamente!");
                    this.inhabilitarControlesZoologico();
                    this.habilitarControlesAnimal();
                    tabControl1.SelectedIndex = 1;
                } else {
                    Utilidad.mensajeAdvertencia("Llego al numero maximo de registros de Zoologicos");
                    this.inhabilitarControlesZoologico();
                    this.inhabilitarControlesAnimal();
                }
                this.limpiarCajaTexto();
            } catch (Exception ex) { Utilidad.mensajeError(ex.Message); }
        }

        private void habilitarControlesZoologico() {
            txtNitZool.Enabled = true;
            txtNomZool.Enabled = true;
            rbAbierto.Enabled = true;
            rbCerrado.Enabled = true;
            btnGuardarInformacion.Enabled = true;
        }

        private void inhabilitarControlesZoologico() {
            txtNitZool.Enabled = false;
            txtNomZool.Enabled = false;
            rbAbierto.Enabled = false;
            rbCerrado.Enabled = false;
            btnGuardarInformacion.Enabled = false;
        }

        private void habilitarControlesAnimal() {
            txtCodAnim.Enabled = true;
            txtNomAnim.Enabled = true;
            cbxContOrig.Enabled = true;
            txtPesoAnim.Enabled = true;
            btnGuardarInformacionAnimal.Enabled = true;
        }

        private void inhabilitarControlesAnimal() {
            txtCodAnim.Enabled = false;
            txtNomAnim.Enabled = false;
            cbxContOrig.Enabled = false;
            txtPesoAnim.Enabled = false;
            btnGuardarInformacionAnimal.Enabled = false;
        }

        public void limpiarCajaTexto() {
            txtCodAnim.Text = "";
            txtNomAnim.Text = "";
            cbxContOrig.Text = "";
            txtPesoAnim.Text = "";
            txtNitZool.Text = "";
            txtNomZool.Text = "";
            rbAbierto.Checked = false;
            rbCerrado.Checked = false;
            txtNitZooElimAnim.Text = "";
            txtCodElimAnim.Text = "";
            txtZooBusAnim.Text = "";
            txtCodBusAnim.Text = "";
            txtNitBuscar.Text = "";
        }
    }
}