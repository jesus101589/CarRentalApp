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
    public partial class AddRentalRecord : Form
    {
        private readonly Car_RentalEntities2 car_RentalEntities2;
        public AddRentalRecord()
        {
            InitializeComponent();
            car_RentalEntities2 = new Car_RentalEntities2();
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
                    var rentalRecord = new CarRentalRecord();
                    rentalRecord.CustomerName = customerName;
                    rentalRecord.DateRented = dateOut;
                    rentalRecord.DateReturne = dateIn;
                    rentalRecord.Cost = Convert.ToDecimal(cost);
                    rentalRecord.TypeOfCarId = Convert.ToInt32(cbTypeOfCar.SelectedValue);
                    
                    car_RentalEntities2.CarRentalRecords.Add(rentalRecord);
                    car_RentalEntities2.SaveChanges();


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

        private void Form1_Load(object sender, EventArgs e)
        {
            // Same as SQL: SELECT * FROM TypesOfCars
            //var cars = car_RentalEntities2.TypesOfCars.ToList();
            var cars = car_RentalEntities2.TypesOfCars
                .Select(q => new { Id = q.Id, Name = q.Make + " " + q.Model }).ToList();
            cbTypeOfCar.DisplayMember = "Name"; // Display the Name property in the ComboBox
            cbTypeOfCar.ValueMember = "Id"; // Use the id property as the value
            cbTypeOfCar.DataSource = cars; // Set the data source of the ComboBox to the list of cars
        }
    }
}