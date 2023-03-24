using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        double num1 = 0, num2 = 0;
        char operador;
        public Form1()
        {
            InitializeComponent();
        }

        public void AgregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            if (txtRes.Text == "0")
            {
                txtRes.Text = "";
            }
            txtRes.Text += boton.Text;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            num2 = Convert.ToDouble(txtRes.Text);
            if (operador == '+')
            {
                txtRes.Text = (num1 + num2).ToString();
                num1 = Convert.ToDouble(txtRes.Text);
            }
            else if (operador == '-')
            {
                txtRes.Text = (num1 - num2).ToString();
                num1 = Convert.ToDouble(txtRes.Text);
            }
            else if (operador == 'x')
            {
                txtRes.Text = (num1 * num2).ToString();
                num1 = Convert.ToDouble(txtRes.Text);
            }
            else if (operador == '/')
            {
                if (num2 != 0)
                {
                    txtRes.Text = (num1 / num2).ToString();
                    num1 = Convert.ToDouble(txtRes.Text);
                }
                else
                {
                    MessageBox.Show("No se puede dividir por cero", "Error");
                }
            }
        }

        private void btnUnoSobre_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(txtRes.Text);
            num1 = 1 / num1;
            txtRes.Text = num1.ToString();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(txtRes.Text.Length > 1)
            {
                txtRes.Text = txtRes.Text.Substring(0, txtRes.Text.Length - 1);
            }
            else
            {
                txtRes.Text = "0";
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            operador = '\0';
            txtRes.Text = "0";
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtRes.Text = "0";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if(!txtRes.Text.Contains(","))
            {
                txtRes.Text += ",";
            }
        }

        private void btnMasMenos_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(txtRes.Text);
            num1 *= -1;
            txtRes.Text = num1.ToString();
        }

        private void btnPorciento_Click(object sender, EventArgs e)
        {
            num2 = Convert.ToDouble(txtRes.Text);
            if(num2 < 10)
            {
                txtRes.Text = "0,0" + num2.ToString();
            }
            else if(num2 >= 10 && num2 < 100)
            {
                txtRes.Text = "0," + num2.ToString();
            }
            else if(num2 == 100)
            {
                num2 = 1;
                txtRes.Text = num2.ToString();
            }
            else if(num2 > 100)
            {
                MessageBox.Show("Debe elegir un porcentaje menor o igual a 100%","Error");
            }
        }

        public void ClickOperador(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            num1 = Convert.ToDouble(txtRes.Text);
            operador = Convert.ToChar(boton.Tag);
            if (operador == '²')
            {
                num1 = Math.Pow(num1, 2);
                txtRes.Text = num1.ToString();
            }
            else if(operador == '√')
            {
                num1 = Math.Sqrt(num1);
                txtRes.Text = num1.ToString();
            }
            else
            {
                txtRes.Text = "0";
            }     
        }
    }
}
