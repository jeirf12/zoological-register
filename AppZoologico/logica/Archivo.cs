using System.IO;

namespace AppZoologico.logica {
    class Archivo {
        private StreamWriter writer;
        private StreamReader reader;
        private FileStream stream;

        public void abrirArchivo(string nombre, bool escritura) {
            if (escritura == true) {
                writer = new StreamWriter(nombre, true);
            } else {
                stream = new FileStream(nombre, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(stream);
            }
        }

        public void escribirArchivo(string datos) {
            writer.WriteLine(datos);
        }
        
        public string leerArchivo() {
            return reader.ReadLine();
        }
        
        public void cerrarArchivo() {
            if (writer != null) writer.Close();
            if (reader != null) reader.Close();
        }

        //método
        public int puedeLeer() {
            return reader.Peek(); //verifica si hay un caracter siguiente en la lectura de linea
        }
        
        //método para contar las lineas que tiene el archivo
        public int contarLineas(string nombre) {
            this.abrirArchivo(nombre, false);
            int lineas = 0;
            while (this.puedeLeer() != -1) {
                this.leerArchivo();
                ++lineas;
            }
            this.cerrarArchivo();
            return lineas;
        }
        
        //método adicional
        public string[] leerPalabras(string nombre, int cantidad) {
            string[] palabras = new string[cantidad];
            int i = 0;
            this.abrirArchivo(nombre, false);
            while (this.puedeLeer() != -1 && i < cantidad) {
                palabras[++i] = this.leerArchivo();
            }
            this.cerrarArchivo();
            return palabras;
        }
    }
}
