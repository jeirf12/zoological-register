namespace AppZoologico.logica {
    
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public static class Utilidad {

        public static object CrearClase(this string[] palabras) => palabras.Length == 4
                ? (object)new Animal(int.Parse(palabras[0]), palabras[1], palabras[2], double.Parse(palabras[3]))
                : (object)new Zoologico(int.Parse(palabras[0]), palabras[1], palabras[2]);

        public static bool VerificarUnicidad<T>(this T[] matriz, int identificadorUnico) =>
            matriz.Count(elemento => elemento != null
            && CompararIgualdad(
                elemento is Zoologico zoologico 
                ? zoologico.Nit 
                : elemento is Animal animal 
                ? animal.Codigo 
                : -1
                , identificadorUnico)) == 0;

        public static bool EsIgualACero(this int indice) => indice.CompararIgualdad(0);

        public static int ObtenerTamanioSinContarValoresNulos<T>(this T[] matriz) => matriz.Count(element => element != null);

        public static bool CompararIgualdad(this int a, int b) => a == b;

        public static void MensajeExito(this string mensaje) => 
            MessageBox.Show(mensaje, "Mensaje de éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void MensajeError(this string mensaje) => 
            MessageBox.Show(mensaje, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void MensajeAdvertencia(this string mensaje) => 
            MessageBox.Show(mensaje, "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static bool EsNumerico(this string dato) =>
            Regex.IsMatch(dato, @"^[+-]?\d*(\.\d+)?$");

        public static string CrearInformacionZoologico(this Zoologico zoologico) => 
            $"{zoologico.Nit}, {zoologico.Nombre}, {zoologico.Estado}";

        public static string CrearInformacionAnimal(this Animal animal) => 
            $"{animal.Codigo}, {animal.Nombre}, {animal.ContinenteOrigen}, {animal.Peso}";

        public static void EsExcepcion(this bool criterio, string mensaje)
        {
            if (criterio) 
                throw new Exception(mensaje);
        }
    }
}