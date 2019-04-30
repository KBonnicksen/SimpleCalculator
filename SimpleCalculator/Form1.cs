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

        private bool isPresent(Textbox box)
        {
            if (string.IsNullOrWhiteSpace(box.Text))
            {
                return false;
            }
            return true;
        }


        private bool isDecimal(TextBox box)
        {
            try
            {
                Convert.ToDecimal(box.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool IsOperator(TextBox box)
        {
            string validOperators = "/*+-";
            if (validOperators.Contains(box.Text))
            {
                return true;
            }
            return false;
        }

        private decimal Calculate(decimal operand1, String operator1, decimal operand2)
        {
            switch (operator1)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    return operand1 / operand2;
            }
            return 0;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
