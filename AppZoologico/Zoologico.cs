using AppZoologico.logica;
using System;
using System.IO;
using System.Windows.Forms;

namespace AppZoologico {
    public partial class appZoologico : Form {
        private Archivo objArchivo;
        private string rutaArchivoZ;
        private string rutaArchivoA;
        private Zoologico zoo;
        private Animal ani;
        private Zoologico[] vecZool;
        private Animal[] vecAnimal;
        private int i, j;

        public appZoologico() {
            InitializeComponent();
            this.objArchivo = new Archivo();
            this.rutaArchivoZ = "../../../data/Zoologico.txt"; 
            this.rutaArchivoA = "../../../data/Anim.txt";
            this.zoo = new Zoologico();
            this.ani = new Animal();
            this.i = 0;
            this.j = 0;
            this.vecZool = (Zoologico[])this.getDate(rutaArchivoZ, "Zoologico");
            this.vecAnimal = (Animal[])this.getDate(rutaArchivoA, "Animal");
            if (this.vecAnimal[0] != null && this.vecZool[0] != null) {
                Animal[] ani1 = new Animal[2];
                Animal[] ani2 = new Animal[2];
                int cont = 0;
                int k;
                for (k = 0; k < vecAnimal.Length; k++) {
                    if (k < 2) { ani1[k] = vecAnimal[k]; }
                    else {
                        ani2[cont] = vecAnimal[k];
                        cont++;
                    }
                }
                if (vecZool[0] != null && vecAnimal[0] != null && vecAnimal[1] != null) { vecZool[0].VecAnimales = ani1; }
                if (vecZool[1] != null && vecAnimal[2] != null && vecAnimal[3] != null) {
                    vecZool[1].VecAnimales = ani2;
                    this.inhabilitarControlesZoologico();
                    this.inhabilitarControlesAnimal();
                } else {
                    if (vecAnimal[1] != null && vecZool[1] == null) {
                        i = 1;
                        j = 0;
                        this.inhabilitarControlesAnimal();
                    } else if (vecZool[0] != null && vecAnimal[1] == null) {
                        this.inhabilitarControlesZoologico();
                        tabControl1.SelectedIndex = 1;
                        j = 1;
                    } else if (vecZool[1] != null && vecAnimal[3] == null) {
                        i = 2;
                        j = 1;
                        this.inhabilitarControlesZoologico();
                        tabControl1.SelectedIndex = 1;
                    } else if (vecZool[1] != null && vecAnimal[2] == null) {
                        i = 2;
                        j = 0;
                        this.inhabilitarControlesZoologico();
                        tabControl1.SelectedIndex = 1;
                    }
                }
            } else if (vecAnimal[0] == null && vecZool[0] != null) {
                this.inhabilitarControlesZoologico();
                tabControl1.SelectedIndex = 1;
            } else if(vecAnimal[0] == null && vecZool[0] == null) {
                this.inhabilitarControlesAnimal();
            }
        }

        private void btnBuscarZoologico_Click(object sender, EventArgs e) {
            int nit;
            String mensajeZool = "";
            try {
                nit = int.Parse(txtNitBuscar.Text);
                Array.ForEach(this.vecZool, zoo => {
                    if (zoo != null && this.comparar(nit, zoo.nit)) {
                        mensajeZool += zoo.ToString();
                    }
                });
                mensajeZool = mensajeZool == "" ? "El nit no pertenece a ningun zoologico registrado en la base de datos" : mensajeZool; 
                rtxtInfoZool.Text = mensajeZool;
                this.limpiarCajaTexto();
            } catch (Exception ex) { this.mensajeError(ex.Message); }
        }

        private void btnBuscarAnimal_Click(object sender, EventArgs e) {
            int nit, cod;  
            try {
                string anim = "";
                nit = int.Parse(txtZooBusAnim.Text);
                cod = int.Parse(txtCodBusAnim.Text);
                Array.ForEach(this.vecZool, zoo => {
                    if(zoo != null && this.comparar(nit, zoo.nit)) {
                        Array.ForEach(zoo.VecAnimales, ani => {
                            if(ani != null && this.comparar(cod, ani.codigo)) anim += ani.ToString() + "\n"; 
                        });
                    }
                });
                anim = anim == "" ? "El codigo o el nit ingresado no pertenece a ningun animal registrado" : anim;
                rtxtInfoAnim.Text = anim;
                this.limpiarCajaTexto();
            } catch (Exception ex) { this.mensajeError(ex.Message); }
        }

        private Func<int, int, bool> comparar = (a, b) => a == b;

        private void btnEliminar_Click(object sender, EventArgs e) {
            int nit, cod, cont;
            try {
                Animal[] vecAuxAnim = new Animal[2];
                String mensaje = "El animal no se ha borrado satisfactoriamente porque no existe nit o codigo";
                nit = int.Parse(txtNitZooElimAnim.Text);
                cod = int.Parse(txtCodElimAnim.Text);
                cont = 0;
                bool isDeleted = false;
                Array.ForEach(this.vecZool, zoo => {
                    if(zoo != null && this.comparar(nit, zoo.nit)) {
                        Array.ForEach(zoo.VecAnimales, ani => {
                            if (ani != null && cod != ani.codigo) {
                                vecAuxAnim[cont] = ani;
                                cont++;
                            } else if(ani != null && cod == ani.codigo) {
                                mensaje = "El animal se ha borrado satisfactoriamente";
                                isDeleted = true;
                            }
                        });
                        zoo.VecAnimales = vecAuxAnim;
                    }
                });
                if(isDeleted) this.mensajeExito(mensaje);
                else this.mensajeAdvertencia(mensaje);
                this.limpiarCajaTexto();
            } catch (Exception ex) { this.mensajeError(ex.Message); }
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
                    this.insertarArchivo(rutaArchivoA, datosAnimal);
                    ani = new Animal(cod, nomAnim, continent, peso);
                    vecAnimal[j] = ani;     
                    this.mensajeExito("Informacion del animal Registrada");
                    j++;
                    if (j == 2 && i < 2) {
                        vecZool[i].VecAnimales = vecAnimal;
                        i++;
                        if(j == 2 && i == 2) {
                            this.mensajeAdvertencia("Llego al numero maximo de registros de animales y Zoologicos");
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
            } catch (Exception ex) { this.mensajeError(ex.Message); }
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
                    this.insertarArchivo(rutaArchivoZ, datosZoologico);
                    zoo = new Zoologico(nit, nomZool, estad);
                    vecZool[i] = zoo;
                    this.mensajeExito("Informacion del zoologico Registrada correctamente!");
                    this.inhabilitarControlesZoologico();
                    this.habilitarControlesAnimal();
                    tabControl1.SelectedIndex = 1;
                } else {
                    this.mensajeAdvertencia("Llego al numero maximo de registros de Zoologicos");
                    this.inhabilitarControlesZoologico();
                    this.inhabilitarControlesAnimal();
                }
                this.limpiarCajaTexto();
            } catch (Exception ex) { this.mensajeError(ex.Message); }
        }

        private void mensajeExito(String message) {
            MessageBox.Show(message, "Mensaje de exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void mensajeError(string message) {
            MessageBox.Show(message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mensajeAdvertencia(String message) {
            MessageBox.Show(message, "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void insertarArchivo(string nameArchive, string data) {
            try {
                this.objArchivo.abrirArchivo(nameArchive, true);
                this.objArchivo.escribirArchivo(data);
                this.objArchivo.cerrarArchivo();
            } catch (IOException ex) { Console.WriteLine(ex); }
        }

        private object[] getDate(string nameArchive, string type) {
            int k = 0;
            Zoologico [] vecZ = new Zoologico[2];
            Animal [] vecA = new Animal[4];
            //paso 1: abro el archivo 
            this.objArchivo.abrirArchivo(nameArchive, false);
            //paso 2: recorrer el archivo
            while (this.objArchivo.puedeLeer() != -1) {
                string line = this.objArchivo.leerArchivo();
                string [] dates = line.Split(',');
                if(type.Equals("Zoologico")) {
                    Zoologico zool = this.createZoologico(dates);
                    vecZ[k] = zool; 
                }
                //paso 3: creo un objeto de type
                if(type.Equals("Animal")) {
                    Animal anim = this.createAnimal(dates);
                    vecA[k] = anim;
                }
                k++;
            }
            //paso 4: cerrar archivo
            this.objArchivo.cerrarArchivo();
            return type.Equals("Zoologico") ? (object[])vecZ : (object[])vecA;
        }

        private Zoologico createZoologico(string [] dates) {
            int nit;
            string nom, est;
            nit = int.Parse(dates[0]);
            nom = dates[1];
            est = dates[2];
            Zoologico zool = new Zoologico(nit, nom, est);
            return zool;
        }

        private Animal createAnimal(string [] dates) {
            int cod;
            Double peso;
            String nom, orig;
            cod = int.Parse(dates[0]);
            nom = dates[1];
            orig = dates[2];
            peso = double.Parse(dates[3]);
            Animal anim = new Animal(cod, nom, orig, peso);
            return anim;
        }
    }
}
