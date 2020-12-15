using System.Collections.Generic;
using System.Runtime.Serialization;
using Library.Airplanes;



namespace Library
{
    [DataContract]
    [KnownType(typeof(CargoAirplane))]
    [KnownType(typeof(PassengerAirplane))]
    [KnownType(typeof(AirplanesComparer))]
    public class Airline
    {
        [DataMember]
        private List<Airplane> Airoplanes;
        [DataMember]
        IComparer<Airplane> Comparer;
        private float SumTakeoffWeights = 0;
        public float MeanTakeoffWeight { 
            get {
                return SumTakeoffWeights / Count;
            }
        }
        public Airline(IComparer<Airplane> comp = null)
        {
            Comparer = comp ?? new AirplanesComparer();
            Airoplanes = new List<Airplane>();
        }
        [OnDeserializing]
        void OnSerializing(StreamingContext ctx)
        {
            Airoplanes = new List<Airplane>();
        }

        public Airline(List<Airplane> airoplanes, IComparer<Airplane> comparer = null)
        {
            Comparer = comparer ?? new AirplanesComparer();
            Airoplanes = airoplanes;
            foreach (var item in Airoplanes)
            {
                SumTakeoffWeights += item.TakeoffWeight();
            }
        }

        public void Add(Airplane item)
        {
            SumTakeoffWeights += item.TakeoffWeight();
            Airoplanes.Add(item);
            Airoplanes.Sort(Comparer);
        }

        public void Add(List<Airplane> items)
        {
            foreach (var item in items)
            {
                SumTakeoffWeights += item.TakeoffWeight();
                Airoplanes.Add(item);
            }
            Airoplanes.Sort(Comparer);
        }

        public override string ToString()
        {
            string res = $"{new string('*', 30)}\nMean Takeoff Weight:{MeanTakeoffWeight}\n{new string('-', 30)}\n";
            foreach (var item in Airoplanes)
            {
                res += item.ToString() + $"\n{new string('-', 30)}\n";
            }
            return res;
        }

        public Airplane this[int index] {
            get
            {
                return Airoplanes[index];
            }
        }
        public int Count {
            get
            {
                return Airoplanes.Count;
            }
        }
    }
}
