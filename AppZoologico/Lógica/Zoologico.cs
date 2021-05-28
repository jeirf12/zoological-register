
namespace AppZoologico.Lógica
{
    class Zoologico
    {
        private int nit;
        private string nombre;
        private string estado;
        private Animal [] VecAnimales;

        public Zoologico()
        {
            nit = 0;
            nombre = "";
            estado = "";
            VecAnimales = new Animal[2];
        }

        public Zoologico(int inNit,string nom,string est)
        {
            nit = inNit;
            nombre = nom;
            estado = est;
            VecAnimales = new Animal[2];
        }

        public void setNit(int inNit)
        {
            nit=inNit;
        }
        
        public int getNit()
        {
            return nit;
        }
        
        public void setNombre(string nom)
        {
            nombre = nom;
        }
        
        public string getNombre()
        {
            return nombre;
        }
        
        public void setEstado(string est)
        {
            estado = est; ;
        }
        
        public string getEstado()
        {
            return estado;
        }
        
        public void setAnimales(Animal[] animales)
        {
            VecAnimales=animales;
        }
        
        public Animal[] getAnimales()
        {
            return VecAnimales;
        }
        
        public string informacionZoologico()
        {
            return "Nit: " + nit + "\nNombre: " + nombre + "\nEstado: " + estado;
        }
    }
}
