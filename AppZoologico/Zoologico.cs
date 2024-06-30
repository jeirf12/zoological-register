using AppZoologico.logica;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AppZoologico {
    public partial class appZoologico : Form {
        private string rutaArchivoZoologico;
        private string rutaArchivoAnimal;
        private Zoologico[] zoologicos;
        private Animal[] animales;
        private Archivo objArchivo;
        private int tamanioZoologico;
        private int tamanioAnimal;
        private const int TOPEZOOLOGICOS = 2, TOPEANIMALES = 4;

        public appZoologico() {
            this.InitializeComponent();
            this.rutaArchivoZoologico = "../../../data/Zoologico.txt";
            this.rutaArchivoAnimal = "../../../data/Anim.txt";
            this.zoologicos = new Zoologico[2];
            this.animales = new Animal[4];
            this.objArchivo = new Archivo();
            this.objArchivo.llenarMatrizInformacion(this.rutaArchivoZoologico, this.zoologicos);
            this.objArchivo.llenarMatrizInformacion(this.rutaArchivoAnimal, this.animales);
            this.tamanioZoologico = Utilidad.contarValoresNulos(this.zoologicos);
            this.tamanioAnimal = Utilidad.contarValoresNulos(this.animales);
            this.completarInformacionGuardada();
        }

        private void completarInformacionGuardada() {
            bool zoo = this.verificarZoologicos();
            bool ani = this.verificarAnimales();
            if (zoo & ani) return;

            this.tamanioZoologico = this.tamanioZoologico - 1;
            this.tamanioAnimal = this.tamanioAnimal > 2 
                        ? (int) Math.Round(((double)this.tamanioAnimal / 2) - 1)
                        : this.tamanioAnimal == 0 ? this.tamanioAnimal : this.tamanioAnimal - 1;
            for (int k = 0; k < this.animales.Length; k++) {
                if (this.animales[k] != null) {
                    this.zoologicos[k > 1 ? 1 : 0].animales[k > 1 ? k - 2 : k] = this.animales[k];
                }
            }
        }

        private bool verificarZoologicos() {
            if (this.tamanioZoologico == 0 && this.tamanioAnimal == TOPEANIMALES) {
                this.inhabilitarControlesAnimal();
                this.objArchivo.eliminarArchivo(this.rutaArchivoAnimal);
                this.animales = new Animal[4];
                this.tamanioAnimal = 0;
                return true;
            } else if(this.tamanioZoologico > 0 || this.tamanioZoologico == TOPEZOOLOGICOS) {
                this.inhabilitarControlesZoologico();
                this.tabControl1.SelectedIndex = 1;
            } else if(this.tamanioZoologico == 0) {
                this.inhabilitarControlesAnimal();
                return true;
            }
            return false;
        }

        private bool verificarAnimales() {
            if (this.tamanioZoologico == 0 && this.tamanioAnimal == 0) {
                return true;
            } else if(this.tamanioZoologico == 2 && this.tamanioAnimal == 0) {
                this.zoologicos[--this.tamanioZoologico] = null;
                string informacion = this.zoologicos[this.tamanioZoologico - 1].nit + ", "
                                    + this.zoologicos[this.tamanioZoologico - 1].nombre + ", "
                                    + this.zoologicos[this.tamanioZoologico - 1].estado;
                this.objArchivo.escribirInformacion(this.rutaArchivoZoologico, informacion, true);
            } else if(this.tamanioZoologico == 1 && this.tamanioAnimal == TOPEANIMALES) {
                for (int i = 0; i < 2; i++) {
                    this.animales[i + 2] = null;
                    string informacion = this.animales[i].codigo + ", "
                                        + this.animales[i].nombre + ", "
                                        + this.animales[i].continenteOrigen + ", "
                                        + this.animales[i].peso;
                    this.objArchivo.escribirInformacion(this.rutaArchivoAnimal, informacion, i == 0 ? true : false);
                }
                this.tamanioAnimal = 2;
                this.inhabilitarControlesAnimal();
                this.habilitarControlesZoologico();
                this.tabControl1.SelectedIndex = 0;
            } else if (this.tamanioAnimal == 2) {
                this.inhabilitarControlesAnimal();
                this.habilitarControlesZoologico();
                this.tabControl1.SelectedIndex = 0;
            } else if (this.tamanioAnimal == TOPEANIMALES) {
                this.inhabilitarControlesAnimal();
            }
            return false;
        }

        private void btnBuscarZoologico_Click(object sender, EventArgs e) {
            int nit;
            string mensajeZool = null;
            try {
                if (txtNitBuscar.Text.Length == 0) throw new Exception("El nit no debe estar vacío"); 
                nit = int.Parse(txtNitBuscar.Text);
                foreach (var zoo in this.zoologicos) {
                    if (zoo != null && Utilidad.compararIgualdad(nit, zoo.nit)) {
                        mensajeZool = zoo.ToString();
                        break;
                    }
                    mensajeZool = "El nit del zoológico no existe en la base de datos";
                }
                rtxtInfoZool.Text = mensajeZool;
                this.limpiarCajaTexto();
            } catch (Exception ex) { Utilidad.mensajeError(ex.Message); }
        }

        private void btnBuscarAnimal_Click(object sender, EventArgs e) {
            int nit, cod;  
            try {
                string mensajeAnimal = null;
                if (txtZooBusAnim.Text.Length == 0) throw new Exception("El nit del zoológico no debe estar vacío");
                if (txtCodBusAnim.Text.Length == 0) throw new Exception("El código del animal no debe estar vacío");
                nit = int.Parse(txtZooBusAnim.Text);
                cod = int.Parse(txtCodBusAnim.Text);
                foreach (var zoo in this.zoologicos) {
                    if (zoo != null && Utilidad.compararIgualdad(nit, zoo.nit)) {
                        foreach(var ani in zoo.animales) {
                            if (ani != null && Utilidad.compararIgualdad(cod, ani.codigo)) { 
                                mensajeAnimal = ani.ToString();
                                break;
                            }
                            mensajeAnimal = "El código del animal no existe en la base de datos";
                        }
                        break;
                    }
                    mensajeAnimal = "El nit del zoológico no existe en la base de datos";
                }
                rtxtInfoAnim.Text = mensajeAnimal;
                this.limpiarCajaTexto();
            } catch (Exception ex) { Utilidad.mensajeError(ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            int nit, cod;
            try {
                Animal[] vecAuxAnim = new Animal[2];
                string mensaje = null;
                if (txtNitZooElimAnim.Text.Length == 0) throw new Exception("El nit del zoológico no debe estar vacío");
                if (txtCodElimAnim.Text.Length == 0) throw new Exception("El código del animal no debe estar vacío");
                nit = int.Parse(txtNitZooElimAnim.Text);
                cod = int.Parse(txtCodElimAnim.Text);
                bool isDeleted = false;
                foreach(var zoo in this.zoologicos) {
                    if(zoo != null && Utilidad.compararIgualdad(nit, zoo.nit)) {
                        int contadorAux = Utilidad.contarValoresNulos(zoo.animales);
                        zoo.animales = zoo.animales.Where(ani => ani != null && ani.codigo != cod).ToArray();
                        isDeleted = Utilidad.contarValoresNulos(zoo.animales) != contadorAux;
                        mensaje =  isDeleted
                                    ? "El animal se ha borrado satisfactoriamente" 
                                    : "El código del animal no existe en la base de datos";
                        break;
                    }
                    mensaje = "El nit del zoológico no existe en la base de datos";
                }
                if (isDeleted) {
                    this.tamanioAnimal--;
                    Utilidad.mensajeExito(mensaje);
                } else Utilidad.mensajeAdvertencia(mensaje);
                this.limpiarCajaTexto();
            } catch (Exception ex) { Utilidad.mensajeError(ex.Message); }
        }

        private void btnGuardarInformacionAnimal_Click(object sender, EventArgs e) {
            int cod;
            double peso;
            string nomAnim, continent, datosAnimal;
            try {
                if (this.tamanioAnimal < 2) {
                    if (txtCodAnim.Text.Length == 0) throw new Exception("El código del animal no puede ingresarse vacío");
                    if (txtNomAnim.Text.Length == 0) throw new Exception("El nombre del animal no puede ingresarse vacío");
                    if (cbxContOrig.Text.Length == 0) throw new Exception("El continente de origén del animal no puede ingresarse vacío");
                    if (txtPesoAnim.Text.Length == 0) throw new Exception("El peso del animal no puede ingresarse vacío");
                    cod = int.Parse(txtCodAnim.Text);
                    if (!this.verificarCodigoAnimalUnico(cod)) throw new Exception("El código del animal debe ser único, vuelvalo a ingresar");
                    nomAnim = txtNomAnim.Text;
                    continent = cbxContOrig.SelectedItem.ToString();
                    peso = double.Parse(txtPesoAnim.Text);
                    this.animales[this.tamanioAnimal] = new Animal(cod, nomAnim, continent, peso);
                    datosAnimal = cod + ", " + nomAnim + ", " + continent + ", " + peso;
                    this.objArchivo.escribirInformacion(rutaArchivoAnimal, datosAnimal);
                    Utilidad.mensajeExito("Información del animal Registrada");
                    Console.WriteLine("CONTADOR ANIMAL " + this.tamanioAnimal + " - " + this.tamanioZoologico);
                    if (this.tamanioAnimal == 1 && this.tamanioZoologico < 2) {
                        for (int k = 0; k < this.animales.Length; k++) {
                            if (this.animales[k] != null) {
                                this.zoologicos[k > 1 ? 1 : 0].animales[k > 1 ? k - 2 : k] = this.animales[k];
                            }
                        }
                        if(this.tamanioAnimal == 1 && this.tamanioZoologico == 1) {
                            this.tamanioAnimal--;
                            Utilidad.mensajeAdvertencia("Llegó al número máximo de registros de animales y Zoologicos");
                            this.inhabilitarControlesZoologico();
                            this.inhabilitarControlesAnimal();
                        } else if(this.tamanioAnimal == 1 && this.tamanioZoologico == 0) {
                            this.tamanioAnimal = -1;
                            this.tamanioZoologico++;
                            this.inhabilitarControlesAnimal();
                            this.habilitarControlesZoologico();
                            tabControl1.SelectedIndex = 0;
                        }
                    }
                    this.tamanioAnimal++;
                }
                this.limpiarCajaTexto();
            } catch (Exception ex) { Utilidad.mensajeError(ex.Message); }
        }

        private void btnGuardarInformacion_Click(object sender, EventArgs e) {
            int nit;
            string nomZool, estad = "", datosZoologico;
            try {                   
                if (this.tamanioZoologico < 2) {
                    if (txtNitZool.Text.Length == 0) throw new Exception("El nit del zoológico ingresado no debe ser vacío");
                    if (txtNomZool.Text.Length == 0) throw new Exception("El nombre del zoológico ingresado no debe ser vacío");
                    if (!rbAbierto.Checked && !rbCerrado.Checked) throw new Exception("El estado del zoológico ingresado debe ser seleccionado");
                    nit = int.Parse(txtNitZool.Text);
                    if (!this.verificarNitZoologicoUnico(nit)) throw new Exception("El nit del zoológico debe ser único, vuelvalo a ingresar");
                    nomZool = txtNomZool.Text;
                    estad = rbAbierto.Checked && !rbCerrado.Checked ? "Abierto" : "Cerrado";
                    datosZoologico = nit + ", " + nomZool + ", " + estad;
                    this.zoologicos[this.tamanioZoologico] = new Zoologico(nit, nomZool, estad);
                    this.objArchivo.escribirInformacion(rutaArchivoZoologico, datosZoologico);
                    Utilidad.mensajeExito("Información del zoológico Registrada correctamente!");
                    this.inhabilitarControlesZoologico();
                    this.habilitarControlesAnimal();
                    tabControl1.SelectedIndex = 1;
                } else {
                    Utilidad.mensajeAdvertencia("Llegó al número máximo de registros de Zoologicos");
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

        private void limpiarCajaTexto() {
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

        private bool verificarNitZoologicoUnico(int nit) {
            return this.zoologicos.Count(zoologico => zoologico != null && Utilidad.compararIgualdad(nit, zoologico.nit)) == 0;
        }

        private bool verificarCodigoAnimalUnico(int codigo) {
            return this.zoologicos[this.tamanioZoologico].animales.Count(animal => animal != null && Utilidad.compararIgualdad(codigo, animal.codigo)) == 0;
        }
    }
}