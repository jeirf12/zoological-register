using System;
using System.IO;

namespace AppZoologico.logica {
    class Archivo {
        private StreamWriter writer;
        private StreamReader reader;
        private FileStream stream;

        private void abrirArchivo(string nombre, bool escritura, bool esReemplazable) {
            if (escritura == true) {
                this.writer = this.obtenerFlujoEscritura(nombre, esReemplazable);
            } else {
                this.stream = this.existeArchivo(nombre)
                    ? this.leerFlujoArchivo(nombre)
                    : this.crearArchivo(nombre);
                this.reader = this.obtenerFlujoLectura(this.stream);
            }
        }

        private StreamWriter obtenerFlujoEscritura(string nombre, bool esReemplazable) => new StreamWriter(nombre, !esReemplazable);

        private bool existeArchivo(string nombre) => File.Exists(nombre);

        private FileStream leerFlujoArchivo(string nombre) => new FileStream(nombre, FileMode.Open, FileAccess.Read);

        private FileStream crearArchivo(string nombre) => File.Create(nombre);

        public void eliminarArchivo(string nombre) => File.Delete(nombre);

        private StreamReader obtenerFlujoLectura(FileStream stream) => new StreamReader(stream);

        private void escribirArchivo(string datos) => this.writer.WriteLine(datos);
        
        private string leerArchivo() => this.reader.ReadLine();
        
        private void cerrarArchivo() {
            if (this.writer != null) this.writer.Close();
            if (this.reader != null) this.reader.Close();
        }

        private int puedeLeer() => this.reader.Peek();

        public void llenarMatrizInformacion<T>(string nombre, T[] matrizIngresada) {
            int i = 0;
            try {
                this.abrirArchivo(nombre, false, false);
                while (this.puedeLeer() != -1 && i < matrizIngresada.Length) {
                    string[] palabras = this.leerArchivo().Split(',');
                    matrizIngresada[i++] = (T)Utilidad.crearClase(palabras);
                }
                this.cerrarArchivo();
            } catch (IOException ex) { Console.WriteLine(ex); }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public void llenarMatrizInformacion<T>(string nombre, T[] matrizIngresada, int cantidadLineas) {
            int i = 0;
            try {
                this.abrirArchivo(nombre, false, false);
                while (this.puedeLeer() != -1 && i < cantidadLineas) {
                    string[] palabras = this.leerArchivo().Split(',');
                    matrizIngresada[i++] = (T)Utilidad.crearClase(palabras);
                }
                this.cerrarArchivo();
            } catch (IOException ex) { Console.WriteLine(ex); }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public void escribirInformacion(string nombre, string informacion, bool esReemplazable = false) {
            try {
                this.abrirArchivo(nombre, true, esReemplazable);
                this.escribirArchivo(informacion);
                this.cerrarArchivo();
            } catch (IOException ex) { Console.WriteLine(ex); }
        }
    }
}