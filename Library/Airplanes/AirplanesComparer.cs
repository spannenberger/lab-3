using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.Airplanes
{
    [DataContract]
    [KnownType(typeof(Airplane))]
    [KnownType(typeof(AirplanesComparer))]
    class AirplanesComparer : IComparer<Airplane>
    {
        public int Compare(Airplane x, Airplane y)
        {
            if (x == null) throw new ArgumentNullException("Argument 'x' must be not null");
            if (y == null) throw new ArgumentNullException("Argument 'y' must be not null");

            var tmp1 = x.TakeoffWeight();
            var tmp2 = y.TakeoffWeight();

            if (tmp1 == tmp2)
            {
                if (x.FlightNumber==y.FlightNumber)
                {
                    return 0;
                }
                else if (x.FlightNumber > y.FlightNumber) return 1;
                return -1;
            }
            else if (tmp1 > tmp2) return 1;
            return -1;
        }
    }
}
