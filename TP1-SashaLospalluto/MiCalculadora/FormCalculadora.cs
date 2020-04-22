using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            lblResultado.Text = "";
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }        
        
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text)).ToString();
        }

        /// <summary>
        /// Metodo que recibe 2 numeros y el operador aritmetico para llamar a funcion Calculadora.operar para que realice la operacion
        /// </summary>
        /// <param name="numero1">numero que recibo como parametro para realizar la operacion aritmetica</param>
        /// <param name="numero2">numero que recibo como parametro para realizar la operacion aritmetica</param>
        /// <param name="operador">operador que recibo, el cual me indica si se quiere realizar una suma, resta, multiplicacion o division</param>
        /// <returns></returns>
        private static double operar(string numero1, string numero2, string operador)
        {
            double resultado;

            Numero numeroUno = new Numero(numero1);
            Numero numeroDos = new Numero(numero2);

            resultado = Calculadora.Operar(numeroUno, numeroDos, operador);

            return resultado;
        }
                
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Elimina los datos ingresados en el form, tanto los valores numericos como el operador
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = 4;
            lblResultado.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();

            lblResultado.Text = numero.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();

            lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
        }
    }
}
