using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        #region Atributos

        private string html;
        private Uri direccion;

        #endregion

        #region Eventos y delegados

        public delegate void delegadoProgresoDescarga(int porcentaje);  //delegado para controlar evento de cambio en el porcentaje de descarga
        public event delegadoProgresoDescarga cambioProgresoDescarga;   //Evento que se va invocar cuando el webclient invoque su evento DownloadProgressChanged

        public delegate void delegadoFinDescarga(string datosHtml);     //delegado para controlar el evento de descarga finalizada
        public event delegadoFinDescarga descargaFinalizada;            //Evento que se va invocar cuando el webclient invoque su evento DownloadStringCompleted 

        #endregion

        #region Constructores

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        #endregion

        #region Métodos públicos

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
               
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged; //nos suscribimos al evento DownloadProgressChanged del webclient para que llame a nuestro metodo cuando cambie el progreso de descarga
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;       //nos sucribimos al evento DownloadStringCompleted del webclient para que llame a nuestro metodo cuando finalice la descarga
                
                cliente.DownloadStringAsync(this.direccion);                         //Comienza a descargar lo que se encuentra en la URI
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Métodos privados

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.cambioProgresoDescarga(e.ProgressPercentage);          //Invocamos nuestro evento y le pasamos como argumento el porcentaje que nos llega del webclient
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null && e.Cancelled == false)
            {
                this.descargaFinalizada(e.Result);  //Si no ocurrio un error invocamos nuestro evento y le pasamos el resultado que nos mando webclient a traves del evento
            }
            else
                this.descargaFinalizada("NO se puede resolver el nombre remto: " + "'" + this.direccion + "'");
        }

        #endregion 
    }
}
