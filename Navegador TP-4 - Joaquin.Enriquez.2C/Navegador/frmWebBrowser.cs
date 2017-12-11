using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;
using System.Text.RegularExpressions;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        #region Enumerados

        enum validarProtocolo { http, https }
        
        #endregion

        #region Atributos

        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;
        Descargador descargador1;
        Thread hiloDescargador1;
        Uri url;

        #endregion

        #region Constructores

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        #endregion

        #region Métodos privados 

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);

        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }

        delegate void FinDescargaCallback(string html);

        private void FinDescarga(string html)
        {


            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }


        private void btnIr_Click(object sender, EventArgs e)
        {
            string urlValidada = "";

            try
            {
                if (validarURL(txtUrl.Text, validarProtocolo.http, out urlValidada))
                {
                    txtUrl.Text = urlValidada;
                    this.url = new Uri(urlValidada);       //Instanciamos la URI con la url del text
                    this.descargador1 = new Descargador(this.url);  //Intaciamos un descargador y le pasamos la url al constructor
                    this.descargador1.cambioProgresoDescarga += ProgresoDescarga;  //Suscribimos al evento cambioProgresoDescarga
                    this.descargador1.descargaFinalizada += FinDescarga;           //Suscribimos al evento descargaFinalizada
                    this.hiloDescargador1 = new Thread(descargador1.IniciarDescarga); //Instaciamos un thread con el metodo de iniciar descarga del descargador
                    this.hiloDescargador1.Start(); //lanzamos el thread
                }
                else
                    MessageBox.Show("URL No valida!");
            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrio un error al intentar comenzar la descarga " + error.Message);
            }

            try
            {
                this.archivos.guardar(urlValidada);
            }

            catch (Exception errorHistorial)
            {
                MessageBox.Show("Ocurrio un error al intentar guardar el historial" + errorHistorial.Message);
            }

        }


        /// <summary>
        /// Valida y completa una URL
        /// </summary>
        /// <param name="url"></param>
        /// <param name="protocolo"></param>
        /// <param name="urlValidada"></param>
        /// <returns>Verdadero si la URL es valida, caso contrario: falso. Por referencia devuelve la URLValidada</returns>
        private bool validarURL(string url, validarProtocolo protocolo, out string urlValidada)
        {
            bool auxReturn = false;
            string auxURL = "";
            string auxProtocolo = "";
            
            //Patrones
            string patternProtocolo = @"^(http|https|)\://";
            string patternEsquema = @"^(www.)";
            string patternProtocoloEsquema = @"^(http|https|)\://www.";
           
            //Expresiones regulares
            Regex expresionRegularProtocolo = new Regex(patternProtocolo, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex expresionRegularProtocoloEsquema = new Regex(patternProtocoloEsquema, RegexOptions.Compiled | RegexOptions.CultureInvariant);
            Regex expresionRegularEsquema = new Regex(patternEsquema, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if (expresionRegularProtocolo.IsMatch(url))
            {
                if (expresionRegularProtocoloEsquema.IsMatch(url))
                {
                    auxURL = url; //Esquema y protocolos correctos, no hace falta hacer nada
                }
                else
                {
                    //Protocolo correcto pero no asi el esquema
                    if ((url.Substring(0, 7)).ToLower() == "http://")
                    {
                        auxURL = "http://" + "wwww." + url.Substring(7, url.Length - 7);
                    }
                    else if ((url.Substring(0, 8)).ToLower() == "https://")
                    {
                        auxURL = "https://" + "www." + url.Substring(8, url.Length - 8);
                    }
                }
            }
            else
            {
                if (expresionRegularEsquema.IsMatch(url))
                {
                    //Esquema correcto pero no el protocolo. En estos casos podemos predeterminar como completamos el protocolo, si http o https
                    if (protocolo == validarProtocolo.https) 
                        auxURL = "https://" + url;
                    else if (protocolo == validarProtocolo.http)
                        auxURL = "http://" + url;
                }
                else
                {
                    //Sin protocolo y sin esquema
                    if (protocolo == validarProtocolo.https)
                        auxURL = "https://wwww." + url;
                    else
                        auxURL = "http://www." + url;
                }
            }

            if (Uri.IsWellFormedUriString(auxURL, UriKind.Absolute))      //Este metodo de la clase URI verifica si la URL es valida y absoluta (contiene protocolo y esquema)
                auxReturn = true;

            urlValidada = auxURL;
            return auxReturn;
        }

        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial cuadroDialogoHistorial = new frmHistorial();
            cuadroDialogoHistorial.Show();
        }

        #endregion
    }
}

