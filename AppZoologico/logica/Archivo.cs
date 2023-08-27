using System.IO;

namespace AppZoologico.logica {
    class Archivo {
        private StreamWriter writer;
        private StreamReader reader;
        private FileStream stream;

        public void abrirArchivo(string nombre, bool escritura) {
            if (escritura == true) {
                writer = obtenerFlujoEscritura(nombre);
            } else {
                stream = existeArchivo(nombre)
                    ? leerFlujoArchivo(nombre)
                    : crearArchivo(nombre);
                reader = obtenerFlujoLectura(stream);
            }
        }

        private StreamWriter obtenerFlujoEscritura(string nombre) => new StreamWriter(nombre, true);

        private bool existeArchivo(string nombre) => File.Exists(nombre);

        private FileStream leerFlujoArchivo(string nombre) => new FileStream(nombre, FileMode.Open, FileAccess.Read);

        private FileStream crearArchivo(string nombre) => File.Create(nombre);

        private StreamReader obtenerFlujoLectura(FileStream stream) => new StreamReader(stream);

        public void escribirArchivo(string datos) => writer.WriteLine(datos);
        
        public string leerArchivo() => reader.ReadLine();
        
        public void cerrarArchivo() {
            if (writer != null) writer.Close();
            if (reader != null) reader.Close();
        }

        public int puedeLeer() => reader.Peek();
        
        public int contarLineas(string nombre) {
            abrirArchivo(nombre, false);
            int lineas = 0;
            while (puedeLeer() != -1) {
                leerArchivo();
                ++lineas;
            }
            cerrarArchivo();
            return lineas;
        }
        
        public string[] leerPalabras(string nombre, int cantidad) {
            string[] palabras = new string[cantidad];
            int i = 0;
            abrirArchivo(nombre, false);
            while (puedeLeer() != -1 && i < cantidad) {
                palabras[++i] = leerArchivo();
            }
            cerrarArchivo();
            return palabras;
        }
    }
}