using System;
using System.Linq;
using System.Windows.Forms;

namespace AppZoologico.logica {
    static class Utilidad {

        public static Object crearClase(string[] palabras) => palabras.Length == 4
                ? (Object)new Animal(int.Parse(palabras[0]), palabras[1], palabras[2], double.Parse(palabras[3]))
                : (Object)new Zoologico(int.Parse(palabras[0]), palabras[1], palabras[2]);

        public static int contarValoresNulos<T>(T[] matriz) => matriz.Count(element => element != null);

        public static bool compararIgualdad(int a, int b) => a == b;

        public static void mensajeExito(string mensaje) => MessageBox.Show(mensaje, "Mensaje de éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void mensajeError(string mensaje) => MessageBox.Show(mensaje, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void mensajeAdvertencia(string mensaje) => MessageBox.Show(mensaje, "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}