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
            double juros, valorInicial, cotacao, jurosCompostos;
            int peridoTrabalho;
            peridoTrabalho = Convert.ToInt32(textBox1.Text);
            juros = Convert.ToDouble(textBox5.Text);
            juros = juros / 100;
            valorInicial = Convert.ToDouble(textBox3.Text);
            cotacao = Convert.ToDouble(textBox2.Text);
            jurosCompostos = valorInicial * Math.Pow((1 + juros), peridoTrabalho);
            textBox6.Text = Convert.ToString(jurosCompostos); 
            jurosCompostos = jurosCompostos * cotacao;
            textBox4.Text = String.Format("{0:C}", jurosCompostos);
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
    }
}
