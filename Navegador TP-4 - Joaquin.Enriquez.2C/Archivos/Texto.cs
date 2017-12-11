using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        string archivo;

        public Texto(string archivo)
        {
            this.archivo = archivo;
        }

      
        public bool guardar(string datos)
        {
            bool auxReturn = false;
            try
            {
                using (FileStream file = new FileStream(this.archivo, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter fileWriter = new StreamWriter(file))
                    {
                        fileWriter.WriteLine(datos);
                    }
                }
                auxReturn = true;
            }

            catch (Exception)
            {
                auxReturn = false;
            }

            return auxReturn;
        }

        public bool leer(out List<string> datos)
        {
            bool auxReturn = false;
            datos = new List<string>();
            string url;

            try
            {
                using (FileStream file = new FileStream(this.archivo, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader fileReader = new StreamReader(file))
                    {
                        while ((url = fileReader.ReadLine()) != null)
                        {
                            datos.Add(url);
                        }
                    }
                }
                auxReturn = true;
            }
            
            catch (Exception)
            {
                auxReturn = false;
            }

            return auxReturn;
        }
    }
}
