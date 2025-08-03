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
            string customerName = txtboxCustomerName.Text;
            string dateOut = dtrented.Value.ToString();
            string dateIn = dtreturned.Value.ToString();
            var carType = cbTypeOfCar.SelectedItem.ToString();

            MessageBox.Show($"Customer Name: {customerName}\n\r" +
                $"Date Rented: {dateOut}\n\r" +
                $"Date Returned: {dateIn}\n\r" +
                $"Car Type: {carType}\n\r" +
                $"Thank You For Your Business!");
        }
    }
}