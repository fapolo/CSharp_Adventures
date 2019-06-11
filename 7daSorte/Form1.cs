using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7daSorte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ImagemResultado.Visible = false;

            //Adiciona números aleatórios
            Random rnd = new Random();
            Num1.Text = rnd.Next(1, 10).ToString();
            Num2.Text = rnd.Next(1, 10).ToString();
            Num3.Text = rnd.Next(1, 10).ToString();

            if (Num1.Text == "7" && Num2.Text == "7" && Num3.Text == "7")
            {
                ImagemResultado.Image = Image.FromFile("");
                ImagemResultado.Visible = true;
                System.Media.SystemSounds.Beep.Play();
            } else if (Num1.Text == "7" || Num2.Text == "7" || Num3.Text == "7")
            {
                ImagemResultado.Image = Image.FromFile("");
                ImagemResultado.Visible = true;
                System.Media.SystemSounds.Beep.Play();
            } else
            {
                ImagemResultado.Image = Image.FromFile("");
                ImagemResultado.Visible = true;
            }
        }
    }
}
