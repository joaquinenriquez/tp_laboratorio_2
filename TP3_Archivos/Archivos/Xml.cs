//using System;
//using Excepciones;
//using System.IO;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Xml;
//using System.Xml.Serialization;
//using System.Threading.Tasks;

//namespace Archivos
//{
//    public class Xml<T>:IArchivo<T>
//    {
//        #region Métodos públicos
//        public bool Guardar(string archivo, string datos)
//        {
//            try
//            {
             
//                FileStream fs = new FileStream(archivo, FileMode.Create, FileAccess.Write);

//                using (StreamWriter sw = new StreamWriter(fs))
//                {
//                    sw.Write(datos);
//                }

//                return true;
//            }

//            catch (Exception e)
//            {
//                throw new ArchivoException(e);
//            }
            
//        }

//        public bool Leer(string archivo, out string datos)
//        {
//            try
//            {
//                FileStream fs = new FileStream(archivo, FileMode.Open, FileAccess.Read);

//                using (StreamReader sr = new StreamReader(fs))
//                {
//                    datos = sr.ReadToEnd();
//                }

//                return true;
//            }

//            catch (Exception e)
//            {
//                throw new ArchivoException(e);
//            }
//        }


//        #endregion
//    }
//}
