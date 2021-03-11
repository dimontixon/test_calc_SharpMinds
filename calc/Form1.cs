using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc
{
    public partial class Form1 : Form
    {
        // ініціалізація всіх компонентів на головній формі
        public Form1()
        {
            InitializeComponent();
        }

        //клік по цифрі і відображенні її в полі вводу
        private void ClickNumber(object sender, EventArgs e)
        {
            input.Text += (sender as Button).Text;

            // Уже є одна крапка в input
            if (input.Text.IndexOf('.') != -1)
            {

                return;
            }
            
        }

        double a, b, c;     //числа
        char znak = '+';    //знак операції, яка буде виконуватись 
        bool areZnak = false;
        
        private void ClickOperation(object sender, EventArgs e)
        {
            if (areZnak)
            {
                equal_Click(sender, e);
            }
            try
            {
                if (input.Text != "")
                {
                    a = Convert.ToDouble(input.Text);
                    znak = (sender as Button).Text[0];
                    label1.Text = input.Text + znak;
                    input.Clear();
                    areZnak = true;
                }
            }
            catch (FormatException)
            {
                input.Clear();
                a = 0; b = 0; c = 0;
                areZnak = false;
            }
        }

        // клікаємо на = (дорівнює)
        private void equal_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            if (input.Text != "" )
            {
                b = Convert.ToDouble(input.Text);
                switch (znak)
                {
                    case '+':
                        c = a + b;
                        break;
                    case '-':
                        c = a - b;
                        break;
                    case '*':
                        c = a * b;
                        break;
                    case '/':
                        if (b == 0)
                        {
                            input.Text = "На 0 не можна ділити!";
                        }
                        else
                        {
                            c = a / b;
                        }
                        break;
                }
                input.Text = c.ToString();
                a = 0; b = 0; c = 0;
                areZnak = false;
            }
        }


        // клікаємо на С (очистити все)
        private void clear_Click(object sender, EventArgs e)
        {
            a = 0; b = 0; c = 0;
            input.Text = "";
            label1.Text = "";
            areZnak = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (input.Text != "")
            {
                if (input.Text[0] == '-')
                {
                    input.Text = input.Text.Remove(0, 1);
                }
                else
                {
                    input.Text = '-' + input.Text;
                }
            }
        }

        // клікаємо на <- (стерти останню цифру із введених)
        private void backspace_Click(object sender, EventArgs e)
        {
            if (input.Text != "")
            {
                input.Text = input.Text.Remove(input.Text.Length - 1, 1);
            }

        }       

        // обробка події натискання клавіш у полі введення числа
        private void input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != '.' && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.')
            {
                if (input.Text.IndexOf('.') != -1)
                {
                    //Уже есть одна запятая в textBox1
                    e.Handled = true;
                }
                return;
            }
        }

        

    }
}
