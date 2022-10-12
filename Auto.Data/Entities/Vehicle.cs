﻿using Newtonsoft.Json;

namespace Auto.Data.Entities {
	public partial class Vehicle {
		public string Registration { get; set; }
		public string ModelCode { get; set; }
		public string Color { get; set; }
		public int Year { get; set; }

		[JsonIgnore]
		public virtual Model VehicleModel { get; set; }
		[JsonIgnore]
		public virtual Owner Owner { get; set; }
    }
}
