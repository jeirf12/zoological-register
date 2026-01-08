namespace AppZoologico.logica {

    using System;
    using System.IO;
    using System.Linq;

    class Archivo {

        private StreamWriter Writer;

        private StreamReader Reader;

        private FileStream Stream;

        private void AbrirArchivo(string nombre, bool escritura, bool esReemplazable) {
            if (escritura)
            {
                this.Writer = this.ObtenerFlujoEscritura(nombre, esReemplazable);
                return;
            }

            this.Stream = this.ExisteArchivo(nombre)
                    ? this.LeerFlujoArchivo(nombre)
                    : this.CrearArchivo(nombre);

            this.Reader = this.ObtenerFlujoLectura(this.Stream);
        }

        private StreamWriter ObtenerFlujoEscritura(string nombre, bool esReemplazable) => 
            new StreamWriter(nombre, !esReemplazable);

        private bool ExisteArchivo(string nombre) => File.Exists(nombre);

        private FileStream LeerFlujoArchivo(string nombre) => 
            new FileStream(nombre, FileMode.Open, FileAccess.Read);

        private FileStream CrearArchivo(string nombre) => File.Create(nombre);

        public void EliminarArchivo(string nombre) => File.Delete(nombre);

        private StreamReader ObtenerFlujoLectura(FileStream stream) => 
            new StreamReader(stream);

        private void EscribirArchivo(string datos) => this.Writer.WriteLine(datos);
        
        private string LeerArchivo() => this.Reader.ReadLine();
        
        private void CerrarArchivo() {
            if (!(this.Writer is null)) this.Writer.Close();
            if (!(this.Reader is null)) this.Reader.Close();
        }

        private int PuedeLeer() => this.Reader.Peek();

        public void LlenarMatrizInformacion<T>(string nombre, ref T[] matrizIngresada) {
            try {
                this.AbrirArchivo(nombre, false, false);
                matrizIngresada = matrizIngresada
                    .Select(this.ObtenerItemMatriz)
                    .ToArray();
                this.CerrarArchivo();
            } catch (IOException ex) { Console.WriteLine(ex); }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public void LlenarMatrizInformacion<T>(string nombre, ref T[] matrizIngresada, int cantidadLineas) {
            try {
                this.AbrirArchivo(nombre, false, false);
                matrizIngresada = matrizIngresada
                    .Select((item) => this.ObtenerItemMatriz(item, cantidadLineas))
                    .ToArray();
                this.CerrarArchivo();
            } catch (IOException ex) { Console.WriteLine(ex); }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public void EscribirInformacion(string nombre, string informacion, bool esReemplazable = false) {
            try {
                this.AbrirArchivo(nombre, true, esReemplazable);
                this.EscribirArchivo(informacion);
                this.CerrarArchivo();
            } catch (IOException ex) { Console.WriteLine(ex); }
        }

        private T ObtenerItemMatriz<T>(T item, int cantidadLineas = 0)
        {
            int i = 0;
            cantidadLineas = cantidadLineas.EsIgualACero() 
                ? int.MaxValue 
                : cantidadLineas;

            if (this.PuedeLeer() != -1 && i < cantidadLineas)
            {
                string[] palabras = this.LeerArchivo().Split(',');
                i++;
                return (T)palabras.CrearClase();
            }
            return item;
        }
    }
}