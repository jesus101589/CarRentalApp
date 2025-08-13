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
    public partial class ManageVehicleListing : Form
    {
        private readonly Car_RentalEntities2 car_RentalEntities2;
        public ManageVehicleListing()
        {
            InitializeComponent();
            car_RentalEntities2 = new Car_RentalEntities2();
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e)
        {
            //Select * From TypesOfCars
            //var cars = car_RentalEntities2.TypesOfCars.ToList();
            //var cars = car_RentalEntities2.TypesOfCars.Select(q => new { carId = q.Id, CarName = q.Make }).ToList();
            var cars = car_RentalEntities2.TypesOfCars.Select(q => new { Make = q.Make, Model = q.Model, VIN = q.VIN, Year = q.Year, LicensePlateNumber = q.LicensePlateNumber, Id = q.Id }).ToList();
            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[4].HeaderText = "License Plate Number";
            gvVehicleList.Columns[5].Visible = false; // Hide the Id column
            //gvVehicleList.Columns[0].HeaderText = "ID";
            //gvVehicleList.Columns[1].HeaderText = "NAME";
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            var addEditVehicle = new AddEditVehicle();
            addEditVehicle.MdiParent = this.MdiParent;
            addEditVehicle.Show();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            // get ID of selected row
            var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

            // Query the database for the car with that ID
            var car = car_RentalEntities2.TypesOfCars.FirstOrDefault(q => q.Id == id);

            //Launch the AddEditVehicle form with the car details
            var addEditVehicle = new AddEditVehicle(car);
            addEditVehicle.MdiParent = this.MdiParent;
            addEditVehicle.Show();
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            // get ID of selected row
            var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

            // Query the database for the car with that ID
            var car = car_RentalEntities2.TypesOfCars.FirstOrDefault(q => q.Id == id);

            // Delete the car from the database
            car_RentalEntities2.TypesOfCars.Remove(car);
            car_RentalEntities2.SaveChanges();

            gvVehicleList.Refresh();
        }
    }
}
