using System;
using System.IO;
using System.Windows.Forms;

namespace AppZoologico.logica { 
    static class Utilidad {
        private static Archivo objArchivo = new Archivo();

        public static void insertarArchivo(string nameArchive, string data) {
            try {
                objArchivo.abrirArchivo(nameArchive, true);
                objArchivo.escribirArchivo(data);
                objArchivo.cerrarArchivo();
            }
            catch (IOException ex) { Console.WriteLine(ex); }
        }

        public static void leerArchivo<T>(string nameArchive, T[] arrayInput) {
            int k = 0;
            objArchivo.abrirArchivo(nameArchive, false);
            while (objArchivo.puedeLeer() != -1) {
                string[] dates = objArchivo.leerArchivo().Split(',');
                arrayInput[++k] = (T)crearClase(dates);
            }
            objArchivo.cerrarArchivo();
        }

        public static Object crearClase(string[] dates) {
            return dates.Length == 4
                ? (Object)new Animal(int.Parse(dates[0]), dates[1], dates[2], double.Parse(dates[3]))
                : (Object)new Zoologico(int.Parse(dates[0]), dates[1], dates[2]);
        }

        public static int contarValoresNulos<T>(T[] arrayGeneric) {
            int size = 0;
            for (int i = 0; i < arrayGeneric.Length; i++) {
                if (arrayGeneric[i] != null) ++size;
            }
            return size;
        }

        public static Func<int, int, bool> compararIgualdad = (a, b) => a == b;

        public static void mensajeExito(String message) {
            MessageBox.Show(message, "Mensaje de exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void mensajeError(string message) {
            MessageBox.Show(message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void mensajeAdvertencia(String message) {
            MessageBox.Show(message, "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
