using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPriceDesktop.Models
{
    internal sealed class CarModel
    {
        public string Company { get; set; }

        public string Model { get; set; }

        public int Mileage { get; set; }

        public string Year { get; set; }

        public int EnginePower { get; set; }

        public double EngineVolume { get; set; }

        public bool Transmission { get; set; }

        public int Price { get; set; }
    }
}
