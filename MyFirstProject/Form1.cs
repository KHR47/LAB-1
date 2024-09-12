using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstProject
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
            btnPlus.Tag = "Add";
            btnMinus.Tag = "Subtract";
            btnMult.Tag = "Multiply";
            btnDiv.Tag = "Divide";

            btnPlus.Click += btnOperation_Click;
            btnMinus.Click += btnOperation_Click;
            btnMult.Click += btnOperation_Click;
            btnDiv.Click += btnOperation_Click;
        }
        private void btnOperation_Click(object sender, EventArgs e)
        {
            try
            {
                string txt1 = txtMessage1.Text;
                string txt2 = txtMessage2.Text;
                double num1 = double.Parse(txt1);
                double num2 = double.Parse(txt2);
                double result = 0;

                // Get the operation from the button's Tag property
                Button clickedButton = sender as Button;
                string operation = clickedButton.Tag.ToString();

                switch (operation)
                {
                    case "Add":
                        result = num1 + num2;
                        break;
                    case "Subtract":
                        result = num1 - num2;
                        break;
                    case "Multiply":
                        result = num1 * num2;
                        break;
                    case "Divide":
                        if (num2 == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        result = num1 / num2;
                        break;
                }

                MessageBox.Show("Result: " + result.ToString());
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
