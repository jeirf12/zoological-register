namespace AppZoologico.logica {

    public class Animal {

        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public string ContinenteOrigen { get; set; }

        public double Peso { get; set; }

        public Animal() {
            this.Codigo = 0;
            this.Nombre = string.Empty;
            this.ContinenteOrigen = string.Empty;
            this.Peso = 0.0;
        }
        
        public Animal(int inCod, string inNom, string inCont, double inPeso) {
            this.Codigo = inCod;
            this.Nombre = inNom;
            this.ContinenteOrigen = inCont;
            this.Peso = inPeso;
        }
        
        public override string ToString() => $"Codigo: { Codigo }\nNombre: { Nombre }" +
            $"\nContinente de Origen: { ContinenteOrigen }\nPeso: { Peso } kg\n";
    }
}