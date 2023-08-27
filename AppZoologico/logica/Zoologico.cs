namespace AppZoologico.logica {
    class Zoologico {
        public int nit { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public Animal[] animales { get; set; }

        public Zoologico() {
            this.nit = 0;
            this.nombre = "";
            this.estado = "";
            this.animales = new Animal[2];
        }

        public Zoologico(int inNit, string nom, string est) {
            this.nit = inNit;
            this.nombre = nom;
            this.estado = est;
            this.animales = new Animal[2];
        }
        
        public override string ToString() => "Nit: " + nit + "\nNombre: " + nombre + "\nEstado: " + estado;
    }
}