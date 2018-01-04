using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraRendimentos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text.ToString().Replace(".", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double juros, valorInicial, cotacao, jurosCompostos, resultado = 0;
            int peridoTrabalho, qtdeOperacoes;
            qtdeOperacoes = Convert.ToInt32(textBox7.Text);
            peridoTrabalho = Convert.ToInt32(textBox1.Text);
            juros = Convert.ToDouble(textBox5.Text);
            juros = juros / 100;
            valorInicial = Convert.ToDouble(textBox3.Text);
            cotacao = Convert.ToDouble(textBox2.Text);
            jurosCompostos = Math.Pow((1 + juros), peridoTrabalho);
            if(qtdeOperacoes <= 1)
            {
                resultado = valorInicial * jurosCompostos;
            }
            else
            {
                if(qtdeOperacoes > 1)
                {
                    resultado = valorInicial * jurosCompostos;
                    for (int i = 1; i < qtdeOperacoes; i++)
                    {
                        resultado = resultado * jurosCompostos;
                    }
                }
            }
            
            textBox6.Text = Convert.ToString(resultado);
            resultado = resultado * cotacao;
            textBox4.Text = String.Format("{0:C}", resultado);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToString().Replace(".", "");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.ToString().Replace(".", "");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text.ToString().Replace(".", "");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
