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
    public partial class AddEditVehicle : Form
    {
        private bool isEditMode;
        private readonly Car_RentalEntities2 car_RentalEntities2;
        public AddEditVehicle()
        {
            InitializeComponent();
            lblTitle.Text = "Add New Vehicle";
            isEditMode = false;
            car_RentalEntities2 = new Car_RentalEntities2();
        }

        public AddEditVehicle(TypesOfCar carToEdit)
        {
            InitializeComponent();
            lblTitle.Text = "Edit Vehicle";
            isEditMode = true;
            car_RentalEntities2 = new Car_RentalEntities2();
            PopulateFields(carToEdit);
        }

        private void PopulateFields(TypesOfCar car)
        {
            lblId.Text = car.Id.ToString();
            tbMake.Text = car.Make;
            tbModel.Text = car.Model;
            tbVIN.Text = car.VIN;
            tbYear.Text = car.Year.ToString();
            tbLicenseNum.Text = car.LicensePlateNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if(isEditMode == true)
            if (isEditMode)
            {
                // Edit Code here
                var id = int.Parse(lblId.Text);
                var car = car_RentalEntities2.TypesOfCars.FirstOrDefault(q => q.Id == id);
                car.Model = tbModel.Text;
                car.Make = tbMake.Text;
                car.VIN = tbVIN.Text;
                car.Year = int.Parse(tbYear.Text);
                car.LicensePlateNumber = tbLicenseNum.Text;

                car_RentalEntities2.SaveChanges();

            }
            else 
            {
                // Add Code here
                var newCar = new TypesOfCar
                {
                    LicensePlateNumber = tbLicenseNum.Text,
                    Make = tbMake.Text,
                    Model = tbModel.Text,
                    VIN = tbVIN.Text,
                    Year = int.Parse(tbYear.Text)
                };

                car_RentalEntities2.TypesOfCars.Add(newCar);
                car_RentalEntities2.SaveChanges();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
