using System;

namespace Singleton
{
    public class Singleton
    {
        //Constructor Privado
        private Singleton() { }

        //Propiedad privada estatica
        private static Singleton _instance;

        //Metodo de acceso publico para obtener la instancia
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        //Metodo publico de la clase
        public void SomeBusinessLogic()
        {
            Console.WriteLine("SomeBusinessLogic");
        }

        public void SomeBusinessLogic2()
        {
            Console.WriteLine("SomeBusinessLogic");
        }
    }
}
