using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    //public class Changuito //Para impedir que se hereden clases debe ser sealed
    public sealed class Changuito
    {
        #region Enumerados

        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #endregion

        #region Atributos

        List<Producto> _productos;
        int _espacioDisponible;

        #endregion

        #region Constructores

        private Changuito()
        {
            this._productos = new List<Producto>();
        }

        //public Changuito(int espacioDisponible) //No llama al constructor privado que instancia la lista.
        public Changuito (int espacioDisponible)
            :this()
        {
            this._espacioDisponible = espacioDisponible;
        }

        #endregion

        #region Sobrecargas de métodos

        /// <summary>
        /// Muestro la concecionaria y TODOS los Productos // copypasted detected :)
        /// </summary>
        /// <returns></returns>
        //public string ToString() //Falta modificador override para poder sobrescribir.
        public override string ToString()
        {
            return this.Mostrar(ETipo.Todos);
        }


        #endregion

        #region Métodos de instancia 

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        //public static string Mostrar(Changuito c, ETipo tipo) //quitar static //Como el comentario dice quitar static, el metodo pasa a ser de instancia.
        //dejamos de pedir como argumento al objeto
        public string Mostrar(ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", this._productos.Count, this._espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in this._productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Dulce:
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Leche:
                        sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            //return sb; //El metodo devuelve string no StringBuilder
            return sb.ToString();
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            //Verificamos que el changuito no ese lleno
            if (c._productos.Count < c._espacioDisponible)
            {
                foreach (Producto v in c._productos)
                {
                    if (v == p)
                        return c;
                }

                c._productos.Add(p);
            }
            
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto v in c._productos)
            {
                if (v == p)
                {
                    c._productos.Remove(p);
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}
