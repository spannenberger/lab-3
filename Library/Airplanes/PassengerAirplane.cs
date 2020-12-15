using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.Airplanes
{
    [DataContract]
    [KnownType(typeof(PassengerAirplane))]
    public class PassengerAirplane : Airplane
    {
        [DataMember]
        public int PassengersCount { get; set; }
        public const int PassengerWeight = 64;
        public PassengerAirplane(int passengersCount,int flightNumber, List<Crewman> crew, float planeWeight = 23000) : base(flightNumber, planeWeight, crew)
        {
            PassengersCount = passengersCount;
        }

        public override float TakeoffWeight()
        {
            return PlaneWeight + PassengersCount * PassengerWeight;
        }
        public override string ToString()
        {
            return "Type:Passanger Airplane\n" + base.ToString();
        }
    }
}
