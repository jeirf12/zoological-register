using AppZoologico.Lógica;
using System;
using System.IO;
using System.Windows.Forms;

namespace AppZoologico
{
    public partial class appZoologico : Form
    {
        static Archivo objArchivo;
        static string pathCurrent = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString();
        static string rutaArchivoZ = pathCurrent + "\\data\\Zoologico.txt";
        static string rutaArchivoA = pathCurrent + "\\data\\Anim.txt";
        static Zoologico zoo = new Zoologico();
        static Animal ani = new Animal();
        Zoologico[] vecZool;
        Animal[] vecAnimal;
        int i = 0, j = 0;

        public appZoologico()
        {
            InitializeComponent();
            objArchivo = new Archivo();
            vecZool = (Zoologico[])getDate(rutaArchivoZ, "Zoologico");
            vecAnimal = (Animal[])getDate(rutaArchivoA, "Animal");
            if (vecAnimal[0] != null && vecZool[0] != null)
            {
                Animal[] ani1 = new Animal[2];
                Animal[] ani2 = new Animal[2];
                int cont = 0;
                int k;
                for (k = 0; k < vecAnimal.Length; k++)
                {
                    if (k < 2)
                    {
                        ani1[k] = vecAnimal[k];
                    }
                    else
                    {
                        ani2[cont] = vecAnimal[k];
                        cont++;
                    }
                }
                if (vecZool[0] != null && vecAnimal[0] != null && vecAnimal[1] != null)
                {
                    vecZool[0].setAnimales(ani1);
                }
                if (vecZool[1] != null && vecAnimal[2] != null && vecAnimal[3] != null) {
                    vecZool[1].setAnimales(ani2);
                    inhabilitaControlesZoologico();
                    inhabilitaControlesAnimal();
                }
                else
                {
                    if (vecAnimal[1] != null && vecZool[1] == null)
                    {
                        i = 1;
                        j = 0;
                        this.inhabilitaControlesAnimal();
                    } else if (vecZool[0] != null && vecAnimal[1] == null) {
                        inhabilitaControlesZoologico();
                        tabControl1.SelectedIndex = 1;
                        j = 1;
                    } else if (vecZool[1] != null && vecAnimal[3] == null)
                    {
                        i = 2;
                        j = 1;
                        this.inhabilitaControlesZoologico();
                        tabControl1.SelectedIndex = 1;
                    }
                    else if (vecZool[1] != null && vecAnimal[2] == null)
                    {
                        i = 2;
                        j = 0;
                        this.inhabilitaControlesZoologico();
                        tabControl1.SelectedIndex = 1;
                    }
                }
            } else if (vecAnimal[0] == null && vecZool[0] != null)
            {
                this.inhabilitaControlesZoologico();
                tabControl1.SelectedIndex = 1;
            }
        }

        private void btnBuscarZoologico_Click(object sender, EventArgs e)
        {
            int nit;
            String mensajeZool = "el nit no pertenece a ningun objeto del archivo";
            try
            {
                nit = int.Parse(txtNitBuscar.Text);

                if (vecZool[0] != null)
                {
                    for (int k = 0; k < vecZool.Length; k++)
                    {
                        if (comparar(nit, vecZool[k].getNit()))
                        {
                            mensajeZool = vecZool[k].informacionZoologico();
                            break;
                        }
                    }
                }
                rtxtInfoZool.Text = mensajeZool;
                limpiaCajaTexto();
            }
            catch (Exception ex)
            {
                mensajeExcepcion(ex);
            }
        }
        private bool comparar(int a, int b) => a == b;

        private void btnBuscarAnimal_Click(object sender, EventArgs e)
        {
            int nit, cod;  
            try
            {
                string anim = "El codigo o el nit ingresado no pertenece a ningun animal registrado";
                nit = int.Parse(txtZooBusAnim.Text);
                cod = int.Parse(txtCodBusAnim.Text);
                if(vecZool[0] != null)
                {
                    for (int k = 0; k < vecZool.Length; k++)
                    {
                        if (comparar(vecZool[k].getNit(), nit))
                        {
                            if (vecZool[k].getAnimales()[0] != null)
                            {
                                for (int h = 0; h < vecZool[k].getAnimales().Length; h++)
                                {
                                    if (comparar(cod, vecZool[k].getAnimales()[h].getCodigo()))
                                    {
                                        anim = vecZool[k].getAnimales()[h].mostrarAnimal();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                rtxtInfoAnim.Text = anim;
                limpiaCajaTexto();
            }
            catch (Exception ex)
            {
                mensajeExcepcion(ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int nit, cod, cont;
            try
            {
                Animal[] vecAuxAnim = new Animal[1];
                String mensaje = "El animal no se ha borrado satisfactoriamente porque no existe nit o codigo";
                nit = int.Parse(txtNitZooElimAnim.Text);
                cod = int.Parse(txtCodElimAnim.Text);
                cont = 0;
                if(vecZool[0] != null)
                {
                    for (int k = 0; k < vecZool.Length; k++)
                    {
                        if (nit.Equals(vecZool[k].getNit()) && vecZool[k].getAnimales()[0] != null)
                        {
                            for (int h = 0; h < vecZool[k].getAnimales().Length; h++)
                            {
                                if (cod != vecZool[k].getAnimales()[h].getCodigo())
                                {
                                    vecAuxAnim[cont] = vecZool[k].getAnimales()[h];
                                    cont++;
                                }
                                else
                                {
                                    mensaje = "El animal se ha borrado satisfactoriamente";
                                }
                            }
                            vecZool[k].setAnimales(vecAuxAnim);
                        }
                    }
                }
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                limpiaCajaTexto();
            }
            catch (Exception ex)
            {
                mensajeExcepcion(ex);
            }
        }

        private void btnGuardarInformacionAnimal_Click(object sender, EventArgs e)
        {
            int cod;
            double peso;
            string nomAnim, continent, datosAnimal;
            try
            {
                if (j<2)
                {
                    cod = int.Parse(txtCodAnim.Text);
                    nomAnim = txtNomAnim.Text;
                    continent = cbxContOrig.SelectedItem.ToString();
                    peso = double.Parse(txtPesoAnim.Text);
                    datosAnimal = cod + ", " + nomAnim + ", " + continent + ", " + peso;
                    insertarArchivo(rutaArchivoA, datosAnimal);
                    ani = new Animal(cod, nomAnim, continent, peso);
                    vecAnimal[j]=ani;     
                    MessageBox.Show("Informacion del animal Registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    j++;
                    if (j==2 && i<2)
                    {
                        vecZool[i].setAnimales(vecAnimal);
                        i++;
                        if(j==2 && i==2){
                            MessageBox.Show("Llego al numero maximo de registros de animales y Zoologicos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            inhabilitaControlesZoologico();
                            inhabilitaControlesAnimal();
                        }
                        else{
                            j = 0;
                            this.habilitaControlesZoologico();
                            tabControl1.SelectedIndex = 0;
                        }
                    } 
                }
                limpiaCajaTexto();
            }
            catch (Exception ex)
            {
                mensajeExcepcion(ex);
            }
        }

        private void btnGuardarInformacion_Click(object sender, EventArgs e)
        {
            int nit;
            string nomZool, estad = "", datosZoologico;
            try
            {                   
                if (i < 2)
                {
                    nit = int.Parse(txtNitZool.Text);
                    nomZool = txtNomZool.Text;
                    if (rbAbierto.Checked)
                    {
                        estad = "Abierto";
                    }
                    else if (rbCerrado.Checked)
                    {
                        estad = "Cerrado";
                    }
                    datosZoologico = nit + ", " + nomZool + ", " + estad;
                    insertarArchivo(rutaArchivoZ, datosZoologico);
                    zoo = new Zoologico(nit, nomZool, estad);
                    vecZool[i] = zoo;
                    MessageBox.Show("Informacion del zoologico Registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.inhabilitaControlesZoologico();
                    this.habilitaControlesAnimal();
                    tabControl1.SelectedIndex = 1;
                }
                else
                {
                    MessageBox.Show("Llego al numero maximo de registros de Zoologicos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.inhabilitaControlesZoologico();
                    this.inhabilitaControlesAnimal();
                }
                this.limpiaCajaTexto();
            }   
            catch (Exception ex)
            {
                mensajeExcepcion(ex);
            }
        }
        
        private static void mensajeExcepcion(Exception ex)
        {
            MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void habilitaControlesZoologico() 
        {
            txtNitZool.Enabled = true;
            txtNomZool.Enabled = true;
            rbAbierto.Enabled = true;
            rbCerrado.Enabled = true;
            btnGuardarInformacion.Enabled = true;
        }
        private void inhabilitaControlesZoologico() 
        {
            txtNitZool.Enabled = false;
            txtNomZool.Enabled = false;
            rbAbierto.Enabled = false;
            rbCerrado.Enabled = false;
            btnGuardarInformacion.Enabled = false;
        }
        private void habilitaControlesAnimal(){
            txtCodAnim.Enabled = true;
            txtNomAnim.Enabled = true;
            cbxContOrig.Enabled = true;
            txtPesoAnim.Enabled = true;
            btnGuardarInformacionAnimal.Enabled = true;
        }
        private void inhabilitaControlesAnimal(){
            txtCodAnim.Enabled = false;
            txtNomAnim.Enabled = false;
            cbxContOrig.Enabled = false;
            txtPesoAnim.Enabled = false;
            btnGuardarInformacionAnimal.Enabled = false;
        }
        private void limpiaCajaTexto()
        {
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

        private void insertarArchivo(string nameArchive, string datos){
            try
            {
                objArchivo.abrirArchivo(nameArchive, true);
                objArchivo.escribirArchivo(datos);
                objArchivo.cerrarArchivo();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private object[] getDate(string nameArchive, string type){
            int k = 0;
            Zoologico [] vecZ = new Zoologico[2];
            Animal [] vecA = new Animal[4];
            //paso 1: abro el archivo 
            objArchivo.abrirArchivo(nameArchive, false);
            //paso 2: recorrer el archivo
            while (objArchivo.puedeLeer() != -1)
            {
                string line = objArchivo.leerArchivo();
                string [] dates = line.Split(',');
                if(type.Equals("Zoologico")){
                    Zoologico zool = createZoologico(dates);
                    vecZ[k] = zool; 
                }
                //paso 3: creo un objeto de type
                if(type.Equals("Animal"))
                {
                    Animal anim = createAnimal(dates);
                    vecA[k] = anim;
                }
                k++;
            }
            //paso 4: cerrar archivo
            objArchivo.cerrarArchivo();
            if (type.Equals("Zoologico"))
            {
               return (object[])vecZ; 
            }
            else
            {
               return (object[])vecA;
            }
        }
        private Zoologico createZoologico(string [] dates)
        {
            int nit;
            string nom, est;
            nit = int.Parse(dates[0]);
            nom = dates[1];
            est = dates[2];
            Zoologico zool = new Zoologico(nit, nom, est);
            return zool;
        }

        private Animal createAnimal(string [] dates)
        {
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
