﻿using System.Collections.Generic;
using Auto.Data.Entities;

namespace Auto.Data {
	public interface IAutoDatabase {
		
		public int CountVehicles();
		public IEnumerable<Vehicle> ListVehicles();
		public IEnumerable<Manufacturer> ListManufacturers();
		public IEnumerable<Model> ListModels();

		public Vehicle FindVehicle(string registration);
		public Model FindModel(string code);
		public Manufacturer FindManufacturer(string code);

		public void CreateVehicle(Vehicle vehicle);
		public void UpdateVehicle(Vehicle vehicle);
		public void DeleteVehicle(Vehicle vehicle);
	}
}
