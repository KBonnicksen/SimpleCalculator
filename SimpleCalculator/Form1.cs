using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class FrmSimpleCalc : Form
    {
        public FrmSimpleCalc()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                string operator1 = txtOperator.Text;
                decimal num1 = Convert.ToDecimal(txtOperand1.Text);
                decimal num2 = Convert.ToDecimal(txtOperand2.Text);

                decimal solution = Calculate(num1, operator1, num2);
                txtResult.Text = Convert.ToString(solution);
            }
        }

        private bool IsValidData()
        {
            if (isDecimal(txtOperand1) &&
                isDecimal(txtOperand2) &&
                IsOperator(txtOperator))
            {
                return true;
            }
            return false;
        }

        private bool isPresent(TextBox box)
        {
            if (String.IsNullOrEmpty(box.Text))
            {
                MessageBox.Show("Please enter a number for " + box.AccessibleName);
                return false;
            }
            return true;
        }


        private bool isDecimal(TextBox box)
        {
            if (isPresent(box))
            {
                try 
                {
                    decimal dec = Convert.ToDecimal(box.Text);
                    if(dec >= 0 && dec < 1000000)
                    {
                        return true;
                    }
                    MessageBox.Show("Please enter a value from 0 up to 1000000 (inclusive) for " + box.AccessibleName);
                    return false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter a number for " + box.AccessibleName);
                    return false;
                }
            }
            return false;
        }

        private bool IsOperator(TextBox box)
        {
            string validOperators = "/*+-";
            if (validOperators.Contains(box.Text))
            {
                return true;
            }
            MessageBox.Show("Please enter a valid operator of *, /, +. or -");
            return false;
        }

        private decimal Calculate(decimal operand1, String operator1, decimal operand2)
        {
            switch (operator1)
            {
                case "+":
                    return Math.Round(operand1 + operand2, 4);
                case "-":
                    return Math.Round(operand1 - operand2, 4); 
                case "*":
                    return Math.Round(operand1 * operand2, 4); 
                case "/":
                    try
                    {
                        return Math.Round(operand1 / operand2, 4);
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show("Cannot divide by 0: result is undefined");
                    }
                    break;
            }
            return 0;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            txtResult.Text = "";
        }

        private void txtOperator_TextChanged(object sender, EventArgs e)
        {
            textBox3_TextChanged(sender, e);
        }

        private void txtOperand1_TextChanged(object sender, EventArgs e)
        {
            textBox3_TextChanged(sender, e);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
