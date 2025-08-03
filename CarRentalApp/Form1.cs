using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = txtboxCustomerName.Text;
                var dateOut = dtrented.Value;
                var dateIn = dtreturned.Value;
                double cost = Convert.ToDouble(tbCost.Text);

                var carType = cbTypeOfCar.Text;
                var isValid = true;
                var errorMessage = "";

                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(carType))
                {
                    isValid = false;
                    errorMessage += "Error: Please enter missing data\n\r";
                }

                if (dateOut > dateIn)
                {
                    isValid = false;
                    errorMessage += "Error: Date Rented cannot be after Date Returned\n\r";
                }

                // if(isValid == true) below shows a cleaner way to write the if statement
                if (isValid)
                {
                    MessageBox.Show($"Customer Name: {customerName}\n\r" +
                        $"Date Rented: {dateOut}\n\r" +
                        $"Date Returned: {dateIn}\n\r" +
                        $"Cost: {cost}\n\r" +
                        $"Car Type: {carType}\n\r" +
                        $"Thank You For Your Business!");
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                //throw;
            }
            
        }
    }
}