﻿using System;
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
            var cars = car_RentalEntities2.TypesOfCars.Select(q => new { carId = q.id, CarName = q.name }).ToList();
            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[0].HeaderText = "ID";
            gvVehicleList.Columns[1].HeaderText = "NAME";
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {

        }
    }
}
