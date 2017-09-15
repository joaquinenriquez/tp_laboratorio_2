using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_Calculadora
{
    public partial class Form1 : Form
    {
        //Operador
        string operador;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpiamos los cuadros de texto y dejamos la etiqueta de resultado en 0
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = "0,00";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);
            
            operador = Calculadora.ValidarOperador(cmbOperacion.Text);
            lblResultado.Text = Calculadora.Operar(numero1, numero2, operador).ToString();
            
        }
    }
}
