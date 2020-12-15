using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.Airplanes
{
    [DataContract]
    [KnownType(typeof(CargoAirplane))]
    public class CargoAirplane : Airplane
    {
        [DataMember]
        public float CargoWeight { get; set; }
        public CargoAirplane(float cargoWeight, int flightNumber, List<Crewman> crew, float planeWeight=20000) 
        : base(flightNumber, planeWeight, crew)
        {
            CargoWeight = cargoWeight;
        }

        public override float TakeoffWeight()
        {
            return PlaneWeight + CargoWeight;
        }
        public override string ToString()
        {
            return "Type:Cargo Airplane\n" + base.ToString();
        }
    }
}
