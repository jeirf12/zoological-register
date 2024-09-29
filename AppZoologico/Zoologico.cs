namespace AppZoologico {
    
    using global::AppZoologico.logica;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class AppZoologico : Form {

        private const string RUTA_ARCHIVO_ZOOLOGICO = "../../../data/Zoologico.txt";

        private const string RUTA_ARCHIVO_ANIMAL = "../../../data/Anim.txt";

        private const int TOPE_ZOOLOGICOS = 2, TOPE_ANIMALES = 4, TOPE_ANIMALES_POR_ZOOLOGICO = 2;

        private readonly Archivo ObjArchivo = new Archivo();

        private Zoologico[] Zoologicos;

        private Animal[] Animales;

        private int TamanioZoologico;

        private int TamanioAnimal;

        public AppZoologico() {
            this.InitializeComponent();
            this.inicializacionInformacion();
        }

        private void inicializacionInformacion() {
            this.Zoologicos = new Zoologico[TOPE_ZOOLOGICOS];
            this.Animales = new Animal[TOPE_ANIMALES];
            this.ObjArchivo.LlenarMatrizInformacion(RUTA_ARCHIVO_ZOOLOGICO, ref this.Zoologicos);
            this.ObjArchivo.LlenarMatrizInformacion(RUTA_ARCHIVO_ANIMAL, ref this.Animales);
            this.TamanioZoologico = this.Zoologicos.ObtenerTamanioSinContarValoresNulos();
            this.TamanioAnimal = this.Animales.ObtenerTamanioSinContarValoresNulos();
            this.CompletarInformacionGuardada();
        }

        private void CompletarInformacionGuardada() {
            bool zoo = this.VerificarZoologicos();
            bool ani = this.VerificarAnimales();
            if (zoo & ani) 
                return;

            this.TamanioZoologico = this.TamanioZoologico - 1;
            this.TamanioAnimal = this.TamanioAnimal > TOPE_ANIMALES_POR_ZOOLOGICO 
                        ? (int) Math.Round(((double)this.TamanioAnimal / 2) - 1)
                        : this.TamanioAnimal.EsIgualACero() 
                        ? this.TamanioAnimal 
                        : this.TamanioAnimal - 1;
            for (int k = 0; k < TOPE_ANIMALES; k++) {
                if (this.Animales[k] != null)
                    this.Zoologicos[k > 1 ? 1 : 0].Animales[k > 1 ? k - 2 : k] = this.Animales[k];
            }
        }

        private bool VerificarZoologicos() {
            if (this.TamanioZoologico.EsIgualACero() && this.TamanioAnimal == TOPE_ANIMALES) {
                this.InhabilitarControlesAnimal();
                this.ObjArchivo.EliminarArchivo(RUTA_ARCHIVO_ANIMAL);
                this.Animales = new Animal[TOPE_ANIMALES];
                this.TamanioAnimal = 0;
                return true;
            } else if(this.TamanioZoologico > 0 || this.TamanioZoologico == TOPE_ZOOLOGICOS) {
                this.InhabilitarControlesZoologico();
                this.tabControl1.SelectedIndex = 1;
            } else if(this.TamanioZoologico.EsIgualACero()) {
                this.InhabilitarControlesAnimal();
                return true;
            }
            return false;
        }

        private bool VerificarAnimales() {
            if (this.TamanioZoologico.EsIgualACero() && this.TamanioAnimal.EsIgualACero())
                return true;
            else if(this.TamanioZoologico == TOPE_ZOOLOGICOS && this.TamanioAnimal.EsIgualACero()) {
                this.Zoologicos[--this.TamanioZoologico] = null;
                Zoologico Zoologico = this.Zoologicos[this.TamanioZoologico - 1];
                this.ObjArchivo.EscribirInformacion(RUTA_ARCHIVO_ZOOLOGICO, Zoologico.CrearInformacionZoologico(), true);
            } else if(this.TamanioZoologico == TOPE_ZOOLOGICOS && this.TamanioAnimal == TOPE_ANIMALES_POR_ZOOLOGICO) {
                this.InhabilitarControlesZoologico();
                this.HabilitarControlesAnimal();
                this.tabControl1.SelectedIndex = 1;
            } else if (this.TamanioZoologico == TOPE_ZOOLOGICOS && this.TamanioAnimal < TOPE_ANIMALES) {
                this.HabilitarControlesAnimal();
            } else if (this.TamanioZoologico == TOPE_ZOOLOGICOS - 1 && this.TamanioAnimal == TOPE_ANIMALES) {
                for (int i = 0; i < TOPE_ANIMALES_POR_ZOOLOGICO; i++) {
                    this.Animales[i + 2] = null;
                    Animal Animal = this.Animales[i];
                    this.ObjArchivo.EscribirInformacion(RUTA_ARCHIVO_ANIMAL, Animal.CrearInformacionAnimal(), i.EsIgualACero());
                }
                this.TamanioAnimal = 2;
                this.InhabilitarControlesAnimal();
                this.HabilitarControlesZoologico();
                this.tabControl1.SelectedIndex = 0;
            } else if (this.TamanioAnimal == TOPE_ANIMALES_POR_ZOOLOGICO) {
                this.InhabilitarControlesAnimal();
                this.HabilitarControlesZoologico();
                this.tabControl1.SelectedIndex = 0;
            } else if (this.TamanioAnimal == TOPE_ANIMALES) {
                this.InhabilitarControlesAnimal();
            }
            return false;
        }

        private void BtnBuscarZoologico_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrEmpty(txtNitBuscar.Text)) 
                    throw new Exception("El nit no debe estar vacío");
                if (!txtNitBuscar.Text.EsNumerico()) 
                    throw new Exception("El nit del zoológico no tiene el formato adecuado");
                int nit = int.Parse(txtNitBuscar.Text);
                
                Zoologico zoologicoEncontrado = this.Zoologicos
                    .Where(zoologico => zoologico != null && Utilidad.CompararIgualdad(nit, zoologico.Nit))
                    .FirstOrDefault();

                if (zoologicoEncontrado == null) {
                    rtxtInfoZool.Text = "El nit del zoológico no existe en la base de datos";
                    return;
                }

                rtxtInfoZool.Text = zoologicoEncontrado.ToString();
                this.LimpiarCajaTexto();
            } catch (Exception ex) { Utilidad.MensajeError(ex.Message); }
        }

        private void BtnBuscarAnimal_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrEmpty(txtZooBusAnim.Text)) 
                    throw new Exception("El nit del zoológico no debe estar vacío");
                if (string.IsNullOrEmpty(txtCodBusAnim.Text)) 
                    throw new Exception("El código del animal no debe estar vacío");
                if (!txtZooBusAnim.Text.EsNumerico()) 
                    throw new Exception("El  nit del zoológico no tiene el formato adecuado");
                if (!txtCodBusAnim.Text.EsNumerico()) 
                    throw new Exception("El código del animal no tiene el formato adecuado");
                
                int nit = int.Parse(txtZooBusAnim.Text);
                int cod = int.Parse(txtCodBusAnim.Text);

                Zoologico zoologicoEncontrado = this.Zoologicos
                    .Where(zoologico => zoologico != null && Utilidad.CompararIgualdad(nit, zoologico.Nit))
                    .FirstOrDefault();

                if (zoologicoEncontrado == null) {
                    rtxtInfoAnim.Text = "El nit del zoológico no existe en la base de datos";
                    return;
                }

                Animal animalEncontrado = zoologicoEncontrado.Animales
                    .Where(animal => animal != null && Utilidad.CompararIgualdad(cod, animal.Codigo))
                    .FirstOrDefault();

                if (animalEncontrado == null) {
                    rtxtInfoAnim.Text = "El código del animal no existe en la base de datos";
                    return;
                }

                rtxtInfoAnim.Text = animalEncontrado.ToString();
                this.LimpiarCajaTexto();
            } catch (Exception ex) { Utilidad.MensajeError(ex.Message); }
        }

        private void BtnEliminar_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrEmpty(txtNitZooElimAnim.Text)) 
                    throw new Exception("El nit del zoológico no debe estar vacío");
                if (string.IsNullOrEmpty(txtCodElimAnim.Text)) 
                    throw new Exception("El código del animal no debe estar vacío");
                if (!txtNitZooElimAnim.Text.EsNumerico()) 
                    throw new Exception("El  nit del zoológico no tiene el formato adecuado");
                if (!txtCodElimAnim.Text.EsNumerico()) 
                    throw new Exception("El código del animal no tiene el formato adecuado");
                int nit = int.Parse(txtNitZooElimAnim.Text);
                int cod = int.Parse(txtCodElimAnim.Text);

                Zoologico zoologicoEncontrado = this.Zoologicos
                    .Where(zoologico => zoologico != null && Utilidad.CompararIgualdad(nit, zoologico.Nit))
                    .FirstOrDefault();

                if (zoologicoEncontrado == null) {
                    Utilidad.MensajeError("El nit del zoológico no existe en la base de datos");
                    return;
                }

                Animal animalABorrar = zoologicoEncontrado.Animales
                    .Where(animal => animal != null && Utilidad.CompararIgualdad(cod, animal.Codigo))
                    .FirstOrDefault();

                if (animalABorrar == null) {
                    Utilidad.MensajeError("El código del animal no existe en la base de datos");
                    return;
                }

                var indice = 0;
                foreach (var animal in this.Animales) {
                    if (animal != null && !Utilidad.CompararIgualdad(animalABorrar.Codigo, animal.Codigo)) {
                        this.ObjArchivo.EscribirInformacion(RUTA_ARCHIVO_ANIMAL, animal.CrearInformacionAnimal(), indice.EsIgualACero());
                        indice++;
                    }
                }

                this.inicializacionInformacion();
                Utilidad.MensajeExito("El animal se ha borrado satisfactoriamente");
                this.LimpiarCajaTexto();
            } catch (Exception ex) { Utilidad.MensajeError(ex.Message); }
        }

        private void BtnGuardarInformacionAnimal_Click(object sender, EventArgs e) {
            try {
                if (this.TamanioAnimal < TOPE_ANIMALES_POR_ZOOLOGICO) {
                    if (string.IsNullOrEmpty(txtCodAnim.Text)) 
                        throw new Exception("El código del animal no puede ingresarse vacío");
                    if (!txtCodAnim.Text.EsNumerico()) 
                        throw new Exception("El código del animal no tiene el formato adecuado");
                    if (string.IsNullOrEmpty(txtNomAnim.Text)) 
                        throw new Exception("El nombre del animal no puede ingresarse vacío");
                    if (string.IsNullOrEmpty(cbxContOrig.Text)) 
                        throw new Exception("El continente de origén del animal no puede ingresarse vacío");
                    if (string.IsNullOrEmpty(txtPesoAnim.Text)) 
                        throw new Exception("El peso del animal no puede ingresarse vacío");
                    int cod = int.Parse(txtCodAnim.Text);
                    if (!Utilidad.VerificarUnicidad(this.Zoologicos[this.TamanioZoologico].Animales, cod)) 
                        throw new Exception("El código del animal debe ser único, vuelvalo a ingresar");
                    string nomAnim = txtNomAnim.Text;
                    string continent = cbxContOrig.SelectedItem.ToString();
                    double peso = double.Parse(txtPesoAnim.Text);
                    Animal animal = new Animal(cod, nomAnim, continent, peso);
                    for(int i = 0; i < TOPE_ANIMALES; i++) {
                        if (this.Animales[i] == null) {
                            this.Animales[i] = animal;
                            break;
                        }
                    }
                    this.ObjArchivo.EscribirInformacion(RUTA_ARCHIVO_ANIMAL, animal.CrearInformacionAnimal());
                    Utilidad.MensajeExito("Información del animal Registrada");
                    this.TamanioAnimal++;
                }
                if (this.TamanioAnimal <= TOPE_ANIMALES_POR_ZOOLOGICO && this.TamanioZoologico <= TOPE_ZOOLOGICOS) {
                    for (int k = 0; k < TOPE_ANIMALES; k++) {
                        if (this.Animales[k] != null)
                            this.Zoologicos[k > 1 ? 1 : 0].Animales[k > 1 ? k - 2 : k] = this.Animales[k];
                    }
                    var cantidadAnimales = this.Animales.ObtenerTamanioSinContarValoresNulos();

                    if (this.TamanioAnimal == TOPE_ANIMALES_POR_ZOOLOGICO - 1 && this.TamanioZoologico == TOPE_ZOOLOGICOS - 1 && cantidadAnimales == TOPE_ANIMALES) {
                        Utilidad.MensajeAdvertencia("Llegó al número máximo de registros de animales y Zoologicos");
                        this.InhabilitarControlesZoologico();
                        this.InhabilitarControlesAnimal();
                    } else if (this.TamanioAnimal == TOPE_ANIMALES_POR_ZOOLOGICO - 1 && this.TamanioZoologico == TOPE_ZOOLOGICOS - 2) {
                        this.TamanioAnimal = 0;
                        this.InhabilitarControlesAnimal();
                        this.HabilitarControlesZoologico();
                        tabControl1.SelectedIndex = 0;
                    } else if(this.TamanioAnimal == TOPE_ANIMALES_POR_ZOOLOGICO && cantidadAnimales < TOPE_ANIMALES) {
                        this.TamanioAnimal -= 2;
                    }
                }
                this.LimpiarCajaTexto();
            } catch (Exception ex) { Utilidad.MensajeError(ex.Message); }
        }

        private void BtnGuardarInformacion_Click(object sender, EventArgs e) {
            try {
                if (this.TamanioZoologico == TOPE_ZOOLOGICOS - 1) {
                    Utilidad.MensajeAdvertencia("Llegó al número máximo de registros de Zoologicos");
                    this.InhabilitarControlesZoologico();
                    this.HabilitarControlesAnimal();
                    tabControl1.SelectedIndex = 1;
                    this.LimpiarCajaTexto();
                    return;
                }

                if (string.IsNullOrEmpty(txtNitZool.Text))
                    throw new Exception("El nit del zoológico ingresado no debe ser vacío");
                if (string.IsNullOrEmpty(txtNomZool.Text))
                    throw new Exception("El nombre del zoológico ingresado no debe ser vacío");
                if (!rbAbierto.Checked && !rbCerrado.Checked)
                    throw new Exception("El estado del zoológico ingresado debe ser seleccionado");
                int nit = int.Parse(txtNitZool.Text);
                if (!Utilidad.VerificarUnicidad(Zoologicos, nit))
                    throw new Exception("El nit del zoológico debe ser único, vuelvalo a ingresar");
                string nombreZoologico = txtNomZool.Text;
                string estado = rbAbierto.Checked && !rbCerrado.Checked
                    ? "Abierto"
                    : "Cerrado";
                Zoologico zoologico = new Zoologico(nit, nombreZoologico, estado);
                this.Zoologicos[this.TamanioZoologico++] = zoologico;
                this.ObjArchivo.EscribirInformacion(RUTA_ARCHIVO_ZOOLOGICO, zoologico.CrearInformacionZoologico());
                Utilidad.MensajeExito("Información del zoológico Registrada correctamente!");
                this.InhabilitarControlesZoologico();
                this.HabilitarControlesAnimal();
                tabControl1.SelectedIndex = 1;
                this.LimpiarCajaTexto();
            } catch (Exception ex) { Utilidad.MensajeError(ex.Message); }
        }

        private void HabilitarControlesZoologico() {
            txtNitZool.Enabled = true;
            txtNomZool.Enabled = true;
            rbAbierto.Enabled = true;
            rbCerrado.Enabled = true;
            btnGuardarInformacion.Enabled = true;
        }

        private void InhabilitarControlesZoologico() {
            txtNitZool.Enabled = false;
            txtNomZool.Enabled = false;
            rbAbierto.Enabled = false;
            rbCerrado.Enabled = false;
            btnGuardarInformacion.Enabled = false;
        }

        private void HabilitarControlesAnimal() {
            txtCodAnim.Enabled = true;
            txtNomAnim.Enabled = true;
            cbxContOrig.Enabled = true;
            txtPesoAnim.Enabled = true;
            btnGuardarInformacionAnimal.Enabled = true;
        }

        private void InhabilitarControlesAnimal() {
            txtCodAnim.Enabled = false;
            txtNomAnim.Enabled = false;
            cbxContOrig.Enabled = false;
            txtPesoAnim.Enabled = false;
            btnGuardarInformacionAnimal.Enabled = false;
        }

        private void LimpiarCajaTexto() {
            txtCodAnim.Text = string.Empty;
            txtNomAnim.Text = string.Empty;
            cbxContOrig.Text = string.Empty;
            txtPesoAnim.Text = string.Empty;
            txtNitZool.Text = string.Empty;
            txtNomZool.Text = string.Empty;
            rbAbierto.Checked = false;
            rbCerrado.Checked = false;
            txtNitZooElimAnim.Text = string.Empty;
            txtCodElimAnim.Text = string.Empty;
            txtZooBusAnim.Text = string.Empty;
            txtCodBusAnim.Text = string.Empty;
            txtNitBuscar.Text = string.Empty;
        }
    }
}