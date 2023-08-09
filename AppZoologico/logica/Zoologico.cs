namespace AppZoologico.logica {
    class Zoologico {
        public int nit { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public Animal[] VecAnimales { get; set; }

        public Zoologico() {
            this.nit = 0;
            this.nombre = "";
            this.estado = "";
            this.VecAnimales = new Animal[2];
        }

        public Zoologico(int inNit, string nom, string est) {
            this.nit = inNit;
            this.nombre = nom;
            this.estado = est;
            this.VecAnimales = new Animal[2];
        }
        
        public override string ToString() {
            return "Nit: " + nit + "\nNombre: " + nombre + "\nEstado: " + estado;
        }
    }
}
