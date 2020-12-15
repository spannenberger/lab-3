using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.Airplanes
{
    [DataContract]
    public abstract class Airplane
    {
        [DataMember]
        public int FlightNumber;
        [DataMember]
        public List<Crewman> Crew { get; private set; }
        
        [OnDeserializing]
        void OnSerializing(StreamingContext ctx)
        {
            Crew = new List<Crewman>();
        }
        [DataMember]
        public float PlaneWeight;
        public abstract float TakeoffWeight();
        protected Airplane(int flightNumber, float planeWeight, List<Crewman> crew)
        {
            FlightNumber = flightNumber;
            Crew = crew;
            PlaneWeight = planeWeight;
        }
        public override string ToString()
        {
            var res = $"Flight Number:{FlightNumber}\n" +
                $"Takeoff Weight:{TakeoffWeight()}\n"+
                "Crew:\n";
            foreach(var i in Crew)
            {
                res += i.ToString() + '\n';
            }
            return res;
                
        }
    }
}
