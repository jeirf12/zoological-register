namespace AppZoologico.logica {
    class Animal {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string continenteOrigen { get; set; }
        public double peso { get; set; }

        public Animal() {
            this.codigo = 0;
            this.nombre = "";
            this.continenteOrigen = "";
            this.peso = 0.0;
        }
        
        public Animal(int inCod, string inNom, string inCont, double inPeso) {
            this.codigo = inCod;
            this.nombre = inNom;
            this.continenteOrigen = inCont;
            this.peso = inPeso;
        }
        
        public override string ToString() {
            return "Codigo: " + codigo + "\nNombre: " + nombre + "\nContinente de Origen: " + continenteOrigen + "\nPeso: " + peso;
        }
    }
}
