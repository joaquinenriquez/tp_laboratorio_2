using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

using Excepciones;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        #region Métodos público
        
        public bool Guardar(string archivo, T datos)
        {
            bool auxReturn = false;

            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                using (XmlTextWriter xmlTW = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    serializador.Serialize(xmlTW, datos);
                }

                auxReturn = true;
            }

            catch (Exception)
            {
                throw new ArchivosException();
            }
           
            return auxReturn;
        }
        
        public bool Leer(string archivo, out T datos)
        {
            bool auxReturn = false;

            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                using (XmlTextReader xmlTR = new XmlTextReader(archivo))
                {
                    datos = (T)serializador.Deserialize(xmlTR);
                }

                auxReturn = true;
            }

            catch (Exception e)
            {
                throw new ArchivosException("Error al intentar acceder al archivo", e);
            }

            return auxReturn;
        }

        
        #endregion
    }
}
