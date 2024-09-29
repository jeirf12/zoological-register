namespace AppZoologico.logica {

    public class Zoologico {

        public int Nit { get; set; }

        public string Nombre { get; set; }

        public string Estado { get; set; }

        public Animal[] Animales { get; set; }

        public Zoologico() {
            this.Nit = 0;
            this.Nombre = string.Empty;
            this.Estado = string.Empty;
            this.Animales = new Animal[2];
        }

        public Zoologico(int inNit, string nom, string est) {
            this.Nit = inNit;
            this.Nombre = nom;
            this.Estado = est;
            this.Animales = new Animal[2];
        }

        public override string ToString() => 
            $"Nit: { Nit }\nNombre: { Nombre }\nEstado: { Estado }\n";
    }
}