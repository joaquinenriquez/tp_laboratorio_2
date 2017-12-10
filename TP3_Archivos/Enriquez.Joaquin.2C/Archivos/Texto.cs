using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Métodos públicos

        public bool Guardar(string archivo, string datos)
        {
            bool auxReturn = false;

            try
            {
                //if (!File.Exists(archivo))
                //    throw new ArchivosException();

                using (FileStream fs = new FileStream(archivo, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(datos);
                    }
                }
                auxReturn = true;
            }

            catch (Exception e)
            {
               throw new ArchivosException();
            }

            return auxReturn;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool auxReturn = false;

            try
            {
                if (!File.Exists(archivo))
                    throw new ArchivosException();

                using (FileStream fs = new FileStream(archivo, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        datos = sr.ReadToEnd();
                    }
                }
                auxReturn = true;
            }

            catch (Exception)
            {
                throw new ArchivosException();
            }

            return auxReturn;
        }
        #endregion
    }
}
 
