using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {

        Random randomizer = new Random();
        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;
        int timeLeft;

        /// <summary>
        /// Inicia o quiz preenchento todos os problemas
        /// e inicia o timer.
        /// </summary>
        
        public void StartTheQuiz()
        {
            //Preenche o problema de adição, salva os valores e converte em strings para exibir nas labels
            addend1 = randomizer.Next(51); //para não ser maior que 50
            addend2 = randomizer.Next(51); //para não ser maior que 50
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            //Preenche o problema de subtração, salva os valores e converte em strings para exibir nas labels
            minuend = randomizer.Next(1, 101); //para não ser 0 e não ser maior que 100
            subtrahend = randomizer.Next(1, minuend); //para não ser 0 nem maior que o minuend
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //Preenche o problema de multiplicação, salva os valores e converte em strings
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //Preenche o problema de divisão, salva os valores e converte em strings
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            //Inicia o timer
            timeLeft = 30;
            timeLabel.Text = "30 segundos";
            timer1.Start();
        }

        /// <summary>
        /// Verifica a resposta do usuário
        /// </summary>
        /// <returns>True se estiver correo e False se errado</returns>

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void PlusRightLabel_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                //se True, usuário acertou. Para o timer e exibe mensagem
                timer1.Stop();
                MessageBox.Show("Você acertou todas as respostas!", "Parabéns!!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                //se CheckTheAnswer retorna falso, segue contando o tempo
                timeLeft--;
                timeLabel.Text = timeLeft + " segundos";
            }
            else
            {
                //se tempo acaba, exibe msg, para o timer e preenche respostas
                timer1.Stop();
                timeLabel.Text = "Acabou!";
                MessageBox.Show("Você não terminou em tempo.", "Sinto muito!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void Answer_Enter(object sender, EventArgs e)
        {
            //seta toda a respostas no controle
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
