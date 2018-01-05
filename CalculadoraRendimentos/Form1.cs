using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            double juros, valorInicial, cotacao, jurosCompostos, resultado = 0;
            int peridoTrabalho, qtdeOperacoes;
            qtdeOperacoes = Convert.ToInt32(textBox7.Text);
            peridoTrabalho = Convert.ToInt32(textBox1.Text);
            juros = Convert.ToDouble(textBox5.Text);
            juros = juros / 100;
            valorInicial = Convert.ToDouble(textBox3.Text);
            cotacao = Convert.ToDouble(textBox2.Text);
            if (qtdeOperacoes <= 1)
            {
                jurosCompostos = Math.Pow((1 + juros), peridoTrabalho);
                resultado = valorInicial * jurosCompostos;
            }
            else
            {
                if (qtdeOperacoes > 1)
                {
                    bool first = false;
                    jurosCompostos = (1 + juros);
                    for (int i = 0; i < peridoTrabalho; i++)
                    {                        
                        for (int j = 0; j < qtdeOperacoes; j++)
                        {
                            if(first == false)
                            {
                                resultado = valorInicial * jurosCompostos;
                                first = true;
                            }
                            else
                            {
                                resultado = resultado * jurosCompostos;
                            }
                            
                        }
                       
                    }
                }
            }



            if (checkBox1.Checked)
            {
                var Res = 0.0;
                textBox4.Text = String.Format("{0:C}", resultado);
                Res = resultado / cotacao;
                textBox6.Text = String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", Res);
            }
            else
            {
                var Res = 0.0;
                textBox6.Text = String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", resultado);
                Res = resultado * cotacao;
                textBox4.Text = String.Format("{0:C}", Res);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double cotacao, capInicial, lucPrincipal, lucTrabalhado, lucroAgregado = 0, margemLucro = 0, resInvestLucro = 0, capAtual = 0;
            int numOperacoes, perTrabalho;

            cotacao = Convert.ToDouble(textBox8.Text);
            capInicial = Convert.ToDouble(textBox9.Text);
            lucPrincipal = Convert.ToDouble(textBox10.Text);
            lucPrincipal = lucPrincipal / 100;
            lucPrincipal = 1 + lucPrincipal;
            lucTrabalhado = Convert.ToDouble(textBox11.Text);
            lucTrabalhado = lucTrabalhado / 100;
            lucTrabalhado = 1 + lucTrabalhado;
            perTrabalho = Convert.ToInt32(textBox12.Text);
            numOperacoes = Convert.ToInt32(textBox13.Text);

            bool first = false;

            textBox16.Clear();

            for (int i = 0; i < perTrabalho; i++)
            {
                if(first == false)
                {
                    lucroAgregado = capInicial * lucPrincipal;
                    margemLucro = lucroAgregado - capInicial;
                    first = true;
                    if (checkBox2.Checked)
                    {
                        textBox16.AppendText("O capital inicial é de: " + String.Format("{0:C}", capInicial) + "\n");
                        textBox16.AppendText("A o lucro a ser trabalhado é de: " + String.Format("{0:C}", margemLucro) + "\n");
                    }
                    else
                    {
                        textBox16.AppendText("O capital inicial é de: " + String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", lucroAgregado) + "\n");
                        textBox16.AppendText("A o lucro a ser trabalhado é de: " + String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", margemLucro) + "\n");
                    }
                    
                    textBox16.AppendText("----------------------------------------------------------------" + "\n");
                    capAtual = lucroAgregado;
                }
                else
                {
                    capAtual = lucroAgregado;
                    lucroAgregado = lucroAgregado * lucPrincipal;
                    margemLucro = lucroAgregado - capAtual;
                    if (checkBox2.Checked)
                    {
                        textBox16.AppendText("O lucro agregado agora é de: " + String.Format("{0:C}", lucroAgregado) + "\n");
                        textBox16.AppendText("A o lucro a ser trabalhado é de: " + String.Format("{0:C}", margemLucro) + "\n");
                    }
                    else
                    {
                        textBox16.AppendText("O lucro agregado agora é de: " + String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", lucroAgregado) + "\n");
                        textBox16.AppendText("A o lucro a ser trabalhado é de: " + String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", margemLucro) + "\n");
                    }
                   
                    textBox16.AppendText("----------------------------------------------------------------" + "\n");
                    capAtual = lucroAgregado;
                }

                resInvestLucro = margemLucro;
                for (int j = 0; j < numOperacoes; j++)
                {
                    resInvestLucro = resInvestLucro * lucTrabalhado;
                    if (checkBox2.Checked)
                    {
                        textBox16.AppendText("O " + Convert.ToString(j + 1) + "º investimento do lucro é de: " + String.Format("{0:C}", resInvestLucro) + "\n");
                    }
                    else
                    {
                        textBox16.AppendText("O " + Convert.ToString(j + 1) + "º investimento do lucro é de: " + String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", resInvestLucro) + "\n");
                    }
                    
                }
                lucroAgregado = capAtual + resInvestLucro;
                textBox16.AppendText("----------------------------------------------------------------" + "\n");

                if (checkBox2.Checked)
                {
                    textBox16.AppendText("O capital final (Capital Inicial + Lucros obtidos pela da Margem de Lucro Inicial) do dia de operação foi de: " + String.Format("{0:C}", lucroAgregado) + "\n");
                }
                else
                {
                    textBox16.AppendText("O capital final (Capital Inicial + Lucros obtidos pela da Margem de Lucro Inicial) do dia de operação foi de: " + String.Format(new System.Globalization.CultureInfo("en-US"),"{0:C}", lucroAgregado) + "\n");
                }
                textBox16.AppendText("##########################################\n\n\n\n");
            }

            if (checkBox2.Checked)
            {
                textBox14.Text = String.Format("{0:C}", lucroAgregado);
                double resConversao = lucroAgregado / cotacao;
                textBox15.Text = String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", resConversao);
            }
            else
            {
                textBox15.Text = String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", lucroAgregado);
                double resConversao = lucroAgregado * cotacao;
                textBox14.Text = String.Format("{0:C}", resConversao);
            }
        }
    }
}
