
namespace AppZoologico.Lógica
{
    class Animal
    {
        private int codigo;
        private string nombre;
        private string continenteOrigen;
        private double peso;

        public Animal()
        {
            codigo = 0;
            nombre = "";
            continenteOrigen = "";
            peso = 0.0;
        }
        
        public Animal(int inCod, string inNom, string inCont, double inPeso)
        {
            codigo = inCod;
            nombre = inNom;
            continenteOrigen = inCont;
            peso = inPeso;
        }
        
        public void setCodigo(int inCod)
        {
            codigo = inCod;
        }
        
        public int getCodigo()
        {
            return codigo;
        }
        
        public void setNombre(string inNom)
        {
            nombre = inNom;
        }
        
        public string getNombre()
        {
            return nombre;
        }

        public void setContinente(string inCont)
        {
            continenteOrigen = inCont;
        }

        public string getContinente()
        {
            return continenteOrigen;
        }

        public void setPeso(double inPeso)
        {
            peso = inPeso;
        }

        public double getPeso()
        {
            return peso;
        }

        public string mostrarAnimal()
        {
            return "Codigo: " + codigo + "\nNombre: " + nombre + "\nContinente de Origen: " + continenteOrigen +
                "\nPeso: " + peso;
        }
    }
}
