using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    //abstract class Persona
    public class Persona
    {
        #region Enumerados
        
        enum ENacionalidad {ARGENTINO, EXTRANJERO}
        
        #endregion

        #region Atributos privados

        string nombre;
        string apellido;
        
        ENacionalidad nacionalidad;
        
        int dni;
    
        #endregion

        #region Propiedades públicas
        
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        public int DNI
        {
            get { return this.dni; }
            set
            {
                try
                {
                    switch (this.nacionalidad)
                    {
                        case ENacionalidad.ARGENTINO:
                            if (value < 1 || value > 89999999)
                                throw new DniInvalidoException("Se ingresó un DNI no válido");

                            break;
                    }
                }

                catch (DniInvalidoException errorDni)
                {
                    Console.WriteLine(errorDni.Message + errorDni.ToString());
                }
            }
        }


        #endregion
    }
}
